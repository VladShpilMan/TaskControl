using System;
using System.Collections.Generic;
using System.Linq;
using TaskControl.Interface;
using TaskControl.Model;

namespace TaskControl.DbConnections
{
    public class ConnectionMSSQL : ConnectionSQL
    {
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            using (var context = new MyDbContext())
            {
                employees = context.Employees.ToList();
            }

            return employees;
        }
        public List<Category> GetCategory()
        {
            var category = new List<Category>();
            using (var context = new MyDbContext())
            {
                category = context.Categories.ToList();
            }

            return category;
        }
        public List<Task> GetTasks()
        {
            var tasks = new List<Task>();
            using (var context = new MyDbContext())
            {
                tasks = context.Tasks.ToList();
            }

            return tasks;
        }

        public void PushEmployeeToDB(Employee employee)
        {
            using (var context = new MyDbContext())
            {
                var employe = new Employee()
                {
                    EmployeeName = employee.EmployeeName
                };

                context.Employees.Add(employe);
                context.SaveChanges();
            }
        }

        public void PushTaskToDB(Task task)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int Id)
        {
            using (var context = new MyDbContext())
            {
                var employee = context.Employees.Where(x => x.Id == Id).First();

                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }

        public void DeleteTask()
        {
            throw new NotImplementedException();
        }
    }
}
