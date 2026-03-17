using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LoginRequest
    {
        public string CEMAIL { get; set; } = string.Empty;
        public string CPASSWORD { get; set; } = string.Empty;
    }
}
