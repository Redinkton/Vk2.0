using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Settings
{
    public interface IUrlSettings
    {
        string BaseUrl { get; set; }

        int[] GroupId { get; set; }
        List<Dictionary<string, string>> Proxies { get; set; }
    }
}
