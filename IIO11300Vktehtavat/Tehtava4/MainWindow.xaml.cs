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
    private List<Pelaaja> pelaajat;
    private List<string> seurat;
    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    private void init()
    {
      // Allocate memory for lists
      pelaajat = new List<Pelaaja>();
      seurat = new List<string>();
      // Set mockdata
      pelaajat = mockData();
      seurat = mockSeurat();
      // Update all
      updateSeurat();
      updateList();
      updateFeedback("All is well");
    }

    // Update Listbox controller with players
    private void updateList()
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
      cbSeurat.ItemsSource = mockSeurat();
    }

    private List<Pelaaja> mockData()
    {
      List <Pelaaja> lista = new List<Pelaaja>();
      lista.Add(new Pelaaja("jaska", "jokunen", 666,"tappara"));
      lista.Add(new Pelaaja("aku", "ankka", 5000, "jokerit"));
      lista.Add(new Pelaaja("jeesus", "kristus", 456, "kirkko"));
      lista.Add(new Pelaaja("timo", "jutila", 999, "rillaajat"));

      return lista;
    }

    private List<string> mockSeurat()
    {
      List<string> lista = new List<string>();
      lista.Add("Kalpa");
      lista.Add("Jyp");
      lista.Add("kirkko");
      lista.Add("rillaajat");

      return lista;
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
        if(Char.IsNumber(hinta, hinta.Length))
        {
          throw new Exception("Hinta ei voi sisältää kirjaimia!");
        }
        string seura = cbSeurat.Text;

        MessageBox.Show(nimi+snimi+hinta+seura+ " OK OK OK");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        
      }
    }
  }
}
