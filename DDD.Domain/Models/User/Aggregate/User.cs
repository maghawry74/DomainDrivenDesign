using DDD.Domain.Models.User.ValueObjects;

namespace DDD.Domain.Models.User.Aggregate;

public class User
{
     public UserId UserId { get; set; } = null!;
     public Name Name { get; set; } = null!;
     public Password Password { get; set; }= null!;
     public Email Email { get; set; }= null!;
     private List<Order.Aggregate.Order> _orders;
     public IReadOnlyList<Order.Aggregate.Order> Orders => _orders.AsReadOnly();
     private User()
     {
          
     }
     
     public static User Create(string name, string password, string email)
          => new User()
          {
               UserId = new UserId(),
               Name = new Name(name),
               Password = new Password(password),
               Email = new Email(email)
          };
}