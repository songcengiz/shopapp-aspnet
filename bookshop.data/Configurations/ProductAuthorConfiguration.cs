using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookshop.data.Configurations
{
     public class ProductAuthorConfiguration : IEntityTypeConfiguration<ProductAuthor>
    {
        public void Configure(EntityTypeBuilder<ProductAuthor> builder)
        {
            builder.HasKey(p => new { p.AuthorId, p.ProductId });
            
        }
    }
}