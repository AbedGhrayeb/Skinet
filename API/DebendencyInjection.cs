using API.Errors;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwagger();
            services.AddAutoMapper(typeof(MapperProfile));
            //configure valdiation error handling
            services.AddErrorValidationHandling();
            return services;
        }
         private static IServiceCollection AddErrorValidationHandling(this IServiceCollection services)
        {
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
        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
              services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x=> 
            {
                x.SwaggerDoc("v1",new OpenApiInfo{Title="SkiNet" , Version ="v1"});
            });
            return services;
        }
    }
}