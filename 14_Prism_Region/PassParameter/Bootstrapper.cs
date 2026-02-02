using PassParameter.ViewModels;
using PassParameter.Views;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PassParameter
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewList,ViewListViewModel>();
            containerRegistry.RegisterForNavigation<ViewDetail, ViewDetailViewModel>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionManager = this.Container.Resolve<IRegionManager>();
            //regionManager.RequestNavigate("NavigationArea", nameof(ViewList));

            //也可以
            regionManager.RegisterViewWithRegion("NavigationArea", typeof(ViewList));
        }
    }
}
