using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames =new List<VideoGame>
        {
                new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo EPD", Publisher = "Nintendo" },
                new VideoGame { Id = 2, Title = "The Witcher 3: Wild Hunt", Platform = "PC", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
                new VideoGame { Id = 3, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
                new VideoGame { Id = 4, Title = "Minecraft", Platform = "PC", Developer = "Mojang Studios", Publisher = "Mojang" },
                new VideoGame { Id = 5, Title = "Red Dead Redemption 2", Platform = "PlayStation 4", Developer = "Rockstar Studios", Publisher = "Rockstar Games" }
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGame(int id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if (game is null)
            {
                return NotFound();
            }
            return Ok(game);

        }

        [HttpPost]
        public ActionResult<VideoGame> AddGame(VideoGame newGame)
        {
            if(newGame is null)
            {
                return BadRequest();
            }
            newGame.Id = videoGames.Max(g => g.Id) + 1;
            videoGames.Add(newGame);
            return CreatedAtAction(nameof(GetVideoGame), new { id = newGame.Id }, newGame);
        }
    }
}
