using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Newtonsoft.Json;
using Storage.Abstraction.Config;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Abstraction
{
    public class ContainerClientBase
    {
        protected string ConnectionString => config.GetConnectionString();

        private readonly IContainerServiceConfig config;
        private readonly JsonSerializer serializer;
        
        public ContainerClientBase(IContainerServiceConfig config)
        {
            this.config = config;
            this.serializer = new JsonSerializer();
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
                            return this.serializer.Deserialize<Entity>(reader);
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
