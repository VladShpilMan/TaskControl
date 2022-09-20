using System.Collections.Generic;
using System.Linq;
using TaskControl.Model;

namespace TaskControl.ViewModel
{
    public class TasksListModel : BaseViewModelClass
    {
        #region Private Fields
        private EmployeeWithTaskCounter _Employee;
        private string _id = "Identyfikator: ";
        private string _name = "Dane: ";
        private string _currentTask;
        private TaskWithCategoty _selectedTaskWithCategoty;
        #endregion

        #region Public Properties
        public TaskWithCategoty SelectedTaskWithCategoty
        {
            get { return _selectedTaskWithCategoty; }
            set
            {
                _selectedTaskWithCategoty = value;
                CurrentTask = value.TaskDescription;
                _Employee.CurrentTaskName = value.TaskDescription;
                OnPropertyChanged("SelectedTaskWithCategoty");
            }
        }
        public string Id
        {
            get { return _id + _Employee.Id.ToString(); }
        }
        public string Name
        {
            get { return _name + _Employee.EmployeeName; }
        }
        public string CurrentTask
        {
            get { return _currentTask; }
            set 
            { 
                _currentTask = value != null ? value : "Nie ma żadnych zadań";
                OnPropertyChanged("CurrentTask");
            }
        }
        public List<Task> TaskList { get; set; }
        public List<TaskWithCategoty> TaskWithCategotyList { get; set; }
        #endregion

        public TasksListModel(ref EmployeeWithTaskCounter employee)
        {
            _Employee = employee;
            TaskList = WorkersListModel.connectionSQL.GetTasks().Where(x => x.EmployeeId == _Employee.Id).ToList();
            TaskWithCategotyList = Converter(TaskList);
            CurrentTask = employee.CurrentTaskName != null ? employee.CurrentTaskName : TaskList.Count() == 0 ? null : TaskList.First().TaskDescription;
        }

        private List<TaskWithCategoty> Converter(List<Task> tasks)
        {
            var result = new List<TaskWithCategoty>();

            foreach (var t in tasks)
            {
                result.Add(new TaskWithCategoty() { Id = t.Id, CategoryName = GetCategoryName(t.Id), TaskDescription = t.TaskDescription}) ;
            }

            return result;
        }

        private string GetCategoryName(int id)
        {
            var result = from t in TaskList
                         join c in WorkersListModel.connectionSQL.GetCategory() on t.CategoryId equals c.Id
                         where t.Id == id
                         select new { Name = c.CategoryName };

            return result.Last().Name;
        }
    }
}
