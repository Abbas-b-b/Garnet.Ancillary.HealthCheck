using System;
using Microsoft.Extensions.DependencyInjection;

namespace Garnet.Ancillary.HealthCheck
{
    /// <summary>
    /// Providing some methods to add health checks and respect service registration builder pattern
    /// </summary>
    public static class GarnetHealthChecks
    {
        /// <summary>
        /// Add health checks with respect to the service registrations builder pattern
        /// </summary>
        /// <param name="serviceCollection">To register health check services</param>
        /// <param name="configureHealthChecks">Custom configurations on the health check builder</param>
        /// <returns><paramref name="serviceCollection"/> after adding health check services</returns>
        public static IServiceCollection AddGarnetHealthChecks(this IServiceCollection serviceCollection,
            Action<IHealthChecksBuilder> configureHealthChecks)
        {
            return serviceCollection.AddGarnetHealthChecks(out _, configureHealthChecks);
        }

        /// <summary>
        /// Add health checks with respect to the service registrations builder pattern with ref assignment to used <see cref="IHealthChecksBuilder"/>
        /// </summary>
        /// <param name="serviceCollection">To register health check services</param>
        /// <param name="healthCheckBuilder">Assign to <see cref="IHealthChecksBuilder"/> used to add health checks</param>
        /// <param name="configureHealthChecks">Custom configurations on the health check builder</param>
        /// <returns><paramref name="serviceCollection"/> after adding health check services</returns>
        public static IServiceCollection AddGarnetHealthChecks(this IServiceCollection serviceCollection,
            out IHealthChecksBuilder healthCheckBuilder,
            Action<IHealthChecksBuilder> configureHealthChecks)
        {
            healthCheckBuilder = serviceCollection.AddHealthChecks();

            configureHealthChecks(healthCheckBuilder);

            return serviceCollection;
        }
    }
}