using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Abstraction.Contract
{
    public interface IBlobContainerClient
    {
        string GetConnectionString();
        Task<Azure.Storage.Blobs.BlobContainerClient> CreateContainerIfNotExist(string name = "");
        Task<string> UploadBlob(string id, object blob,string containerName);
        Task<object> Get(Guid id,string containerId);
        IEnumerable<object> Get(string containerId);
        Task<bool> RemoveBlob(Guid id,string containerId);


    }
}
