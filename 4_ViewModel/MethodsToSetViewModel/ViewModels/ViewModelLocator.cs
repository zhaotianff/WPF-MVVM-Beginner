using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsToSetViewModel.ViewModels
{
    public class ViewModelLocator
    {
        private ViewCViewModel viewCViewModel;

        public ViewCViewModel ViewCViewModel
        {
            get
            {
                if (viewCViewModel == null)
                    viewCViewModel = new ViewCViewModel();

                return viewCViewModel;
            }
        }
    }
}
