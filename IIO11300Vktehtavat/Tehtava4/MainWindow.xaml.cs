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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava4
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    XMLManager xml; // BL luokka
    private List<Pelaaja> pelaajat; // Lista pelaajista
    private List<string> seurat; // Lista seuroista
    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    private void init()
    {
      // Allocate memory for XMLmanager
      xml = new XMLManager();
      // Allocate memory for lists
      pelaajat = new List<Pelaaja>();
      seurat = new List<string>();
      // Set data
      pelaajat = xml.GetPelaajat(Tehtava4.Properties.Resources.pelaajat);
      seurat = xml.GetSeurat(Tehtava4.Properties.Resources.seurat);
      // Update all
      updateSeurat();
      cbSeurat.SelectedIndex = 0;
      updatePelaajatList();
      updateFeedback("All is well");
    }

    // Update Listbox controller with players
    private void updatePelaajatList()
    {
      lbPelaajat.ItemsSource = null;
      lbPelaajat.ItemsSource = pelaajat;
    }

    // Update Status bar controller
    private void updateFeedback(string message)
    {
      tbFeedBack.Text = message;
    }

    private void updateSeurat()
    {
      cbSeurat.ItemsSource = null;
      cbSeurat.ItemsSource = seurat;
    }

    private void btnLopeta_Click(object sender, RoutedEventArgs e)
    {
      // TODO: Tarkista onko muutokset tallennettu!
      this.Close();
    }

    private void lbPelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      MessageBox.Show("ristuS");
    }

    private void btnUusiPelaaja_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        // Tarkistetaan syötteet
        string nimi = txtEtuNimi.Text;
        if(String.IsNullOrEmpty(nimi))
        {
          throw new Exception("Etunimi ei voi olla tyhjä!");
        }

        string snimi = txtSukunimi.Text;

        if (String.IsNullOrEmpty(snimi))
        {
          throw new Exception("Sukunimi ei voi olla tyhjä!");
        }

        string hinta = txtSiirtoHinta.Text;
        if(!hinta.All(char.IsDigit))
        {
          throw new Exception("Hinnan täytyy olla numero!");
        }
        string seura = cbSeurat.Text;

        // Call business logic?

        // Add player

        pelaajat.Add(new Pelaaja(nimi, snimi, int.Parse(hinta), seura));
        updatePelaajatList();

        MessageBox.Show(nimi+snimi+hinta+seura+ " OK OK OK");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        
      }
    }
  }
}
