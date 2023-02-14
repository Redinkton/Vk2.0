using AngleSharp.Html.Dom;
using Core.Output;


namespace Infrastructure.Parser
{
    /// <summary>
    /// класс парсер
    /// </summary>
    public class MyParser
    {
        /// <summary>
        /// Парсим последний пост в группе.
        /// </summary>
        /// <param name="document">Html загялвная страница</param>
        /// <returns>Номер последнего поста</returns>
        public int ParseLastPostId(IHtmlDocument document)
        {
            int item = Int32.Parse(document.QuerySelector("a.post__anchor").GetAttribute("name").Split('_').Last());
            return item;
        }

        /// <summary>
        /// Парсинг комментариев.
        /// </summary>
        /// <param name="document">Html страница с постом</param>
        /// <returns>Текст, дату, лайки, ссылку на пост</returns>
        public List<Data> ParseComments(IHtmlDocument document)
        {
            int i = 0;
            List<Data> data = new List<Data>();

            var dates = document.GetElementsByClassName("wd_lnk");
            foreach (var date in dates)
            {
                var afterCheckDate = CheckDate.Check(date);
                if (afterCheckDate == null)
                    continue;

                if (afterCheckDate == DateTime.Now | afterCheckDate >= DateTime.Now.AddDays(-1) & afterCheckDate <= DateTime.Now)
                {
                     data.Add(new Data
                    {
                        Text = document.GetElementsByClassName("wall_reply_text")[i].TextContent,
                        Date = date.TextContent,
                        Likes = document.GetElementsByClassName("like_button_count")[i].TextContent,
                        Link = document.GetElementsByClassName("wd_lnk")[i].GetAttribute("href"),
                    });
                }
                else
                {
                    continue;
                }
                i++;
            }
            return data;
        }
    }
}
