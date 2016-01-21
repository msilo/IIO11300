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
    
    public MainWindow()
    {
      InitializeComponent();
      init();
    }

    private void init()
    {
      // Create instance of Lotto
      lotto = new Lotto();
    }

    private void cbGame_Loaded(object sender, RoutedEventArgs e)
    {
      // Set items source and seleted index
      cbGame.ItemsSource = lotto.getLotot();
      cbGame.SelectedIndex = 0;

      lotto.Mode = cbGame.SelectedIndex;
    }

    private void cbGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      lotto.Mode = cbGame.SelectedIndex;
    }

    private void txtDrawns_LostFocus(object sender, RoutedEventArgs e)
    {
      try
      {
        // Get source object
        TextBox t = (TextBox)e.Source;
        // Check if number
        if (System.Text.RegularExpressions.Regex.IsMatch(t.Text, "^[0-9]*$"))
        {
          lotto.Drawns = int.Parse(t.Text);
        }
        else
        {
          throw new Exception(t.Text + " ei ole numero :)");
        }
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnDraw_Click(object sender, RoutedEventArgs e)
    {
      try {
        lotto.arvonta(txtOutcome);
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void txtDrawns_Loaded(object sender, RoutedEventArgs e)
    {
      try
      {
        // Get source object
        TextBox t = (TextBox)e.Source;
        lotto.Drawns = int.Parse(t.Text);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
      txtOutcome.Text = "";
    }
  }
}
