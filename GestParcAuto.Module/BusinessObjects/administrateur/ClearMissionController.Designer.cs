namespace GestParcAuto.Module.BusinessObjects.administrateur
{
    partial class ClearTaskAction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ClearMissionsAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // ClearMissionsAction
            // 
            this.ClearMissionsAction.Caption = "Clear Missions ";
            this.ClearMissionsAction.Category = "ListView";
            this.ClearMissionsAction.ConfirmationMessage = "Are you sure ?";
            this.ClearMissionsAction.Id = "ClearMissionsAction";
            this.ClearMissionsAction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.ClearMissionsAction.ToolTip = null;
            this.ClearMissionsAction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.ClearMissionsAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ClearMissionsAction_Execute);
            // 
            // ClearTaskAction
            // 
            this.Actions.Add(this.ClearMissionsAction);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction ClearMissionsAction;
    }
}
