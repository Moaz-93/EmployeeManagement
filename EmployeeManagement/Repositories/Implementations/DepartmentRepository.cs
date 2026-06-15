using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetAll()
        {
            return _context.Departments
                           .AsNoTracking()
                           .ToList();
        }
        public Department GetById(int id)
        {
            return _context.Departments
                           .FirstOrDefault(d => d.Id == id);
        }
        public Department GetByName(string name)
        {
            return _context.Departments
                           .FirstOrDefault(d => d.Name == name);
        }
        public void Add(Department department)
        {
            _context.Departments.Add(department);
        }
        public void Update(Department department)
        {
            _context.Departments.Update(department);
        }
        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
        }
        public bool Exists(int id)
        {
            return _context.Departments.Any(d => d.Id == id);
        }
        public bool HasEmployees(int departmentId)
        {
            return _context.Employees
                           .Any(e => e.DepartmentId == departmentId);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
