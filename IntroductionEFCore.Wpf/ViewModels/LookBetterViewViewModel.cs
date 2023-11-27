using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroductionEFCore.DBLib.Models;
using Prism.Commands;
using WebAndSoft.Internal;

namespace IntroductionEFCore.Wpf.ViewModels;

/// <summary>
/// Modèle Vue pour LookBetter
/// </summary>
class LookBetterViewViewModel : ObservableObject
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

    /// <summary>
    /// Délégué pour l'ajout d'une espèce.
    /// </summary>
    private DelegateCommand<object> _CommandAddSpecies;

    #endregion

    #region Properties

    /// <summary>
    /// Obtient ou défini la liste des espèces
    /// </summary>
    public ObservableCollection<SpeciesPokemon> SpeciesPokemons 
    { 
        get => _SpeciesPokemons; 
        set => SetProperty(nameof(SpeciesPokemons), ref _SpeciesPokemons, value); 
    }
    
    /// <summary>
    /// Obtient ou défini l'espèce selectionnée.
    /// </summary>
    public SpeciesPokemon? SelectedSpeciesPokemon 
    {
        get => _SelectedSpeciesPokemon; 
        set => SetProperty(nameof(SelectedSpeciesPokemon), ref _SelectedSpeciesPokemon, value);
    }
    
    /// <summary>
    /// Obtient ou défini le délégué
    /// </summary>
    public DelegateCommand<object> CommandAddSpecies 
    { 
        get => _CommandAddSpecies; 
        set => _CommandAddSpecies = value; 
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructeur
    /// Instancie les commandes
    /// </summary>
    public LookBetterViewViewModel()
    {
        CommandAddSpecies = new DelegateCommand<object>(AddSpeciesPokemon, CanAddSpeciesPokemon)
            .ObservesProperty(() => SelectedSpeciesPokemon);

        using (PokemonDBContext context = new())
        {
            this.SpeciesPokemons = new ObservableCollection<SpeciesPokemon>(context.SpeciesPokemons);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Ajoute une nouvelle espèce
    /// </summary>
    internal void AddSpeciesPokemon(object parameter = null)
    {
        using (PokemonDBContext context = new())
        {
            SpeciesPokemon? newSpecies = context.SpeciesPokemons.FirstOrDefault(p => p.Name.Equals("Nouvel Espèce"));
            if (newSpecies is null)
            {
                newSpecies = new("Nouvel Espèce", "Description");
                context.SpeciesPokemons.Add(newSpecies);
                this.SpeciesPokemons.Add(newSpecies);
                context.SaveChanges();
            }

            this.SelectedSpeciesPokemon = newSpecies;
        }
    }

    /// <summary>
    /// Indique si on peut exécuter la commmande <see cref="AddSpeciesPokemon"/>
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns>Indique si c'est possible ou non</returns>
    internal bool CanAddSpeciesPokemon(object parameter = null) => this.SelectedSpeciesPokemon == null;

    /// <summary>
    /// Supprime une espèce
    /// </summary>
    internal void DeletePokemonSpecies()
    {
        using (PokemonDBContext context = new())
        {
            if (this.SelectedSpeciesPokemon is not null)
            {
                context.SpeciesPokemons.Remove(this.SelectedSpeciesPokemon);
                this.SpeciesPokemons.Remove(this.SelectedSpeciesPokemon);
                context.SaveChanges();
            }

            this.SelectedSpeciesPokemon = null;
        }
    }

    /// <summary>
    /// Supprime une espèce
    /// </summary>
    internal void SavePokemonSpecies()
    {
        using (PokemonDBContext context = new())
        {
            if (this.SelectedSpeciesPokemon is not null)
            {
                context.Update(this.SelectedSpeciesPokemon);
                context.SaveChanges();
            }
            this.SelectedSpeciesPokemon = null;
        }
    }








    #endregion
}
