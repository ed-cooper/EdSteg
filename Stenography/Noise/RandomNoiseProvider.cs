using System;

namespace Stenography.Noise
{
    /// <summary>
    /// Provides pseudo-randomly generated noise for disguising the end of the data in an image.
    /// </summary>
    public class RandomNoiseProvider : INoiseProvider
    {
        #region Fields

        /// <summary>
        /// Produces pseudo-random values.
        /// </summary>
        private readonly Random _rng;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="RandomNoiseProvider"/> class.
        /// </summary>
        public RandomNoiseProvider()
        {
            _rng = new Random();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RandomNoiseProvider"/> class.
        /// </summary>
        /// <param name="seed">A number used to calculate the starting value for the pseudo-random sequence.</param>
        public RandomNoiseProvider(int seed)
        {
            _rng = new Random(seed);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the next bit of pseudo-random noise.
        /// </summary>
        /// <returns>The next bit of pseudo-random noise.</returns>
        public bool Next()
        {
            return _rng.NextDouble() > 0.5;
        }

        #endregion
    }
}
