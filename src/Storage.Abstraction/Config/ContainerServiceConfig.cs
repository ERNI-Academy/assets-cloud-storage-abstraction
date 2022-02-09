using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Abstraction.Config
{
    /// <summary>
    /// This implementation it's only a sample. Always return the development connectionstring. 
    /// </summary>
    public class ContainerServiceDevelopmentConfig : IContainerServiceConfig
    {
        public string GetConnectionString()
        {
            return "UseDevelopmentStorage=true";
        }
    }
}
