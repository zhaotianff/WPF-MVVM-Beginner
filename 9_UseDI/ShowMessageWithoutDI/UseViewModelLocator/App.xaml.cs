using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;
using UseViewModelLocator.Services;
using UseViewModelLocator.Services.Contract;
using UseViewModelLocator.ViewModels;

namespace UseViewModelLocator
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
            //指定参数注入
            container.RegisterFactory<MainWindowViewModel>("ParameterViewModel", x => new MainWindowViewModel(x.Resolve<IMyService>()));
        }
    }
}
