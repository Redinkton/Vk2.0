using AngleSharp.Io;
using Core.Settings;
using Infrastructure.Log;
using System.Net;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Infrastructure.Request
{
    /// <summary>
    /// Класс запросов
    /// </summary>
    public class Requests
    {
        IUrlSettings _urlSettings;
        Random _rnd;
        WebProxy _proxy;

        public Requests(IUrlSettings urlSettings)
        {
            _urlSettings = urlSettings;
            _rnd = new Random();
        }
        /// <summary>
        /// Запрос в группу для получения html,
        /// где есть id последнего поста.
        /// </summary>
        /// <param name="groupId">id группы</param>
        /// <returns>Null - не прошел запрос, не пустой - прошел.</returns>
        public string LastPostIdHtml(int groupId)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{_urlSettings.BaseUrl}-{groupId}");
                request.Proxy = SetProxy();
                request.Method = "GET";
                request.Timeout= 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string source = null;

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    source = reader.ReadToEnd();
                }
                return source;
            }
            catch(Exception ex)
            {
                Logger.WriteLog(ex.HResult, ex.Message);
                return null;
            }
            
        }
        /// <summary>
        /// Запрос на пост в группе.
        /// </summary>
        /// <param name="groupId">id группы</param>
        /// <param name="postId">id поста</param>
        /// <returns></returns>
        public string GetCommentsHtml(int groupId, int postId)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{_urlSettings.BaseUrl}-{groupId}_{postId}");
                request.Proxy = SetProxy();
                request.Method = "GET";
                request.Timeout = 5000;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string source = null;

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    source = reader.ReadToEnd();
                }
                return source;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.HResult, ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Устанавливаем прокси на каждый запрос.
        /// </summary>
        /// <returns>Возвращаем прокси</returns>
        public WebProxy SetProxy()
        {
            int randomIndex = _rnd.Next(_urlSettings.Proxies.Count);
            WebProxy myproxy = new WebProxy($"{_urlSettings.Proxies[randomIndex]["host"]}", Int32.Parse(_urlSettings.Proxies[randomIndex]["port"]));
            myproxy.BypassProxyOnLocal = false;
            return myproxy;
        }
    }
}