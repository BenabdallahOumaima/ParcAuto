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

namespace GestParcAuto.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Rendus : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Rendus(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private double prix_assurance;
        private double prix_visite;
        private double prix_vignettes;
        private Vehicule vehicule;
        [XafDisplayName(" Prix de assurance ")]
        public double Prix_assurance
        {
            get { return prix_assurance; }
            set { SetPropertyValue("Prix_assurance", ref prix_assurance, value); }
        }
        [XafDisplayName(" Prix de visite")]
        public double Prix_visite
        {
            get { return prix_visite; }
            set { SetPropertyValue("Prix_visite", ref prix_visite, value); }
        }
        [XafDisplayName("Prix de vignettes")]
        public double Prix_vignettes
        {
            get { return prix_vignettes; }
            set { SetPropertyValue("Prix_vignettes", ref prix_vignettes, value); }
        }
        [Association("Vehicule-Rendus")]
        public Vehicule Vehicule
        {
            get { return vehicule; }
            set { SetPropertyValue("Vehicule", ref vehicule, value); }
        }
    }
}