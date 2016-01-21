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

namespace Tehtava2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void cbGame_Loaded(object sender, RoutedEventArgs e)
    {
      // Lista
      List<string> lista = new List<string>();
      lista.Add("Suomi");
      lista.Add("Viking Lotto");
      lista.Add("Euro Jackpot");

      cbGame.ItemsSource = lista;
      cbGame.SelectedIndex = 0;
    }

    private void cbGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      MessageBox.Show(cbGame.SelectedItem.ToString());
    }

    private void txtDrawns_LostFocus(object sender, RoutedEventArgs e)
    {
      try
      {
        // Get source object
        TextBox t = (TextBox)e.Source;
        MessageBox.Show(t.Text);
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
