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

using EF.kunstwerken;

namespace EF.oefening._05
{
    public partial class MainWindow : Window
    {
        private Catalogus catalogus = new Catalogus();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            Dialoog Dlg = new Dialoog();
            Dlg.Velden(true, "", "", "");
            if (Dlg.ShowDialog () == true )
            {
                catalogus.Nieuw(Dlg.TxtTitel.Text.Trim(), Dlg.TxtArtiest.Text.Trim(), Dlg.TxtSpecs.Text.Trim());
                LstWerken.ItemsSource = null;
                LstWerken.ItemsSource = catalogus.Kunstwerken;
                LblAantalWerken.Content = catalogus.AantalWerken().ToString();
            }
            LstWerken.SelectedIndex = -1;
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstWerken.SelectedIndex > -1) {
                Kunstwerk kunstwerk = (Kunstwerk)LstWerken.SelectedItem;
                Dialoog Dlg = new Dialoog();
                Dlg.Velden(false, kunstwerk.Titel, kunstwerk.Artiest, kunstwerk.Specs);
                if (Dlg.ShowDialog() == true )
                {
                    if (Dlg.Status == "verwijder")
                    {
                        catalogus.Verwijder(kunstwerk);
                    }
                    else
                    {
                        catalogus.Update(kunstwerk, Dlg.TxtTitel.Text.Trim(), Dlg.TxtArtiest.Text.Trim(), Dlg.TxtSpecs.Text.Trim());
                    }
                    LstWerken.ItemsSource = null;
                    LstWerken.ItemsSource = catalogus.Kunstwerken;                    
                    LblAantalWerken.Content = catalogus.AantalWerken().ToString();
                }
                LstWerken.SelectedIndex = -1;
            }
        }
    }
}