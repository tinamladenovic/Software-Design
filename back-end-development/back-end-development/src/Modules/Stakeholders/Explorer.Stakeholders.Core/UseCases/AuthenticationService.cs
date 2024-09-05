using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Internal;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IInternalShoppingCartService _shoppingCartService;
    private readonly IInternalWalletService _walletService;
    private readonly ICrudRepository<Person> _personRepository;
    


    public AuthenticationService(IUserRepository userRepository, IInternalWalletService walletService,IInternalShoppingCartService shoppingCartService, ICrudRepository<Person> personRepository, ITokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
        _personRepository = personRepository;
        _shoppingCartService = shoppingCartService;
        _walletService = walletService;
    }

    public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
    {
        var user = _userRepository.GetActiveByName(credentials.Username);
        if (user == null || credentials.Password != user.Password) return Result.Fail(FailureCode.NotFound);

        long personId;
        try
        {
            personId = _userRepository.GetPersonId(user.Id);
        }
        catch (KeyNotFoundException)
        {
            personId = 0;
        }
        return _tokenGenerator.GenerateAccessToken(user, personId);
    }

    public Result<AuthenticationTokensDto> RegisterTourist(AccountRegistrationDto account)
    {
        if(account.Role == UserRoleDto.Administrator) return Result.Fail(FailureCode.InvalidArgument);
        if(_userRepository.Exists(account.Username)) return Result.Fail(FailureCode.NonUniqueUsername);
        UserRole role = account.Role == UserRoleDto.Author ? UserRole.Author : UserRole.Tourist;
        
        try
        {
            var user = _userRepository.Create(new User(account.Username, account.Password, role, true));
            var person = _personRepository.Create(new Person(user.Id, account.Name, account.Surname, account.Email,"","","", 0, 0));
            var shoppingCart = _shoppingCartService.Create(user.Id);
            var wallet = _walletService.Create(user.Id);
            
            return _tokenGenerator.GenerateAccessToken(user, person.Id);
        }
        catch (ArgumentException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            // There is a subtle issue here. Can you find it?
        }
    }
}