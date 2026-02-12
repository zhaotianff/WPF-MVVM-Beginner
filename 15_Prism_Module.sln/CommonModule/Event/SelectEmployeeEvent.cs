using CommonModule.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModule.Event
{
    public class SelectEmployeeEvent : PubSubEvent<IEmployeeViewModel>
    {
    }
}
