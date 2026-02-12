using Module.Register;
using Module.Register.Views;
using Module.ViewList;
using Module.ViewList.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace _15_Prism_Module.sln
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
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<RegisterModule>();
            moduleCatalog.AddModule<ViewListModule>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionManager = this.Container.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion("EditArea", typeof(RegisterView));
            regionManager.RegisterViewWithRegion("ListArea", typeof(EmployeeListView));
        }
    }

}
