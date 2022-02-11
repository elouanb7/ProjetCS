using Microsoft.Win32;
using MyNamespace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
namespace Raminagrobis.WPF.pages
{
    /// <summary>
    /// Logique d'interaction pour ReferencePage.xaml
    /// </summary>
    public partial class ReferencePage : Page
    {
        private Reference_DTO Selectedreference = null;

        public ReferencePage()
        {
            InitializeComponent();
            liste_references.Visibility = Visibility.Hidden;
            insert_reference.Visibility = Visibility.Hidden;
        }
        private async void Btn_get_all_Click(object sender, RoutedEventArgs e)
        {
            liste_references.Visibility = Visibility.Visible;
            insert_reference.Visibility = Visibility.Hidden;

            Client client = new Client("https://localhost:44354/", new HttpClient());

            ICollection<Reference_DTO> liste = await client.AllReferencesAsync();
            liste_references.ItemsSource = liste;
        }

        private void Btn_insert_Click(object sender, RoutedEventArgs e)
        {
            liste_references.Visibility = Visibility.Hidden;
            insert_reference.Visibility = Visibility.Visible;
        }

        private void liste_reference_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
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
                    Thread.Sleep(100);
                    int u = 0;
                    StreamReader sr = new(file);
                    var lines = sr.ReadToEnd().Split("\n");
                    foreach (string line in lines)
                    {
                        if (u != 0 && u < lines.Length-1)
                        {
                            int[] fs = new int[1];
                            string[] element = line.Split(';');
                            var id = await client.SocieteFournisseurAsync(openFileDialog.SafeFileNames[i].Split(".")[0]);
                            fs[0] = id.Id;
                            await client.ReferencesPOSTAsync(new Reference_DTO()
                            {
                                ReferenceName = element[0],
                                Libelle = element[1],
                                Marque = element[2],
                                Desactive = false,
                                FournisseurID = fs
                            });
                        }
                        u++;
                    }
                    i++;
                }
            }
            liste_references.Visibility = Visibility.Visible;
            insert_reference.Visibility = Visibility.Hidden;

            ICollection<Reference_DTO> liste = await client.AllReferencesAsync();
            liste_references.ItemsSource = liste;
        }
    }
}
