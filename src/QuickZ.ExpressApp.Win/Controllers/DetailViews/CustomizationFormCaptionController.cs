using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Layout;
using DevExpress.ExpressApp;

namespace QuickZ.ExpressApp.Win.Controllers.DetailViews
{
    public class CustomizationFormCaptionController : ViewController<DetailView>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            ((WinLayoutManager)View.LayoutManager).ItemCreated += CustomizationFormCaptionController_ItemCreated;
        }
        void CustomizationFormCaptionController_ItemCreated(object sender, ItemCreatedEventArgs e)
        {
            if (e.ViewItem is PropertyEditor)
            {
                e.Item.CustomizationFormText = CaptionHelper.GetFullMemberCaption(View.ObjectTypeInfo, (((PropertyEditor)e.ViewItem).MemberInfo).Name);
            }
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            ((WinLayoutManager)View.LayoutManager).ItemCreated -= CustomizationFormCaptionController_ItemCreated;
        }
    }
}



