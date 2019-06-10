using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder {
	public class CspRequireSriForBuilder {
		private readonly CspRequireSriForOptions _options = new CspRequireSriForOptions();

		/// <summary>
		/// Require subresource integrity attributes for scripts loaded on this page
		/// </summary>
		public CspRequireSriForBuilder ForScripts()
		{
			_options.Script = true;
			return this;
		}

		/// <summary>
		/// Require subresource integrity attributes for styles loaded on this page
		/// </summary>
		public CspRequireSriForBuilder ForStyles()
		{
			_options.Style = true;
			return this;
		}

		public CspRequireSriForOptions BuildOptions()
		{
			return _options;
		}
	}
}