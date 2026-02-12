using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModule.ViewModels
{
    public interface IEmployeeViewModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Phone { get; set; }

        void XXX();
    }
}
