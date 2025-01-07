using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class OrderEntity
    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public string orderStatus { get; set; }


        public int? custId { get; set; }
        public virtual CustomerEntity Customer { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
