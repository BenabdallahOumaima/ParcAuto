using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace GestParcAuto.Module.BusinessObjects.administrateur
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ClearTaskAction : ViewController
    {
        public ClearTaskAction()
        {
            InitializeComponent();
        }
      
            private void ClearMissionsAction_Execute( Object sender, SimpleActionExecuteEventArgs e)
        {
            ((Mission)View.CurrentObject).Vehicule.Delete();
            ((DetailView)View).FindItem("Vehicules").Refresh();
            ObjectSpace.SetModified(View.CurrentObject);
        }
      

            private void ClearMissionController_Activated(object sender, EventArgs e)
        {
            ClearMissionsAction.Enabled.SetItemValue("EditMode", ((DetailView)View).ViewEditMode == ViewEditMode.Edit);
            ((DetailView)View).ViewEditModeChanged += new EventHandler<EventArgs>(ClearMissionController_ViewEditModeChanged);


        }

        private void ClearMissionController_ViewEditModeChanged(object sender, EventArgs e)
        {
                 ClearMissionsAction.Enabled.SetItemValue("EditMode", 
                ((DetailView)View).ViewEditMode == ViewEditMode.Edit);     
                }

        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        
    }
}
