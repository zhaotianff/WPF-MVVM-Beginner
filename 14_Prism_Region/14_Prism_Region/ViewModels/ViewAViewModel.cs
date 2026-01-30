using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Prism_Region.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string viewName = "ViewA";

        public string ViewName
        {
            get => this.viewName;
            set => SetProperty(ref this.viewName, value);
        }
    }
}
