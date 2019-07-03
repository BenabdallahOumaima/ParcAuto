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
    [ImageName("BO_Document")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class réclamation : BaseObject, ISupportNotifications, IXafEntityObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public réclamation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private string amende;
        private string panne;
        private DateTime _Date;
        private bool _IsPostponed;
        private DateTime _DueDate;
        private string _Subject;
        private int _Id;
        private TimeSpan? _RemindIn;
        #region ISupportNotifications members
        private DateTime? alarmTime;
        private Rapport_chauffeur rapport_Chauffeur;
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
        #endregion
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
        [Browsable(false)]
        public int Id
        {
            get { return _Id; }
            private set { SetPropertyValue("Id", ref _Id, value); }
        }
        public string Subject
        {
            get { return _Subject; }
            set { SetPropertyValue("Subject", ref _Subject, value); }
        }
        public DateTime DueDate
        {
            get { return _DueDate; }
            set { SetPropertyValue("DueDate", ref _DueDate, value); }
        }
       
        private Administrateur assignedTo;
        [Association("Administrateur-réclamation")]
        public virtual Administrateur AssignedTo
        {
            get { return assignedTo; }
            set { SetPropertyValue("AssignedTo", ref assignedTo, value); }
        }
        [Association("réclamation-Rapport_chauffeur")]

        public Rapport_chauffeur Rapport_Chauffeur
        {
            get { return rapport_Chauffeur; }
            set { SetPropertyValue("Rapport_chauffeur", ref rapport_Chauffeur, value); }
        }
    }



}

