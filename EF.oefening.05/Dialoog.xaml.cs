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
using System.Windows.Shapes;

namespace EF.oefening._05
{
    public partial class Dialoog : Window
    {
        public string Status { get; set; } = "";
        public Dialoog()
        {
            InitializeComponent();
        }

        public void Velden(bool nieuw, string titel, string artiest, string specs)
        {
            if (nieuw) BtnVerwijder.Visibility = Visibility.Hidden;
            else BtnVerwijder.Visibility= Visibility.Visible;

            TxtTitel.Text = titel;
            TxtArtiest.Text = artiest;
            TxtSpecs.Text = specs;
            TxtTitel.Focus();
        }

        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Kunstwerk verwijderen ?", "Kunstwerk Verwijderen", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Status = "verwijder";
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }

        private void BtnBewaar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtTitel.Text.Trim().Length == 0 || TxtArtiest.Text.Trim().Length == 0)
            {
                MessageBox.Show("'Titel' en 'Artiest' zijn verplichte velden", "Foutieve invoer", MessageBoxButton.OK);
            }
            else
            {
                this.DialogResult = true;
            }            
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
