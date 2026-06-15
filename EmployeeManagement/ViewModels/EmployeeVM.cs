using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100,MinimumLength = 3,ErrorMessage = "Full Name must be between 3 and 100 characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile Number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Job Title is required.")]
        [StringLength(50,ErrorMessage = "Job Title cannot exceed 50 characters.")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Hire Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please select a department.")]
        [Range(1, int.MaxValue,ErrorMessage = "Please select a valid department.")]
        public int DepartmentId { get; set; }
    }
}
