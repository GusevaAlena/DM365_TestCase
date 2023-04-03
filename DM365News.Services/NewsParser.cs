using DM365News.Database;
using DM365News.Entities;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Text;

namespace DM365News.Services
{
    public class NewsParser : INewsParserService
    {
        private readonly List<News> allNews = new();

        public async Task<string> LoadPage(string url)
        {
            var client = new HttpClient();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return (await client.GetStringAsync(url))
                .Replace("&nbsp;", " ").Replace("&#37;", "%");
        }

        public IEnumerable<HtmlNode> GetAllNewsFromUrl(string pageContent)
        {
            var document = new HtmlDocument();
            document.LoadHtml(pageContent);
            return document.DocumentNode.QuerySelectorAll(DbConstants.AllNewsSelector);
        }

        public IEnumerable<News> ParseNewsToCollection(IEnumerable<HtmlNode> allNewsHtml)
        {
            foreach (var node in allNewsHtml)
            {
                var news = new News();
                var newsType = node.QuerySelector(DbConstants.NewsInfoSelector)
                    .QuerySelector(DbConstants.NewsTypeSelector).InnerText.Trim();

                if (newsType.Contains(DbConstants.ArticleType))
                    continue;

                news.Title = node.QuerySelector(DbConstants.NewsReferenceSelector).InnerText.Trim();
                news.Date = node.QuerySelector(DbConstants.NewsInfoSelector)
                    .QuerySelector(DbConstants.NewsDateSelector).InnerText.Trim();
                news.Reference = DbConstants.MainSiteUrl + node.QuerySelector(DbConstants.NewsReferenceSelector)
                    .GetAttributeValue(DbConstants.ReferenceAttribute, "");
                news.Description = node.QuerySelector(DbConstants.NewsNoticeSelector)?.InnerText.Trim();
                news.Type = newsType;
                news.ImagePath = DbConstants.MainSiteUrl + node.QuerySelector(DbConstants.NewsImageSelector)
                    .GetAttributeValue(DbConstants.ImageSrcAttribute, "");
                allNews.Add(news);
            }

            return allNews;
        }

        public async Task SaveToFileAsync(IEnumerable<News> allNews, string fileName)
        {
            await JsonProvider.SerializeAsync(fileName, allNews);
        }
    }
}
