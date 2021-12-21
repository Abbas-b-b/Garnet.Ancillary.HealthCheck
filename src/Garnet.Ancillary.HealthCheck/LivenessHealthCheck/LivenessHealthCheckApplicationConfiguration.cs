using Garnet.Ancillary.HealthCheck.Configurations;
using Garnet.Ancillary.HealthCheck.HealthCheckSet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace Garnet.Ancillary.HealthCheck.LivenessHealthCheck
{
    public static class LivenessHealthCheckApplicationConfiguration
    {
        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for the liveness health checks
        /// registered already. with default liveness tag and path
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseLivenessHealthChecks(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseLivenessHealthChecks(GarnetHealthCheckConfig.LivenessPath,
                GarnetHealthCheckConfig.LivenessTag,
                port: null,
                healthCheckOptions: null);
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for the liveness health checks
        /// registered already. With default liveness tag
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the liveness health checks result</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseLivenessHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path)
        {
            return applicationBuilder.UseLivenessHealthChecks(path,
                GarnetHealthCheckConfig.LivenessTag,
                port: null,
                healthCheckOptions: null);
        }
        
        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for the liveness health checks
        /// registered already. With default liveness path
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="tag">Custom tag to filter health checks</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseLivenessHealthChecks(this IApplicationBuilder applicationBuilder,
            string tag)
        {
            return applicationBuilder.UseLivenessHealthChecks(GarnetHealthCheckConfig.LivenessPath,
                tag,
                port: null,
                healthCheckOptions: null);
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for the liveness health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the liveness health checks result</param>
        /// <param name="tag">Custom tag to filter health checks</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseLivenessHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string tag)
        {
            return applicationBuilder.UseLivenessHealthChecks(path,
                tag,
                port: null,
                healthCheckOptions: null);
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for the liveness health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the liveness health checks result</param>
        /// <param name="tag">Custom tag to filter health checks</param>
        /// <param name="port">The port to listen on. Must be a local port on which the server is listening.</param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseLivenessHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string tag,
            int port)
        {
            return applicationBuilder.UseLivenessHealthChecks(path,
                tag,
                (int?)port,
                healthCheckOptions: null);
        }

        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for the liveness health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the liveness health checks result</param>
        /// <param name="tag">Custom tag to filter health checks</param>
        /// <param name="healthCheckOptions">A <see cref="HealthCheckOptions"/> used to configure the middleware. <see cref="HealthCheckOptions.Predicate"/> will be overridden to filter health checks that contain <paramref name="tag"/></param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseLivenessHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string tag,
            HealthCheckOptions healthCheckOptions)
        {
            return applicationBuilder.UseLivenessHealthChecks(path,
                tag,
                port: null,
                healthCheckOptions);
        }
        
        /// <summary>
        /// Configure <see cref="IApplicationBuilder"/> to use the health check endpoint for the liveness health checks
        /// registered already.
        /// </summary>
        /// <param name="applicationBuilder">The ApplicationBuilder to apply configurations</param>
        /// <param name="path">The endpoint to get the liveness health checks result</param>
        /// <param name="tag">Custom tag to filter health checks</param>
        /// <param name="port">The port to listen on. Must be a local port on which the server is listening.</param>
        /// <param name="healthCheckOptions">A <see cref="HealthCheckOptions"/> used to configure the middleware. <see cref="HealthCheckOptions.Predicate"/> will be overridden to filter health checks that contain <paramref name="tag"/></param>
        /// <returns><paramref name="applicationBuilder"/> after configuration applied to</returns>
        public static IApplicationBuilder UseLivenessHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string tag,
            int port,
            HealthCheckOptions healthCheckOptions)
        {
            return applicationBuilder.UseLivenessHealthChecks(path,
                tag,
                (int?)port,
                healthCheckOptions);
        }
        
        private static IApplicationBuilder UseLivenessHealthChecks(this IApplicationBuilder applicationBuilder,
            PathString path,
            string tag,
            int? port,
            HealthCheckOptions healthCheckOptions)
        {
            return applicationBuilder.UseSetOfHealthChecks(path,
                healthCheckSetIdentifiers: new[] { tag },
                port,
                healthCheckOptions);
        }
    }
}