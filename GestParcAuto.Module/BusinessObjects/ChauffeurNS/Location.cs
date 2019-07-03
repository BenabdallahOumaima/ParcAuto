using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Security;
using GestParcAuto.Module.BusinessObjects.ChauffeurNS;
using DevExpress.ExpressApp.Model;

namespace GestParcAuto.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Location :BaseObject, IMapsMarker
    {
        public Location(Session session) : base(session)
        { }
        private int id;
        private double latitude;
        private double longitude;
        private string title;
        private DateTime timeStamp;

        [Browsable(false)]
        public int ID { get
            { return id; }
           }
        public double Latitude
        {
            get { return latitude; }
            set { SetPropertyValue("Latitude",ref latitude,value); }
        }
        public double Longitude {
            get { return longitude; }
            set { SetPropertyValue("Longitude", ref longitude, value); } }
        

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { SetPropertyValue("TimeStamp", ref timeStamp, value); }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set { SetPropertyValue("Title", ref title, value); }
        }
       

    }
}
