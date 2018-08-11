namespace Joonasw.AspNetCore.SecurityHeaders
{
    public class XContentTypeOptionsOptions
    {
        /// <summary>
        /// Defines the X-Content-Type-Options header with the 'nosniff' option
        /// </summary>
        public XContentTypeOptionsOptions()
            : this(false)
        {

        }

        /// <summary>
        /// Defines the X-Content-Type-Options header and whether to allow sniffing
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
