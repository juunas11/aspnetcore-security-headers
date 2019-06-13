using Newtonsoft.Json;
using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    public class ReportToOptions
    {
        public IList<Group> Groups { get; set; } = new List<Group>();

        public class Group
        {
            [JsonProperty("group")]
            public string GroupName { get; set; }

            [JsonProperty("include_subdomains")]
            public bool IncludeSubdomains { get; set; }

            [JsonProperty("max_age")]
            public int MaxAgeSeconds { get; set; }

            [JsonProperty("endpoints")]
            public IList<Endpoint> Endpoints { get; set; } = new List<Endpoint>();

            public class Endpoint
            {
                [JsonProperty("url")]
                public string Url { get; set; }

                [JsonProperty("priority")]
                public int? Priority { get; set; }

                [JsonProperty("weight")]
                public int? Weight { get; set; }
            }
        }
    }
}
