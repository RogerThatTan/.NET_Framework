using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PostDTO
    {
        //id te required dibo na karon id generate hobe database theke
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        //foriegn key
        [Required]
        public string PostedBy { get; set; }
        [Required]
        public DateTime Date { get; set; }
       
    }
}
