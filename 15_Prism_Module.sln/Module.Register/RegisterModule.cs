
using Module.Register.ViewModels;
using Module.Register.Views;
using Prism.Ioc;

namespace Module.Register
{
    public class RegisterModule : Prism.Modularity.IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册View的时候同步绑定ViewModel            
            containerRegistry.RegisterForNavigation<RegisterView, RegisterViewModel>();

            //也可以只注册View
            //然后通过ViewModelLocator.AutoWireViewModel附加属性来自动绑定ViewModel
            //containerRegistry.RegisterForNavigation<RegisterView>();
        }
    }
}
