using CommonModule.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Register.ViewModels
{
    public class RegisterViewModel :BindableBase
    {
        private IEventAggregator eventAggregator;

        public DelegateCommand RegisterCommand { get; private set; }

        private EmployeeViewModel employeeViewModel = new EmployeeViewModel();

        public EmployeeViewModel EmployeeViewModel
        {
            get => this.employeeViewModel;
            set => this.SetProperty(ref employeeViewModel, value);
        }

        public RegisterViewModel(IEventAggregator eventAggregator)
        {
            RegisterCommand = new DelegateCommand(Register);

            this.eventAggregator = eventAggregator;
        }

        private void Register()
        {
            this.eventAggregator.GetEvent<SelectEmployeeEvent>().Publish(this.EmployeeViewModel);
        }
    }
}
