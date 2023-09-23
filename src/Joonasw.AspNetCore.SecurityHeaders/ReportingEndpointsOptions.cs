using System;
using System.Collections.Generic;
using System.Linq;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    public class ReportingEndpointsOptions
    {
        /// <summary>
        /// Gets or sets the endpoints to send the violation reports.
        /// </summary>
        /// <value>The endpoints.</value>
        public IDictionary<string, string> Endpoints { get; set; } = new Dictionary<string, string>();

        internal void Validate()
        {
            if (!Endpoints.Any())
                throw new InvalidOperationException("No endpoints specified on UseReportingEndpoints");

            if (Endpoints.Values.Any(x => !x.StartsWith("https://")))
                throw new InvalidOperationException("The endpoint URL must start with https://");
        }

        internal string ToHeaderValue() => string.Join(",", Endpoints.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""));
    }
}
