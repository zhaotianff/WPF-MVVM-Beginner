using Module.ViewListForManual.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Reflection;

namespace Module.ViewListForManual
{
    public class ViewListModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //设置区域默认View
            //这样当模块被手动加载时，就可以显示View
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ListArea", typeof(EmployeeListView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
