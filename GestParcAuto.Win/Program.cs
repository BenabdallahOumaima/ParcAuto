using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Templates.ActionContainers;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using GestParcAuto.Module;
using GestParcAuto.Module.BusinessObjects;
using GestParcAuto.Module.BusinessObjects.ChauffeurNS;
using GestParcAuto.Module.DatabaseUpdate;





namespace GestParcAuto.Win {
   
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
      
        static void Main(string[] args) {
           // active les sytles visuels pour l'application
            Application.EnableVisualStyles();
            /*SetCompatibleTextRenderingDefault est automatiquement généré dans 
             * le fichier Program.cs. Pour changer le rendu du texte par défaut, modifiez le code généré*/
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;

            if(Tracing.GetFileLocationFromSettings() == DevExpress.Persistent.Base.FileLocation.CurrentUserApplicationDataFolder) {
                Tracing.LocalUserAppDataPath = Application.LocalUserAppDataPath;
            }
            Tracing.Initialize();
            GestParcAutoWindowsFormsApplication winApplication = new GestParcAutoWindowsFormsApplication();
            // Refer to the https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112680.aspx help article for more details on how to provide a custom splash form.
            if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
#if EASYTEST
            if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
            }
#endif
#if DEBUG
            if(System.Diagnostics.Debugger.IsAttached && winApplication.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
                winApplication.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
#endif
            try {

               
                winApplication.Setup();
                GestParcAuto .Module .CustomFunctions .CurrentUserNameFunction.Register();
                winApplication.Start();

            }
            catch(Exception e) {
                winApplication.HandleException(e);
            }

           
        }

        
    }
}
