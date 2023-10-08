using DDD.Domain.Models.User.Aggregate;
using DDD.Domain.Models.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Context.Configurations;

public class UserConfigurations:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserId)
            .ValueGeneratedNever()
            .HasConversion(userId => userId.Value, id => new UserId(id));
        
        builder.Property(u => u.Email)
            .HasConversion(email => email.Value, e => new Email(e));
        
        builder.Property(u => u.Name)
            .HasConversion(name => name.Value, n => new Name(n));
        
        builder.Property(u => u.Password)
            .HasConversion(pass => pass.Value, p => new Password(p));

        builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .IsRequired();
    }
}