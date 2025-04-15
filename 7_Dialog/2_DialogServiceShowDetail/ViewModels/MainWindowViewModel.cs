using _2_DialogServiceShowDetail.DialogService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2_DialogServiceShowDetail.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StudentViewModel> studentList = new ObservableCollection<StudentViewModel>();

        public ObservableCollection<StudentViewModel> StudentList
        {
            get => studentList;
            set
            {
                studentList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StudentList"));
            }
        }

        public ICommand ShowStudentDetailCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            ShowStudentDetailCommand = new RelayCommand(ShowStudentDetail);

            StudentList.Add(new StudentViewModel() { Id = 1,Name  = "测试1",Age = "17"});
            StudentList.Add(new StudentViewModel() { Id = 2, Name = "测试2", Age = "18" });
            StudentList.Add(new StudentViewModel() { Id = 3, Name = "测试3", Age = "19" });
        }

        private void ShowStudentDetail()
        {
            //显示对话框
        }
    }
}
