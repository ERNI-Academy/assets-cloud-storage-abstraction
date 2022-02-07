using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Abstraction
{
    public class ContainerClientBase
    {
        
        protected string ConnectionString 
        { 
            get {
                if (this.config != null) return "conectionstring from config";
                else throw new NotImplementedException(); 
            }
            set { }
        }
        private object config;
        public ContainerClientBase(object config)
        {
            this.config = config;
        }
        protected BlobServiceClient GetServiceClient()
        {
            
            BlobServiceClient blobServiceClient = new BlobServiceClient(this.ConnectionString);            
            return blobServiceClient;
        }
        protected async Task<Entity> GetEntityBlobAsync<Entity>(BlobClient blobJson) where Entity : class, new()
        {
            try
            {
                using (MemoryStream s = new MemoryStream())
                {
                    await blobJson.DownloadToAsync(s);
                    using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                    {
                        using (JsonReader reader = new JsonTextReader(sr))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            return serializer.Deserialize<Entity>(reader);
                        }
                    }
                }
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                return null;
            }
        }
    }
}
