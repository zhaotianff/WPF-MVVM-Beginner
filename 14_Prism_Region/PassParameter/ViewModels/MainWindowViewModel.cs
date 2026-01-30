using PassParameter.Model;
using PassParameter.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PassParameter.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager regionManager;

        private ObservableCollection<ImageItem> imageList;

        public ObservableCollection<ImageItem> ImageList
        {
            get => this.imageList;
            set => SetProperty(ref this.imageList, value);
        }

        public DelegateCommand<string> NavigationToViewCommand { get; private set; }


        public MainWindowViewModel(IRegionManager regionManager)
        {
            //构造函数注入IRegionManager
            this.regionManager = regionManager;

            NavigationToViewCommand = new DelegateCommand<string>(NavigationToView);

            //创建示例数据
            CreateDemoData();
        }

        private void NavigationToView(string viewName)
        {
            //导航
            this.regionManager.RequestNavigate("NavigationArea", viewName);
        }

        private void CreateDemoData()
        {
            ImageList =
            [
                new ImageItem() {Name = "此情可待成追忆，只是当时已惘然",Image = "../imgs/1.jpg" },
                new ImageItem() { Name = "纵使相逢应不识，尘满面，鬓如霜。", Image = "../imgs/2.jpg" },
            ];
        }
    }
}
