namespace Garnet.Ancillary.HealthCheck.Configurations
{
    /// <summary>
    /// Contains default values for Garnet health checks
    /// </summary>
    internal abstract class GarnetHealthCheckConfig
    {
        /// <summary>
        /// Default tag that is shared among all registered health checks to filter for readiness purposes.
        /// </summary>
        public const string ReadinessTag = "Garnet.HealthCheck.Readiness";
        
        /// <summary>
        /// Default tag that is shared among all registered health checks to filter for liveness purposes.
        /// </summary>
        public const string LivenessTag = "Garnet.HealthCheck.Liveness";
        
        /// <summary>
        /// Default readiness endpoint
        /// </summary>
        public const string ReadinessPath = "/readiness";
        
        /// <summary>
        /// Default readiness endpoint
        /// </summary>
        public const string LivenessPath = "/liveness";
    }
}