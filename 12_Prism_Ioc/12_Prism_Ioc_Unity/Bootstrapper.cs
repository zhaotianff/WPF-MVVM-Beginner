using _12_Prism_Ioc_Unity.Services;
using _12_Prism_Ioc_Unity.ViewModels;
using _12_Prism_Ioc_Unity.Views;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Unity;
using Unity.Injection;

namespace _12_Prism_Ioc_Unity
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册同一接口的不同实现
            containerRegistry.Register<IMessageService, MessageService>("ServiceA");
            containerRegistry.Register<IMessageService, MessageService2>("ServiceB");

            //注册View和ViewModel，并进行绑定
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();

            //手动配置注入
            containerRegistry.GetContainer().RegisterFactory<MainWindowViewModel>((container, type, name) => new MainWindowViewModel(container.Resolve<IMessageService>("ServiceB")));
        }
    }
}
