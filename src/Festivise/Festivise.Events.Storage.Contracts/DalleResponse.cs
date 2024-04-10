using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Festivise.Events.Storage.Contracts
{
    public class DalleResponse
    {
        public long Created { get; set; }
        public List<DalleImageData> Data { get; set; }
    }

    public class DalleImageData
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
