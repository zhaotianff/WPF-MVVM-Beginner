using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1_DialogService.DialogService
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
            if(instance == null)
            {
                lock(obj)
                {
                    if (instance == null)
                        instance = new DialogService();
                }
            }  

            return instance;
        }

        /// <summary>
        /// ShowMessage接口实现
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public MessageBoxResult ShowMessage(string title, string content)
        {
            return MessageBox.Show(title, content);
        }
    }
}
