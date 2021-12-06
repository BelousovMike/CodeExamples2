using APS.Core.Catalog.DbSeeders;
using APS.Core.Catalog.Models;
using APS.Core.Catalogs.DbSeeders;
using APS.Core.Document;
using APS.Core.Identity;
using APS.Core.LoadExcelData;
using APS.Domain.Interfaces;
using APS.EFDataAccessLibrary;
using Core.Authorization;
using DinkToPdf;
using DinkToPdf.Contracts;
using Doc.Formatter;
using Doc.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace APS.WebApi.Extensions
{
    internal class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        internal IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return LoadUnmanagedDll(absolutePath);
        }

        protected override IntPtr LoadUnmanagedDll(String unmanagedDllName)
        {
            return LoadUnmanagedDllFromPath(unmanagedDllName);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();
            var jwtOptions = serviceProvider.GetService<IOptions<JwtSettings>>();
            return services
                .AddIdentityAndConfigure(configuration)
                .ConfigureJwt(jwtOptions.Value);
        }

        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpContextAccessor()
                .AddDbContext(configuration)
                .AddPdfConverter()
                .AddUserServices(configuration)
                .AddCatalogsServices(configuration)
                .AddAuthorizationServices(configuration)
                .AddDocumentServices()
                .AddExcelDocumentServices();
        }

        public static IServiceCollection ConfigurationSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APS Web Api", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new List<string>()
                    }
                });
            });
        }

        private static IServiceCollection ConfigureJwt(this IServiceCollection services, JwtSettings jwtSettings)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(jwtSettings.Secret)),
                    ValidateIssuerSigningKey = true,
                };
            });

            return services;
        }

        private static IServiceCollection AddIdentityAndConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(configuration.GetSection(nameof(IdentityOptions)));

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationContext>()
               .AddDefaultTokenProviders();

            return services;
        }

        private static IServiceCollection AddPdfConverter(this IServiceCollection services)
        {
            CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(AppContext.BaseDirectory, "libwkhtmltox"));
            services
                .AddSingleton<IPdfConverter, PdfConverter>()
                .AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            return services;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly("APS.EFDataAccessLibrary"));
            });
        }

        private static IServiceCollection AddUserServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient<IDataSeeder, DefaultRolesDbLoader>()
                .AddScoped<IRoleChanger, RoleChanger>()
                .AddScoped<IUserCreator, UserCreator>()
                .AddScoped<IUserService, UserService>();
        }

        private static IServiceCollection AddAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings))).ConfigureOptions<JwtSettingsConfiguration>()
                .AddScoped<IAuthorizeService, AuthorizeService>()
                .AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        }

        private static IServiceCollection AddCatalogsServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
            .Configure<UsageCatalogModel>(configuration.GetSection(nameof(UsageCatalogModel)))
            .Configure<ActivityTypeCatalogModel>(configuration.GetSection(nameof(ActivityTypeCatalogModel)))
            .Configure<ResourcingCatalogModel>(configuration.GetSection(nameof(ResourcingCatalogModel)))
            .Configure<ComplianceCatalogModel>(configuration.GetSection(nameof(ComplianceCatalogModel)))
            .Configure<SystemConditionCatalogModel>(configuration.GetSection(nameof(SystemConditionCatalogModel)))
            .Configure<TacticsTypesOfWorkCatalogModel>(configuration.GetSection(nameof(TacticsTypesOfWorkCatalogModel)))
            .Configure<TaskTypesOfWorkCatalogModel>(configuration.GetSection(nameof(TaskTypesOfWorkCatalogModel)))
            .Configure<DisciplineCatalogModel>(configuration.GetSection(nameof(DisciplineCatalogModel)))
            .Configure<AdditionalDisciplineCodeCatalogModel>(configuration.GetSection(nameof(AdditionalDisciplineCodeCatalogModel)))
            .AddTransient<IDataSeeder, UsagesDbLoader>()
            .AddTransient<IDataSeeder, ActivityTypesDbLoader>()
            .AddTransient<IDataSeeder, ResourcingDbLoader>()
            .AddTransient<IDataSeeder, ComplianceDbLoader>()
            .AddTransient<IDataSeeder, SystemConditionsDbLoader>()
            .AddTransient<IDataSeeder, TacticsTypesOfWorkDbLoader>()
            .AddTransient<IDataSeeder, TaskTypesOfWorkDbLoader>()
            .AddTransient<IDataSeeder, DisciplineDbLoader>()
            .AddTransient<IDataSeeder, AdditionalDisciplineCodeDbLoader>()
            .AddTransient<IDataSeeder, LMIDbLoader>();
        }

        private static IServiceCollection AddDocumentServices(this IServiceCollection services)
        {
            return services.AddScoped<IWordFileReader, WordFileReader>()
                .AddScoped<IPdfConverter, PdfConverter>()
                .AddScoped<IDocumentGenerator, DocumentGenerator>()
                .AddScoped<IWordDataReplacer, WordDataReplacer>();
        }

        private static IServiceCollection AddExcelDocumentServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITaskReader, TaskReader>()
                .AddScoped<IDataReader, ExcelDataReader>();
        }
    }
}
