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
    
    public class Réclamation : XPObject, ISupportNotifications, IXafEntityObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Réclamation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        public int Id { get; private set; }
        public string Subject { get; set; }
        public DateTime DueDate { get; set; }
        private string amende;
        private string panne;
        private DateTime _Date;
        public string Amende
        {
            get { return amende; }
            set { SetPropertyValue("Amende", ref amende, value); }
        }
        public string Panne
        {
            get { return panne; }
            set { SetPropertyValue("Panne", ref panne, value); }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { SetPropertyValue("Date", ref _Date, value); }
        }
        
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
        public bool IsPostponed { get; set; }
        [Browsable(false)]
        private string _Subject;
        public string NotificationMessage
        {
            get { return _Subject; }
        }
        public TimeSpan? RemindIn { get; set; }
        [Browsable(false)]
        public object UniqueId
        {
            get { return Id; }
        }
        #endregion
        #region IXafEntityObject members
        public void OnCreated() { }
        public void OnLoaded() { }
        public void OnSaving()
        {
            if (RemindIn.HasValue)
            {
                if ((AlarmTime == null) || (AlarmTime < DueDate - RemindIn.Value))
                {
                    AlarmTime = DueDate - RemindIn.Value;
                }
            }
            else
            {
                AlarmTime = null;
            }
            if (AlarmTime == null)
            {
                RemindIn = null;
                IsPostponed = false;
            }
        }
        #endregion

        private Administrateur assignedTo;
        [Association("Administrateur-Réclamation")]
        public virtual Administrateur AssignedTo
        {
            get { return assignedTo; }
            set { SetPropertyValue("AssignedTo", ref assignedTo, value); }
        }
        private Rapport_chauffeur rapport_Chauffeur;
        [Association("Réclamation-Rapport_chauffeur")]

      public Rapport_chauffeur Rapport_Chauffeur
        {
            get { return rapport_Chauffeur; }
            set { SetPropertyValue("Rapport_chauffeur", ref rapport_Chauffeur, value); }
        }
    }
}