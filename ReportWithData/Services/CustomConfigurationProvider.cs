using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportWithData.Services
{
    public class CustomConfigurationProvider
    {
        readonly IWebHostEnvironment hostingEnvironment;
        public CustomConfigurationProvider(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public IDictionary<string, string> GetGlobalConnectionStrings()
        {
            var connectionStrings = new Dictionary<string, string>
            {
                [$"ConnectionStrings:ReportConnection"] = "XpoProvider=MySql;Server=localhost;User ID=root;Password=P@55word;Database=report_data;Persist Security Info= true;Charset=utf8",
                [$"ConnectionStrings:Vehicles_InMemory"] = "XpoProvider=SQLite;Data Source=Data/vehicles.db",
                [$"ConnectionStrings:Cars_InMemory"] = "XpoProvider=SQLite;Data Source=Data/cars.db;"
            };

            //return new ConfigurationBuilder()
            //    .SetBasePath(hostingEnvironment.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
            //    .AddInMemoryCollection(connectionStrings)
            //    .AddEnvironmentVariables()
            //    .Build()
            //    .GetSection("ConnectionStrings")
            //    .AsEnumerable(true)
            //    .ToDictionary(x => x.Key, x => x.Value);

            return new ConfigurationBuilder()
                            .AddInMemoryCollection(connectionStrings)
                            .AddEnvironmentVariables()
                            .Build()
                            .GetSection("ConnectionStrings")
                            .AsEnumerable(true)
                            .ToDictionary(x => x.Key, x => x.Value);
        }

        public IConfigurationSection GetReportDesignerWizardConfigurationSection()
        {
            var connectionStrings = new Dictionary<string, string>
            {
                [$"ConnectionStrings:VehiclesInMemory"] = "XpoProvider=SQLite;Data Source=Data/vehicles.db",
                [$"ConnectionStrings:CarsInMemory"] = "XpoProvider=SQLite;Data Source=Data/cars.db;"
            };
            return new ConfigurationBuilder()
              .SetBasePath(hostingEnvironment.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
              .AddInMemoryCollection(connectionStrings)
              .Build()
              .GetSection("ConnectionStrings");
        }
    }
}
