using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroductionEFCore.DBLib.Models;
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


    #region Methods

    /// <summary>
    /// Ajoute une nouvelle espèce
    /// </summary>
    internal void AddPokemonSpecies()
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
