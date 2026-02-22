using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid CUSER_ID { get; set; }
        public string CUSER_NAME { get; private set; } = string.Empty;
        public string CEMAIL { get; private set; } = string.Empty;
        public string CPASSWORD { get; private set; } = string.Empty;
        public UserRole CUSER_ROLE { get; private set; }

        public User(string pcName, string pcEmail, string pcPassword, UserRole pcRole)
        { 
            CUSER_ID = Guid.NewGuid();
            CUSER_NAME = pcName;
            CPASSWORD = pcPassword;
            CUSER_ROLE = pcRole;
        }

        public void ValidatePassword(string pcPassword, SubscriptionPlan pcPlan)
        {
            if (pcPlan == SubscriptionPlan.Basic && pcPassword.Length < 8)
            {
                throw new Exception("Password must be at least 8 characters for Basic plan");
            }
            else if (pcPlan == SubscriptionPlan.Premium && pcPassword.Length < 12)
            {
                throw new Exception("Password must be at least 12 characters for Premium plan");
            }
        }

    }
}
