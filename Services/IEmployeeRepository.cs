using AgriSoft.DTO;
using AgriSoft.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace AgriSoft.Services
{
    public interface IEmployeeRepository
    {
        Task SaveBulk<T>(IEnumerable<T> elements) where T : class;
        Task UpdateBulk<T>(IEnumerable<T> elements) where T : class;
        Task RemoveBulk<T>(IEnumerable<T> elements) where T : class;
        Task Save<T>(T element) where T : class;
        Task Remove<T>(T element) where T : class;
        Task Update<T>(T element) where T : class; 
        Task<List<Employee>> GetEmployees();
        Task<Employee> AddEmployee(Employee employee);
        Task RemoveEmployee(int employeeId);
        Task RemoveTask(int taskId);
        Task UpdateEmployee(Employee employee);
        Task<List<Models.Task>> GetTasks();
        Task SaveEmployeeTask(AgriSoft.Models.Task task);
        Task SaveEmployee(Employee employee);
        Task<List<Models.Task>> GetEmployeeTasks(int employeeId);
        Task<bool> GetLogin(EmployeeLogin login);
    }
}
