using Module.RegisterForManual.Views;
using Module.RegisterForManual;
using Module.ViewListForManual.Views;
using Module.ViewListForManual;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;
using ManualLoadModule.Views;

namespace ManualLoadModule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        /// <summary>
        /// 配置模块
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var moduleRegisterType = typeof(RegisterModule);
            var moduleViewListType = typeof(ViewListModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleRegisterType.Name,
                ModuleType = moduleRegisterType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand //需要时再加载
            });
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleViewListType.Name,
                ModuleType = moduleViewListType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand //需要时再加载
            });
        }
    }

}
