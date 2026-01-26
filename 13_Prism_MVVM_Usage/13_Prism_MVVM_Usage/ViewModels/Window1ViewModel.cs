using _12_Prism_MVVM_Usage.Event;
using _12_Prism_MVVM_Usage.Model;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Prism_MVVM_Usage.ViewModels
{
    public class Window1ViewModel : BindableBase
    {
        private ObservableCollection<Student> students;
        private IEventAggregator eventAggregator;

        public ObservableCollection<Student> Students
        {
            get => students;
            set => SetProperty(ref students, value);
        }

        public DelegateCommand<Student> OnStudentSelectionChangedCommand { get; private set; }

        public Window1ViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            AddDemoData();
            OnStudentSelectionChangedCommand = new DelegateCommand<Student>(OnStudentSelectionChanged);
        }

        private void OnStudentSelectionChanged(Student student)
        {
            eventAggregator.GetEvent<SelectStudentEvent>().Publish(student);
        }

        private void AddDemoData()
        {
            students = new ObservableCollection<Student>();
            students.Add(new Student() {Id = 1,Name = "夺帅",Score = 100 });
            students.Add(new Student() { Id = 2, Name = "明辨", Score = 99 });
            students.Add(new Student() { Id = 3, Name = "暗夜", Score = 98 });
        }
    }
}
