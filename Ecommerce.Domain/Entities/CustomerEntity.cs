using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class CustomerEntity
    {
        public int custId { get; set; }
        public string custName { get; set; }
        public string custEmail { get; set; }
        public string custPhone { get; set; }
        public string custAddress { get; set; }
        public string custCity { get; set; }

        //public virtual ICollection<OrderEntity> Orders { get; set; }

    }
}
