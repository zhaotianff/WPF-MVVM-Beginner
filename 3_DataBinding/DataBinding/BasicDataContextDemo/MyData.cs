using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataContextDemo
{
    public class MyData
    {
        private string displayText = "HelloWorld";

        public string DisplayText
        {
            get => displayText;
            set => displayText = value;
        }
    }
}
