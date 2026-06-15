using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        IEnumerable<Employee> Search(string term);
        void Save();
    }
}
