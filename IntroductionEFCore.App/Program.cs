// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Threading.Channels;
using IntroductionEFCore.DBLib.Models;
using Microsoft.EntityFrameworkCore;
using PokeApiNet;
using Pokemon = IntroductionEFCore.DBLib.Models.Pokemon;

//Console.WriteLine("Hello, World!");


//SpeciesPokemon tadmorv = new SpeciesPokemon("Tadmorv", "");
//SpeciesPokemon grotadmorv = new SpeciesPokemon("Grotadmorv", "");

//var martin = new Pokemon("Martin" ) { SpeciesPokemon = tadmorv };
//var jules = new Pokemon("Jules") { SpeciesPokemon = grotadmorv };

//PokemonDBContext pokemonDBContext = new PokemonDBContext();

////pokemonDBContext.Add(martin);
////pokemonDBContext.Add(jules);
////pokemonDBContext.Remove(pokemonDBContext.Pokemons.First());
////pokemonDBContext.SaveChanges();

//PokeApiClient pokeClient = new PokeApiClient();

//await foreach (NamedApiResource<PokeApiNet.Pokemon> pokemonTemp in pokeClient.GetAllNamedResourcesAsync<PokeApiNet.Pokemon>())
//{
//    PokeApiNet.Pokemon? pokeDetail = await pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(pokemonTemp.Name);
//    Console.WriteLine($"Pokémon n° {pokeDetail.Id} - {pokemonTemp.Name}");

//    SpeciesPokemon spiciesPokemon = new(pokemonTemp.Name, pokemonTemp.Url);

//    foreach (PokemonType pokemonType in pokeDetail.Types)
//    {
//        var elementPokemon = pokemonDBContext.ElementPokemons.FirstOrDefault(pt => pt.Name == pokemonType.Type.Name);
//        if (elementPokemon is null)
//        {
//            elementPokemon = new ElementPokemon(pokemonType.Type.Name);

//        }
//        spiciesPokemon.ElementPokemons.Add(elementPokemon);

//    }
//}
//pokemonDBContext.SaveChanges();
//pokemonDBContext.Dispose();


/*
using (PokemonDBContext context = new())
{

    context.SpeciesPokemons
        .ToList()
        .Where(pokemon => pokemon.Name.StartsWith('e'))
        .ToList()
        .ForEach(p => Console.WriteLine(p.Name));
}*/


//using (PokemonDBContext context = new())
//{

//    foreach (ElementPokemon element in context.ElementPokemons.Include(p => p.SpeciesPokemons))
//    {
//        Console.WriteLine($"Element : {element.Name} - {element.SpeciesPokemons.Count()} espèce(s)");
//    }
//}


//using (PokemonDBContext context = new())
//{

//    foreach (ElementPokemon element in context.ElementPokemons
//        .Include(p => p.SpeciesPokemons)
//        )
//    {
//        Console.WriteLine($"Element : {element.Name} - {element.SpeciesPokemons.Count()} espèce(s)");
//    }

//}
bool keepGoing = true;

while (keepGoing)
{
    Console.WriteLine("""Rechercher par le nom : (Appuyez sur la touche "Entrée" pour sortir)""");
    string? userInput = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(userInput))
        keepGoing = false;
    else
    {
        using (PokemonDBContext context = new())
        {
            foreach (SpeciesPokemon sp in context.SpeciesPokemons
                .Include(p => p.ElementPokemons)
                .ToList()
                .Where(s => s.Name.Contains(userInput, StringComparison.InvariantCultureIgnoreCase))
                )
            {
                string elements = sp.ElementPokemons
                    .Aggregate("Elements : ", 
                        (stringResult, next) => stringResult += next.Name + ", ");
                Console.WriteLine($"Espèce : {sp.Name} - {elements}");
            }
        }
    }

}

