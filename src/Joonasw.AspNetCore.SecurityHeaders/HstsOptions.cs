namespace Joonasw.AspNetCore.SecurityHeaders
{
    public class HstsOptions
    {
        public int Seconds { get; set; }
        public bool IncludeSubDomains { get; set; }
        public bool Preload { get; set; }
    }
}