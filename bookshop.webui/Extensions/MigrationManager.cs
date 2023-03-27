using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.data.Concrete.EfCore;
using bookshop.webui.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace bookshop.webui.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDataBase(this IHost host)
        {
            using(var scope=host.Services.CreateScope())
            {
                using(var applicationContext= scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        applicationContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // loglama
                         throw;
                        
                    }
                }
                using(var shopContext= scope.ServiceProvider.GetRequiredService<ShopContext>())
                {
                    try
                    {
                        shopContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // loglama
                         throw;
                        
                    }
                }
            }
        
            return host;
        }

    }
}