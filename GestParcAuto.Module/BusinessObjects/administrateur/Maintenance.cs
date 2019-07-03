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

namespace GestParcAuto.Module.BusinessObjects.MecanicienNS
{

    [DefaultClassOptions]
   
    [ImageName("BO_Document")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Maintenance : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Maintenance(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private int num_maintenance;
        private DateTime date_début;
        private DateTime date_fin;
        private Mecanicien mecanicien;



        [RuleRequiredField("RuleRequiredField for Maintenance.Num_Maintenance",
        DefaultContexts.Save)]
        [XafDisplayName("N°de maintenance")]
        

        public int Num_Maintenance
        {
            get
            {
                return num_maintenance;
            }
            set
            {
                SetPropertyValue("Num_Maintenance", ref num_maintenance, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Maintenance.Date_Début",
        DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for Maintenance.Date_Fin",
        DefaultContexts.Save)]
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
        [NonPersistent]
        [Browsable(false)]
        [RuleFromBoolProperty("Maintenance.IsIntervalValid", DefaultContexts.Save, "La date de début doit être inférieure à la date de fin", SkipNullOrEmptyValues = false, UsedProperties = "Date_Début,Date_Fin")]
        public bool IsIntervalValid { get { return Date_Début <= Date_Fin; } }
        //[RuleRequiredField("RuleRequiredField for Maintenance.Description",
        //DefaultContexts.Save)]
        [XafDisplayName("Description de maintenance")]
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                SetPropertyValue("Desccription", ref _description, value);
            }
        }
     
        [Association("Mecanicien-Maintenance")]
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
        private Vehicule vehicule;
        [RuleRequiredField("RuleRequiredField for Maintenance.Vehicule",
        DefaultContexts.Save)]
        [Association("Vehicule-Maintenance")]
      public Vehicule Vehicule
        {
            get { return vehicule; }
            set { SetPropertyValue("Vehicule", ref vehicule, value); }
        }
        [Association("Rapport_maintenance-Maintenance")]
        public XPCollection<Rapport_maintenance> Rapport_Maintenances
        {
            get { return GetCollection<Rapport_maintenance>("Rapport_Maintenances"); }
        }

       
    }

}
