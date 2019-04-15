using Newtonsoft.Json;
using System;

namespace Joonasw.AspNetCore.SecurityHeaders.ReportTo
{
    internal static class ReportToOptionsExtensions
    {
        public static string BuildHeaderValue(this ReportToOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.MaxAgeSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(options.MaxAgeSeconds), "ReportTo max age must be positive");
            }

            if (options.Endpoints == null || options.Endpoints.Count <= 0)
            {
                throw new ArgumentNullException(nameof(options.Endpoints), "At least one endpoint required");
            }

            for (var i = 0; i < options.Endpoints.Count; i++)
            {
                var e = options.Endpoints[i];

                if (string.IsNullOrWhiteSpace(e.Url))
                {
                    throw new ArgumentException($"{nameof(options.Endpoints)}[{i}].Url", "Url for endpoint required");
                }

                if (e.Priority.HasValue && e.Priority <= 0)
                {
                    throw new ArgumentException($"{nameof(options.Endpoints)}[{i}].Priority", "Priority must be positive if present");
                }

                if (e.Weight.HasValue && e.Weight <= 0)
                {
                    throw new ArgumentException($"{nameof(options.Endpoints)}[{i}].Weight", "Weight must be positive if present");
                }
            }

            return JsonConvert.SerializeObject(options);
        }
    }
}
