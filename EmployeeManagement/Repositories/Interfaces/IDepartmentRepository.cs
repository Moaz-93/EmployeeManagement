using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        Department GetByName(string name);
        void Add(Department department);
        void Update(Department department);
        void Delete(Department department);
        bool Exists(int id);
        bool HasEmployees(int departmentId);
        void Save();
    }
}
