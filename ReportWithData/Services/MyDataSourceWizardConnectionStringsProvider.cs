﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Native;
using DevExpress.DataAccess.Web;

namespace ReportWithData.Services
{
    public class MyDataSourceWizardConnectionStringsProvider : IDataSourceWizardConnectionStringsProvider
    {
        public Dictionary<string, string> GetConnectionDescriptions()
        {
            Dictionary<string, string> connections = AppConfigHelper.GetConnections().Keys.ToDictionary(x => x, x => x);

            // Customize the loaded connections list. 
            connections.Remove("DefaultConnection");
            connections.Add("Custom Connection", "Custom SQL Connection");
            return connections;
        }

        public DataConnectionParametersBase GetDataConnectionParameters(string name)
        {
            // Return custom connection parameters for the custom connection. 
            if (name == "Custom Connection")
            {
                return new MySqlConnectionParameters("localhost", "report_data", "root", "P@55word", 3306);
            }
            return AppConfigHelper.LoadConnectionParameters(name);
        }
    }
}
