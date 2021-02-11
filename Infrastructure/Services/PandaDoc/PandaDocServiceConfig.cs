using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.PandaDoc
{
    public class PandaDocServiceConfig
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public int ShareLifetimeInSeconds { get; set; }
    }
}
