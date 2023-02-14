using Core.Settings;
using System.Net;

namespace Core
{
    public class UrlSettings : IUrlSettings
    {
        public UrlSettings(int[] groupId, List<Dictionary<string, string>> proxies)
        {
            GroupId = groupId;
            Proxies = proxies;
        }
        public string BaseUrl { get; set; } = "https://vk.com/wall";

        public int[] GroupId { get; set; }
        public List<Dictionary<string, string>> Proxies { get; set; }
    }
}