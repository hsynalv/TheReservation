using Microsoft.Extensions.Configuration;

namespace API.Persistence;

static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            try
            {
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SGT.API"));
                configurationManager.AddJsonFile("appsettings.json");
            }
            catch
            {
                configurationManager.AddJsonFile("appsettings.json");
            }

            return configurationManager.GetConnectionString("DefaultConnection");
            //return configurationManager.GetConnectionString("PostgreSql");
        }
    }
}