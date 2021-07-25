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

        public IActionResult Index()
        {
            return View();
        }

        private CloudBlobContainer getBlobStorageInformation()
        {
            //step 1: read json
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            IConfigurationRoot configure = builder.Build();
            //to get key access
            //once link, time to read the content to get the connectionstring
            CloudStorageAccount objectaccount = CloudStorageAccount.Parse(configure["ConnectionStrings:BlobStorageConnection"]);
            CloudBlobClient blobclient = objectaccount.CreateCloudBlobClient();
            //step 2: how to create a new container in the blob storage account.
            CloudBlobContainer container = blobclient.GetContainerReference("coinsageblobcontainer");
            return container;
        }

        //step 3: create a page to show the successful step - whether you success
        //to build the container or not
        public ActionResult CreateBlobContainer()
        {
            //refer to the container
            CloudBlobContainer container = getBlobStorageInformation();
            ViewBag.Success = container.CreateIfNotExistsAsync().Result;
            ViewBag.BlobContainerName = container.Name;
            return View();
        }

        public string UploadBlob(string filename, IFormFile file)
        {
            // The code in this section goes here
            CloudBlobContainer container = getBlobStorageInformation();
            CloudBlockBlob blob = container.GetBlockBlobReference(filename);
            var stream = file.OpenReadStream();
            
            blob.UploadFromStreamAsync(stream).Wait();

            string imageURL = blob.Uri.AbsoluteUri;
            
            return imageURL;
        }

        public ActionResult ListItemsAsGallery()
        {
            CloudBlobContainer container = getBlobStorageInformation();
            //Step 2: create the empty list to store for the blobs list information
            List<string> blobs = new List<string>();
            //step 3: get the listing record from the blob storage
            BlobResultSegment result = container.ListBlobsSegmentedAsync(null).Result;
            //step 4: to read blob listing from the storage
            foreach (IListBlobItem item in result.Results)
            {
                //step 4.1. check the type of the blob : block blob or directory or page block
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    blobs.Add(blob.Name + "#" + blob.Uri.ToString());
                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory blob = (CloudBlobDirectory)item;
                    blobs.Add(blob.Uri.ToString());
                }
            }
            return View(blobs);
        }
    }
}
