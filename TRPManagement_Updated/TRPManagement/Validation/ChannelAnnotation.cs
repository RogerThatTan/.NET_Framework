using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRPManagement.Validation
{
    public class ChannelAnnotation
    {
        public class EstablishYearAttribute : ValidationAttribute
        {

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                int year = Convert.ToInt32(value);
                if (value != null)
                {
                    if (year < 1900 || year > DateTime.Now.Year)
                    {
                        return new ValidationResult("Established year must be between 1900 and current year.");
                    }
                }
                return ValidationResult.Success;

            }
        }
    }
}