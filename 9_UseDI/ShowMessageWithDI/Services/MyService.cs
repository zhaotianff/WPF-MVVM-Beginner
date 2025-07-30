using ShowMessageWithDI.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMessageWithDI.Services
{
    public class MyService : IMyService
    {
        public void ShowMessage()
        {
            System.Windows.MessageBox.Show("HelloWorld");
        }
    }
}
