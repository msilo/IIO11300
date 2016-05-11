using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Tehtava6
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    List<Viini> viinit;
    List<string> maat;

    ICollectionView view;

    string hakusana = " ";

    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    private void init()
    {
      viinit = new List<Viini>();
      maat = new List<string>();
      
    }

    private void btnHaeViinit_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        // Get vines from XML
        viinit = BLViinit.HaeViinit(@"D:\G8499\Viinit1.xml");

        // Set view
        view = CollectionViewSource.GetDefaultView(viinit);
        // Set Datagrid itemssource
        dgViinit.ItemsSource = view;

        // Sort countries from list
        SortCountries();
        // Set combobox itemssource
        cbMaa.ItemsSource = maat;

        
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void cbMaa_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      hakusana = cbMaa.SelectedItem.ToString();
      MessageBox.Show(hakusana);

      view.Filter = FilterByCountry;

      dgViinit.ItemsSource = view;

    }

    private void SortCountries()
    {
      var filtered = from viini in viinit
                         select viini.Maa;
      maat = filtered.ToList();
    }

    private bool FilterByCountry(object item)
    {
      Viini viini = item as Viini;
      return viini.Maa.Equals(hakusana);
    }
  }
}
