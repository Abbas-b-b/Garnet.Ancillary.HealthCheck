using System;
using Garnet.Ancillary.HealthCheck.Configurations;
using Garnet.Ancillary.HealthCheck.HealthCheckSet;
using Microsoft.Extensions.DependencyInjection;

namespace Garnet.Ancillary.HealthCheck.LivenessHealthCheck
{
    /// <summary>
    /// Extension methods to register liveness related health checks
    /// </summary>
    public static class LivenessHealthCheckRegistration
    {
        /// <summary>
        /// Groups all added health checks as liveness with default tag
        /// </summary>
        /// <param name="healthChecksBuilder">Used as the input for <paramref name="configureHealthChecks"/></param>
        /// <param name="configureHealthChecks">To apply custom configurations to <paramref name="healthChecksBuilder"/></param>
        /// <returns><paramref name="healthChecksBuilder"/> after configurations have been applied</returns>
        public static IHealthChecksBuilder AddLivenessHealthChecks(this IHealthChecksBuilder healthChecksBuilder,
            Action<IHealthChecksBuilder> configureHealthChecks)
        {
            return healthChecksBuilder.AddLivenessHealthChecks(GarnetHealthCheckConfig.LivenessTag,
                configureHealthChecks);
        }

        /// <summary>
        /// Groups all added health checks as liveness
        /// </summary>
        /// <param name="healthChecksBuilder">Used as the input for <paramref name="configureHealthChecks"/></param>
        /// <param name="tag">Custom tag to be added to the health check to be distinguished later</param>
        /// <param name="configureHealthChecks">To apply custom configurations to <paramref name="healthChecksBuilder"/></param>
        /// <returns><paramref name="healthChecksBuilder"/> after configurations have been applied</returns>
        public static IHealthChecksBuilder AddLivenessHealthChecks(this IHealthChecksBuilder healthChecksBuilder,
            string tag,
            Action<IHealthChecksBuilder> configureHealthChecks)
        {
            return healthChecksBuilder.AddSetOfHealthChecks(tag, configureHealthChecks);
        }
    }
}