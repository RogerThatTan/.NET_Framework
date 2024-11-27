using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRPManagement.DTOs
{
    public class LoginDTO
    {
        public int Role { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}