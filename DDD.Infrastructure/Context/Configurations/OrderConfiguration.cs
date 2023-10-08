using DDD.Domain.Models.Order.Aggregate;
using DDD.Domain.Models.Order.Enums;
using DDD.Domain.Models.Order.ValueObjects;
using DDD.Domain.Models.Product.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Context.Configurations;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.OrderId);

        builder.Property(o => o.OrderId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OrderId(value));

        builder.Property(o => o.Price)
            .HasConversion(price => price.Value, value => new OrderPrice(value));

        builder.Property(o => o.OrderStatus)
            .HasDefaultValue(OrderStatus.Placed);

        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .IsRequired();

        builder.HasMany(o => o.LineItems)
            .WithOne(l => l.Order)
            .HasForeignKey(o=>o.OrderId)
            .IsRequired();
        
        builder.Navigation(o=>o.LineItems).Metadata.SetField("_items");
    }
}