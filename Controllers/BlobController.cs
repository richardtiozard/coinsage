using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoinsAge.Controllers
{
    public class BlobController : Controller
    {
        public BlobController()
        {

        }

        private CloudBlobContainer getBlobStorageInformation()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            IConfigurationRoot configure = builder.Build();

            CloudStorageAccount objectaccount = CloudStorageAccount.Parse(configure["ConnectionStrings:BlobStorageConnection"]);
            CloudBlobClient blobclient = objectaccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobclient.GetContainerReference("coinsageblobcontainer");
            return container;
        }

        public string UploadBlob(string filename, IFormFile file)
        {
            CloudBlobContainer container = getBlobStorageInformation();
            CloudBlockBlob blob = container.GetBlockBlobReference(filename);
            var stream = file.OpenReadStream();

            blob.DeleteIfExistsAsync();

            blob.UploadFromStreamAsync(stream).Wait();

            string imageURL = blob.Uri.AbsoluteUri;
            
            return imageURL;
        }

        public string getImageURL(string filename)
        {
            CloudBlobContainer container = getBlobStorageInformation();
            CloudBlockBlob blob = container.GetBlockBlobReference(filename);
            string imageURL = blob.Uri.AbsoluteUri;

            return imageURL;
        }
    }
}
