using MVCPokemon.Models;

namespace MVCPokemon.Data
{
    public class ListPokemon
    {

        public static List<Pokemon> Pokemons =
        [
            new(){Name = "Pikachu", Owner = "Tunji", Power = "Lightening", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/0/6087/2437349-pikachu.png", Colour = "orange"},
            new(){Name = "Balbasaur", Owner = "Yusuf", Power = "Water", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891758-001bulbasaur.png", Colour = "green"},
            new(){Name = "Charmander", Owner = "Glory", Power = "Fire", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891761-004charmander.png", Colour = "darkorange"},
            new(){Name = "Squirtle", Owner = "Oscar", Power = "Stone", ImageUrl = "https://www.giantbomb.com/a/uploads/scale_small/13/135472/1891764-007squirtle.png", Colour = "teal"}
        ];
    }
}
