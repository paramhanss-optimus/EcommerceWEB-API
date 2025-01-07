using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ProductEntity
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public decimal productPrice { get; set; }
        public int productStock { get; set; }

        public virtual ICollection<OrderEntity> OrderDetails { get; set; }
    }
}
