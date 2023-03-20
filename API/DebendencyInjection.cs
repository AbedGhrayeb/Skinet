using API.Errors;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(MapperProfile));
            services.Configure<ApiBehaviorOptions>(options=>
            {
                options.InvalidModelStateResponseFactory= actionContext=>
                {
                    var errors=actionContext.ModelState
                    .Where(x=>x.Value.Errors.Any())
                    .SelectMany(x=>x.Value.Errors)
                    .Select(x=>x.ErrorMessage).ToArray();

                    var errorResponse=new ApiValidationErrorResponse()
                    {
                        Errors=errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}