using System;
using System.Collections.Generic;

namespace Joonasw.AspNetCore.SecurityHeaders
{
    public class ReportToOptions
    {
        public string GroupMemeberName { get; set; }

        public bool IncludeSubdomains { get; set; }

        public int MaxAgeSeconds { get; set; }

        public IList<Endpoint> Endpoints { get; set; } = new List<Endpoint>();

        public class Endpoint
        {
            public string Url { get; set; }

            public int? Priority { get; set; }

            public int? Weight { get; set; }
        }
    }
}
