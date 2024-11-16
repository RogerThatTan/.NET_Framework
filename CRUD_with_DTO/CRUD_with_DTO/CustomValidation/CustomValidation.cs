using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_with_DTO.CustomValidation
{
    public class CustomValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);
            if (date > DateTime.Now)
            {
                return new ValidationResult("Join date cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}