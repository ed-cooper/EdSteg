namespace Stenography.Noise
{
    /// <summary>
    /// Provides noise for disguising the end of the data in an image.
    /// </summary>
    public interface INoiseProvider
    {
        #region Methods

        /// <summary>
        /// Gets the next bit of noise.
        /// </summary>
        /// <returns>The next bit of noise.</returns>
        bool Next();

        #endregion
    }
}
