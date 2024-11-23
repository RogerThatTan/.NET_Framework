using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRPManagement.EF;

namespace TRPManagement.Validation
{
    public class ChannelAnnotation
    {
        public class EstablishedYearAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                int year = Convert.ToInt32(value);

                if (value != null)
                {
                    if (year < 1900)
                    {
                        return new ValidationResult("Established year must be between 1900 and current year");
                    }
                    else if (year > DateTime.Now.Year)
                    {
                        return new ValidationResult("Established year cannot be future");
                    }
                }
                return ValidationResult.Success;
            }
        }

        


    }
}