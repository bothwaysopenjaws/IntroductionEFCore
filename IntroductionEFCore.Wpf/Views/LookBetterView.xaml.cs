using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IntroductionEFCore.Wpf.ViewModels;

namespace IntroductionEFCore.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour LookBetterView.xaml
    /// </summary>
    public partial class LookBetterView : UserControl
    {

        public LookBetterView()
        {
            InitializeComponent();
            //this.DataContext = this;
            this.DataContext = new LookBetterViewViewModel();
        }

        private void DeleteSelectedObject_Click(object sender, RoutedEventArgs e)
         => ((LookBetterViewViewModel)this.DataContext).DeletePokemonSpecies();

        private void SaveSelectedObject_Click(object sender, RoutedEventArgs e)
         => ((LookBetterViewViewModel)this.DataContext).SavePokemonSpecies();
    }
}
