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

namespace Tehtava6
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    List<Viini> viinit;
    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    private void init()
    {
      viinit = new List<Viini>();
    }

    private void btnHaeViinit_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        viinit = BLViinit.HaeViinit(@"D:\G8499\Viinit1.xml");
        dgViinit.ItemsSource = viinit;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void cbMaa_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
  }
}
