using _2_DialogServiceShowDetail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_DialogServiceShowDetail.DialogService
{
    public interface IDialogService
    {
        void ShowStudentDetail(StudentViewModel student);
    }
}
