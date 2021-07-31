using CoinsAge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Controllers
{
    public class TableController : Controller
    {
        public TableController()
        {

        }

        public static CloudTable getTableStorage()
        {
            //read json app settings
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            IConfigurationRoot configure = builder.Build();
            //to get key access
            //once link, time to read the content to get the connectionstring
            CloudStorageAccount objectaccount = CloudStorageAccount.Parse(configure["ConnectionStrings:TableStorageConnection"]);

            CloudTableClient tableclient = objectaccount.CreateCloudTableClient(new TableClientConfiguration());
            //get table from storage account
            CloudTable table = tableclient.GetTableReference("Logging");
            return table;
        }

        public async Task UploadEntity(Logging log)
        {
            CloudTable table = getTableStorage();
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(log);
            TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
            Logging insertedLog = result.Result as Logging;

            return;
        }
    }
}
