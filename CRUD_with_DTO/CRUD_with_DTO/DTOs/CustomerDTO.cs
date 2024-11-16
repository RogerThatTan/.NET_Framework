using CRUD_with_DTO.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_with_DTO.DTOs
{
    public class CustomerDTO : Controller
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits.")]
        public string Phone { get; set; }

        [MaxLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date joined is required.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(DateValidator), "ValidateDateJoined")]
        public System.DateTime DateJoined { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCustomer> ProductCustomers { get; set; }
    }

    public class DateValidator
    {
        public static ValidationResult ValidateDateJoined(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Now)
            {
                return new ValidationResult("Date joined cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}