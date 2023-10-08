namespace DDD.Domain.Models.User.ValueObjects;

public record UserId
{
    public Guid Value { get; private set; }

    public UserId()
    {
        Value = Guid.NewGuid();
    }
    public UserId(Guid value)
    {
        Value = value;
    }
}