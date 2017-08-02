namespace SphereStudio.Base
{
    /// <summary>
    /// Specifies an interface for reading and writing configuration settings.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Reads a boolean value from the settings.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="defValue">A default value if the setting doesn't exist.</param>
        /// <returns></returns>
        bool GetBoolean(string key, bool defValue);
        
        /// <summary>
        /// Reads a floating-point value from the settings.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="defValue">A default value if the setting doesn't exist.</param>
        /// <returns></returns>
        double GetFloat(string key, double defValue);
        
        /// <summary>
        /// Reads an integer value from the settings.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="defValue">A default value if the setting doesn't exist.</param>
        /// <returns></returns>
        int GetInteger(string key, int defValue);

        /// <summary>
        /// Reads a string value from the settings.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="defValue">A default value if the setting doesn't exist.</param>
        /// <returns></returns>
        string GetString(string key, string defValue);

        /// <summary>
        /// Reads a list of comma-separated strings from the settings.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="defValues">A default array to return if the setting doesn't exist.</param>
        string[] GetStringArray(string key, string[] defValues);

        /// <summary>
        /// Writes a value to the settings.
        /// </summary>
        /// <param name="key">The name of the setting.</param>
        /// <param name="value">The value to write.</param>
        void SetValue(string key, object value);
    }
}
