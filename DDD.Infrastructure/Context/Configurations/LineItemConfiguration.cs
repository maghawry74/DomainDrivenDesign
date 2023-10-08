using DDD.Domain.Models.Order.Entites;
using DDD.Domain.Models.Order.ValueObjects;
using DDD.Domain.Models.Product.Aggregate;
using DDD.Domain.Models.Product.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Context.Configurations;

public class LineItemConfiguration:IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.HasKey(l=>new {l.ProductId,l.OrderId});

        builder.Property(l => l.ProductId)
            .HasConversion(id => id.Value, value => new ProductId(value));
        
        builder.Property(l => l.OrderId)
            .HasConversion(id => id.Value, value => new OrderId(value));

        builder.Property(l => l.Count)
            .HasConversion(count => count.Value, value => new LineItemProductCount(value));
        
        builder.HasOne(l => l.Order)
            .WithMany(o => o.LineItems)
            .IsRequired();

        builder.HasOne(l => l.Product)
            .WithMany()
            .HasForeignKey(l=>l.ProductId)
            .IsRequired();
    }
}