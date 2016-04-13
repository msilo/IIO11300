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
    private enum States {NoSelection, RecipeSelected, NewRecipe};
    private List<Recipe> recipes;
    private List<string> recipeTypes;

    public MainWindow()
    {
      InitializeComponent();
      Init();
    }

    private void Init()
    {
      try
      {
        // Load database configurations
        BLRecipes.GetConnStr();

        // Allocate memory
        recipes = new List<Recipe>();
        recipeTypes = new List<string>();

        // Set state to NoSelection
        StateMachine(States.NoSelection);

        // Get all recipetypes and populate ListBox control
        lbRecipeType.ItemsSource = BLRecipes.GetAllTypes();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      try
      {
        dpList.DataContext = dgRecipes.SelectedItem;

        // Set state to RecipeSelected
        StateMachine(States.RecipeSelected);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnGetRecipes_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        System.Collections.IList types = lbRecipeType.SelectedItems;

        // Set state to NoSelection
        StateMachine(States.NoSelection);

        // Call business logic, find recipes
        recipes = BLRecipes.GetAllRecipes(tbGetRecipe.Text, types);
        
        // Set datagrid itessource
        dgRecipes.ItemsSource = recipes;

        // Set feedback string
        tbFeedBack.Text = "Löytyi " + recipes.Count + " reseptiä.";
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnPrint_Click(object sender, RoutedEventArgs e)
    {
      PrintDialog pd = new PrintDialog();

      try
      {
        if (pd.ShowDialog() == true)
        {
          if (dpList.DataContext != null)
          {
            // Get recipe from dockpanel
            Recipe r = (Recipe)dpList.DataContext;
            r.Name = tbRecipeName.Text;
            r.Time = tbRecipeTime.Text;
            r.Instructions = tbInstructions.Text;
            r.Writer = tbRecipeWriter.Text;

            // Generate flow document
            FlowDocument doc = BLRecipes.PrintRecipe(r);
            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer
            pd.PrintDocument(idpSource.DocumentPaginator, "Resepti");

            // Set feedback string
            tbFeedBack.Text = "Resepti " + r.Name + " tulostettu.";
          }
        }
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
        // DataContext exists, user had clicked existing recipe
        if (dpList.DataContext != null)
        {
          Recipe r = (Recipe)dpList.DataContext;
          r.Name = tbRecipeName.Text;
          r.Time = tbRecipeTime.Text;
          r.Instructions = tbInstructions.Text;
          r.Writer = tbRecipeWriter.Text;

          // Save to database
          BLRecipes.SaveRecipe(r, lbRecipeType.SelectedItems);

          // Update datagrid
          //dgRecipes.ItemsSource = null;

          Recipe temp = recipes.Single(s => s.Id == r.Id);
          int index = recipes.IndexOf(temp);
          recipes[index] = r;
          dgRecipes.ItemsSource = recipes;
          
          // Set feedback string
          tbFeedBack.Text = "Resepti " + r.Name + " päivitetty.";
        }
        // If DataContext is set to null, that means that recipe is brand new
        else
        {
          Recipe r = new Recipe(tbRecipeName.Text, tbRecipeTime.Text, tbInstructions.Text, tbRecipeWriter.Text);

          // Save to database, Get id
          int index = BLRecipes.SaveRecipe(r, lbRecipeType.SelectedItems);
          // Set id
          r.Id = index;
          // Update datagrid
          //dgRecipes.ItemsSource = null;
          recipes.Add(r);
          dgRecipes.ItemsSource = recipes;

          // Set feedback string
          tbFeedBack.Text = "Resepti " + r.Name + " lisätty.";
        }

        StateMachine(States.NoSelection);
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
        // Cast selected datacontext to Recipe object
        Recipe r = (Recipe)dpList.DataContext;
        // Send object to business tier
        string sMessageBoxText = "Haluatko varmasti poistaa reseptin " + r.Name + "?";
        string sCaption = "Respentin poistaminen";

        MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
        MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

        MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

        if (rsltMessageBox == MessageBoxResult.Yes)
        {
          BLRecipes.RemoveRecipe(r);

          // Remove recipe from datagrid
          dgRecipes.ItemsSource = null;
          recipes.Remove(r);
          dgRecipes.ItemsSource = recipes;

          // Set state to NoSelection
          StateMachine(States.NoSelection);

          // Set feedback string
          tbFeedBack.Text = "Resepti " + r.Name + " poistettu.";
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void tbGetRecipe_TextChanged(object sender, TextChangedEventArgs e)
    {
      if(tbGetRecipe.Text == String.Empty)
      {
        btnGetRecipes.Content = "Hae kaikki reseptit";
      }
      else if(btnGetRecipes != null)
      {
        btnGetRecipes.Content = "Etsi reseptejä";
      }
    }

    private void btnNew_Click(object sender, RoutedEventArgs e)
    {
      dpList.DataContext = null;
     
      tbRecipeName.Focus();

      // Set state to NewRecipe
      StateMachine(States.NewRecipe);
    }

    // Sets different state to UI
    private void StateMachine(States state)
    {
      switch(state)
      {
        case States.NoSelection:
          btnPrint.IsEnabled = false;
          btnSave.IsEnabled = false;
          btnRemove.IsEnabled = false;

          tbRecipeName.IsEnabled = false;
          tbRecipeTime.IsEnabled = false;
          tbRecipeWriter.IsEnabled = false;
          tbInstructions.IsEnabled = false;
          break;
        case States.RecipeSelected:
          btnPrint.IsEnabled = true;
          btnSave.IsEnabled = true;
          btnRemove.IsEnabled = true;

          tbRecipeName.IsEnabled = true;
          tbRecipeTime.IsEnabled = true;
          tbRecipeWriter.IsEnabled = true;
          tbInstructions.IsEnabled = true;
          break;
        case States.NewRecipe:
          btnPrint.IsEnabled = true;
          btnSave.IsEnabled = true;
          btnRemove.IsEnabled = true;

          tbRecipeName.IsEnabled = true;
          tbRecipeTime.IsEnabled = true;
          tbRecipeWriter.IsEnabled = true;
          tbInstructions.IsEnabled = true;
          break;
        default:
          break;
      }
    }

  }
}
