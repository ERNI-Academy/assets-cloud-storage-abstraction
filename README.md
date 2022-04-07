# About 
**Cloud Storage Abstraction** is a small dll ( on the next iteration, it will be a nuget package) that provides a robust and reusable implementations. 

The main focus is work with CRUD approach with Azure Storage.

## Built With

- [.Net 6.0](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
- [c# 8](https://docs.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-8)


# Features
- Create Container
- Upload Blob
- Get list of blobs
- Get concrete blob
- Delete blob

# Getting Started
At this point, we have to use this project like dll or directly on our production projects.

On next releases, we transform the solution into nuget. 

## Prerequisites

- [.Net 6.0](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
- [c# 8](https://docs.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-8)


## Dependencies

- Newtonsoft 
- Azure.Storage.Blob v12 
- .Net 6.0
- System.Text.Json

## Installation
At this point, it is possible to use that asset:
- Cloning the repo and use it directly on you solution. On this way, you will have access too entire code. 
- Using the dll located on Release folder

## Notes

- the interface **IContainerServiceConfig** has a default implementation that is forbidden use it on production. **ALWAYS RETURN** a connection srting for the Azure Storage Emulator. 
- You should implement your own class where you could manage your proper connectionstring

## samples

```c#
 IContainerServiceConfig config = new ContainerServiceDevelopmentConfig();
 Console.WriteLine($"ConnectionString used: {config.GetConnectionString()}");
 Console.WriteLine("first sample about upload an object");
 IBlobContainerClient blobClient = new BlobContainerClient(config);
 var obj = new { name = "Smith", age = 38 };
 Guid id = Guid.NewGuid();
 string containerName = "localcontainer";
 Console.WriteLine($"object used: {obj}");
 var blobLink = blobClient.UploadBlob(id.ToString(), obj, containerName).Result;
 Console.WriteLine($"Http code response: {blobLink}");
```
* take care about that sample are instances directly. In general situation, we should use DI. 

# Contributing

Please see our [Contribution Guide](CONTRIBUTING.md) to learn how to contribute.

# License

[MIT](LICENSE) © 2022 [ERNI - Swiss Software Engineering](https://www.betterask.erni)

**Contact:** 

Manu Delgado  - [@mdelgadodiaz83](https://twitter.com/MDelgadoDiaz83) - mdelgadodiaz83@gmail.com