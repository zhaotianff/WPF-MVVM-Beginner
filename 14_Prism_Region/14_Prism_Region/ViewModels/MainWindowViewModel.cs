using _14_Prism_Region.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _14_Prism_Region.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager regionManager;

        public DelegateCommand<string> NavigationToViewCommand { get; private set; }


        public MainWindowViewModel(IRegionManager regionManager)
        {
            //构造函数注入IRegionManager
            this.regionManager = regionManager;

            NavigationToViewCommand = new DelegateCommand<string>(NavigationToView);
        }

        private void NavigationToView(string viewName)
        {
            //导航
            this.regionManager.RequestNavigate("NavigationArea", viewName);
        }
    }
}
