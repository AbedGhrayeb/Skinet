using Infrastructure.Data;
using Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            var services=scope.ServiceProvider;
            var loogerFactory= services.GetRequiredService<ILoggerFactory>();
            using (var appContext = services.GetRequiredService<StoreContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                    StoreContextSeed.SeedStoreData(appContext,loogerFactory);
                }
                catch (Exception ex)
                {

                    //Log errors or do anything you think it's needed
                    var logger= loogerFactory.CreateLogger<Program>();
                        logger.LogError(ex,"An error accure during migration");
                }
            }
        }

        return webApp;
    }
}
}