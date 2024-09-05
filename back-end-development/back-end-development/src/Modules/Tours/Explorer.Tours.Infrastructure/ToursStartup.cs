using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.API.Public.Tourist;
using Explorer.Tours.API.Public.Club;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Mappers;
using Explorer.Tours.Core.UseCases;
using Explorer.Tours.Core.UseCases.Administration;
using Explorer.Tours.Core.UseCases.Tourist;
using Explorer.Tours.Core.UseCases.Club;
using Explorer.Tours.Infrastructure.Database;
using Explorer.Tours.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Explorer.Tours.API.Public.Author;
using Explorer.Tours.Core.UseCases.Author;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.API.Public.TourExecution;
using Explorer.Tours.Core.UseCases.Execution;
using Explorer.Encounters.API.Internal;
using Explorer.Encounters.Core.UseCases.Administration;
using Explorer.Encounters.Core.UseCases.Tourist.Execution;
using Explorer.Payments.API.Internal;
using Explorer.Payments.Core.UseCases;
using Explorer.Tours.API.Public.Statistic;
using Explorer.Tours.Core.UseCases.Statistic;
using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.Core.UseCases;


namespace Explorer.Tours.Infrastructure;

public static class ToursStartup
{
    public static IServiceCollection ConfigureToursModule(this IServiceCollection services)
    {
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(ToursProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<ITourPreferencesService, TourPreferencesService>();
        services.AddScoped<ITourRatingService, TourRatingService>();
        services.AddScoped<ITourReviewService, TourReviewService>();
        services.AddScoped<IDestinationService, DestinationService>();
        services.AddScoped<ITouristClubService, TouristClubService>();
        services.AddScoped<ITouristEquipmentService, TouristEquipmentService>();
        services.AddScoped<ITourService, TourService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<IReportCommentService, ReportCommentService>();
        services.AddScoped<ICheckpointService, CheckpointService>();
        services.AddScoped<ITourExecutionService, TourExecutionService>();
        services.AddScoped<IDestinationRequestService, DestinationRequestService>();
        services.AddScoped<ITourExecutionStatsService, TourExecutionStatsService>();
        services.AddScoped<ISaleService, SaleService>();
        services.AddScoped<ITourSaleConnectionService, TourSaleConnectionService>();
        services.AddScoped<ICouponService, CouponService>();
        services.AddScoped<ICompositeTourService, CompositeTourService>();
        services.AddScoped<IAuthorEquipmnetService, AuthorEquipmentService>();
        services.AddScoped<IInternalEncounterService, EncountersService>();
        services.AddScoped<IInternalEncounterExecutionService, EncounterExecutionService>();
        services.AddScoped<IQuestionnaireService, QuestionnaireService>();
        services.AddScoped<IAnswerDatesService, AnswerDatesService>();
        services.AddScoped<IActiveToursRecommender, ActiveToursRecommender>();
        services.AddScoped<IInternalPersonService, PersonService>();
        services.AddScoped<IEmergencyNumbersService, EmergencyNumbersService>();
        services.AddHttpClient<IEmergencyNumbersService, EmergencyNumbersService>();
        services.AddScoped<ITourStatisticService, TourStatisticService>();
        services.AddScoped<IInternalOrderService, OrderService>();
        services.AddScoped<IInternalShoppingCartService, ShoppingCartService>();
        services.AddScoped<IInternalShoppingSession, ShoppingSession>();
    }


    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<Equipment>), typeof(CrudDatabaseRepository<Equipment, ToursContext>));

        services.AddScoped(typeof(ICrudRepository<TourPreferences>), typeof(CrudDatabaseRepository<TourPreferences, ToursContext>));
        

        services.AddScoped<ITouristEquipmentRepository, TouristEquipmentDatabaseRepository>();
        services.AddScoped(typeof(ICrudRepository<TourReview>), typeof(CrudDatabaseRepository<TourReview, ToursContext>));
        services.AddScoped<ITouristClubRepository, TouristClubRepository>();
        services.AddScoped(typeof(IDestinationRepository), typeof(DestinationRepository));
        services.AddScoped(typeof(ICrudRepository<TouristClub>), typeof(CrudDatabaseRepository<TouristClub, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<Tour>), typeof(CrudDatabaseRepository<Tour, ToursContext>));
        services.AddScoped(typeof(ICrudRepository<CompositeTour>), typeof(CrudDatabaseRepository<CompositeTour, ToursContext>));
        services.AddScoped(typeof(ITourRepository), typeof(TourRepository));
        services.AddScoped(typeof(ICrudRepository<Report>), typeof(CrudDatabaseRepository<Report, ToursContext>));
        services.AddScoped(typeof(IReportRepository), typeof(ReportRepository));
        services.AddScoped(typeof(ICrudRepository<ReportComment>), typeof(CrudDatabaseRepository<ReportComment, ToursContext>));
        services.AddScoped(typeof(IReportCommentRepository), typeof(ReportCommentRepository));
        services.AddScoped(typeof(IAuthorEquipmentRepository), typeof(AuthorEquipmentRepository));
        services.AddScoped<ICheckpointRepository, CheckpointDatabaseRepository>();
        services.AddScoped<ITourCouponRepository, TourCouponRepository>();
        services.AddScoped<ITourExecutionRepository, TourExecutionRepository>();
        services.AddScoped<IDestinationRequestDatabaseRepository, DestinationRequestDatabaseRepository>();
        services.AddScoped<ITourExecutionStatsRepository, TourExecutionStatsRepository>();
        services.AddScoped(typeof(ICrudRepository<TourPreferences>), typeof(CrudDatabaseRepository<TourPreferences, ToursContext>));
        services.AddScoped(typeof(ITourPreferencesRepository), typeof(TourPreferencesRepository));
        services.AddScoped(typeof(ITourRatingRepository), typeof(TourRatingRepository));
        services.AddScoped(typeof(ICrudRepository<Sale>), typeof(CrudDatabaseRepository<Sale, ToursContext>));
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped(typeof(ICrudRepository<TourSaleConnection>), typeof(CrudDatabaseRepository<TourSaleConnection, ToursContext>));
        services.AddScoped<ITourSaleConnectionRepository, TourSaleConnectionRepository>();
        services.AddScoped(typeof(ICompositeTourRepository), typeof(CompositeTourRepository));
        services.AddScoped(typeof(IQuestionnaireRepository), typeof(QuestionnaireRepository));
        services.AddScoped(typeof(ICrudRepository<Questionnaire>),typeof(CrudDatabaseRepository<Questionnaire,ToursContext>));
        services.AddScoped(typeof(ICrudRepository<AnswerDates>), typeof(CrudDatabaseRepository<AnswerDates, ToursContext>));
        services.AddScoped(typeof(IAnswerDateRepository), typeof(AnswerDatesRepository));

        services.AddDbContext<ToursContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("tours"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "tours")));
    }
}
