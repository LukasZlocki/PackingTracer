using PackingTracer.Data.Configuration;
using System.Text;

namespace PackingTracer.Service.Services
{
    public static class ConfigurationService
    {
        public static string LoadSqlConfigurationFile()
        {
            const string _fileName = "sqlconfig.txt";
            string _sqlConfig = "";
            try
            {
                _sqlConfig = System.IO.File.ReadAllText(_fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return _sqlConfig;
        }
    }
}
