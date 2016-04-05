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
    public static void getAll()
    {
      throw new Exception("Business class");
    }

    public static List<Recipe> staticData()
    {
      List<Recipe> recipes = new List<Recipe>();
      // Versio 1
      /*
      recipes.Add(new Recipe(1, "Keitto", "3h"));
      recipes.Add(new Recipe(2, "Kossu", "1h"));
      recipes.Add(new Recipe(3, "Leipä", "5h"));
      */

      // Versio 2
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

    public static void SaveRecipe()
    {
      // If id exists update row. Else create new row.
      try
      {
        DBRecipes.SaveRecipe();
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

    public static void RemoveRecipe()
    {
      string sMessageBoxText = "Haluatko varmasti poistaa reseptin xxxxx?";
      string sCaption = "Respentin poistaminen";

      MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
      MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

      MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
    }
  }
}
