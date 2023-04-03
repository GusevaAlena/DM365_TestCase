using DM365News.Entities;
using HtmlAgilityPack;

namespace DM365News.Services
{
    public interface INewsParserService
    {
        Task<string> LoadPage(string url);
        IEnumerable<HtmlNode> GetAllNewsFromUrl(string pageContent);
        IEnumerable<News> ParseNewsToCollection(IEnumerable<HtmlNode> newsHtml);
        Task SaveToFileAsync(IEnumerable<News> allNews, string fileName);
    }
}
