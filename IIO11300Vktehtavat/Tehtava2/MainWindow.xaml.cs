using JAMK.IT.IIO11300;
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
    private Lotto lotto;
    List<ComboBoxItem> lista;
    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    private void init()
    {
      // Create instance of Lotto
      lotto = new Lotto();

      // Create instance of List and populate it
      lista = new List<ComboBoxItem>();
      // Key - Value
      lista.Add(new ComboBoxItem("Suomi", 0));
      lista.Add(new ComboBoxItem("Viking Lotto", 1));
      lista.Add(new ComboBoxItem("Euro Jackpot", 0));
    }

    private void cbGame_Loaded(object sender, RoutedEventArgs e)
    {
      // Set items source and seleted index
      cbGame.ItemsSource = lista;
      cbGame.SelectedIndex = 0;
    }

    private void cbGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      // Set mode in Lotto
      //lotto.Mode = 
      //MessageBox.Show(cbGame.SelectedItem.ToString());
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
