using DDD.Domain.Models.Product.Aggregate;
using DDD.Domain.Models.Product.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Context.Configurations;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);

        builder.Property(o => o.ProductId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProductId(value));

        builder.Property(p => p.Name)
            .HasConversion(name => name.Value, value => new ProductName(value));

        builder.Property(p => p.Price)
            .HasConversion(price => price.Value, value => new Price(value));

        builder.Property(p => p.Image)
            .HasConversion(image => image.Value, value => new Image(value));

        builder.Property(p => p.InventoryCount)
            .HasConversion(count => count.Value, value => new InventoryCount(value));
    }
}