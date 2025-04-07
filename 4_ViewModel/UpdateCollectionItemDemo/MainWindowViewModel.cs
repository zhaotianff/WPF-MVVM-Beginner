using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateCollectionItemDemo
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<Student> studentList;

        public List<Student> StudentList 
        { 
            get => studentList;
            set
            {
                studentList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StudentList"));
            }
        }

        private List<Student2> studentList2;

        public List<Student2> StudentList2
        {
            get => studentList2;
            set
            {
                studentList2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StudentList2"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            LoadDemoData();
            LoadDemoData2();
        }

        private async void LoadDemoData()
        {
            StudentList = new List<Student>() 
            {
                new Student(){Id = 1,Name = "姓名1" },
                new Student(){Id = 2,Name = "姓名2" }
            };

            await Task.Delay(2000);

            StudentList[0].Name = "姓名2_修改";
        }

        private async void LoadDemoData2()
        {
            StudentList2 = new List<Student2>()
            {
                new Student2(){Id = 1,Name = "姓名1" },
                new Student2(){Id = 2,Name = "姓名2" }
            };

            await Task.Delay(2000);

            StudentList2[0].Name = "姓名2_修改";
        }
    }
}
