using Storage.Abstraction.Contract;
using Storage.Abstraction;
using System;
using Storage.Abstraction.Config;

namespace App.Sample1
{
    /// <summary>
    /// Assumptions
    /// 
    /// We are using ContainerServiceDevelopmentConfig and always return UseDevelopmentStorage=true like connectionstring ONLY FOR LOCALMACHINE ENVIRONMENTS
    /// We are using .Result on each call because we are not on asyn method. (not nice we know ;)
    /// 
    /// )
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {



            // simple use of storage abstraction
            IContainerServiceConfig config = new ContainerServiceDevelopmentConfig();
            Console.WriteLine($"ConnectionString used: {config.GetConnectionString()}");

            Console.WriteLine("first sample about upload an object");
            IBlobContainerClient blobClient = new BlobContainerClient(config);
            var obj = new { name = "manu", age = 38 };
            Guid id = Guid.NewGuid();
            string containerName = "localcontainer";
            Console.WriteLine($"object used: {obj}");
            var blobLink = blobClient.UploadBlob(id.ToString(), obj, containerName).Result;
            Console.WriteLine($"Http code response: {blobLink}");


            Console.WriteLine("Second sample about delete an object");
            var res = blobClient.RemoveBlob(id, containerName).Result;
            Console.WriteLine($"response: {res}");
            Console.ReadLine();

        }
    }
}
