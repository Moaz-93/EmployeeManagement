using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        void Create(Department department);
        void Update(Department department);
        void Delete(int id);
        bool Exists(int id);
        bool HasEmployees(int departmentId);
    }
}
