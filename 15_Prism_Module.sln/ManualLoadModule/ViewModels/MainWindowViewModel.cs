using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualLoadModule.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IModuleManager moduleManager;

        public DelegateCommand ManualLoadModuleCommand { get; private set; }

        public MainWindowViewModel(IModuleManager moduleManager)
        {
            this.moduleManager = moduleManager;
            ManualLoadModuleCommand = new DelegateCommand(ManualLoadModule);
        }

        /// <summary>
        /// 手动加载模块
        /// </summary>
        private void ManualLoadModule()
        {
            this.moduleManager.LoadModule("RegisterModule");
            this.moduleManager.LoadModule("ViewListModule");
        }
    }
}
