using MyNamespace;
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

namespace Raminagrobis.WPF.pages
{
    /// <summary>
    /// Logique d'interaction pour AdherentsPage.xaml
    /// </summary>
    public partial class AdherentsPage : Page
    {
        private Adherent_DTO SelectedAdherent = null;

        public AdherentsPage()
        {
            InitializeComponent();
            liste_adherent.Visibility = Visibility.Hidden;
            insert_adherent.Visibility = Visibility.Hidden;
            update_adherent.Visibility = Visibility.Hidden;
        }

        private async void Btn_get_all_Click(object sender, RoutedEventArgs e)
        {
            liste_adherent.Visibility = Visibility.Visible;
            insert_adherent.Visibility = Visibility.Hidden;
            update_adherent.Visibility = Visibility.Hidden;

            Client client = new Client("https://localhost:44354/", new HttpClient());

            ICollection<Adherent_DTO> adherents = await client.AllAdherentsAsync();
            liste_adherent.ItemsSource = adherents;
        }

        private void Btn_insert_Click(object sender, RoutedEventArgs e)
        {
            liste_adherent.Visibility = Visibility.Hidden;
            insert_adherent.Visibility = Visibility.Visible;
            update_adherent.Visibility = Visibility.Hidden;
        }

        private void Btn_modify_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedAdherent != null)
            {
                liste_adherent.Visibility = Visibility.Hidden;
                insert_adherent.Visibility = Visibility.Hidden;
                update_adherent.Visibility = Visibility.Visible;

                input_update_ste.Text = SelectedAdherent.Societe;
                if (SelectedAdherent.Civilite == true) {
                    checkbox_update_h.IsChecked = true;
                    checkbox_update_f.IsChecked = false;
                } else
                {
                    checkbox_update_h.IsChecked = false;
                    checkbox_update_f.IsChecked = true;
                }
                input_update_nom.Text = SelectedAdherent.Nom;
                input_update_prenom.Text = SelectedAdherent.Prenom;
                input_update_email.Text = SelectedAdherent.Email;
                input_update_adresse.Text = SelectedAdherent.Adresse;
                checkbox_update_desactive.IsChecked = SelectedAdherent.Desactive;
            } else
            {
                _ = MessageBox.Show("Veuillez séléctionner un adhérent dans le tableau");
            }
            
        }

        private void liste_adherent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Adherent_DTO sa = (Adherent_DTO)liste_adherent.SelectedItem;
            if (sa != null) { 
                btn_update.Width = 90;
                SelectedAdherent = sa;
                btn_update.Content = $"Modifier (id: {SelectedAdherent.Id})";
            } else
            {
                btn_update.Width = 75;
                btn_update.Content = $"Modifier";
            }
        }

        private async void Btn_valid_update_form_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44354/", new HttpClient());
            
            if (input_update_ste != null && (checkbox_update_h.IsChecked == true ^ checkbox_update_f.IsChecked == true) &&  input_update_nom != null && input_update_prenom != null && input_update_email != null && input_update_adresse != null)
            {
                await client.AdherentsPUTAsync(new Adherent_DTO()
                {
                    Id = SelectedAdherent.Id,
                    Societe = input_update_ste.Text,
                    Civilite = checkbox_update_h.IsChecked == true ? true : false,
                    Nom = input_update_nom.Text,
                    Prenom = input_update_prenom.Text,
                    Email = input_update_email.Text,
                    Adresse = input_update_adresse.Text,
                    Desactive = (bool)checkbox_update_desactive.IsChecked
                });

                liste_adherent.Visibility = Visibility.Visible;
                update_adherent.Visibility = Visibility.Hidden;
                ICollection<Adherent_DTO> adherents = await client.AllAdherentsAsync();
                liste_adherent.ItemsSource = adherents;
            }
            else
            {
                _ = MessageBox.Show("Veuillez renseigner tous les champs");
            }
        }

        private async void Btn_valid_insert_form_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44354/", new HttpClient());
            
            if (input_insert_ste != null && (checkbox_insert_h.IsChecked == true ^ checkbox_insert_f.IsChecked == true) && input_insert_nom != null && input_insert_prenom != null && input_insert_email != null && input_insert_adresse != null)
            {
                await client.AdherentsPOSTAsync(new Adherent_DTO()
                {
                    Societe = input_insert_ste.Text,
                    Civilite = checkbox_insert_h.IsChecked == true ? true : false,
                    Nom = input_insert_nom.Text,
                    Prenom = input_insert_prenom.Text,
                    Email = input_insert_email.Text,
                    Adresse = input_insert_adresse.Text,
                    DateAdhesion = DateTime.Now,
                    Desactive = false
                });

                liste_adherent.Visibility = Visibility.Visible;
                insert_adherent.Visibility = Visibility.Hidden;
                ICollection<Adherent_DTO> adherents = await client.AllAdherentsAsync();
                liste_adherent.ItemsSource = adherents;
            }
            else
            {
                _ = MessageBox.Show("Veuillez renseigner tous les champs");
            }
        }
    }
}
