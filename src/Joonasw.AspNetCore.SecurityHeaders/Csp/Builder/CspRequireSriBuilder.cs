using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder {
	public class CspRequireSriBuilder {
		private readonly CspRequireSriOptions _options = new CspRequireSriOptions();

		/// <summary>
		/// Require subresource integrity attributes for scripts loaded on this page
		/// </summary>
		public CspRequireSriBuilder ForScripts()
		{
			_options.ForScripts = true;
			return this;
		}

		/// <summary>
		/// Require subresource integrity attributes for styles loaded on this page
		/// </summary>
		public CspRequireSriBuilder ForStyles()
		{
			_options.ForStyles = true;
			return this;
		}

		public CspRequireSriOptions BuildOptions()
		{
			return _options;
		}
	}
}