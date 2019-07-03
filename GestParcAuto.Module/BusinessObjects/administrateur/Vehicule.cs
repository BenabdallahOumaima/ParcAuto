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
using GestParcAuto.Module.BusinessObjects.MecanicienNS;
using GestParcAuto.Module.BusinessObjects.ChauffeurNS;
using DevExpress.Persistent.Base.General;
using System.Web.Configuration;
using System.Runtime.Remoting.Contexts;
using DevExpress.ExpressApp.Xpo.Updating;
using System.Data.Common;

namespace GestParcAuto.Module.BusinessObjects
{
   
    [DefaultClassOptions]
    public class Vehicule : XPObject, ISupportNotifications, IXafEntityObject
    { 
        public Vehicule(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string modele;
        private DateTime date_fabrication;
        private string userName;
        private int auto_matricule;
        private int num_serie;
        private int num_carte_grise;
        private int puissance;
        private double prix_achat;
        private DateTime assurance;
        private DateTime visite;
        private DateTime vignettes;
       
        private Chauffeur chauffeur;
        private DateTime date;
        private bool _IsPostponed;
        private DateTime _DueDate;
        private string _Subject;
        private int _Id;
        private TimeSpan? _RemindIn;
        #region ISupportNotifications members
        private DateTime? alarmTime;
        [Browsable(false)]
        public DateTime? AlarmTime
        {
            get { return alarmTime; }
            set
            {
                alarmTime = value;
                if (value == null)
                {
                    RemindIn = null;
                    IsPostponed = false;
                }
            }
        }
        [Browsable(false)]

        public bool IsPostponed
        {
            get { return _IsPostponed; }
            set { SetPropertyValue("IsPostponed", ref _IsPostponed, value); }

        }
        [Browsable(false)]
        public string NotificationMessage
        {
            get { return _Subject; }
        }
        [XafDisplayName("Rappeler dans")]
        public TimeSpan? RemindIn
        {
            get { return _RemindIn; }
            set { SetPropertyValue("RemindIn", ref _RemindIn, value); }
        }
        [Browsable(false)]
        public object UniqueId
        {
            get { return _Id; }
        }
        #endregion
        #region IXafEntityObject members
        public void OnCreated() { }
        void IXafEntityObject.OnLoaded() { }
        void IXafEntityObject.OnSaving()
        {
            if (_RemindIn.HasValue)
            {
                if ((AlarmTime == null) || (AlarmTime < _DueDate - _RemindIn.Value))
                {
                    AlarmTime = _DueDate - _RemindIn.Value;
                }
            }
            else
            {
                AlarmTime = null;
            }
            if (AlarmTime == null)
            {
                _RemindIn = null;
                IsPostponed = false;
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [XafDisplayName("date d'échéance")]
        public DateTime DueDate
        {
            get { return _DueDate; }
            set { SetPropertyValue("DueDate", ref _DueDate, value); }
        }
        #endregion
       
        [RuleRequiredField("RuleRequiredField for Vehicule.UserName",DefaultContexts.Save)]
        [XafDisplayName("Modèle de véhicule")]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }

        private string type;
        [RuleRequiredField("RuleRequiredField for Vehicule.Marque", DefaultContexts.Save)]
        [XafDisplayName("Marque de véhicule")]
        public string Type
        {
            get { return type; }
            set { SetPropertyValue("Type", ref type, value); }
        }
     
        [RuleRequiredField("RuleRequiredField for Vehicule.DateFabrication",DefaultContexts.Save)]
        [XafDisplayName("Date de fabrication")]
        public DateTime DateFabrication
        {
            get { return date_fabrication; }
            set { SetPropertyValue("DateFabrication" ,ref date_fabrication, value); }
        }
        [RuleRequiredField("RuleRequiredField for Vehicule.Auto_Matricule",DefaultContexts.Save)]
        [XafDisplayName("N° matricule")]
        public int Auto_Matricule
        {
            get
            {
                return auto_matricule;
            }
            set
            {
                SetPropertyValue("Auto_Matricule", ref auto_matricule, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Vehicule.Num_Serie", DefaultContexts.Save)]

        [XafDisplayName("N°série")]
        public int Num_Serie
        {
            get
            {
                return num_serie;

            }
            set
            {
                SetPropertyValue("Num_Serie", ref num_serie, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Vehicule.Num_Carte_Crise", DefaultContexts.Save)]

        [XafDisplayName("N° Carte Grise")]
        public int Num_Carte_Crise
        {
            get
            {
                return num_carte_grise;
            }
            set
            {
                SetPropertyValue("Num_Carte_Crise", ref num_carte_grise, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Vehicule.Puissance", DefaultContexts.Save)]

        public int Puissance
        {
            get
            {
                return puissance;
            }
            set
            {
                SetPropertyValue("Puissance", ref puissance, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Vehicule.Prix_Achat", DefaultContexts.Save)]

        [XafDisplayName("Prix d'achat")]
        public double Prix_Achat
        {
            get
            {
                return prix_achat;
            }
            set
            {
                SetPropertyValue("Prix_achat", ref prix_achat, value);
            }

        }
        [RuleRequiredField("RuleRequiredField for Vehicule.Assurance", DefaultContexts.Save)]

        [XafDisplayName("Date d'assurance")]

        public DateTime Assurance
        {
            get { return assurance; }
            set { SetPropertyValue("Assrance", ref assurance, value); }
        }
        [RuleRequiredField("RuleRequiredField for Vehicule.Visite", DefaultContexts.Save)]

        [XafDisplayName("Date de visite")]

        public DateTime Visite
        {
            get { return visite; }
            set { SetPropertyValue("Visite", ref visite, value); }
        }
        [RuleRequiredField("RuleRequiredField for Vehicule.Vignettes", DefaultContexts.Save)]

        [XafDisplayName("Date de vignettes")]

        public DateTime Vignettes
        {
            get { return vignettes; }
            set { SetPropertyValue("Vignettes", ref vignettes, value); }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Browsable(false)]
        public int Id
        {
            get { return _Id; }
            private set { SetPropertyValue("Id", ref _Id, value); }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Browsable(false)]
        [RuleRequiredField("RuleRequiredField for Vehicule.Subject", DefaultContexts.Save)]

        [XafDisplayName("Sujet")]
        public string Subject
        {
            get { return _Subject; }
            set { SetPropertyValue("Subject", ref _Subject, value); }
        }
       

        
    
    


        [Association("Mission-Vehicule")]
        public XPCollection<Mission> Missions
        {
            get { return GetCollection<Mission>("Missions"); }
        }


        [Association("Rapport_maintenance-Vehicule")]
        public XPCollection<Rapport_maintenance> Rapport_maintenances
        {
            get { return GetCollection<Rapport_maintenance>("Rapport_maintenances"); }
        }
        [Association("Rapport_chauffeur-Vehicule")]
        public XPCollection<Rapport_chauffeur> Rapport_Chauffeurs
        {

            get { return GetCollection<Rapport_chauffeur>("Rapport_Chauffeurs"); }
        }
        [Association("Vehicule-Maintenance")]
         public XPCollection<Maintenance> Maintenances
        {
            get { return GetCollection<Maintenance>("Maintenances"); }
        }
        [Association("Vehicule-Rendus")]
      public XPCollection<Rendus> Rendus
        {
            get { return GetCollection<Rendus>("Rendus"); }
        }

    }
}