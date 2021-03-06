using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Price).HasPrecision(10, 2);
            
            builder.HasOne(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CategoryId);
            //.OnDelete(DeleteBehavior.Restrict);//Para evitar que os registros da propriedade
            //filha sejam removidas automaticamente em cascata caso uma propriedade pai
            //seja excluída.

        }
    }
}
