# About

**Cloud Storage Abstraction** is a small dll ( on the next iteration, it will be a nuget package) that provides a robust and reusable implementations.

The main focus is work with CRUD approach with Azure Storage.

<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
<!-- ALL-CONTRIBUTORS-BADGE:END -->

## Built With

- [.Net 6.0](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
- [c# 8](https://docs.microsoft.com/es-es/dotnet/csharp/whats-new/csharp-8)

## Features

- Create Container
- Upload Blob
- Get list of blobs
- Get concrete blob
- Delete blob

## Getting Started

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

- take care about that sample are instances directly. In general situation, we should use DI.

## Contributing

Please see our [Contribution Guide](CONTRIBUTING.md) to learn how to contribute.

## License

![MIT](https://img.shields.io/badge/License-MIT-blue.svg)

(LICENSE) © {{Year}} [ERNI - Swiss Software Engineering](https://www.betterask.erni)

## Code of conduct

Please see our [Code of Conduct](CODE_OF_CONDUCT.md)

## Stats

![https://repobeats.axiom.co/api/embed/4564855c7fec933f06c61413a4403a3aff4c28fd.svg](https://repobeats.axiom.co/api/embed/4564855c7fec933f06c61413a4403a3aff4c28fd.svg)

## Follow us

[![Twitter Follow](https://img.shields.io/twitter/follow/ERNI?style=social)](https://www.twitter.com/ERNI)
[![Twitch Status](https://img.shields.io/twitch/status/erni_academy?label=Twitch%20Erni%20Academy&style=social)](https://www.twitch.tv/erni_academy)
[![YouTube Channel Views](https://img.shields.io/youtube/channel/views/UCkdDcxjml85-Ydn7Dc577WQ?label=Youtube%20Erni%20Academy&style=social)](https://www.youtube.com/channel/UCkdDcxjml85-Ydn7Dc577WQ)
[![Linkedin](https://img.shields.io/badge/linkedin-31k-green?style=social&logo=Linkedin)](https://www.linkedin.com/company/erni)

## Contact

📧 [esp-services@betterask.erni](mailto:esp-services@betterask.erni)

Manu Delgado  - [@mdelgadodiaz83](https://twitter.com/MDelgadoDiaz83) - mdelgadodiaz83@gmail.com

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- ALL-CONTRIBUTORS-LIST:END -->
This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
