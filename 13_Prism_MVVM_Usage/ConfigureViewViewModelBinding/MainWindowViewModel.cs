using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureViewViewModelBinding
{
    public class MainWindowViewModel: BindableBase
    {
        public MainWindowViewModel()
        {
            //测试ViewModel是否绑定生效
            System.Windows.MessageBox.Show("HelloWorld");
        }
    }
}
