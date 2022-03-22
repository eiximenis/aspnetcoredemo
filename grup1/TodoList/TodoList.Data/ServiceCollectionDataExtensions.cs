using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain;

namespace TodoList.Data
{
    public static class ServiceCollectionDataExtensions
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITodoItemRepository, TodoItemRepository>();
            return services;
        }
    }
}
