using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Mappers;
using Explorer.Encounters.Core.UseCases.Administration;
using Explorer.Encounters.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Explorer.Encounters.Core.UseCases.Tourist.Execution;
using Explorer.Encounters.Core.Domain.NewFolder;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Explorer.Encounters.Infrastructure.Database.Repositories;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;

namespace Explorer.Encounters.Infrastructure
{
    public static class EncountersStartup
    {
        public static IServiceCollection ConfigureEncountersModule(this IServiceCollection services)
        {
            // Registers all profiles since it works on the assembly
            services.AddAutoMapper(typeof(EncounterProfile).Assembly);
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IEncounterService, EncountersService>();
            services.AddScoped<IEncounterExecutionService, EncounterExecutionService>();
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(IEncountersRepository), typeof(EncountersRepository));
            services.AddScoped(typeof(IEncounterExecutionRepository), typeof(EncounterExecutionRepository));

            services.AddDbContext<EncountersContext>(opt =>
                opt.UseNpgsql(DbConnectionStringBuilder.Build("encounters"),
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "encounters")));
        }
    }
}
