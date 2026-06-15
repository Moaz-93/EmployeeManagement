using EmployeeManagement.Models;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index(string searchTerm)
        {
            var employees = string.IsNullOrEmpty(searchTerm)? _employeeService.GetAll(): _employeeService.Search(searchTerm);
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _departmentService.GetAll();
                return View(vm);
            }
            Employee employee = new Employee
            {
                FullName = vm.FullName,
                Email = vm.Email,
                MobileNumber = vm.MobileNumber,
                JobTitle = vm.JobTitle,
                HireDate = vm.HireDate,
                IsActive = vm.IsActive,
                DepartmentId = vm.DepartmentId
            };
            _employeeService.Create(employee);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();
            ViewBag.Departments = _departmentService.GetAll();
            EmployeeVM vm = new EmployeeVM
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                MobileNumber = employee.MobileNumber,
                JobTitle = employee.JobTitle,
                HireDate = employee.HireDate,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _departmentService.GetAll();
                return View(vm);
            }
            var employee = _employeeService.GetById(vm.Id);
            if (employee == null)
                return NotFound();
            employee.FullName = vm.FullName;
            employee.Email = vm.Email;
            employee.MobileNumber = vm.MobileNumber;
            employee.JobTitle = vm.JobTitle;
            employee.HireDate = vm.HireDate;
            employee.IsActive = vm.IsActive;
            employee.DepartmentId = vm.DepartmentId;
            _employeeService.Update(employee);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
