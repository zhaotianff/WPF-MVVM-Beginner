using _12_Prism_Ioc.Services;
using _12_Prism_Ioc.Views;
using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace _12_Prism_Ioc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        // 1. 配置主窗口（Prism 启动时加载）
        protected override Window CreateShell()
        {
            // DryIoc 会自动解析 MainWindow（依赖注入）
            return Container.Resolve<MainWindow>();
        }

        // 2. 注册服务到 DryIoc 容器
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // ========== 基础注册方式 ==========
            // 单例注册（全局唯一）
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();

            // 瞬时注册（每次解析新建实例）
            containerRegistry.Register<IDataService, DataService>();

            // 若需要使用 DryIoc 原生 API，可通过 Container 转换
            var dryIocContainer = containerRegistry.GetContainer();

            //dryIocContainer是DryIoc原生容器对象，可以参考DryIoc文档了解详细使用
            //https://github.com/dadhi/DryIoc

            // 注册视图（Prism 导航用）
            containerRegistry.RegisterForNavigation<HomeView>();
        }

        // 3. 可选：模块化配置（若使用模块）
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            // 注册模块（示例）
            // moduleCatalog.AddModule<MyModule>();
        }
    }

}
