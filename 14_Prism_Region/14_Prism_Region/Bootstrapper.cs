using _14_Prism_Region.ViewModels;
using _14_Prism_Region.Views;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _14_Prism_Region
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            //containerRegistry.RegisterForNavigation<ViewA>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            //设置默认视图
            var regionManager = this.Container.Resolve<IRegionManager>();
            regionManager.RequestNavigate("NavigationArea", nameof(ViewA));
        }
    }
}
