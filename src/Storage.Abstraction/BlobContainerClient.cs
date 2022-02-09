using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Newtonsoft.Json;
using Storage.Abstraction.Config;
using Storage.Abstraction.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Abstraction
{
    public class BlobContainerClient : ContainerClientBase, IBlobContainerClient
    {
        private BlobServiceClient serviceClient;
        public BlobContainerClient(IContainerServiceConfig config) : base(config)
        {
            serviceClient = this.GetServiceClient();
        }
        public async Task<Azure.Storage.Blobs.BlobContainerClient> CreateContainerIfNotExist(string name = "")
        {
            string actualName = name ?? ("container" + Guid.NewGuid().ToString());
            Azure.Response<Azure.Storage.Blobs.BlobContainerClient> containerClient = null;
            var exist = serviceClient.GetBlobContainerClient(actualName).Exists();
            if (!exist)
            {
                containerClient = await serviceClient.CreateBlobContainerAsync(actualName);
                return containerClient.Value;
            }
            return serviceClient.GetBlobContainerClient(actualName);
        }
        public async Task<object> Get(Guid id, string containerId)
        {
            Azure.Storage.Blobs.BlobContainerClient containerClient = null;
            containerClient = await CreateContainerIfNotExist(containerId);
            BlobClient blobJson = containerClient.GetBlobClient(id.ToString());
            object blob = await GetEntityBlobAsync<object>(blobJson);
            
            return blob;
        }
        public  IEnumerable<object> Get(string containerId)
        {
            Azure.Storage.Blobs.BlobContainerClient containerClient = null;
            containerClient =  CreateContainerIfNotExist(containerId).Result;

            foreach (BlobItem blob in containerClient.GetBlobs(BlobTraits.None, BlobStates.None, string.Empty))
            {
                yield return Get(new Guid(blob.Name), containerId);
            }
        }
        public string GetConnectionString()
        {
            return this.ConnectionString;
        }
        public async Task<bool> RemoveBlob(Guid id,string containerId)
        {
            Azure.Storage.Blobs.BlobContainerClient containerClient = await CreateContainerIfNotExist(containerId);
            BlobClient blobClient = containerClient.GetBlobClient(id.ToString());
            try
            {
                await blobClient.DeleteAsync();
            }
            catch (RequestFailedException ex)
               when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                return false;
            }
            return true;
        }
        public async Task<string> UploadBlob(string id, object blob, string containerName)
        {
            Azure.Storage.Blobs.BlobContainerClient containerClient = await CreateContainerIfNotExist(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(id);
            var objToJSON = JsonConvert.SerializeObject(blob);
            var res = await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(objToJSON)),
                               new BlobHttpHeaders()
                               {
                                   ContentType = "application/json"
                               });
            return res.GetRawResponse().Status.ToString();
        }
    }
}
