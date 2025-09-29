using eCommerce.Core.Entities.DTO;
using eCommerce.Core.Service;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services) // extension method
        {
            services.AddTransient<IUserService,UserService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
            return services;
        }
    }
}
