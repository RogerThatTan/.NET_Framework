using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidExam.Validation
{
    public class CustomValidation
    {
        public class EstablishYearAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime date)
                {
                    if (date > DateTime.Now)
                    {
                        return new ValidationResult("Date cannot be in the future.");
                    }

                    return ValidationResult.Success;
                }

                return new ValidationResult("Invalid date format.");
            }
        }
    }
}
