using Microsoft.Win32;
using MyNamespace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
    /// Logique d'interaction pour ListeAchatPage.xaml
    /// </summary>
    public partial class ListeAchatPage : Page
    {
        private ListeAchat_DTO SelectedListe = null;

        public ListeAchatPage()
        {
            InitializeComponent();
            liste_achat.Visibility = Visibility.Hidden;
            liste_details.Visibility = Visibility.Hidden;
            insert_liste.Visibility = Visibility.Hidden;
        }

        private async void Btn_get_all_Click(object sender, RoutedEventArgs e)
        {
            liste_achat.Visibility = Visibility.Visible;
            liste_details.Visibility = Visibility.Hidden;
            insert_liste.Visibility = Visibility.Hidden;

            Client client = new Client("https://localhost:44354/", new HttpClient());

            ICollection<ListeAchat_DTO> liste = await client.AllListeAchatAsync();
            liste_achat.ItemsSource = liste;
        }

        private void Btn_see_details_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedListe != null)
            {
                liste_achat.Visibility = Visibility.Hidden;
                liste_details.Visibility = Visibility.Visible;
                insert_liste.Visibility = Visibility.Hidden;

                liste_details.ItemsSource = SelectedListe.Details;
            }
            else
            {
                _ = MessageBox.Show("Veuillez séléctionner une liste dans le tableau");

            }
        }

        private void Btn_insert_Click(object sender, RoutedEventArgs e)
        {
            liste_achat.Visibility = Visibility.Hidden;
            liste_details.Visibility = Visibility.Hidden;
            insert_liste.Visibility = Visibility.Visible;
        }

        private void liste_achat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListeAchat_DTO sa = (ListeAchat_DTO)liste_achat.SelectedItem;
            if (sa != null)
            {
                btn_see_details.Width = 90;
                SelectedListe = sa;
                btn_see_details.Content = $"Details (id: {SelectedListe.Id})";
            }
            else
            {
                btn_see_details.Width = 75;
                btn_see_details.Content = $"Details";
            }
        }

        private async void btn_SelectCSV_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44354/", new HttpClient());

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

                    var details = new ListeAchatDetails_DTO[lines.Length - 2];

                    foreach (string line in lines)
                    {
                        if (u != 0 && u < lines.Length - 1)
                        {
                            string[] element = line.Split(';');
                            var reference = await client.ReferenceAsync(element[0]);
                            details[u-1] = new ListeAchatDetails_DTO()
                            {
                                IdReference = reference.Id,
                                Quantite = (Convert.ToInt32(element[1]))
                            };
                        }
                        u++;
                    }

                    string[] fileInfo = openFileDialog.SafeFileNames[i].Split(".")[0].Split("_s");
                    var adherent = await client.NameAdherentAsync(fileInfo[0]);
                    await client.ListeAchatPOSTAsync(new ListeAchat_DTO()
                    {
                        IdAdherent = adherent.Id,
                        Semaine = Convert.ToInt32(fileInfo[1]),
                        Details = details
                    });
                    i++;
                }
            }
            liste_achat.Visibility = Visibility.Visible;
            insert_liste.Visibility = Visibility.Hidden;

            ICollection<Reference_DTO> liste = await client.AllReferencesAsync();
            liste_achat.ItemsSource = liste;
        }
    }
}
