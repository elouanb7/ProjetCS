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
    /// Logique d'interaction pour FournisseurPage.xaml
    /// </summary>
    public partial class FournisseurPage : Page
    {
        private Fournisseur_DTO SelectedFournisseur = null;

        public FournisseurPage()
        {
            InitializeComponent();
            liste_fournisseur.Visibility = Visibility.Hidden;
            insert_fournisseur.Visibility = Visibility.Hidden;
            update_fournisseur.Visibility = Visibility.Hidden;
        }
        private async void Btn_get_all_Click(object sender, RoutedEventArgs e)
        {
            liste_fournisseur.Visibility = Visibility.Visible;
            insert_fournisseur.Visibility = Visibility.Hidden;
            update_fournisseur.Visibility = Visibility.Hidden;

            Client client = new Client("https://localhost:44354/", new HttpClient());

            ICollection<Fournisseur_DTO> adherents = await client.AllFournisseursAsync();
            liste_fournisseur.ItemsSource = adherents;
        }

        private void Btn_insert_Click(object sender, RoutedEventArgs e)
        {
            liste_fournisseur.Visibility = Visibility.Hidden;
            insert_fournisseur.Visibility = Visibility.Visible;
            update_fournisseur.Visibility = Visibility.Hidden;
        }

        private void Btn_modify_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedFournisseur != null)
            {
                liste_fournisseur.Visibility = Visibility.Hidden;
                insert_fournisseur.Visibility = Visibility.Hidden;
                update_fournisseur.Visibility = Visibility.Visible;

                input_update_ste.Text = SelectedFournisseur.Societe;
                if (SelectedFournisseur.Civilite == true)
                {
                    checkbox_update_h.IsChecked = true;
                    checkbox_update_f.IsChecked = false;
                }
                else
                {
                    checkbox_update_h.IsChecked = false;
                    checkbox_update_f.IsChecked = true;
                }
                input_update_nom.Text = SelectedFournisseur.Nom;
                input_update_prenom.Text = SelectedFournisseur.Prenom;
                input_update_email.Text = SelectedFournisseur.Email;
                input_update_adresse.Text = SelectedFournisseur.Adresse;
                checkbox_update_desactive.IsChecked = SelectedFournisseur.Desactive;
            }
            else
            {
                _ = MessageBox.Show("Veuillez séléctionner un adhérent dans le tableau");
            }

        }

        private void liste_fournisseur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fournisseur_DTO sa = (Fournisseur_DTO)liste_fournisseur.SelectedItem;
            if (sa != null)
            {
                btn_update.Width = 90;
                SelectedFournisseur = sa;
                btn_update.Content = $"Modifier (id: {SelectedFournisseur.Id})";
            }
            else
            {
                btn_update.Width = 75;
                btn_update.Content = $"Modifier";
            }
        }

        private async void Btn_valid_update_form_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44354/", new HttpClient());

            if (input_update_ste != null && (checkbox_update_h.IsChecked == true ^ checkbox_update_f.IsChecked == true) && input_update_nom != null && input_update_prenom != null && input_update_email != null && input_update_adresse != null)
            {
                await client.FournisseursPUTAsync(new Fournisseur_DTO()
                {
                    Id = SelectedFournisseur.Id,
                    Societe = input_update_ste.Text,
                    Civilite = checkbox_update_h.IsChecked == true ? true : false,
                    Nom = input_update_nom.Text,
                    Prenom = input_update_prenom.Text,
                    Email = input_update_email.Text,
                    Adresse = input_update_adresse.Text,
                    Desactive = (bool)checkbox_update_desactive.IsChecked
                });

                liste_fournisseur.Visibility = Visibility.Visible;
                update_fournisseur.Visibility = Visibility.Hidden;
                ICollection<Fournisseur_DTO> adherents = await client.AllFournisseursAsync();
                liste_fournisseur.ItemsSource = adherents;
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
                await client.FournisseursPOSTAsync(new Fournisseur_DTO()
                {
                    Societe = input_insert_ste.Text,
                    Civilite = checkbox_insert_h.IsChecked == true ? true : false,
                    Nom = input_insert_nom.Text,
                    Prenom = input_insert_prenom.Text,
                    Email = input_insert_email.Text,
                    Adresse = input_insert_adresse.Text,
                    Desactive = false
                });

                liste_fournisseur.Visibility = Visibility.Visible;
                insert_fournisseur.Visibility = Visibility.Hidden; 
                ICollection<Fournisseur_DTO> adherents = await client.AllFournisseursAsync();
                liste_fournisseur.ItemsSource = adherents;
            }
            else
            {
                _ = MessageBox.Show("Veuillez renseigner tous les champs");
            }
        }
    }
}
