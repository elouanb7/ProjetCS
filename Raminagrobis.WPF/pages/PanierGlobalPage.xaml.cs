using CsvHelper;
using Microsoft.Win32;
using MyNamespace;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Logique d'interaction pour PanierGlobalPage.xaml
    /// </summary>
    public partial class PanierGlobalPage : Page
    {
        public PanierGlobalPage()
        {
            InitializeComponent();
        }

        private async void Btn_generate_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client("https://localhost:44354/", new HttpClient());

            var la = await client.ListeSemaineAsync(); // get all listes de la dernière semaine

            var refs = new Dictionary<string, int>();
            var details = Array.Empty<PanierGlobalDetails_DTO>();
            foreach (var l in la)
            {
                foreach (var d in l.Details)
                {
                    var refName = await client.ReferencesGETAsync(d.IdReference);
                    if (refs.ContainsKey(refName.ReferenceName))
                    {
                        refs[refName.ReferenceName] += d.Quantite;
                    }
                    else
                    {
                        refs.Add(refName.ReferenceName, d.Quantite);
                    }
                }
            }

            foreach (var r in refs)
            {
                var reference = await client.ReferenceAsync(r.Key);
                details = details.Append(new PanierGlobalDetails_DTO()
                {
                    IdReference = reference.Id,
                    Quantite = r.Value
                }).ToArray();
            }

            var week = await client.ListeMaxSemaineAsync();

            await client.PanierGlobalPOSTAsync(new PanierGlobal_DTO()
            {
                Semaine  = week,
                Details = details
            });

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {

                try
                {
                    using (Stream fs = saveFileDialog1.OpenFile())
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes($"Reference;Quantite;PUHT");
                        fs.Write(info, 0, info.Length);
                        foreach (var r in refs)
                        {
                            info = new UTF8Encoding(true).GetBytes($"\n{r.Key};{r.Value};");
                            fs.Write(info, 0, info.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de la création du panier global");
                }
            }
        }
    }
}
