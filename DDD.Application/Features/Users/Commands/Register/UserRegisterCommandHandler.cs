
using AutoMapper;
using DDD.Application.Contracts.Persistence.Repository;
using DDD.Application.Contracts.Services;
using DDD.Application.Exceptions;
using DDD.Domain.Models.User.Aggregate;
using FluentValidation;
using MediatR;

namespace DDD.Application.Features.Users.Commands.Register;

public class UserRegisterCommandHandler:IRequestHandler<UserRegisterCommand,UserRegisterDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UserRegisterCommand> _validator;
    private readonly IUnitWork _unitWork;

    public UserRegisterCommandHandler(IUserRepository userRepository,
        IMapper mapper,
        IValidator<UserRegisterCommand> validator,
        IUnitWork unitWork)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = validator;
        _unitWork = unitWork;
    }
    public async Task<UserRegisterDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        var result =await _validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
            throw new BadRequestException(result.ToString()!);
        
        var newUser = User.Create(request.Name, request.Password, request.Email);
        await _userRepository.Add(newUser);
        await _unitWork.SaveChanges();
        return _mapper.Map<UserRegisterDto>(newUser);
    }
}