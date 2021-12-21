using System;
using Microsoft.Extensions.DependencyInjection;

namespace Garnet.Ancillary.HealthCheck.HealthCheckSet
{
    /// <summary>
    /// Extension methods to register a group of related health checks
    /// </summary>
    public static class HealthCheckSetRegistration
    {
        /// <summary>
        /// Groups all added health checks using <paramref name="configureHealthChecks"/> to be used for different purposes
        /// </summary>
        /// <param name="healthChecksBuilder">Used as the input for <paramref name="configureHealthChecks"/></param>
        /// <param name="healthCheckIdentifier">Identifier to be added to the health check to be distinguished later</param>
        /// <param name="configureHealthChecks">To apply custom configurations to <paramref name="healthChecksBuilder"/></param>
        /// <returns><paramref name="healthChecksBuilder"/> after configurations have been applied</returns>
        public static IHealthChecksBuilder AddSetOfHealthChecks(this IHealthChecksBuilder healthChecksBuilder,
            string healthCheckIdentifier,
            Action<IHealthChecksBuilder> configureHealthChecks)
        {
            var healthCheckIdentifiers = new[] { healthCheckIdentifier };

            return healthChecksBuilder.AddSetOfHealthChecks(healthCheckIdentifiers, configureHealthChecks);
        }

        /// <summary>
        /// Groups all added health checks using <paramref name="configureHealthChecks"/> to be used for different purposes
        /// </summary>
        /// <param name="healthChecksBuilder">Used as the input for <paramref name="configureHealthChecks"/></param>
        /// <param name="healthCheckIdentifiers">Identifiers to be added to the health check to be distinguished later</param>
        /// <param name="configureHealthChecks">To apply custom configurations to <paramref name="healthChecksBuilder"/></param>
        /// <returns><paramref name="healthChecksBuilder"/> after configurations have been applied</returns>
        public static IHealthChecksBuilder AddSetOfHealthChecks(this IHealthChecksBuilder healthChecksBuilder,
            string[] healthCheckIdentifiers,
            Action<IHealthChecksBuilder> configureHealthChecks)
        {
            var tagAppenderHealthCheckBuilderProxy = new TagAppenderHealthCheckBuilderProxy(healthChecksBuilder,
                healthCheckIdentifiers);

            configureHealthChecks(tagAppenderHealthCheckBuilderProxy);

            return healthChecksBuilder;
        }
    }
}