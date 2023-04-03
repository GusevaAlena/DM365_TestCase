using DM365News.Entities;
using DM365News.Services;
using Microsoft.AspNetCore.Mvc;

namespace DM365WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository newsRepository;
        public NewsController(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<News>> Index()
        {
            return await newsRepository.GetAllAsync();
        }
    }
}
