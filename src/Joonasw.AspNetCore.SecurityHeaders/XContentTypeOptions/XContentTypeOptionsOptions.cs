namespace Joonasw.AspNetCore.SecurityHeaders.XContentTypeOptions
{
    public class XContentTypeOptionsOptions
    {
        public XContentTypeOptionsOptions()
        {
            
        }

        /// <summary>
        /// Defines the X-Content-Type-Options header and whether to allow sniffing
        /// NoSniff is turned on by default
        /// </summary>
        /// <param name="allowSniffing"></param>
        public XContentTypeOptionsOptions(bool allowSniffing)
        {
            AllowSniffing = allowSniffing;
        }

        /// <summary>
        /// Gets the value to allow sniffing on your site
        /// </summary>
        public bool AllowSniffing { get; set; }
    }
}
