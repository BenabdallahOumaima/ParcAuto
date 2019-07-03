using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using GestParcAuto.Module.BusinessObjects.ChauffeurNS;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;
using DevExpress.ExpressApp.Utils;
using DevExpress.Web;

namespace GestParcAuto.Module.BusinessObjects.MecanicienNS
{

    [DefaultClassOptions]
    public class Mecanicien : XPObject
    { 
        public Mecanicien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _UserName;
        private int password;
        private string nom;
        private string prenom;
        private int cin;
        private int tel;

        [RuleRequiredField("RuleRequiredField for Mecanicien.Nom",
      DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]

        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                SetPropertyValue("Nom", ref nom, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Mecanicien.Prenom",DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]

        public string Prenom
        {
            get
            {
                return prenom;
            }
            set
            {
                SetPropertyValue("Prenom", ref prenom, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Mecanicien.UserName",
      DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                SetPropertyValue("UserName", ref _UserName, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Mecanicien.Password",
      DefaultContexts.Save)]

        public int Password
        {
            get
            {
                return password;
            }
            set
            {
                SetPropertyValue("Login", ref password, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Mecanicien.CIN",
          DefaultContexts.Save)]
        [RuleRange("", DefaultContexts.Save,10000000,99999999)]
        public int CIN
        {
            get
            {
                return cin;
            }
            set
            {
                SetPropertyValue("CIN", ref cin, value);
            }
        }

        [RuleRequiredField("RuleRequiredField for Mecanicien.Tel",
      DefaultContexts.Save)]
        [RuleRange("", DefaultContexts.Save,10000000,99999999)]
        public int Tel
        {
            get { return tel; }
            set { SetPropertyValue("Tel", ref tel, value); }
        }

        [Association("Mecanicien-Rapport_maintenance")]
        public XPCollection<Rapport_maintenance> Rapport_maintenances
        {
            get { return GetCollection<Rapport_maintenance>("Rapport_maintenances"); }
        }
        [Association("Mecanicien-Maintenance")]
        public XPCollection<Maintenance> Maintenances
        {
            get { return GetCollection<Maintenance>("Maintenances"); }
        }

       


        }
    }

