using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Abstraction.Config
{
    public interface IContainerServiceConfig
    {
        string GetConnectionString();
    }
}
