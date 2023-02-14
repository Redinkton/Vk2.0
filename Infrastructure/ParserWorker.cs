using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Core.Output;
using Core.Settings;
using Infrastructure.Parser;
using Infrastructure.Request;
using System.Reflection.Metadata.Ecma335;

namespace Infrastructure
{
    public class ParserWorker 
    {
        private bool IsActive { get; set; }
        IUrlSettings _urlSettings;
        Requests _newRequest;
        public List<Data> data;
        public event Action<object> OnCompleted;

        public ParserWorker(IUrlSettings urlSetting) 
        {
            _urlSettings = urlSetting;
        }
        public void Start()
        {
            IsActive= true;
            Worker();
        }
        public void Stop()
        {
            IsActive= false;
        }
        public void Worker()
        {
            _newRequest = new Requests(_urlSettings);

            Parallel.For(0, _urlSettings.GroupId.Length, i =>
            {
                if (!IsActive)
                    return;
               
                string htmlId = _newRequest.LastPostIdHtml(_urlSettings.GroupId[i]);
                if (htmlId == null)
                    return;

                HtmlParser domParser = new HtmlParser();
                var documentId = domParser.ParseDocument(htmlId);
                MyParser myParser = new MyParser();
                int lastPostId = myParser.ParseLastPostId(documentId);

                Parallel.For(lastPostId - 5, lastPostId, j =>
                {
                    string htmlComments = _newRequest.GetCommentsHtml(_urlSettings.GroupId[i], j);
                    if (htmlComments == null)
                        return;

                    var documentComments = domParser.ParseDocument(htmlComments);
                    List<Data> info = myParser.ParseComments(documentComments);
                    data = info;
                });
            });
            OnCompleted?.Invoke(this);
            IsActive = false;
        }
    }
}
