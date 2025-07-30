using ShowMessageWithoutDI.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMessageWithoutDI.Services
{
    internal class MyService : IMyService
    {
        public void ShowMessage()
        {
            System.Windows.MessageBox.Show("HelloWorld");
        }
    }
}
