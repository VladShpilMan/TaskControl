using System.Windows.Controls;
using TaskControl.Model;
using TaskControl.ViewModel;

namespace TaskControl.View
{
    /// <summary>
    /// Логика взаимодействия для TasksList.xaml
    /// </summary>
    public partial class TasksList : UserControl
    {
        public TasksList(ref EmployeeWithTaskCounter employee)
        {
            DataContext = new TasksListModel(ref employee);
            InitializeComponent();
        }
    }
}
