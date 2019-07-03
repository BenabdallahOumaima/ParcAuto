namespace AutoDashbord
{
    partial class DesignerForm1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dashboardBarAndDockingController1 = new DevExpress.DashboardWin.Native.DashboardBarAndDockingController(this.components);
            this.dashboardDesigner = new DevExpress.DashboardWin.DashboardDesigner();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBarAndDockingController1)).BeginInit();
            this.SuspendLayout();
            // 
            // dashboardBarAndDockingController1
            // 
            this.dashboardBarAndDockingController1.PropertiesDocking.ViewStyle = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Classic;
            // 
            // dashboardDesigner
            // 
            this.dashboardDesigner.AllowMaximizeAnimation = true;
            this.dashboardDesigner.AllowMaximizeDashboardItems = true;
            this.dashboardDesigner.AllowPrintDashboard = true;
            this.dashboardDesigner.AllowPrintDashboardItems = true;
            this.dashboardDesigner.BarAndDockingController = this.dashboardBarAndDockingController1;
            this.dashboardDesigner.DataSourceWizard.ShowConnectionsFromAppConfig = true;
            this.dashboardDesigner.DataSourceWizard.SqlWizardSettings.DatabaseCredentialsSavingBehavior = DevExpress.DataAccess.Wizard.SensitiveInfoSavingBehavior.Prompt;
            this.dashboardDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardDesigner.Location = new System.Drawing.Point(0, 0);
            this.dashboardDesigner.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dashboardDesigner.Name = "dashboardDesigner";
            this.dashboardDesigner.Size = new System.Drawing.Size(1388, 732);
            this.dashboardDesigner.TabIndex = 0;
            this.dashboardDesigner.UseNeutralFilterMode = true;
            this.dashboardDesigner.Load += new System.EventHandler(this.dashboardDesigner_Load);
            // 
            // DesignerForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 732);
            this.Controls.Add(this.dashboardDesigner);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DesignerForm1";
            this.Text = "Dashboard Designer";
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBarAndDockingController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.DashboardWin.DashboardDesigner dashboardDesigner;
        private DevExpress.DashboardWin.Native.DashboardBarAndDockingController dashboardBarAndDockingController1;
    }
}