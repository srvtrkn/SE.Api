using System.IO;
using Microsoft.Extensions.Configuration;
namespace SE.Service.Helpers
{
    public class AppSettingsHelper
    {
        private static IConfigurationRoot root;
        private static IConfigurationRoot Root
        {
            get
            {
                if (root == null)
                {
                    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                    configurationBuilder.AddJsonFile(path, false);
                    root = configurationBuilder.Build();
                }
                return root;
            }
        }
        public static string GetProperty(string root, string property)
        {
            var appSetting = Root.GetSection(root);
            return appSetting[property];
        }
    }
}
