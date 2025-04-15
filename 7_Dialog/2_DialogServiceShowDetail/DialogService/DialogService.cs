using _2_DialogServiceShowDetail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2_DialogServiceShowDetail.DialogService
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

        public void ShowStudentDetail(StudentViewModel student)
        {
            
        }
    }
}
