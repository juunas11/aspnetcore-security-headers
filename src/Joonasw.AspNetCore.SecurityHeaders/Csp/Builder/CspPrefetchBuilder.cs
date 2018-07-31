using System;
using Joonasw.AspNetCore.SecurityHeaders.Csp.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.Csp.Builder
{
	/// <summary>
	/// Builder for Content Security Policy rules
	/// related to pre-fetching and pre-rendering content
	/// </summary>
	public class CspPrefetchBuilder
	{
		private readonly CspPrefetchSrcOptions _options = new CspPrefetchSrcOptions();

		/// <summary>
		/// Block all pre-fetching/pre-rendering
		/// </summary>
		public void FromNowhere() 
		{
			_options.AllowNone = true;
		}

		/// <summary>
		/// Allow pre-fetching/pre-rendering
		/// from current domain.
		/// </summary>
		/// <returns>The builder for call chaining</returns>
		public CspPrefetchBuilder FromSelf()
		{
			_options.AllowSelf = true;
			return this;
		}

		/// <summary>
		/// Allow pre-fetching/pre-rendering
		/// from the given <paramref name="uri"/>.
		/// </summary>
		/// <param name="uri">The URI to allow.</param>
		/// <returns>The builder for call chaining</returns>
		public CspPrefetchBuilder From(string uri)
		{
			if (uri == null) throw new ArgumentNullException(nameof(uri));
			if (uri.Length == 0) throw new ArgumentException("Uri can't be empty", nameof(uri));

			_options.AllowedSources.Add(uri);
			return this;
		}

		/// <summary>
		/// Allow pre-fetching/pre-rendering
		/// from anywhere, except data:, blob:,
		/// and filesystem: schemes.
		/// </summary>
		/// <returns>The builder for call chaining</returns>
		public CspPrefetchBuilder FromAnywhere() 
		{
			_options.AllowAny = true;
			return this;
		}

		/// <summary>
		/// Allow pre-fetching/pre-rendering
		/// only over secure connections.
		/// </summary>
		/// <returns>The builder for call chaining</returns>
		public CspPrefetchBuilder OnlyOverHttps()
		{
			_options.AllowOnlyHttps = true;
			return this;
		}

		public CspPrefetchSrcOptions BuildOptions()
		{
			return _options;
		}
	}
}