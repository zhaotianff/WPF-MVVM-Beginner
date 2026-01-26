using _12_Prism_MVVM_Usage.Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Prism_MVVM_Usage.Event
{
    public class SelectStudentEvent :PubSubEvent<Student>
    {
    }
}
