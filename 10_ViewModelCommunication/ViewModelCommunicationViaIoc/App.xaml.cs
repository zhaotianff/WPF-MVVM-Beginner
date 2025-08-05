using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity.Lifetime;
using Unity;
using ViewModelCommunicationViaIoc.ViewModels;

namespace ViewModelCommunicationViaIoc
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

            Receive receive = new Receive();
            receive.Show();
        }

        private void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<SendViewModel>();
            container.RegisterType<ReceiveViewModel>(new ContainerControlledLifetimeManager());
        }
    }
}
