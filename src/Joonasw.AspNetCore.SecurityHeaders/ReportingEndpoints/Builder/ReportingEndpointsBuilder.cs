namespace Joonasw.AspNetCore.SecurityHeaders.ReportingEndpoints.Builder
{
    using System;

    /// <summary>
    /// Builder for Reporting-Endpoints which instructs the user agent to store reporting endpoints for an origin.
    /// </summary>
    public class ReportingEndpointsBuilder
    {
        private readonly ReportingEndpointsOptions _options = new ReportingEndpointsOptions();

        public ReportingEndpointsBuilder AddEndpoint(string groupName, string url)
        {
            if (string.IsNullOrWhiteSpace(groupName))
                throw new ArgumentNullException(nameof(groupName));

            if (_options.Endpoints.ContainsKey(groupName))
                throw new ArgumentException("The provided group name already exist", nameof(groupName));

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            if (!url.StartsWith("https://"))
                throw new ArgumentException("The URL must start with https://", nameof(url));

            _options.Endpoints.Add(groupName, url);

            return this;
        }

        public ReportingEndpointsOptions BuildOptions() => _options;
    }
}
