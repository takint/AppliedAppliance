using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Infrastructure.Services;
using Infrastructure.Services.PandaDoc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("AppliedApplianceDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                    .EnableSensitiveDataLogging());
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            // Just for testing the using of repository.
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<ISchoolRequestRepository, SchoolRequestRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ICampusRepository, CampusRepository>();
            services.AddScoped<IProgramCategoryRepository, ProgramCategoryRepository>();
            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<ICampusProgramRepository, CampusProgramRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<ISchoolDocumentRepository, SchoolDocumentRepository>();
            services.AddScoped<IPandaDocTemplateRepository, PandaDocTemplateRepository>();

            // Identity for authentication
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.Cookie.Name = ".AspNetCore.Identity.Application";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 4;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            });

            // add pandadoc related services
            services.AddPandaDocService(configuration);

            return services;
        }

        private static IServiceCollection AddPandaDocService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<PandaDocServiceConfig>();
            services.Configure<PandaDocServiceConfig>(configuration.GetSection("PandaDocServiceConfig"));
            services.AddHttpClient<IPandaDocService, PandaDocService>()
                    .ConfigureHttpClient((serviceProvider, client) =>
                    {
                        var apiKey = serviceProvider.GetRequiredService<IOptions<PandaDocServiceConfig>>().Value.ApiKey;
                        client.DefaultRequestHeaders.Add("Authorization", apiKey);
                    });
            return services;
        }
    }
}
