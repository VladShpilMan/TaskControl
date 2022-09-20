using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskControl.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }

        virtual public ICollection<Task> Tasks { get; set; }
    }
}
