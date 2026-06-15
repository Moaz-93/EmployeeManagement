using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(30,MinimumLength = 2,ErrorMessage = "Department Name must be between 2 and 30 characters.")]
        public string Name { get; set; }
    }
}
