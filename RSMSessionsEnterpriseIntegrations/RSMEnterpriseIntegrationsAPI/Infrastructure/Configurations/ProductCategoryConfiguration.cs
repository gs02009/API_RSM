using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            // Nombre de la tabla y esquema
            builder.ToTable(nameof(ProductCategory), "Production");

            // Definición de la clave primaria
            builder.HasKey(e => e.ProductCategoryID);
            
            // Mapeo de propiedades a columnas
            builder.Property(e => e.ProductCategoryID).HasColumnName("ProductCategoryID");
            builder.Property(e => e.Name).IsRequired().HasColumnName("Name");
            builder.Property(e => e.rowguid).HasColumnName("rowguid");
            builder.Property(e => e.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
