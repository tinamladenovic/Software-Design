using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.API.Public.Administration;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Stakeholders.Core.Mappers;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Stakeholders.Core.UseCases.Administration;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Stakeholders.Infrastructure.Database;
using Explorer.Stakeholders.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Explorer.Stakeholders.Infrastructure;

public static class StakeholdersStartup
{
    public static IServiceCollection ConfigureStakeholdersModule(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(StakeholderProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ITokenGenerator, JwtGenerator>();
        services.AddScoped<IRequestToJoinClubService, RequestToJoinClubService>();
        services.AddScoped<IClubRequestService, ClubRequestService>();
        services.AddScoped<IClubUsersService, ClubUsersService>();
        services.AddScoped<IApplicationRateService, ApplicationRateService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ITouristNoteService, TouristNoteService>();
        services.AddScoped<IUserManagmentService, UserManagmentService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITouristNoteService, TouristNoteService>();
        services.AddScoped<IFollowersService, FollowersService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IInternalFollowersService, FollowersService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<Person>), typeof(CrudDatabaseRepository<Person, StakeholdersContext>));
        services.AddScoped(typeof(ICrudRepository<ApplicationRate>), typeof(CrudDatabaseRepository<ApplicationRate, StakeholdersContext>));
        services.AddScoped<IUserRepository, UserDatabaseRepository>();
        services.AddScoped(typeof(ICrudRepository<RequestToJoinClub>), typeof(CrudDatabaseRepository<RequestToJoinClub, StakeholdersContext>));
        services.AddScoped(typeof(ICrudRepository<ClubRequest>), typeof(CrudDatabaseRepository<ClubRequest, StakeholdersContext>));
        services.AddScoped(typeof(ICrudRepository<ClubUsers>), typeof(CrudDatabaseRepository<ClubUsers, StakeholdersContext>));
        services.AddScoped<IClubUsersRepository, ClubUsersRepository>();
        services.AddScoped<IApplicationRateRepository, ApplicationRateRepository>();
        services.AddScoped(typeof(ICrudRepository<TouristNote>), typeof(CrudDatabaseRepository<TouristNote, StakeholdersContext>));
        services.AddScoped(typeof(ITouristNotesRepository), typeof(TouristNotesRepository));
        services.AddScoped(typeof(ICrudRepository<User>), typeof(CrudDatabaseRepository<User, StakeholdersContext>));
        services.AddScoped<IClubRequestRepository, ClubRequestRepository>();
        services.AddScoped(typeof(ITouristNotesRepository), typeof(TouristNotesRepository));
        services.AddScoped(typeof(ICrudRepository<Followers>), typeof(CrudDatabaseRepository<Followers, StakeholdersContext>));
        services.AddScoped<IFollowersRepository, FollowersRepository>();
        services.AddScoped(typeof(ICrudRepository<Notification>), typeof(CrudDatabaseRepository<Notification, StakeholdersContext>));

        services.AddDbContext<StakeholdersContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("stakeholders"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "stakeholders")));
    }
}