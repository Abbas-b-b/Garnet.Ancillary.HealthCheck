using System;
using Garnet.Ancillary.HealthCheck.Configurations;
using Garnet.Ancillary.HealthCheck.HealthCheckSet;
using Microsoft.Extensions.DependencyInjection;

namespace Garnet.Ancillary.HealthCheck.ReadinessHealthCheck
{
    /// <summary>
    /// Extension methods to register readiness related health checks
    /// </summary>
    public static class ReadinessHealthCheckRegistration
    {
        /// <summary>
        /// Groups all added health checks as readiness with default tag
        /// </summary>
        /// <param name="healthChecksBuilder">Used as the input for <paramref name="configureHealthChecks"/></param>
        /// <param name="configureHealthChecks">To apply custom configurations to <paramref name="healthChecksBuilder"/></param>
        /// <returns><paramref name="healthChecksBuilder"/> after configurations have been applied</returns>
        public static IHealthChecksBuilder AddReadinessHealthChecks(this IHealthChecksBuilder healthChecksBuilder,
            Action<IHealthChecksBuilder> configureHealthChecks)
        {
            return healthChecksBuilder.AddReadinessHealthChecks(GarnetHealthCheckConfig.ReadinessTag,
                configureHealthChecks);
        }

        /// <summary>
        /// Groups all added health checks as readiness
        /// </summary>
        /// <param name="healthChecksBuilder">Used as the input for <paramref name="configureHealthChecks"/></param>
        /// <param name="tag">Custom tag to be added to the health check to be distinguished later</param>
        /// <param name="configureHealthChecks">To apply custom configurations to <paramref name="healthChecksBuilder"/></param>
        /// <returns><paramref name="healthChecksBuilder"/> after configurations have been applied</returns>
        public static IHealthChecksBuilder AddReadinessHealthChecks(this IHealthChecksBuilder healthChecksBuilder,
            string tag,
            Action<IHealthChecksBuilder> configureHealthChecks)
        {
            return healthChecksBuilder.AddSetOfHealthChecks(tag, configureHealthChecks);
        }
    }
}
