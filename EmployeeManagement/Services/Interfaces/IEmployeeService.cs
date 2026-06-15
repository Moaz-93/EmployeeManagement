using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        IEnumerable<Employee> Search(string term);
    }
}
