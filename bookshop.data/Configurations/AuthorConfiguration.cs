using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookshop.data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(m=>m.AuthorId);
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(100);
           
        }
    }
}