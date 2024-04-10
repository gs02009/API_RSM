using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "Production");

            builder.HasKey(p => p.ProductID);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.ProductNumber)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.MakeFlag)
                .IsRequired();

            builder.Property(p => p.FinishedGoodsFlag)
                .IsRequired();

            builder.Property(p => p.Color)
                .HasMaxLength(15);

            builder.Property(p => p.SafetyStockLevel)
                .IsRequired();

            builder.Property(p => p.ReorderPoint)
                .IsRequired();

            builder.Property(p => p.StandardCost)
                .HasColumnType("money")
                .IsRequired();

            builder.Property(p => p.ListPrice)
                .HasColumnType("money")
                .IsRequired();

            builder.Property(p => p.Size)
                .HasMaxLength(5);

            builder.Property(p => p.SizeUnitMeasureCode)
                .HasMaxLength(3);

            builder.Property(p => p.WeightUnitMeasureCode)
                .HasMaxLength(3);

            builder.Property(p => p.Weight)
                .HasColumnType("decimal(8,2)");

            builder.Property(p => p.DaysToManufacture)
                .IsRequired();

            builder.Property(p => p.ProductLine)
                .HasMaxLength(2);

            builder.Property(p => p.Class)
                .HasMaxLength(2);

            builder.Property(p => p.Style)
                .HasMaxLength(2);

            builder.Property(p => p.ProductSubcategoryID);

            builder.Property(p => p.ProductModelID);

            builder.Property(p => p.SellStartDate)
                .IsRequired();

            builder.Property(p => p.SellEndDate);

            builder.Property(p => p.DiscontinuedDate);

            builder.Property(p => p.rowguid)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(p => p.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();
        }
    }
}
