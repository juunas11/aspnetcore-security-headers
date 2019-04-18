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

            if (options.Groups == null || options.Groups.Count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(options.Groups), "ReportToOptions must have at least one group");
            }

            var values = new string[0];
            for (var i = 0; i < options.Groups.Count; i++)
            {
                var group = options.Groups[i];

                if (group.MaxAgeSeconds <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(group.MaxAgeSeconds), "ReportTo max age must be positive");
                }

                if (group.Endpoints == null || group.Endpoints.Count <= 0)
                {
                    throw new ArgumentNullException(nameof(group.Endpoints), "At least one endpoint required");
                }

                for (var j = 0; j < group.Endpoints.Count; j++)
                {
                    var e = group.Endpoints[j];

                    if (string.IsNullOrWhiteSpace(e.Url))
                    {
                        throw new ArgumentException($"{nameof(group.Endpoints)}[{j}].Url", "Url for endpoint required");
                    }

                    if (e.Priority.HasValue && e.Priority <= 0)
                    {
                        throw new ArgumentException($"{nameof(group.Endpoints)}[{j}].Priority", "Priority must be positive if present");
                    }

                    if (e.Weight.HasValue && e.Weight <= 0)
                    {
                        throw new ArgumentException($"{nameof(group.Endpoints)}[{j}].Weight", "Weight must be positive if present");
                    }
                }

                values[i] = JsonConvert.SerializeObject(group);
            }

            return string.Join(",\r\n", values);
        }
    }
}
