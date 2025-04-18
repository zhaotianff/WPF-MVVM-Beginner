using _3_DialogResult.ViewModels;
using _3_DialogResult.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DialogResult.DialogService
{
    public class DialogService : IDialogService
    {
        private static volatile DialogService instance;
        private static object obj = new object();

        /// <summary>
        /// 单例模式
        /// </summary>
        public static DialogService GetInstance()
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                        instance = new DialogService();
                }
            }

            return instance;
        }

        public void ShowNotificationDialog(Action<DialogResult> resultCallback)
        {
            DialogResult dialogResult;
            var dialog = new DialogView();

            NotificationDialogViewModel notificationDialogViewModel = new NotificationDialogViewModel();
            notificationDialogViewModel.RequestClose += (x)=> 
            {
                dialogResult = x;
                dialog.Close();
                resultCallback?.Invoke(dialogResult);
            };

            dialog.ShowInTaskbar = false;
            dialog.DataContext = notificationDialogViewModel;
            dialog.ShowDialog();
        }
    }
}
