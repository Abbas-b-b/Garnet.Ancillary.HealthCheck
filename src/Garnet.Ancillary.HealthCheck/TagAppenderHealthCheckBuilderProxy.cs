using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Garnet.Ancillary.HealthCheck
{
    /// <summary>
    /// A proxy to add needed tags to the registered health check without changing the usage methods
    /// </summary>
    internal class TagAppenderHealthCheckBuilderProxy : IHealthChecksBuilder
    {
        private readonly IHealthChecksBuilder _actualHealthChecksBuilder;
        private readonly string[] _tagsToAppend;

        /// <summary>
        /// A proxy to add needed tags to the registered health check without changing the usage methods
        /// </summary>
        /// <param name="actualHealthChecksBuilder">the <see cref="IHealthChecksBuilder"/> to apply proxy on</param>
        /// <param name="tagsToAppend">tags to append to the registered health checks</param>
        public TagAppenderHealthCheckBuilderProxy(IHealthChecksBuilder actualHealthChecksBuilder, string[] tagsToAppend)
        {
            _actualHealthChecksBuilder = actualHealthChecksBuilder;
            _tagsToAppend = tagsToAppend;
        }

        /// <inheritdoc cref="IHealthChecksBuilder.Add"/>
        public IHealthChecksBuilder Add(HealthCheckRegistration registration)
        {
            AppendTags(registration, _tagsToAppend);

            return _actualHealthChecksBuilder.Add(registration);
        }

        /// <inheritdoc cref="IHealthChecksBuilder.Services"/>
        public IServiceCollection Services => _actualHealthChecksBuilder.Services;

        private static void AppendTags(HealthCheckRegistration healthCheckRegistration, string[] tags)
        {
            if (tags is null || healthCheckRegistration?.Tags is null)
            {
                return;
            }

            foreach (var tag in tags)
            {
                healthCheckRegistration.Tags.Add(tag);
            }
        }
    }
}