using CommonModule.Event;
using CommonModule.ViewModels;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.ViewList.ViewModels
{
    public class EmployeeListViewModel : BindableBase
    {
        private ObservableCollection<IEmployeeViewModel> employeeList = new ObservableCollection<IEmployeeViewModel>();

        public ObservableCollection<IEmployeeViewModel> EmployeeList
        {
            get => this.employeeList;
            set => this.SetProperty(ref employeeList, value);
        }

        public EmployeeListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<SelectEmployeeEvent>().Subscribe(OnAddEmployee);
        }

        private void OnAddEmployee(IEmployeeViewModel model)
        {
            this.EmployeeList.Add(model);
        }
    }
}
