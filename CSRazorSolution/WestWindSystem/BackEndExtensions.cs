using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.DAL;
using WestWindSystem.BLL;
#endregion

namespace WestWindSystem
{
    //
    public  static class BackEndExtensions
    {
        public static void WWBackEndDependencies(this IServiceCollection services,Action<DbContextOptionsBuilder> options)
        {
            // we will register all the services taht will be used by the system (context setup)
            // and will be provided by the system (BLL services)

            //register the context service
            //options contains the connection string information
            services.AddDbContext<WestWindContext>(options);

            //register each serivice class (BLL classess)
            //each service calls will have an AddTransient<T>() method

            //use the AddTransient<T> method where T is your BLL class name 
            //AddTransient is called a factory 
            // I read my lamba symble => as "do the following ..."
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
            {//get the Context class that was registed above in AddDbContext
                var context = serviceProvider.GetService<WestWindContext>();

                //create an instance of the service class(BuildVersionServices)
                // supplying the context reference to the service class
                return new BuildVersionServices(context);
            });

        }
    }
}
