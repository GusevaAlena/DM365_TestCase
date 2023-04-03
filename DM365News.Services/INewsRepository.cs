using DM365News.Entities;

namespace DM365News.Services
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllAsync();
    }
}
