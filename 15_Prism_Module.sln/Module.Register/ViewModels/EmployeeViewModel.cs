using CommonModule.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Register.ViewModels
{
    public class EmployeeViewModel : BindableBase, IEmployeeViewModel
    {
        private int id;

        public int Id
        { 
            get => this.id;
            set => this.SetProperty(ref id,value);
        }

        private string name;

        public string Name 
        { 
            get => this.name;
            set => SetProperty(ref this.name,value); 
        }

        private string phone;

        public string Phone
        {
            get => this.phone;
            set => SetProperty(ref phone, value);
        }

        public void XXX()
        {
            
        }
    }
}
