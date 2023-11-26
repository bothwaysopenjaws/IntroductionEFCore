using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroductionEFCore.DBLib.Models;

namespace IntroductionEFCore.Wpf.ViewModels
{

    /// <summary>
    /// Modèle Vue pour LookBetter
    /// </summary>
    class LookBetterViewViewModel
    {
        #region Fields

        /// <summary>
        /// Espèces
        /// </summary>
        private ObservableCollection<SpeciesPokemon> _SpeciesPokemons;

        /// <summary>
        /// Espèce sélectionnée
        /// </summary>
        private SpeciesPokemon? _SelectedSpeciesPokemon;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou défini la liste des espèces
        /// </summary>
        public ObservableCollection<SpeciesPokemon> SpeciesPokemons 
        { 
            get => _SpeciesPokemons; 
            set => _SpeciesPokemons = value; 
        }
        
        /// <summary>
        /// Obtient ou défini l'espèce selectionnée.
        /// </summary>
        public SpeciesPokemon? SelectedSpeciesPokemon 
        {
            get => _SelectedSpeciesPokemon; 
            set => _SelectedSpeciesPokemon = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur
        /// </summary>
        public LookBetterViewViewModel()
        {
            using (PokemonDBContext context = new())
            {
                this.SpeciesPokemons = new ObservableCollection<SpeciesPokemon>(context.SpeciesPokemons);
            }
        }

        #endregion
    }
}
