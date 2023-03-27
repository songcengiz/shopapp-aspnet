using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookshop.data.Configurations
{
    public class ProductTranslatorConfiguration : IEntityTypeConfiguration<ProductTranslator>
    {
        public void Configure(EntityTypeBuilder<ProductTranslator> builder)
        {
            builder.HasKey(t => new { t.TranslatorId, t.ProductId });
            
        }
    }
}