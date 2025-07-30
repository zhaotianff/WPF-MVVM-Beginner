using ShowMessageWithDI.Services;
using ShowMessageWithDI.Services.Contract;
using ShowMessageWithDI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace ShowMessageWithDI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static IUnityContainer Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Container = new UnityContainer();
            RegisterTypes(Container);
        }

        private void RegisterTypes(IUnityContainer container)
        {
            //控制生命周期为单例
            container.RegisterType<IMyService, MyService>(new ContainerControlledLifetimeManager());

            //默认
            //container.RegisterType<MainWindowViewModel>();

            //指定参数注入
            container.RegisterFactory<MainWindowViewModel>("ParameterViewModel", x => new MainWindowViewModel(x.Resolve<IMyService>()));
        }
    }
}
