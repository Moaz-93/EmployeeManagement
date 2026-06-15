using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _repo.GetAll();
        }
        public Employee GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Create(Employee employee)
        {
            _repo.Add(employee);
            _repo.Save();
        }
        public void Update(Employee employee)
        {
            _repo.Update(employee);
            _repo.Save();
        }
        public void Delete(int id)
        {
            var emp = _repo.GetById(id);
            if (emp != null)
            {
                _repo.Delete(emp);
                _repo.Save();
            }
        }
        public IEnumerable<Employee> Search(string term)
        {
            return _repo.Search(term);
        }
    }
}
