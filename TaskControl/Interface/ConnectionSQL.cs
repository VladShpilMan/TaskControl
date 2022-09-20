using System.Collections.Generic;
using TaskControl.Model;

namespace TaskControl.Interface
{
    public interface ConnectionSQL
    {
        List<Employee> GetEmployees();
        void DeleteEmployee(int Id);
        void PushEmployeeToDB(Employee employee);
        List<Task> GetTasks();
        void DeleteTask();
        void PushTaskToDB(Task task);
        List<Category> GetCategory();
    }
}
