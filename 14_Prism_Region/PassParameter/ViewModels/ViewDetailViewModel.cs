using PassParameter.Model;
using PassParameter.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PassParameter.ViewModels
{
    public class ViewDetailViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        private ImageItem selectedImageItem;
        public ICommand ReturnCommand { get; private set; }

        public ImageItem SelectedImageItem
        { 
            get => selectedImageItem;
            set => SetProperty(ref selectedImageItem,value); 
        }

        public ViewDetailViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            ReturnCommand = new DelegateCommand(Return);
        }

        private void Return()
        {
            //不附带参数返回
            this.regionManager.RequestNavigate("NavigationArea", nameof(ViewList));
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //导航进入
            System.Windows.MessageBox.Show("导航进入ViewDetail");

            //获取传递过来的参数
            this.SelectedImageItem = navigationContext.Parameters["selected"] as ImageItem;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //仅当目标区域中已存在该视图的实例，且再次导航到该视图类型时触发，返回 bool 值：
            //返回 true：复用已存在的视图实例（不创建新实例，仅调用 OnNavigatedTo 更新数据）。
            //返回 false：销毁已存在的视图实例，创建新的视图实例并导航到它。
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //导航离开
            System.Windows.MessageBox.Show("导航离开ViewDetail");
        }
    }
}
