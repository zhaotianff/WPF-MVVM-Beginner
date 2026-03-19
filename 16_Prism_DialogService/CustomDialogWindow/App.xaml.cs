using CustomDialogWindow.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CustomDialogWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册自定义宿主窗口
            containerRegistry.RegisterDialogWindow<CustomDialog>();

            //注册对话框View类型
            containerRegistry.RegisterDialog<DialogView>();
        }
    }

}
