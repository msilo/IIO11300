using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IIO11300HT_Siloaho
{
  public class BLRecipes
  {
    public static List<Recipe> GetAllRecipes(string searchWord)
    {
      List<Recipe> recipes = new List<Recipe>();

      try
      {
        DataTable dt = DBRecipes.GetAll(searchWord);

        Recipe recipe;

        foreach (DataRow dr in dt.Rows)
        {
          recipe = new Recipe(Convert.ToInt32(dr["id"]), Convert.ToString(dr["name"]), Convert.ToString(dr["time"]), Convert.ToString(dr["instructions"]));

          recipes.Add(recipe);

        }
        return recipes;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static List<Recipe> staticData()
    {
      List<Recipe> recipes = new List<Recipe>();

      try
      {
        DataTable dt = DBRecipes.getData();

        Recipe recipe;

        foreach (DataRow dr in dt.Rows)
        {
          recipe = new Recipe(Convert.ToInt32(dr["id"]), Convert.ToString(dr["name"]), Convert.ToString(dr["time"]), Convert.ToString(dr["instructions"]));
 
          recipes.Add(recipe);

        }
        return recipes;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static void SaveRecipe(Recipe recipe)
    {
      // If id exists update row. Else create new row.
      //MessageBox.Show(recipe.Id + "  " + recipe.Name + "  " + recipe.Time + "  " + recipe.Instructions);
      try
      {
        DBRecipes.SaveRecipe(recipe);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static void PrintRecipe()
    {
      throw new NotImplementedException();
    }

    public static void RemoveRecipe(Recipe recipe)
    {
      try
      {
        string sMessageBoxText = "Haluatko varmasti poistaa reseptin" + recipe.Name + "?";
        string sCaption = "Respentin poistaminen";

        MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
        MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

        MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

        if (rsltMessageBox == MessageBoxResult.Yes)
        {
          DBRecipes.DeleteRecipe(recipe);
        }
      }
      catch (Exception)
      {
        throw;
      }

    }
  }
}
