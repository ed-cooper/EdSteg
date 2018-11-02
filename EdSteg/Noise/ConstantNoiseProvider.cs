using System;

namespace EdSteg.Noise
{
    /// <summary>
    /// Provides constant, unchaning noise values.
    /// </summary>
    public class ConstantNoiseProvider : INoiseProvider
    {
        #region Fields

        /// <summary>
        /// The output supplied by <see cref="Next"/>.
        /// </summary>
        private readonly bool _output;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the <see cref="ConstantNoiseProvider"/> class.
        /// </summary>
        public ConstantNoiseProvider()
        {
            _output = false;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ConstantNoiseProvider"/> class.
        /// </summary>
        /// <param name="output">The constant output supplied when <see cref="Next"/> is called.</param>
        public ConstantNoiseProvider(bool output)
        {
            _output = output;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the next bit of constant noise.
        /// </summary>
        /// <returns>The next bit of constant noise.</returns>
        public bool Next()
        {
            return _output;
        }

        #endregion
    }
}
