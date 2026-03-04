using Module.RegisterForManual.Views;
using Prism.Ioc;
using Prism.Regions;

namespace Module.RegisterForManual
{
    public class RegisterModule : Prism.Modularity.IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //设置区域默认View
            //这样当模块被手动加载时，就可以显示View
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("EditArea", typeof(RegisterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
