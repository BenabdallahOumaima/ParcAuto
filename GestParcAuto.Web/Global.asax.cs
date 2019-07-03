using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;
using System.Collections.Generic;
using GestParcAuto.Module.BusinessObjects.ChauffeurNS;
using GestParcAuto.Module.DatabaseUpdate;
using static GestParcAuto.Module.BusinessObjects.ChauffeurNS.Chauffeur;

namespace GestParcAuto.Web {
    public class Global : System.Web.HttpApplication {
        public Global() {
            InitializeComponent();
        }
  
        protected void Application_Start(Object sender, EventArgs e) {
            ASPxWebControl.CallbackError += new EventHandler(Application_Error);
#if EASYTEST
            DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = true;
#endif
        }
       
        protected void Session_Start(Object sender, EventArgs e) {
            Tracing.Initialize();
            WebApplication.SetInstance(Session, new GestParcAutoAspNetApplication());
            DevExpress.ExpressApp.Web.Templates.DefaultVerticalTemplateContentNew.ClearSizeLimit();
            WebApplication.Instance.SwitchToNewStyle();
            if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }

        
            WebApplication.Instance.Setup();
            GestParcAuto.Module.CustomFunctions.CurrentUserNameFunction.Register();
            WebApplication.Instance.Start();

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached && WebApplication.Instance.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
                WebApplication.Instance.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
#endif
            WebApplication.Instance.Setup();
        //    WebApplication.Instance.Start();
        }
        protected void Application_BeginRequest(Object sender, EventArgs e) {
        }
        protected void Application_EndRequest(Object sender, EventArgs e) {
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e) {
        }
        protected void Application_Error(Object sender, EventArgs e) {
            ErrorHandling.Instance.ProcessApplicationError();
        }
        const double LogoffTimeout = 10;// (seconds)

       protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null) return;
            DateTime? lastRequest = Session["LastRequestTime"] as DateTime?;
            if (lastRequest.HasValue && DateTime.Now.Subtract(lastRequest.Value).TotalSeconds > LogoffTimeout)
            {
                if (WebApplication.Instance != null && WebApplication.Instance.IsLoggedOn)
                {
                    WebApplication.LogOff(Session);
                }
            }
            Session["LastRequestTime"] = (DateTime?)DateTime.Now;
        }
        protected void Application_End(Object sender, EventArgs e) {
        }
        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
        }
        #endregion

        


    }
}
