using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormValidation.Models
{
    public class Student
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z.-]+$", ErrorMessage = "Name must contain only alphabets, spaces, (.), and (-)")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Id must follow XX-XXXXX-X where X is number")]
        public string Id { get; set; }

        [Required]
        [CustomDob(20)]
        public string Dob { get; set; }

        [Required]
        [CustomEmail("iid")]
        public string Email { get; set; }



    }
}