using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository (ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees
                           .Include(e => e.Department)
                           .ToList();
        }
        public Employee GetById(int id)
        {
            return _context.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
        public IEnumerable<Employee> Search(string term)
        {
            term = term.Trim();
            return _context.Employees
                .Include(e => e.Department)
                .Where(e =>
                    e.FullName.Contains(term) ||
                    e.Department.Name.Contains(term))
                .ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
