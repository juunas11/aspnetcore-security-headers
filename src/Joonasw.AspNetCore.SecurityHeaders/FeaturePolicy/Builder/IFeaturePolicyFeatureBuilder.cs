namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    internal interface IFeaturePolicyFeatureBuilder<out T>
    {
        /// <summary>
        /// Block access to feature from all domains.
        /// </summary>
        void FromNowhere();
        /// <summary>
        /// Allowed from current domain.
        /// </summary>
        /// <returns></returns>
        T FromSelf();
        /// <summary>
        /// Allowed from any domain.
        /// </summary>
        /// <returns></returns>
        T FromAnywhere();
        /// <summary>
        /// Allowed from the given
        /// <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The URI to allow.</param>
        /// <returns>The builder for call chaining</returns>
        T From(string uri);
    }
}
