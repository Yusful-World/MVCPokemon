using Microsoft.EntityFrameworkCore;
using MVCPokemon.Models;

namespace MVCPokemon.Data
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pokemon>().HasData(
                new()
                {
                    Id = 1,
                    Name = "Pikachu",
                    Owner = "Tunji",
                    Power = "Lightening",
                    ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/0/6087/2437349-pikachu.png",
                    Colour = "orange"
                },
                new()
                {
                    Id = 2,
                    Name = "Balbasaur",
                    Owner = "Yusuf",
                    Power = "Water",
                    ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891758-001bulbasaur.png",
                    Colour = "green"
                },
                new()
                {
                    Id = 3,
                    Name = "Charmander",
                    Owner = "Glory",
                    Power = "Fire",
                    ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891761-004charmander.png",
                    Colour = "darkorange"
                },
                new()
                {
                    Id = 4,
                    Name = "Squirtle",
                    Owner = "Oscar",
                    Power = "Stone",
                    ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891764-007squirtle.png",
                    Colour = "teal"
                }
            );
        }
    }
}
