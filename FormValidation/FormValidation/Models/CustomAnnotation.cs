using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormValidation.Models
{
    public class CustomDob : ValidationAttribute
    {
        private readonly int _dob;
        public CustomDob(int dob) : base("Age must be grater than 20")
        {
            _dob = dob;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {

                DateTime date;
                if (DateTime.TryParse(value.ToString(), out date))
                {
                    if (date.AddYears(_dob) > DateTime.Now)
                    {
                        var errorMessage = FormatErrorMessage(base.ErrorMessage);
                        return new ValidationResult(errorMessage);

                    }
                }

            }
            return ValidationResult.Success;
        }
    }

    public class CustomEmail : ValidationAttribute
    {
        private readonly string _iid;
        public CustomEmail(string iid) : base("Must be a valid email address")
        {
            _iid = iid;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                Student student = (Student)validationContext.ObjectInstance;
                string _iid = student.Id;
                string email = "";
                string value_email = value.ToString();
                int length = value_email.Length;

                for (int i = 0; i < length; i++)
                {
                    if (value_email[i] == '@')
                    {
                        break;
                    }
                    else
                    {
                        email += value_email[i];
                    }
                }
                if (email != _iid)
                {
                    var errorMessage = "Email does not match with student ID";
                    return new ValidationResult(errorMessage);
                }
                else
                {
                    var complete_email = _iid + "@student.aiub.edu";
                    if (complete_email != value_email)
                    {
                        var errorMessage = "Email must be in the format: XX-XXXXX-X@student.aiub.edu";
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }



        }