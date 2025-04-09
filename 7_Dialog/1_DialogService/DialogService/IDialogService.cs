using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1_DialogService.DialogService
{
    public interface IDialogService
    {
        MessageBoxResult ShowMessage(string title, string content);
    }
}
