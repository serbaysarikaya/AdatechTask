using AdatechTask.Data.Abstract;
using AdatechTask.Data.Concrete.EntityFramework;
using AdatechTask.Data.Concrete.EntityFramework.Contexts;
using AdatechTask.Services.Abstract;
using AdatechTask.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AdatechTask.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<AdatechTaskContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(); // IUnitOfWork bağımlılığını ekleyin
            serviceCollection.AddScoped<IBookService, BookManager>();

            return serviceCollection;
        }

    }
}
