using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TaskControl.DbConnections;
using TaskControl.Helpers;
using TaskControl.Interface;
using TaskControl.Model;
using TaskControl.View;

namespace TaskControl.ViewModel
{
    public class WorkersListModel : BaseViewModelClass
    {
        #region Commands
        public ICommand AddEmployeeCMD { get; set; }
        public ICommand RemoveEmployeeCMD { get; set; }
        #endregion

        #region Private Fields
        public static ConnectionSQL connectionSQL;
        private List<Employee> _employeesList;
        private ObservableCollection<EmployeeWithTaskCounter> _employeesListWithTaskCounter;
        private List<Task> _tasksList;
        private EmployeeWithTaskCounter _selectedEmployee;
        #endregion

        #region Public Properties
        public EmployeeWithTaskCounter SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                if(_selectedEmployee != null)
                    (Application.Current.MainWindow.DataContext as MainWindowModel).CurrentWindow = new TasksList(ref _selectedEmployee);
                OnPropertyChanged("SelectedEmployee");
            }
        }
        public List<Employee> EmployeesList
        {
            get { return _employeesList; }
            set
            {
                _employeesList = value;
                EmployeesListWithTaskCounter = new ObservableCollection<EmployeeWithTaskCounter>(EmployeeToEmployeeWithTaskCounterConverter(_employeesList));
                OnPropertyChanged("Employees");
            }
        }
        public ObservableCollection<EmployeeWithTaskCounter> EmployeesListWithTaskCounter
        {
            get { return _employeesListWithTaskCounter; }
            set
            {
                _employeesListWithTaskCounter = value;
                OnPropertyChanged("EmployeesListWithTaskCounter");
            }
        }
        #endregion

        public WorkersListModel()
        {
            connectionSQL = new ConnectionMSSQL();
            _tasksList = new List<Task>(connectionSQL.GetTasks());
            EmployeesList = new List<Employee>(connectionSQL.GetEmployees());

            AddEmployeeCMD = new RelayCommand(x => AddEmployee());
            RemoveEmployeeCMD = new RelayCommand(x => RemoveEmployee());
        }

        public void AddEmployee()
        {
            CreateNewEmployee ok = new CreateNewEmployee();
            ok.ShowDialog();

            EmployeesList = new List<Employee>(connectionSQL.GetEmployees());
        }

        public void RemoveEmployee()
        {
            connectionSQL.DeleteEmployee(SelectedEmployee.Id);

            EmployeesList = new List<Employee>(connectionSQL.GetEmployees());
        }

        private List<EmployeeWithTaskCounter> EmployeeToEmployeeWithTaskCounterConverter(List<Employee> employees)
        {
            List<EmployeeWithTaskCounter> result = new List<EmployeeWithTaskCounter>();

            foreach (var e in employees)
            {
                result.Add(new EmployeeWithTaskCounter() { Id = e.Id, EmployeeName = e.EmployeeName, TaskCounter = GetNumberOfTasks(e.Id) });
            }
            return result;
        }

        private int GetNumberOfTasks(int Id)
        {
            var result = (from t in _tasksList
                         join e in EmployeesList on t.EmployeeId equals e.Id
                         where e.Id == Id
                         select new { e.Id }).Count();

            return result;
        }
    }
}
