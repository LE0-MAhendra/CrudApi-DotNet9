using CrudApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        //static private List<VideoGame> videoGames =new List<VideoGame>
        //{
        //        new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo EPD", Publisher = "Nintendo" },
        //        new VideoGame { Id = 2, Title = "The Witcher 3: Wild Hunt", Platform = "PC", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
        //        new VideoGame { Id = 3, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
        //        new VideoGame { Id = 4, Title = "Minecraft", Platform = "PC", Developer = "Mojang Studios", Publisher = "Mojang" },
        //        new VideoGame { Id = 5, Title = "Red Dead Redemption 2", Platform = "PlayStation 4", Developer = "Rockstar Studios", Publisher = "Rockstar Games" }
        //};

        private readonly VideoGameDbContext _context=context;

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync( id);
            if (game is null)
            {
                return NotFound();
            }
            return Ok(game);

        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddGame(VideoGame newGame)
        {
            if(newGame is null)
            {
                return BadRequest();
            }
            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGame), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGameID(int id, VideoGame updatesGame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            game.Title = updatesGame.Title;
            game.Platform = updatesGame.Platform;
            game.Developer = updatesGame.Developer;
            game.Publisher = updatesGame.Publisher;
            await _context.SaveChangesAsync();
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<VideoGame>>> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
