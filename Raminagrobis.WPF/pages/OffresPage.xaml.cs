using Microsoft.Win32;
using MyNamespace;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Raminagrobis.WPF.pages
{
    /// <summary>
    /// Logique d'interaction pour OffresPage.xaml
    /// </summary>
    public partial class OffresPage : Page
    {
        public OffresPage()
        {
            InitializeComponent();
            liste_offre.Visibility = Visibility.Hidden;
            insert_offre.Visibility = Visibility.Hidden;
        }

        private async void Btn_get_all_Click(object sender, RoutedEventArgs e)
        {
            liste_offre.Visibility = Visibility.Visible;
            insert_offre.Visibility = Visibility.Hidden;

            Client client = new Client("https://localhost:44354/", new HttpClient());

            var offres = await client.SemaineOffreAsync();

            liste_offre.ItemsSource = offres;

        }

        private void Btn_insert_Click(object sender, RoutedEventArgs e)
        {
            liste_offre.Visibility = Visibility.Hidden;
            insert_offre.Visibility = Visibility.Visible;

        }

        private void liste_offre_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void Btn_import_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44354/", new HttpClient());

            var week = await client.ListeMaxSemaineAsync();
            var panier = await client.SemainePanierAsync(week);

            OpenFileDialog openFileDialog = new();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                var i = 0;
                Stream[] files = openFileDialog.OpenFiles();
                foreach (Stream file in files)
                {
                    int u = 0;

                    StreamReader sr = new(file);
                    var lines = sr.ReadToEnd().Split("\n");

                    var offre = new Offre_DTO();
                    string[] fileInfo = openFileDialog.SafeFileNames[i].Split(".")[0].Split("_s");

                    foreach (string line in lines)
                    {
                        if (u != 0 && u < lines.Length - 1)
                        {
                            string[] element = line.Split(';');
                            var reference = await client.ReferenceAsync(element[0]);
                            var fournisseur = await client.SocieteFournisseurAsync(fileInfo[0]);
                            await client.OffresPOSTAsync(new Offre_DTO()
                            {
                                IdFournisseur = fournisseur.Id,
                                IdPanierGlobalDetail = panier.Details.Where(d => d.IdReference == reference.Id).Select(d => d.Id).First(),
                                Puht = element[2] != "" ? float.Parse(element[2]) : null
                            });
                        }
                        u++;
                    }

                    i++;
                }
            }
        }
    }
}
