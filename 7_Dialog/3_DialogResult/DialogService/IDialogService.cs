using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DialogResult.DialogService
{
    public interface IDialogService
    {
        void ShowNotificationDialog(Action<DialogResult> resultCallback);
    }
}
