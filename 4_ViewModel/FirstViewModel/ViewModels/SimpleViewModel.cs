using FirstViewModel.Models;
using FirstViewModel.Services.Contract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstViewModel.ViewModels
{
    public class SimpleViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        //本地变量
        private bool xxx;
        private int nxxx;

        //基础类型字段
        private string property1;

        //属性
        public string Property1
        {
            get
            {
                return property1;
            }

            set
            {
                property1 = value;
                //属性更改通知
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Property1") );
            }
        }

        //对象类型字段
        private Model1 model1;

        //属性
        public Model1 Model1
        {
            get
            {
                return model1;
            }
            
            set
            {
                model1 = value;
                //属性更改通知
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Model1"));
            }
        }

        //可通知的列表
        private ObservableCollection<string> observableList = new ObservableCollection<string>();

        //属性
        public ObservableCollection<string> ObservableList
        {
            get
            {
                return observableList;
            }

            set
            {
                observableList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ObservableList"));
            }
        }

        /// <summary>
        /// 命令
        /// </summary>
        public ICommand MyCommand { get; private set; }

        //Service类
        private IMyService myService;

        public SimpleViewModel(IMyService myService)
        {
            //通过Ioc注入Service类
            this.myService = myService;

            //初始化命令，并绑定到对应的回调函数
            MyCommand = new RelayCommand(MyMethod);
        }

        /// <summary>
        /// MyCommand绑定的函数
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void MyMethod()
        {
            throw new NotImplementedException();
        }

        //数据校验
        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public string this[string columnName]
        {
            get
            {
                //验证
                return "";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
