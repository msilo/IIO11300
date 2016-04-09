using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace IIO11300HT_Siloaho
{
  public class BLRecipes
  {
    public static List<Recipe> GetAllRecipes(string searchWord, IList types)
    {
      List<Recipe> recipes = new List<Recipe>();

      try
      {
        DataTable dt = DBRecipes.GetAll(searchWord, types);

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
      try
      {
        DBRecipes.SaveRecipe(recipe);
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static FlowDocument PrintRecipe(Recipe r)
    {
      // Before printing check that all fields are valid
      if (r.Name == String.Empty || r.Time == String.Empty || r.Instructions == String.Empty || r.Writer == String.Empty)
      {
        throw new Exception("Reseptissä ei voi olla tyhjiä kenttiä!");
      }
      // If all fields are valid print the recipe
      else
      {
        // Create a FlowDocument
        FlowDocument doc = new FlowDocument();

        // Create a Section
        Section sec = new Section();

        // Create first Paragraph
        Paragraph p1 = new Paragraph();

        // Create and add a new Bold, Italic and Underline
        Bold bld = new Bold();
        bld.Inlines.Add(new Run("First Paragraph"));
        Italic italicBld = new Italic();
        italicBld.Inlines.Add(bld);
        Underline underlineItalicBld = new Underline();
        underlineItalicBld.Inlines.Add(italicBld);

        // Add Bold, Italic, Underline to Paragraph
        p1.Inlines.Add(underlineItalicBld);

        // Add Paragraph to Section
        sec.Blocks.Add(p1);

        // Add Section to FlowDocument
        doc.Blocks.Add(sec);

        return doc;
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

    public static List<string> GetAllTypes()
    {
      List<string> types = new List<string>();
      try
      {
        DataTable dt = DBRecipes.GetAllTypes();

        string temp = null;

        foreach (DataRow dr in dt.Rows)
        {
          //recipe = new Recipe(Convert.ToInt32(dr["id"]), Convert.ToString(dr["name"]), Convert.ToString(dr["time"]), Convert.ToString(dr["instructions"]), Convert.ToString(dr["writer"]));
          temp = Convert.ToString(dr["typename"]);
          //recipes.Add(recipe);
          types.Add(temp);
        }

        return types;
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
