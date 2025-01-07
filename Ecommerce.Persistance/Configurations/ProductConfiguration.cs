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
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.productId);
            builder.Property(p => p.productName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.productPrice).IsRequired();
            builder.Property(p => p.productDescription).HasMaxLength(500);
            builder.Property(p => p.productStock).IsRequired();

            builder.HasMany(p => p.OrderDetails)
                .WithMany(o => o.Products);
        }
    }
}
