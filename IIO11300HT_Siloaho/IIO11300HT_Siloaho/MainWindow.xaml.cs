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

namespace IIO11300HT_Siloaho
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

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      dpList.DataContext = dgRecipes.SelectedItem;
      try
      {
       
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnGetRecipes_Click(object sender, RoutedEventArgs e)
    {
      // Todo
      try
      {

      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);
      }
    }

    private void btnGetTestRecipes_Click(object sender, RoutedEventArgs e)
    {
      //todo
      try
      {
        dgRecipes.DataContext =  BLRecipes.staticData();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnPrint_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        BLRecipes.PrintRecipe();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      // Save recipe into database
      try
      {
        BLRecipes.SaveRecipe();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnRemove_Click(object sender, RoutedEventArgs e)
    {
      // Remove recipe from database
      try
      {
        BLRecipes.RemoveRecipe();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
