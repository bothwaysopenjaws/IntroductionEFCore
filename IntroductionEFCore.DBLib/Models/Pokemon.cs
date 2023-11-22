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
    /// Pokémon
    /// </summary>
    [Table("Pokemon")]
    public class Pokemon
    {
        #region Fields

        /// <summary>
        /// Identifiant
        /// </summary>
        private int _Identifier;

        /// <summary>
        /// Nom du pokémon
        /// </summary>
        private string _Name;

        /// <summary>
        /// Niveau
        /// </summary>
        private int? _Level;

        /// <summary>
        /// Obtient l'espèce du pokémon
        /// </summary>
        private SpeciesPokemon _SpeciesPokemon;

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
        /// Obtient ou défini le nom
        /// </summary>
        public string Name
        {
            get => _Name;
            set => _Name = value;
        }

        /// <summary>
        /// Obtient ou défini l'espèce
        /// </summary>
        public SpeciesPokemon SpeciesPokemon 
        { 
            get => _SpeciesPokemon; 
            set => _SpeciesPokemon = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur de pokémon
        /// </summary>
        /// <param name="name">Nom</param>
        /// <param name="speciesPokemon">Espèce</param>
        public Pokemon(string name)
        {
            this.Name = name;
        }

        #endregion
    }
}
