using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntroductionEFCore.DBLib.Models
{

    /// <summary>
    /// Contexte de données de l'application
    /// </summary>
    public class PokemonDBContext : DbContext
    {

        #region Liste des DBSets

        /// <summary>
        /// Liste des pokémons
        /// </summary>
        public DbSet<Pokemon> Pokemons { get; set; }

        /// <summary>
        /// Liste des espèces
        /// </summary>
        public DbSet<SpeciesPokemon> SpeciesPokemons { get; set; }

        /// <summary>
        /// Liste des éléments
        /// </summary>
        public DbSet<ElementPokemon> ElementPokemons { get; set; }

        #endregion

        #region Methods


        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=PokemonDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }


        #endregion

    }
}

