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
using System.Windows;

namespace PassParameter.ViewModels
{
    public class ViewListViewModel : BindableBase
    {
        private IRegionManager regionManager;
        private ObservableCollection<ImageItem> imageList;

        public DelegateCommand<ImageItem> SelectImageItemCommand { get; private set; }

        public ObservableCollection<ImageItem> ImageList
        {
            get => this.imageList;
            set => SetProperty(ref this.imageList, value);
        }

        public ViewListViewModel(IRegionManager regionManager)
        {
            SelectImageItemCommand = new DelegateCommand<ImageItem>(SelectImageItem);

            //创建示例数据
            CreateDemoData();

            this.regionManager = regionManager;
        }

        private void SelectImageItem(ImageItem item)
        {
            //构造NavigationParameters
            NavigationParameters keyValuePairs = new NavigationParameters();
            keyValuePairs.Add("selected", item);

            //传递参数
            this.regionManager.RequestNavigate("NavigationArea", nameof(ViewDetail), keyValuePairs);

            //不传递参数
            //this.regionManager.RequestNavigate("NavigationArea", "ViewDetail");
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
