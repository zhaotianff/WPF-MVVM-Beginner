using CustomDialogWindow.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDialogWindow.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private string dialogResultContent;

        public string DialogResultContent
        {
            get => dialogResultContent;
            set => SetProperty(ref dialogResultContent, value);
        }

        public DelegateCommand ShowDialogCommand { get; private set; }

        private IDialogService dialogService;

        public ShellViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;

            ShowDialogCommand = new DelegateCommand(ShowDialog);
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        private void ShowDialog()
        {
            DialogParameters keyValuePairs = new DialogParameters();
            keyValuePairs.Add("message", "这是用于显示在对话框上的消息");
            this.dialogService.Show(nameof(DialogView), keyValuePairs, HandleDialogResult);
        }

        /// <summary>
        /// 处理对话框返回结果
        /// </summary>
        /// <param name="dialogResult"></param>
        private void HandleDialogResult(IDialogResult dialogResult)
        {
            //显示对话框结果
            DialogResultContent = dialogResult.Result.ToString();
        }
    }
}
