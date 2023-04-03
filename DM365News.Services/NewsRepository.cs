using DM365News.Database;
using DM365News.Entities;

namespace DM365News.Services
{
    public class NewsRepository : INewsRepository
    {
        private readonly INewsParserService newsParser;

        public NewsRepository(INewsParserService newsParser)
        {
            this.newsParser = newsParser;
        }

        public async Task<IEnumerable<News>> GetAllAsync()
        {
            await AddNewsAsync();
            return await JsonProvider.DeserializeAsync<IEnumerable<News>>(DbConstants.NewsFileName);
        }

        private async Task AddNewsAsync()
        {
            var pageContent = await newsParser.LoadPage(DbConstants.Url);
            var allNewsHtml = newsParser.GetAllNewsFromUrl(pageContent);
            var allNews = newsParser.ParseNewsToCollection(allNewsHtml);
            await newsParser.SaveToFileAsync(allNews, DbConstants.NewsFileName);
        }
    }
}