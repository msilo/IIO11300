using System;
using System.Collections;
using System.Collections.ObjectModel; // For observableCollection
using System.ComponentModel;
using System.Data.Entity;
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

namespace Harjoitus10_BookShopEF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    BookShopEntities ctx;
    ObservableCollection<Book> localBooks;
    ICollectionView view; // DataGridin filtteröintiä varten
    bool IsBooks; // Onko gridissä kirjat vai asiakkaat?
    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    public void init()
    {
      // Luodaan konteksti = datasisältö
      ctx = new BookShopEntities();
      // Ladataan kirjatiedot paikalliseksi
      ctx.Books.Load();
      localBooks = ctx.Books.Local;

      // Täytetään comboboksi kirjailiijoitten maitten nimillä. 101 LINQ SAMPLES
      cmbMaa.DataContext = localBooks.Select(n => n.country).Distinct();

      // Luodaan view
      view = CollectionViewSource.GetDefaultView(localBooks);
    }

    private void btnAsiakkaanTilaukset_Click(object sender, RoutedEventArgs e)
    {
      // Haetaan EDM navigaatio-ominaisuuksien avulla valitun asiakkaan tilaukset
      string msg = "";
      Customer current = (Customer)spCustomers.DataContext;
      msg += string.Format("Asiakkaan {0} tilaukset \n", current.lastname);
      foreach (var tilaus in current.Orders)
      {
        msg += string.Format("Tilaus {0} sisältää {1} tilausriviä:\n", tilaus.odate, tilaus.Orderitems.Count);
        // Loopitetaan tilauksen tilausrivit
        foreach (var tilausrivi in tilaus.Orderitems)
        {
          msg += string.Format(" -kirja {0}\n", tilausrivi.Book.name);
        }
      }

      MessageBox.Show(msg);
    }

    private void grdDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      // Näytetään valitun entiteetin tiedot stackpanelissa
      if (IsBooks)
        spBook.DataContext = grdDataGrid.SelectedItem;
      else
        spCustomers.DataContext = grdDataGrid.SelectedItem;
    }

    private void btnHaeKirjat_Click(object sender, RoutedEventArgs e)
    {
      // Haetaan kirjat datagridiin
      // Vaihoehto 1
      //grdDataGrid.DataContext = ctx.Books.ToList();

      // Vaihtoehto 2. Käytetään paikallista muuttujaa
      grdDataGrid.DataContext = localBooks;
      IsBooks = true;
      // Mahdollinen filtterönti pois
      cmbMaa.SelectedIndex = -1;
    }

    private void btnHaeAsiakkaat_Click(object sender, RoutedEventArgs e)
    {
      // Haetaan asiakkaat
      grdDataGrid.DataContext = ctx.Customers.ToList();
      IsBooks = false;
    }

    private void cmbMaa_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      // Asetetaan filtteri päälle
      view.Filter = myCountryFilter;
    }

    private bool myCountryFilter(object item)
    {
      if (cmbMaa.SelectedIndex == -1)
        return true;
      else
        return (item as Book).country.Contains(cmbMaa.SelectedItem.ToString());
    }
  }
}
