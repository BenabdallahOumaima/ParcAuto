using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;

public partial class Default : BaseXafPage
{
    protected override ContextActionsMenu CreateContextActionsMenu()
    {
        return new ContextActionsMenu(this, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports");
    }
    public override Control InnerContentPlaceHolder
    {
        get
        {
            return Content;
        }
    }
    protected void Page_Init()
    {
        CustomizeTemplateContent += (s, e) => {
            IHeaderImageControlContainer content = TemplateContent as IHeaderImageControlContainer;
            if (content == null) return;
            content.HeaderImageControl.DefaultThemeImageLocation = "Images";
            content.HeaderImageControl.ImageName = "optimiser-ma-flotte-auto.png";
            content.HeaderImageControl.Width = Unit.Pixel(120);
            content.HeaderImageControl.Height = Unit.Pixel(120);
            
        };

    }
}
