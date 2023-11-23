using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionEFCore.DBLib.Models
{
    /// <summary>
    /// Espèce du pokémon
    /// </summary>
    [Table("SpeciesPokemon")]
    public class SpeciesPokemon
    {
        #region Fields

        /// <summary>
        /// Identifiant
        /// </summary>
        private int _Identifier;

        /// <summary>
        /// Nom
        /// </summary>
        private string _Name;

        /// <summary>
        /// Description
        /// </summary>
        private string _Description;

        /// <summary>
        /// Liste des éléments de l'espèce du pokémon
        /// </summary>
        private List<ElementPokemon> _ElementPokemons;

        /// <summary>
        /// Liste des pokémons
        /// </summary>
        private List<Pokemon> _Pokemons;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient l'identifiant
        /// </summary>
        [Key]
        public int Identifier 
        { 
            get => _Identifier; 
            set => _Identifier = value; 
        }

        /// <summary>
        /// Obtient le nom
        /// </summary>
        public string Name { get => _Name; set => _Name = value; }

        /// <summary>
        /// Obtient la description
        /// </summary>
        public string Description { get => _Description; set => _Description = value; }


        /// <summary>
        /// Obtient la liste des éléments de l'espèce du pokémon
        /// </summary>
        public List<ElementPokemon> ElementPokemons { get => _ElementPokemons; set => _ElementPokemons = value; }

        /// <summary>
        /// Liste des pokémons
        /// </summary>
        public List<Pokemon> Pokemons
        { 
            get => _Pokemons; 
            set => _Pokemons = value;
        }


        #endregion

        #region Constructor

        public SpeciesPokemon(string name, string description)
        {
            this.Pokemons = new List<Pokemon>();
            this.Name = name;
            this.Description  = description;
            this.ElementPokemons = new List<ElementPokemon>();

        }
        #endregion


    }
}
