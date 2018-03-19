using System.Collections.Generic;
using System.Threading.Tasks;
using JavascriptTemplates.Models;

namespace JavascriptTemplates.Database
{
    public interface IVideoGameRepository
    {
        Task<VideoGame> GetByIdAsync(int id);
        Task<List<VideoGame>> GetAllAsync();
        Task AddAsync(VideoGame videoGame);
        Task DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}