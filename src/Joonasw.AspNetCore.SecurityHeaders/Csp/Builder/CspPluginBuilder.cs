using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
    /// <summary>
    /// Builder for Content Security Policy rules
    /// related to plugins in e.g. &lt;object&gt;,
    /// &lt;embed&gt;, and &lt;applet&gt; elements.
    /// </summary>
    public class CspPluginBuilder
    {
        private readonly CspPluginTypesOptions _pluginOptions = new CspPluginTypesOptions();
        private readonly CspObjectSrcOptions _objectOptions = new CspObjectSrcOptions();

        /// <summary>
        /// Block all &lt;object&gt;, &lt;embed&gt;,
        /// and &lt;applet&gt; sources.
        /// </summary>
        public void FromNowhere()
        {
            _objectOptions.AllowNone = true;
        }

        /// <summary>
        /// Allow &lt;object&gt;, &lt;embed&gt;, and &lt;applet&gt;
        /// sources from current domain.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspPluginBuilder FromSelf()
        {
            _objectOptions.AllowSelf = true;
            return this;
        }

        /// <summary>
        /// Allow &lt;object&gt;, &lt;embed&gt;, and &lt;applet&gt;
        /// sources from the given <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspPluginBuilder From(string uri)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

            _objectOptions.AllowedSources.Add(uri);
            return this;
        }

        /// <summary>
        /// Allow &lt;object&gt;, &lt;embed&gt;, and &lt;applet&gt;
        /// sources from anywhere.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspPluginBuilder FromAnywhere()
        {
            _objectOptions.AllowAny = true;
            return this;
        }

        /// <summary>
        /// Add valid MIME type for plugins invoked via
        /// &lt;object&gt;, &lt;embed&gt;, or &lt;applet&gt;.
        /// In order to use &lt;applet&gt;, you must add
        /// application/x-java-applet.
        /// </summary>
        /// <param name="mimeType">The MIME type to allow.</param>
        /// <returns>The builder for call chaining</returns>
        public CspPluginBuilder WithMimeType(string mimeType)
        {
            _pluginOptions.AllowedMediaTypes.Add(mimeType);
            return this;
        }

        /// <summary>
        /// Allow &lt;object&gt;, &lt;embed&gt;, and &lt;applet&gt;
        /// sources only over secure connections.
        /// </summary>
        /// <returns>The builder for call chaining</returns>
        public CspPluginBuilder OnlyOverHttps()
        {
            _objectOptions.AllowOnlyHttps = true;
            return this;
        }

        public Tuple<CspObjectSrcOptions, CspPluginTypesOptions> BuildOptions()
        {
            return Tuple.Create(_objectOptions, _pluginOptions);
        }
    }
}