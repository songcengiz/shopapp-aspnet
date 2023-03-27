using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookshop.data.Configurations
{
   public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(m=>m.PublisherId);
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m=>m.Phone).HasMaxLength(14);
           
        }
    }
}