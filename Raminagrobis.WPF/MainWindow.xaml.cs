using MyNamespace;
using Raminagrobis.WPF.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Raminagrobis.WPF
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

        private void Btn_adherent_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AdherentsPage();
        }

        private void Btn_fournisseur_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new FournisseurPage();
        }

        private void Btn_reference_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ReferencePage();
        }

        private void Btn_liste_achats_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ListeAchatPage();
        }

        private void Btn_panier_global_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PanierGlobalPage();
        }

        private void Btn_offre_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new OffresPage();
        }
    }
}
