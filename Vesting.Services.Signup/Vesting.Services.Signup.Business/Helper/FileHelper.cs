using System.Configuration;

namespace Vesting.Services.Signup.Business.Helper
{
    /// <summary>
    /// The helper class.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Gets the repository full path.
        /// </summary>
        /// <returns></returns>
        public static string GetRepositoryFilePath()
        {
            var configuredRepositoryPath = ConfigurationManager.AppSettings[Constants.RepositoryFilePath].Trim();
            var configuredRepositoryName = ConfigurationManager.AppSettings[Constants.RepositoryFileName].Trim();

            string fullPath = Constants.DefaultFullPath;
            if (!string.IsNullOrEmpty(configuredRepositoryPath) && !string.IsNullOrEmpty(configuredRepositoryName))
            {
                fullPath = string.Format(@"{0}\{1}", configuredRepositoryPath, configuredRepositoryName);
            }

            return fullPath;
        }
    }
}
