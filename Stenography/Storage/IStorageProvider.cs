using System.Windows.Forms;

namespace Stenography.Storage
{
    public interface IStorageProvider
    {
        #region Properties
        /// <summary>
        /// Gets the filter to be used for <see cref="OpenFileDialog"/> windows.
        /// </summary>
        string OpenFileDialogFilter { get; }

        /// <summary>
        /// Gets the filter to be used for <see cref="SaveFileDialog"/> windows.
        /// </summary>
        string SaveFileDialogFilter { get; }
        #endregion
        #region Methods
        /// <summary>
        /// Saves the specified data to the specified file.
        /// </summary>
        /// <param name="file">The file to use as the base.</param>
        /// <param name="newPath">The path of the file to create.</param>
        /// <param name="data">The data to save.</param>
        void Save(string file, string newPath, byte[] data);

        /// <summary>
        /// Reads the data from the specified file.
        /// </summary>
        /// <param name="path">The file to read the data from.</param>
        /// <returns>The data from the speciied file.</returns>
        byte[] Read(string path);
        #endregion
    }
}
