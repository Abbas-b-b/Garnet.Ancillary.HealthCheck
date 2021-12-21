using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace Garnet.Ancillary.HealthCheck.HealthCheckSet
{
    /// <summary>
    /// Extension methods to add health checks to the application pipeline for a group of health checks registered already
    /// </summary>
    public static class HealthCheckSetApplicationConfiguration
    {
        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifier">Identifier to filter health checks by their tags.</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string healthCheckSetIdentifier)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers: new[] { healthCheckSetIdentifier },
                port: null,
                new HealthCheckOptions());
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifier">Identifier to filter health checks by their tags.</param>
        /// <param name="port">The port to listen on. Must be a local port on which the server is listening.</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string healthCheckSetIdentifier,
            int port)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers: new[] { healthCheckSetIdentifier },
                (int?)port,
                new HealthCheckOptions());
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifier">Identifier to filter health checks by their tags.</param>
        /// <param name="healthCheckOptions">A <see cref="HealthCheckOptions"/> used to configure the middleware. <see cref="HealthCheckOptions.Predicate"/> will be overridden to filter health checks that contain <paramref name="healthCheckSetIdentifier"/></param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string healthCheckSetIdentifier,
            HealthCheckOptions healthCheckOptions)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers: new[] { healthCheckSetIdentifier },
                port: null,
                healthCheckOptions);
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifier">Identifier to filter health checks by their tags.</param>
        /// <param name="port">The port to listen on. Must be a local port on which the server is listening.</param>
        /// <param name="healthCheckOptions">A <see cref="HealthCheckOptions"/> used to configure the middleware. <see cref="HealthCheckOptions.Predicate"/> will be overridden to filter health checks that contain <paramref name="healthCheckSetIdentifier"/></param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string healthCheckSetIdentifier,
            int port,
            HealthCheckOptions healthCheckOptions)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers: new[] { healthCheckSetIdentifier },
                (int?)port,
                healthCheckOptions);
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifiers">Identifiers to filter health checks by their tags. All identifiers should exist in the health check tags to be picked</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string[] healthCheckSetIdentifiers)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers,
                port: null,
                new HealthCheckOptions());
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifiers">Identifiers to filter health checks by their tags. All identifiers should exist in the health check tags to be picked</param>
        /// <param name="port">The port to listen on. Must be a local port on which the server is listening.</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string[] healthCheckSetIdentifiers,
            int port)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers,
                (int?)port,
                new HealthCheckOptions());
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifiers">Identifiers to filter health checks by their tags. All identifiers should exist in the health check tags to be picked</param>
        /// <param name="healthCheckOptions">A <see cref="HealthCheckOptions"/> used to configure the middleware. <see cref="HealthCheckOptions.Predicate"/> will be overridden to filter health checks that contain all <paramref name="healthCheckSetIdentifiers"/></param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string[] healthCheckSetIdentifiers,
            HealthCheckOptions healthCheckOptions)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers,
                port: null,
                healthCheckOptions);
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifiers">Identifiers to filter health checks by their tags. All identifiers should exist in the health check tags to be picked</param>
        /// <param name="port">The port to listen on. Must be a local port on which the server is listening.</param>
        /// <param name="healthCheckOptions">A <see cref="HealthCheckOptions"/> used to configure the middleware. <see cref="HealthCheckOptions.Predicate"/> will be overridden to filter health checks that contain all <paramref name="healthCheckSetIdentifiers"/></param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string[] healthCheckSetIdentifiers,
            int port,
            HealthCheckOptions healthCheckOptions)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers,
                (int?)port,
                healthCheckOptions);
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for a group of health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the group of health checks result</param>
        /// <param name="healthCheckSetIdentifiers">Identifiers to filter health checks by their tags. All identifiers should exist in the health check tags to be picked</param>
        /// <param name="port">The port to listen on. Must be a local port on which the server is listening.</param>
        /// <param name="healthCheckOptions">A <see cref="HealthCheckOptions"/> used to configure the middleware. <see cref="HealthCheckOptions.Predicate"/> will be overridden to filter health checks that contain all <paramref name="healthCheckSetIdentifiers"/></param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        internal static IApplicationBuilder UseSetOfHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string[] healthCheckSetIdentifiers,
            int? port,
            HealthCheckOptions healthCheckOptions)
        {
            healthCheckOptions ??= new HealthCheckOptions();

            healthCheckOptions.Predicate =
                registration => healthCheckSetIdentifiers.All(identifier => registration.Tags.Contains(identifier));

            return port.HasValue
                ? applicationBuilder.UseHealthChecks(path, port.Value, healthCheckOptions)
                : applicationBuilder.UseHealthChecks(path, healthCheckOptions);
        }
    }
}