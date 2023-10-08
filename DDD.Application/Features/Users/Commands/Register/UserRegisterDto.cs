namespace DDD.Application.Features.Users.Commands.Register;

public class UserRegisterDto
{
    public Guid Id { set; get; }
    public string Email{ set; get; }
    public string Name{ set; get; }
    public string Password{ set; get; }
};
