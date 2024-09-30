using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDependencyProperty
{
    public class CLRProperty
    {
        private int id;

        public int Id
        {
            get => id;
            set => id = value;
        }
    }
}
