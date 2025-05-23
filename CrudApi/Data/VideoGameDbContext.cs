using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options): DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo EPD", Publisher = "Nintendo" },
                new VideoGame { Id = 2, Title = "The Witcher 3: Wild Hunt", Platform = "PC", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
                new VideoGame { Id = 3, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
                new VideoGame { Id = 4, Title = "Minecraft", Platform = "PC", Developer = "Mojang Studios", Publisher = "Mojang" },
                new VideoGame { Id = 5, Title = "Red Dead Redemption 2", Platform = "PlayStation 4", Developer = "Rockstar Studios", Publisher = "Rockstar Games" }

                );
        }
    }

    
}
