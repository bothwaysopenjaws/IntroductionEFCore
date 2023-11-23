using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IntroductionEFCore.Wpf.Views;

namespace IntroductionEFCore.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonTestView_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new TestView());
        }

        private void ButtonLookBetterView_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new LookBetterView());
        }
    }
}