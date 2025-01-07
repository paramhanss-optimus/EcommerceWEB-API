using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Persistance.Configurations
{
    public  class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(x => x.orderId);
            builder.Property(x => x.orderDate).IsRequired();
            builder.Property(x => x.orderStatus).IsRequired();
            
            //builder.HasOne(x => x.Customer)
            //    .WithMany(x => x.Orders)
            //    .HasForeignKey(x => x.custId);




        }
    }
}
