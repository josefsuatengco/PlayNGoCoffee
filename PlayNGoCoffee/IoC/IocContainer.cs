using Microsoft.Extensions.DependencyInjection;
using System;

namespace PlayNGoCoffee
{
    /// <summary>
    /// Shorthand access class to get DI services with cleaner code
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Scoped instance of the <see cref="ApplicationDbContext"/>
        /// </summary>
        public static ApplicationDbContext ApplicationDbContext => IocContainer.Provider.GetService<ApplicationDbContext>();
    }

    /// <summary>
    /// Dependency Injection container making use of the build in .Net Core service provider
    /// </summary>
    public static class IocContainer
    {
        /// <summary>
        /// Service Provider for this app
        /// </summary>
        public static IServiceProvider Provider { get; set; }
    }
}
