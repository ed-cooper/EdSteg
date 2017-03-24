namespace Stenography.Storage
{
    interface IStorageProvider
    {
        /// <summary>
        /// Saves the specified data to the specified file.
        /// </summary>
        /// <param name="path">The file to save the data to.</param>
        /// <param name="data">The data to save.</param>
        void Save(string path, byte[] data);

        /// <summary>
        /// Reads the data from the specified file.
        /// </summary>
        /// <param name="path">The file to read the data from.</param>
        /// <returns>The data from the speciied file.</returns>
        byte[] Read(string path);
    }
}
