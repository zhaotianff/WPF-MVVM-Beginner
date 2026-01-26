using _12_Prism_MVVM_Usage.Event;
using _12_Prism_MVVM_Usage.Model;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Prism_MVVM_Usage.ViewModels
{
    public class Window2ViewModel : BindableBase
    {
        private IEventAggregator eventAggregator;

        private int id;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private string name;

        public string Name
        {
            get => this.name;
            set => SetProperty(ref this.name, value);
        }

        private int score;

        public int Score
        {
            get => this.score;
            set => SetProperty(ref this.score, value);
        }

        public Window2ViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            //订阅事件
            this.eventAggregator.GetEvent<SelectStudentEvent>().Subscribe(OnSelectStudent);
        }

        private void OnSelectStudent(Student student)
        {
            this.Id = student.Id;
            this.Name = student.Name;
            this.Score = student.Score;
        }
    }
}
