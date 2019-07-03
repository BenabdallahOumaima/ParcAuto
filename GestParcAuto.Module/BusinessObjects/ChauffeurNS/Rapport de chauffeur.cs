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
using DevExpress.Persistent.Base.General;

namespace GestParcAuto.Module.BusinessObjects.ChauffeurNS
{
    [DefaultClassOptions]
    
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Rapport_chauffeur : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Rapport_chauffeur(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
       
        private DateTime date_aller;
        private DateTime date_retour;
        private double kilométrage;
        private double carbuarnt;
        private string destination;
        private Chauffeur chauffeur;
        private Vehicule vehicule;

        [XafDisplayName("Date d'aller")]
        public DateTime DateAller
        {
            get { return date_aller; }
            set { SetPropertyValue("DateAller", ref date_aller, value); }
        }
        [XafDisplayName("Date d'arrivée")]
        public DateTime DateArrivé
        {
            get { return date_retour; }
            set { SetPropertyValue("DateArrivé", ref date_retour, value); }
        }
        [XafDisplayName("Le kilométrage")]
        public double Kilométrage
        {
            get { return kilométrage; }
            set { SetPropertyValue("Kilométrage", ref kilométrage, value); }
        }
        [XafDisplayName("Consommation de carburant")]
        public double Carburant
        {
            get { return carbuarnt; }
            set { SetPropertyValue("Carburant", ref carbuarnt, value); }
        }
       
        public string Destination
        {
            get { return destination; }
            set { SetPropertyValue("Destination", ref destination, value); }
        }


        [Association("Rapport_chauffeur-Chauffeur")]
        public Chauffeur Chauffeur
        {
            get { return chauffeur; }
            set { SetPropertyValue("Chauffeur", ref chauffeur, value); }
        }
        [Association("Rapport_chauffeur-Vehicule")]
        public Vehicule Vehicule
        {
            get { return vehicule; }
            set { SetPropertyValue("Vehicule", ref vehicule, value); }
        }
        [Association("Réclamation-Rapport_chauffeur")]
        public XPCollection<Réclamation> Réclamations
        {
            get { return GetCollection<Réclamation>("Réclamations"); }
        }

    }
}
