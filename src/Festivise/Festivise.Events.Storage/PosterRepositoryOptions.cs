using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivise.Events.Storage
{
    public class PosterRepositoryOptions
    {
        public string DalleApiKey { get; set; }
        public string AzureBlobConnectionString { get; set; }
    }
}
