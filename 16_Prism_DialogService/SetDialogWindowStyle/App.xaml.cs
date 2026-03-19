using Prism.Ioc;
using Prism.Unity;
using SetDialogWindowStyle.Views;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SetDialogWindowStyle
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
            //注册对话框View类型
            containerRegistry.RegisterDialog<DialogView>();
        }
    }
}
