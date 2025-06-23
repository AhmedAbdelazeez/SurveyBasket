using FluentValidation.AspNetCore;
using MapsterMapper;
using System.Reflection;

namespace SurveyBasket.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDepndecies(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<IPollService, PollService>();
            services

                .AddSwaggerServices()
                .AddMapsterConfig()
                .AddFluentValidation();
            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static IServiceCollection AddMapsterConfig(this IServiceCollection services)
        {

            var mappingConfig = TypeAdapterConfig.GlobalSettings;
            mappingConfig.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(mappingConfig));
            return services;
        }

        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {


            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
