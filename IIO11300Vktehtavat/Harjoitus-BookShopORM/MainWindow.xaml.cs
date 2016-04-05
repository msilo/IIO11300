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

namespace Harjoitus_BookShopORM
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Book> books;
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnHaeTestiKirjat_Click(object sender, RoutedEventArgs e)
    {
      // Haetaan staattista testidataa
      books = BookShop.GetTestBooks();
      grdDataGrid.DataContext = books;
    }

    private void btnHaeSQLKirjat_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        // Haetaan kirjat tietokannasta. ORM = muutetaan tulosjoukon tietueet Book -olioiksi
        books = BookShop.GetBooks(true);
        grdDataGrid.DataContext = books;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnTallenna_Click(object sender, RoutedEventArgs e)
    {
      // Valittu Book -olio tallennetaan kantaan
      try
      {
        Book current = (Book)spBook.DataContext;
        BookShop.UpdateBook(current);
        MessageBox.Show(string.Format("Kirja {0} päivitetty kantaan onnistuneesti", current.ToString()));
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void grdDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      // Gridissä valittu olio asetetaan stackpanelin datacontekstiksi
      spBook.DataContext = grdDataGrid.SelectedItem;
    }
  }
}
