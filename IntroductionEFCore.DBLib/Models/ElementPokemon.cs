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
    /// Elément d'un pokémon
    /// </summary>
    [Table(nameof(ElementPokemon))]
    public class ElementPokemon
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
        /// Liste des espèces
        /// </summary>
        private List<SpeciesPokemon> _SpeciesPokemons;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient l'identifiant
        /// </summary>
        [Key]
        public int Identifier 
        { 
            get => _Identifier; 
            init => _Identifier = value; 
        }

        /// <summary>
        /// Obtient le nom
        /// </summary>
        public string Name 
        { 
            get => _Name; 
            set => _Name = value; 
        }

        /// <summary>
        /// Obtient ou défini la listes des espèces
        /// </summary>
        public List<SpeciesPokemon> SpeciesPokemons { get => _SpeciesPokemons; set => _SpeciesPokemons = value; }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ElementPokemon(string name)
        {
            this.Name = name;
            this.SpeciesPokemons  = new List<SpeciesPokemon>();
        }
        #endregion

    }
}
