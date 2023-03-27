using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookshop.data.Configurations
{
    public class ProductPublisherConfiguration : IEntityTypeConfiguration<ProductPublisher>
    {
        public void Configure(EntityTypeBuilder<ProductPublisher> builder)
        {
            builder.HasKey(p => new { p.PublisherId, p.ProductId });
            
        }
    }
}