using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoRibbon
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dashboardDesigner1_Load(object sender, EventArgs e)
        {
            //dashboardDesigner1.CustomizeDashboardTitle += dashboardDesigner1_CustomizeDashboardTitle;
            //dashboardDesigner1.LoadDashboard(@"F:\GestParcAuto\DXApplication4\AutoRibbon\bin\Debug\DashbordDsigner1");
        }
        //private void ChangeLayout(DashboardToolbarItemClickEventArgs args)
        //{
        //    Dashboard dashboard = new Dashboard();
        //    dashboard.LoadFromXml(@"F:\GestParcAuto\DXApplication4\AutoRibbon\bin\Debug\DashbordDsigner1");
        //    dashboard.BeginUpdate();
        //    // Switch off the DateFilter item's AutoHeight arrangement mode so that the DateFilter layout does not ignore its layout weight.
        //   // ((DateFilterDashboardItem)(dashboard.Items["dateFilterDashboardItem1"])).ArrangementMode = DateFilterArrangementMode.Horizontal;
        //    // Hide captions.
        //    dashboard.Items.ForEach(item => item.ShowCaption = false);
        //    dashboard.Groups.ForEach(item => item.ShowCaption = false);
        //    // Create layout items for the DateFilter and Chart dashboard items.
        //    DashboardLayoutItem dateFilterLayoutItem = new DashboardLayoutItem(dashboard.Items["dateFilterDashboardItem1"], 13);
        //    DashboardLayoutItem chartLayoutItem = new DashboardLayoutItem(dashboard.Items["chartDashboardItem1"], 87);
        //    // Create a layout item for the dashboard Group item.
        //    DashboardLayoutGroup groupLayoutItem = new DashboardLayoutGroup()
        //    {
        //        Orientation = DashboardLayoutGroupOrientation.Vertical,
        //        DashboardItem = dashboard.Groups["dashboardItemGroup1"],
        //        Weight = 70
        //    };
        //    // Connect layout items in the layout tree.
        //    groupLayoutItem.ChildNodes.AddRange(dateFilterLayoutItem, chartLayoutItem);
        //    // Create a Grid layout item.
        //    DashboardLayoutItem gridLayoutItem = new DashboardLayoutItem(dashboard.Items["gridDashboardItem1"], 30);
        //    // Create a group layout item to organize the Grid layout item and a Dashboard Group layout item.
        //    DashboardLayoutGroup layoutGroup = new DashboardLayoutGroup(DashboardLayoutGroupOrientation.Horizontal, 85);
        //    // Connect layout items in the layout tree.
        //    layoutGroup.ChildNodes.AddRange(gridLayoutItem, groupLayoutItem);
        //    // Create a RangeFilter layout item.
        //    DashboardLayoutItem rangeFilterLayoutItem = new DashboardLayoutItem(dashboard.Items["rangeFilterDashboardItem1"], 15);
        //    // Create a root layout group. Its DashboardItem property is null.
        //    DashboardLayoutGroup rootGroup = new DashboardLayoutGroup()
        //    {
        //        Orientation = DashboardLayoutGroupOrientation.Vertical,
        //        Weight = 100,
        //        DashboardItem = null
        //    };
        //    // Connect layout items in the layout tree. 
        //    rootGroup.ChildNodes.AddRange(layoutGroup, rangeFilterLayoutItem);
        //    // The layout treee is built. Set the dashboard's root layout node to finalize the layout.
        //    dashboard.LayoutRoot = rootGroup;
        //    dashboard.EndUpdate();

        //    dashboardDesigner1.Dashboard = dashboard;
        //}

        //private void RepositionItems(DashboardToolbarItemClickEventArgs args)
        //{
        //    Dashboard dashboard = dashboardDesigner1.Dashboard;
        //    DashboardLayoutGroup rootGroup = dashboard.LayoutRoot.ChildNodes[0] as DashboardLayoutGroup;
        //    if ((rootGroup != null) && (rootGroup.ChildNodes.Count > 1))
        //        rootGroup.ChildNodes[0].MoveRight(rootGroup.ChildNodes[1]);
        //}

        //private void SaveLayoutToFile(DashboardToolbarItemClickEventArgs args)
        //{
        //    dashboardDesigner1.SaveDashboardLayout("DashboradLayout.xml");
        //}

        //private void LoadLayoutFromFile(DashboardToolbarItemClickEventArgs obj)
        //{
        //    if (File.Exists("DasboradDsigner1.xml"))
        //        dashboardDesigner1.LoadDashboardLayout("DasboradDsigner1.xml");
        //}

        //private void dashboardDesigner1_CustomizeDashboardTitle(object sender, CustomizeDashboardTitleEventArgs e)
        //{
        //    var exportItem = e.Items.FirstOrDefault(i => i.ButtonType == DashboardButtonType.Export);
        //    if (exportItem != null)
        //        e.Items.Remove(exportItem);
        //    DashboardToolbarItem btnChangeLayout = new DashboardToolbarItem();
        //    btnChangeLayout.Caption = "Change Layout";
        //    btnChangeLayout.ClickAction = new Action<DashboardToolbarItemClickEventArgs>(ChangeLayout);
        //    e.Items.Add(btnChangeLayout);
        //    DashboardToolbarItem btnRepositionItems = new DashboardToolbarItem();
        //    btnRepositionItems.Caption = "Reposition Items";
        //    btnRepositionItems.ClickAction = new Action<DashboardToolbarItemClickEventArgs>(RepositionItems);
        //    e.Items.Add(btnRepositionItems);
        //    DashboardToolbarItem btnSaveLayout = new DashboardToolbarItem();
        //    btnSaveLayout.Caption = "Save Layout to File";
        //    btnSaveLayout.ClickAction = new Action<DashboardToolbarItemClickEventArgs>(SaveLayoutToFile);
        //    e.Items.Add(btnSaveLayout);
        //    DashboardToolbarItem btnLoadLayout = new DashboardToolbarItem();
        //    btnLoadLayout.Caption = "Load Layout from File";
        //    btnLoadLayout.ClickAction = new Action<DashboardToolbarItemClickEventArgs>(LoadLayoutFromFile);
        //    e.Items.Add(btnLoadLayout);
        //}
    }
}

