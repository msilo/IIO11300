using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      DataTable dt = DBRecipes.getTestData();

      Recipe recipe;
      foreach (DataRow dr in dt.Rows)
      {
        recipe = new Recipe((int)dr[0], dr["name"].ToString(), dr["time"].ToString(), dr["instructions"].ToString());

        recipes.Add(recipe);

      }
      return recipes;
    }
  }
}
