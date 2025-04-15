using _1_DialogService.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _1_DialogService.ViewModels
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// DialogService实例
        /// </summary>
        private IDialogService dialogService;

        public ICommand ShowMessageCommand { get; set; }

        public MainWindowViewModel()
        {
            ShowMessageCommand = new RelayCommand(ShowMessage);

            //如果通过注入的形式，可以我们从构造函数取得IDialogService的实例
            //这里我们手动获取
            this.dialogService = DialogService.DialogService.GetInstance();
        }

        private void ShowMessage()
        {
            var result = this.dialogService.ShowMessage("标题", "内容");
        }
    }
}
