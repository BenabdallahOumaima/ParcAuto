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
using DevExpress.Xpo.Metadata;
using System.Xml;

namespace GestParcAuto.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]C:\Users\pc\source\repos\GestParcAuto\GestParcAuto.Module\BusinessObjects\Utilisateur.cs
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class VehiEvent : BaseObject, IEvent, IRecurrentEvent
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

        private bool _AllDay;
        private string _Description;
        private DateTime _StartOn;
        private DateTime _EndOn;
        private int _Label;
        private string _Location;
        private int _Status;
        private string _Subject;
        private int _Type;
        private string _RecurrenceInfoXml;
        [Persistent("ResourceIds"), Size(SizeAttribute.Unlimited)]
        private string _MissionIds;
        //  [Persistent("RecurrencePattern")]
        // private Activity _RecurrencePattern;



        public VehiEvent(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            StartOn = DateTime.Now;
            EndOn = StartOn.AddHours(1);
            Missions.Add(Session.GetObjectByKey<Mission>(SecuritySystem.CurrentUserId));

        }


        [Association("VehiEvent-Mission")]
        public XPCollection<Mission> Missions
        {
            get { return GetCollection<Mission>("Missions"); }
        }
        protected override XPCollection<T> CreateCollection<T>(XPMemberInfo property)
        {
            XPCollection<T> result = base.CreateCollection<T>(property);
            if (property.Name == "Missions")
            {
                result.ListChanged += Missions_ListChanged;
            }
            return result;
        }
        public void UpdateMissionIds()
        {
            _MissionIds = string.Empty;
            foreach (Mission activityUser in Missions)
            {
                _MissionIds += String.Format(@"<ResourceId Type=""{0}"" Value=""{1}"" />", activityUser.Id.GetType().FullName, activityUser.Id);
            }
            _MissionIds = String.Format("<ResourceIds>{0}</ResourceIds>", _MissionIds);
        }
        private void UpdateMission()
        {
            Missions.SuspendChangedEvents();
            try
            {
                while (Missions.Count > 0)
                    Missions.Remove(Missions[0]);
                if (!String.IsNullOrEmpty(_MissionIds))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(_MissionIds);
                    foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
                    {
                        Mission activityUser = Session.GetObjectByKey<Mission>(new Guid(xmlNode.Attributes["Value"].Value));
                        if (activityUser != null)
                            Missions.Add(activityUser);
                    }
                }
            }
            finally
            {
                Missions.ResumeChangedEvents();
            }
        }
        private void Missions_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                UpdateMissionIds();
                OnChanged("ResourceId");
            }
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            if (Missions.IsLoaded && !Session.IsNewObject(this))
                Missions.Reload();
        }
        
        #region IEvent Members
        public bool AllDay
        {
            get { return _AllDay; }
            set { SetPropertyValue("AllDay", ref _AllDay, value); }
        }
        [Browsable(false), NonPersistent]
        public object AppointmentId
        {
            get { return Oid; }
        }
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue("Description", ref _Description, value); }
        }
        public int Label
        {
            get { return _Label; }
            set { SetPropertyValue("Label", ref _Label, value); }
        }
        public string Location
        {
            get { return _Location; }
            set { SetPropertyValue("Location", ref _Location, value); }
        }
        [PersistentAlias("_MissionIds"), Browsable(false)]
        public string ResourceId
        {
            get
            {
                if (_MissionIds == null)
                    UpdateMissionIds();
                return _MissionIds;
            }
            set
            {
                if (_MissionIds != value && value != null)
                {
                    _MissionIds = value;
                    UpdateMissionIds();
                }
            }
        }
        [Indexed]
        [ModelDefault("DisplayFormat", "{0:G}")]
        [ModelDefault("EditMask", "G")]
        public DateTime StartOn
        {
            get { return _StartOn; }
            set { SetPropertyValue("StartOn", ref _StartOn, value); }
        }
        [Indexed]
        [ModelDefault("DisplayFormat", "{0:G}")]
        [ModelDefault("EditMask", "G")]
        public DateTime EndOn
        {
            get { return _EndOn; }
            set { SetPropertyValue("EndOn", ref _EndOn, value); }
        }
        public int Status
        {
            get { return _Status; }
            set { SetPropertyValue("Status", ref _Status, value); }
        }
        [Size(250)]
        public string Subject
        {
            get { return _Subject; }
            set { SetPropertyValue("Subject", ref _Subject, value); }
        }
        [Browsable(false)]
        public int Type
        {
            get { return _Type; }
            set { SetPropertyValue("Type", ref _Type, value); }
        }
        #endregion

        #region IRecurrentEvent Members
        [DevExpress.Xpo.DisplayName("Recurrence"), Size(SizeAttribute.Unlimited)]
        public string RecurrenceInfoXml
        {
            get { return _RecurrenceInfoXml; }
            set { SetPropertyValue("RecurrenceInfoXml", ref _RecurrenceInfoXml, value); }
        }

        public IRecurrentEvent RecurrencePattern { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
    #endregion
}



