using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            //services.AddScoped<IBookService, BookService>();
            services.AddScoped<IPersonService, PersonService>();
            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            //services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
