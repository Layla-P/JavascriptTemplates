using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavascriptTemplates.Models;
using Microsoft.EntityFrameworkCore;

namespace JavascriptTemplates.Database
{
    public class VideoGameRepository : IVideoGameRepository
    {
        private readonly JsContext _context;
        public VideoGameRepository(JsContext context)
        {
            _context = context;
        }


        public async Task<VideoGame> GetByIdAsync(int id)
        {
            try
            {
                return await _context.VideoGames.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

        public async Task<List<VideoGame>> GetAllAsync()
        {
            try
            {
                //add id to search so only bring back user's items once identity is in
                return await _context.VideoGames.Select(e => e).OrderBy(e => e.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

        public async Task AddAsync(VideoGame videoGame)
        {
            try
            {
                if (videoGame == null) throw new InvalidOperationException("Unable to add a null entity to the repository.");
                await _context.VideoGames.AddAsync(videoGame);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var videoGame = await _context.VideoGames.FirstOrDefaultAsync(e => e.Id == id);
                _ = _context.VideoGames.Remove(videoGame).Entity;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }

        public async Task DeleteAllAsync()
        {
            try
            {
                _context.VideoGames.RemoveRange(await GetAllAsync());
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                //todo: add in logging
                throw;
            }
        }


    }
}
