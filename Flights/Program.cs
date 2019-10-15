using Microsoft.Extensions.Configuration;
using Airport.DataAccess;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Airport.Domain;
using Airport.Service;

namespace Airport.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot.GetConnectionString("DebugConnectionString");
            var providerName = configurationRoot.GetSection("AppConfig").GetChildren().Single(item => item.Key == "ProviderName").Value;

            DbProviderFactories.RegisterFactory(providerName, SqlClientFactory.Instance);

            Repository<Flight> repository = new Repository<Flight>(connectionString, providerName);

            TicketSale ticketSale = new TicketSale(connectionString, providerName);
            ticketSale.BuyTicket();
        }
    }
}
