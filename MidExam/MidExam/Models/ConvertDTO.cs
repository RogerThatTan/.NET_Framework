using MidExam.DTOs;
using MidExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidExam.Models
{
    public class ConvertDTO
    {
        public static BillDTO Convert(Bill bill)
        {
            return new BillDTO
            {

                BillId = bill.BillId,
                Amount = bill.Amount,
                Date = bill.Date,
                Status = bill.Status,
            };

        }

        public static Bill Convert(BillDTO billDTO)
        {
            return new Bill
            {
                BillId = billDTO.BillId,
                Amount = billDTO.Amount,
                Date = billDTO.Date,
                Status = billDTO.Status,
            };
        }

        public static List<BillDTO>Convert(List<Bill> bills)
        {
            var list = new List<BillDTO>();
            foreach (var bill in bills)
            {
                list.Add(Convert(bill));
            }
            return list;
        }

    }
}