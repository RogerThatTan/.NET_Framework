using MidExam.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MidExam.Validation.CustomValidation;

namespace MidExam.DTOs
{
    public class BillDTO
    {
        public int BillId { get; set; }

        [Required(ErrorMessage = "Amount is Required")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Year  is Required")]
        [EstablishYear]
        public System.DateTime Date { get; set; }
        [Required(ErrorMessage = "Status  is Required")]
        public int Status { get; set; }
    }
}