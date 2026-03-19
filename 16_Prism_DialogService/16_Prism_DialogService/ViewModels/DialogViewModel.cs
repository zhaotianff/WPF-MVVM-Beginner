using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Prism_DialogService.ViewModels
{
    public class DialogViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// 确认/取消 绑定的命令，通过参数来判断true/false
        /// </summary>
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public DialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _title = "通知消息";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public event Action<IDialogResult> RequestClose;

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            //判断选择了“确认”还是“取消”
            if (parameter?.ToLower() == "true")
                result = ButtonResult.OK;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
            //对话框关闭时调用
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            //从参数中获取消息
            Message = parameters.GetValue<string>("message");
        }
    }
}
