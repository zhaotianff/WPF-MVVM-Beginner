using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DialogResult.DialogService
{
    public interface IMyDialog
    {
        event Action<DialogResult> RequestClose;
    }
}
