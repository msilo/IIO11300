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
          recipe = new Recipe(Convert.ToInt32(dr["id"]), Convert.ToString(dr["name"]), Convert.ToString(dr["time"]), Convert.ToString(dr["instructions"]), Convert.ToString(dr["writer"]));

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
      // TODO implement saving properly
      try
      {
        DBRecipes.SaveRecipe(recipe);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static void PrintRecipe(Recipe r)
    {
      // Before printing check that all fields are valid
      if (r.Name == String.Empty || r.Time == String.Empty || r.Instructions == String.Empty || r.Writer == String.Empty)
      {
        throw new Exception("Reseptissä ei voi olla tyhjiä kenttiä!");
      }
      // If all fields are valid print the recipe
      else
      {
        throw new NotImplementedException();
      }
    }

    public static void RemoveRecipe(Recipe recipe)
    {
      try
      {
        DBRecipes.DeleteRecipe(recipe);
      }
      catch (Exception)
      {
        throw;
      }

    }
  }
}
