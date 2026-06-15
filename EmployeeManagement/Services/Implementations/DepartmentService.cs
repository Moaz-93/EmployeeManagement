using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Department> GetAll()
        {
            return _repository.GetAll();
        }
        public Department GetById(int id)
        {
            return _repository.GetById(id);
        }
        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }
        public void Create(Department department)
        {
            _repository.Add(department);
            _repository.Save();
        }
        public void Update(Department department)
        {
            _repository.Update(department);
            _repository.Save();
        }
        public void Delete(int id)
        {
            var department = _repository.GetById(id);
            if (department != null)
            {
                _repository.Delete(department);
                _repository.Save();
            }
        }
        public bool HasEmployees(int departmentId)
        {
            return _repository.HasEmployees(departmentId);
        }
    }
}
