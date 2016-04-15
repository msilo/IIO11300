using Microsoft.Win32;
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

namespace Tehtava5
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    // Oliot ja kokoelmat
    BLPelaajat blPelaajat; // BL-olio
    private List<Pelaaja> pelaajat; // pelaajat
    private List<string> seurat; // Seurat

    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    // Alustukset
    private void init()
    {
      try
      {
        // Varataan muistit
        blPelaajat = new BLPelaajat();
        pelaajat = new List<Pelaaja>();
        seurat = new List<string>();

        // Haetaan data
        pelaajat = blPelaajat.GetPelaajat(Tehtava5.Properties.Resources.pelaajat);
        seurat = blPelaajat.GetSeurat(Tehtava5.Properties.Resources.seurat);

        // Päivitetään kaikki
        updateSeurat();
        cbSeurat.SelectedIndex = 0;
        updatePelaajatList();
        updateFeedback("Kaikki ok!");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    // Päivittää Listboksin
    private void updatePelaajatList()
    {
      lbPelaajat.ItemsSource = null;
      lbPelaajat.ItemsSource = pelaajat;
    }

    // Päivittää statusbar controllerin
    private void updateFeedback(string message)
    {
      tbFeedBack.Text = message;
    }

    // Päivittää seura comboboksin
    private void updateSeurat()
    {
      cbSeurat.ItemsSource = null;
      cbSeurat.ItemsSource = seurat;
    }

    // Lopettaa ohjelman
    private void btnLopeta_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void lbPelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      spLomake.DataContext = lbPelaajat.SelectedItem;

    }

    private void btnUusiPelaaja_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        // Tarkistetaan syötteet
        string nimi = tbEtunimi.Text;
        if (String.IsNullOrEmpty(nimi))
        {
          throw new Exception("Etunimi ei voi olla tyhjä!");
        }

        string snimi = tbSukunimi.Text;

        if (String.IsNullOrEmpty(snimi))
        {
          throw new Exception("Sukunimi ei voi olla tyhjä!");
        }

        string hinta = tbSiirtohinta.Text;
        if (!hinta.All(char.IsDigit))
        {
          throw new Exception("Hinnan täytyy olla numero!");
        }
        string seura = cbSeurat.Text;

        // Call business logic?

        // Tarkistetaan onko saman nimistä pelaajaa olemassa
        Pelaaja temp = new Pelaaja(nimi, snimi, int.Parse(hinta), seura);

        int index = pelaajat.FindIndex(f => f.KokoNimi == temp.KokoNimi);

        if (index >= 0)
        {
          // Saman niminen pelaaja löytyi
          throw new Exception("Pelaaja on jo olemassa!");
        }
        else
        {
          // Saman nimistä ei löytynyt, joten tallennetaan listaan 
          pelaajat.Add(new Pelaaja(nimi, snimi, int.Parse(hinta), seura));
          updatePelaajatList();
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);

      }
    }

    private void btnTalletaPelaaja_Click(object sender, RoutedEventArgs e)
    {
      int index = pelaajat.FindIndex(r => r == (Pelaaja)spLomake.DataContext);
      if (index >= 0)
      {
        pelaajat[index].Etunimi = tbEtunimi.Text;
        pelaajat[index].Sukunimi = tbSukunimi.Text;
        pelaajat[index].SiirtoHinta = Int32.Parse(tbSiirtohinta.Text);
        pelaajat[index].Seura = cbSeurat.SelectedItem.ToString();
        updatePelaajatList();
      }

    }

    private void btnPoistaPelaaja_Click(object sender, RoutedEventArgs e)
    {
      int index = pelaajat.FindIndex(r => r == (Pelaaja)spLomake.DataContext);
      if (index >= 0)
      {
        pelaajat.RemoveAt(index);
        updatePelaajatList();
      }
    }

    private void btnKirjoitaTiedostoon_Click(object sender, RoutedEventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      if (saveFileDialog.ShowDialog() == true)
        //File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
        MessageBox.Show("Jees");

    }

    private void btnsXML_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        blPelaajat.serializeXML(pelaajat, tbPath.Text);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btndsXML_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        pelaajat = blPelaajat.DeserializeXML(tbPath.Text);
        updatePelaajatList();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnsTEXT_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        blPelaajat.serializeTEXT(pelaajat, tbPath.Text);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btndsTEXT_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        pelaajat = blPelaajat.DeserializeTEXT(tbPath.Text);
        updatePelaajatList();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
