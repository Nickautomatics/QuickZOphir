using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Themes.SlackifyWin.Controllers
{
    /// <summary>
    /// A good way to handle JumpList events/actions
    /// See: https://www.devexpress.com/Support/Center/Question/Details/Q556109/how-to-open-a-view-using-information-from-command-line-arguments-passed-when-launching
    /// </summary>
    //public class TaskbarJumpListHandleStartupItemController : WindowController
    //{
    //    public TaskbarJumpListHandleStartupItemController()
    //    {
    //        TargetWindowType = WindowType.Main;
    //    }

    //    private void WinShowNavigationItemController_StartupWindowShown(object sender, EventArgs e)
    //    {
    //        ((WinShowViewStrategyBase)Application.ShowViewStrategy).StartupWindowLoad -= WinShowNavigationItemController_StartupWindowShown;
    //        var controller = Window.GetController<ShowNavigationItemController>();
    //        ShowStartupNavigationItem(controller);
    //    }
    //    protected virtual void ShowStartupNavigationItem(ShowNavigationItemController controller)
    //    {
    //        var args = Environment.GetCommandLineArgs();

    //        if (args.Length >= 2)
    //        {
    //            var sc = ViewShortcut.FromString(args[1]);

    //            var item = new ChoiceActionItem("CommandLineArgument", sc);
    //            controller.ShowNavigationItemAction.DoExecute(item);
    //        }
    //    }

    //    protected override void OnActivated()
    //    {
    //        base.OnActivated();
    //        ((WinShowViewStrategyBase)Application.ShowViewStrategy).StartupWindowLoad += WinShowNavigationItemController_StartupWindowShown;
    //    }

    //    protected override void OnDeactivated()
    //    {
    //        ((WinShowViewStrategyBase)Application.ShowViewStrategy).StartupWindowLoad -= WinShowNavigationItemController_StartupWindowShown;
    //        base.OnDeactivated();
    //    }
    //}
}
