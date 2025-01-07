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
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(x => x.custId);
            builder.Property(x => x.custPhone).IsRequired();
            builder.Property(x => x.custName).IsRequired();
            builder.Property(x => x.custAddress).IsRequired();
            builder.Property(x => x.custEmail).IsRequired();
        }

    }

}
