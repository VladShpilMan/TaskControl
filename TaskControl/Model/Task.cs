using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskControl.Model
{
    public class Task
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int EmployeeId { get; set; }
        public string TaskDescription { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Category Category { get; set; }
    }
}
