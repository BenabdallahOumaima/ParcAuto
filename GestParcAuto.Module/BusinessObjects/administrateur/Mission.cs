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
using System.Drawing;
using GestParcAuto.Module.BusinessObjects.ChauffeurNS;

namespace GestParcAuto.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class Mission : XPObject, IResource
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Mission(Session session)
            : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [Browsable(false)]
        public Color Color
        {
            get { return Color.FromArgb(_Color); }
            set { SetPropertyValue("Color", ref _Color, value.ToArgb()); }
        }
        private DateTime datedepart;
        private DateTime datearrivé;
        private string destination;
   
        private string _Caption;
        private Chauffeur chauffeur;
        private Vehicule vehicule;

        [RuleRequiredField("RuleRequiredField for Mission.DateDepart",
          DefaultContexts.Save)]
        [XafDisplayName("Date de départ")]

        public DateTime DateDepart
        {
            get
            {
                return datedepart;
            }
            set
            {
                SetPropertyValue("DateDepart", ref datedepart, value);
            }
        }

        [RuleRequiredField("RuleRequiredField for Mission.DateArrivée",
      DefaultContexts.Save)]
        [XafDisplayName("Date d'arivée")]

        public DateTime DateArrivée
        {
            get
            {
                return datearrivé;
            }
            set
            {
                SetPropertyValue("DateArrivée", ref datearrivé, value);
            }
        }
        [NonPersistent]
        [Browsable(false)]
        [RuleFromBoolProperty("Mission.IsIntervalValid", DefaultContexts.Save, "La date de départ doit être inférieure à la date d'arrivée", SkipNullOrEmptyValues = false, UsedProperties = "DateDepart,DateArrivée")]
        public bool IsIntervalValid { get { return DateDepart <= DateArrivée; } }
        [RuleRequiredField("RuleRequiredField for Mission.Destination",
       DefaultContexts.Save)]
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                SetPropertyValue("Destination", ref destination, value);
            }
        }

        [Association("Mission-Vehicule")]
        [RuleRequiredField("RuleRequiredField for Mission.Vehicule",

        DefaultContexts.Save)]
        public Vehicule Vehicule
        {
            get { return vehicule; }
            set { SetPropertyValue("Vehicule", ref vehicule, value); }
        }
        [RuleRequiredField("RuleRequiredField for Mission.Chauffeur",
         DefaultContexts.Save)]
        [Association("Chauffeur-Mission")]

        public Chauffeur Chauffeurs
        {
            get { return chauffeur; }
            set { SetPropertyValue("Chauffeur", ref chauffeur, value); }
        }
        [XafDisplayName("Légende")]
        [RuleRequiredField("RuleRequiredField for Mission.Caption",
       DefaultContexts.Save)]
        public string Caption
        {
            get { return _Caption; }
            set { SetPropertyValue("Caption", ref _Caption, value); }
        }



        [VisibleInDetailView(false)]
        [VisibleInListView(false)]

        [XafDisplayName("Véhicule occupé")]
        public bool isVehiculeBusy
        {
            get
            {
                if (this.vehicule != null)
                {
                    return this.vehicule.Missions.LongCount(x => x.Oid != this.Oid && x.datedepart == this.datedepart && x.datearrivé == this.datearrivé) == 0;

                }
                return true;
            }

        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]

        [XafDisplayName("Chauffeur occupé")]
        public bool isChauffeurBusy
        {
            get
            {
                if (this.chauffeur != null)
                {
                    return this.chauffeur.Missions.LongCount(x => x.Oid != this.Oid && x.datedepart == this.datedepart && x.datearrivé == this.datearrivé) == 0;

                }
                return true;
            }
        }
        [Association("VehiEvent-Mission")]
        public XPCollection<VehiEvent> VehiEvents
        {
            get { return GetCollection<VehiEvent>("VehiEvents"); }
        }
    
        
        [Browsable(false)]
        public object Id { get { return Id; } }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Browsable(false)]

        private int _Color;
        public int OleColor
        {
            get { return ColorTranslator.ToOle(Color.FromArgb(_Color)); }
        }
    }
}