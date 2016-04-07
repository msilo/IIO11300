﻿using System;
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

    public MainWindow()
    {
      InitializeComponent();
      Init();
    }

    private void Init()
    {
      // Allocate memory
      recipes = new List<Recipe>();

      // Set state to NoSelection
      StateMachine(States.NoSelection);

      // Populate combobox with recipe types
      // Call BL -> DB. Execute query -> return result -> populate combobox
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
        // Set state to NoSelection
        StateMachine(States.NoSelection);

        // Call business logic
        recipes = BLRecipes.GetAllRecipes(tbGetRecipe.Text);
        
        // Set datagrid itessource
        dgRecipes.ItemsSource = recipes;
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
        Recipe r = (Recipe)dpList.DataContext;
        r.Name = tbRecipeName.Text;
        r.Time = tbRecipeTime.Text;
        r.Instructions = tbInstructions.Text;
        r.Writer = tbRecipeWriter.Text;

        BLRecipes.PrintRecipe(r);
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
        Recipe r = (Recipe)dpList.DataContext;
        r.Name = tbRecipeName.Text;
        r.Time = tbRecipeTime.Text;
        r.Instructions = tbInstructions.Text;
        r.Writer = tbRecipeWriter.Text;
        // Save to database
        BLRecipes.SaveRecipe(r);
        // Update datagrid
        dgRecipes.ItemsSource = null;

        Recipe temp = recipes.Single(s => s.Id == r.Id);

        int index = recipes.IndexOf(temp);
        recipes[index] = r;
        dgRecipes.ItemsSource = recipes;
        
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
        string sMessageBoxText = "Haluatko varmasti poistaa reseptin" + r.Name + "?";
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
      btnRemove.IsEnabled = false;
      tbRecipeName.Focus();
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
