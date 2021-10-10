namespace MovieApp.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MovieApp.Core.Entities;
    using MovieApp.Database;

    public static class IdentityServiceExtensions
    {
        //Configuring the identity net core
        public static IServiceCollection AddIdentityServiceExtensions(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            }).AddRoles<AppRole>().AddRoleManager<RoleManager<AppRole>>()
              .AddSignInManager<SignInManager<AppUser>>()
              .AddRoleValidator<RoleValidator<AppRole>>()
              .AddEntityFrameworkStores<DataContext>();
            return services;
        }
    }
}
