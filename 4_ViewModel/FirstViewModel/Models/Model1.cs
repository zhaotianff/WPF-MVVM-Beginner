using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstViewModel.Models
{
    public class Model1 : INotifyPropertyChanged
    {
        //如果不需要模型内部的值在更改时通知UI
        //就可以使用自动属性
        public string Field1 { get; set; }

        private string field2;

        /// <summary>
        /// 可通知的属性
        /// </summary>
        public string Field2 
        { 
            get
            {
                return field2;
            }

            set
            {
                field2 = value;
                //属性更改通知
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Field2"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
