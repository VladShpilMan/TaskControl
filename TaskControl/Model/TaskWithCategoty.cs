using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskControl.Model
{
    public class TaskWithCategoty
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string TaskDescription { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Category Category { get; set; }
    }
}
