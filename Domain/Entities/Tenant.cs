using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Tenant
    {
        public Guid CTENANT_ID { get; set; }
        public string CTENANT_NAME { get; set; } = string.Empty;
        public SubscriptionPlan CSUBSCRIPTION_PLAN { get; private set; }
        public DateTime? DCREATED_DATE { get; set; }

        private Tenant() { }
        public Tenant(string pcName, SubscriptionPlan pcPlan)
        { 
            CTENANT_ID = Guid.NewGuid();
            CTENANT_NAME = pcName;
            CSUBSCRIPTION_PLAN = pcPlan;
            DCREATED_DATE = DateTime.Now;
        }
    }
}
