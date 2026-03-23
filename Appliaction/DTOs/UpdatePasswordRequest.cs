using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdatePasswordRequest
    {
        public string CEMAIL { get; set; } = string.Empty;
        public string CCURRENT_PASSWORD { get; set; } = string.Empty;
        public string CNEW_PASSWORD { get; set; } = string.Empty;
        public string CCONFIRM_NEW_PASSWORD { get; set; } = string.Empty;

    }
}
