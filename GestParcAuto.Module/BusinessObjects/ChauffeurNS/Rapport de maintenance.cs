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
using System.Threading.Tasks;
using DevExpress.ExpressApp.Security;
using System.Security;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Office.Win;
using DevExpress.XtraRichEdit;
using GestParcAuto.Module.BusinessObjects.MecanicienNS;

namespace GestParcAuto.Module.BusinessObjects.ChauffeurNS
{
     
    [DefaultClassOptions]


    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Rapport_maintenance : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Rapport_maintenance(Session session)
            : base(session)
        { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string type;
        private DateTime date_début;
        private DateTime date_fin;
        private double _Facture;
        private Vehicule vehicule;
        private Mecanicien mecanicien;



        [XafDisplayName("Type de maintenance")]
        public string Type
        {
            get { return type; }
            set { SetPropertyValue("Type", ref type, value); }
        }

        [XafDisplayName("Début de maintenance")]
        public DateTime Date_Début
        {
            get
            {
                return date_début;
            }
            set
            {
                SetPropertyValue("Date_Début", ref date_début, value);
            }
        }
        [XafDisplayName("Fin de maintenance")]
        public DateTime Date_Fin
        {
            get
            {
                return date_fin;
            }
            set
            {
                SetPropertyValue("Date_Fin", ref date_fin, value);
            }

        }
        public double Facture
        {
            get { return _Facture; }
            set { SetPropertyValue("Facture", ref _Facture, value); }
        }
        [Association("Rapport_maintenance-Vehicule")]
        public Vehicule Vehicule
        {
            get { return vehicule; }
            set { SetPropertyValue("Vehicule", ref vehicule, value); }
        }
     

        [Association("Mecanicien-Rapport_maintenance")]
        public Mecanicien Mecanicien
        {
            get
            {
                return mecanicien;
            }
            set
            {
                SetPropertyValue("Mecanicien", ref mecanicien, value);
            }
        }
        private Maintenance maintenance;
        [Association("Rapport_maintenance-Maintenance")]
      public XPCollection<Maintenance> Maintenances
        {
            get { return GetCollection<Maintenance>("Maintenances"); }
        }


    }




}

