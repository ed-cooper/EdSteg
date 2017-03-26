namespace Stenography.Storage
{
    /// <summary>
    /// Provides storage of encrpyted data using a specific stenography system.
    /// </summary>
    public interface IStorageProvider
    {
        #region Properties
        /// <summary>
        /// Gets the dialog file filter to be used for browsing files to import.
        /// </summary>
        string ImportFileDialogFilter { get; }

        /// <summary>
        /// Gets the dialog file filter to be used for browsing exported files.
        /// </summary>
        string ExportFileDialogFilter { get; }
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

        /// <summary>
        /// Returns the max number of bytes that could be encoded within the specified file.
        /// </summary>
        /// <param name="file">The file to test.</param>
        /// <returns>The max number of bytes that could be encoded within the specified file.</returns>
        /// <remarks>Returns 0 for invalid files.</remarks>
        int GetStoragePotential(string file);
        #endregion
    }
}
