using EmployeeManagement.Models;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }
        public IActionResult Details(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            Department department = new Department
            {
                Name = vm.Name
            };
            _departmentService.Create(department);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
                return NotFound();
            DepartmentVM vm = new DepartmentVM
            {
                Id = department.Id,
                Name = department.Name
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            var department = _departmentService.GetById(vm.Id);
            if (department == null)
                return NotFound();
            department.Name = vm.Name;
            _departmentService.Update(department);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_departmentService.HasEmployees(id))
            {
                TempData["Error"] ="Cannot delete department because it contains employees.";
                return RedirectToAction(nameof(Index));
            }
            _departmentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
