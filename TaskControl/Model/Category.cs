using System.Collections.Generic;

namespace TaskControl.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
