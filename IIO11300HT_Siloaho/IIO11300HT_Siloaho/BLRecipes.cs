﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;

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

    public static int SaveRecipe(Recipe recipe, IList types)
    {
      // Send information to database layer
      try
      {
        // Before printing check that all fields are valid
        if (recipe.Name == String.Empty || recipe.Time == String.Empty || recipe.Instructions == String.Empty || recipe.Writer == String.Empty)
        {
          throw new Exception("Reseptissä ei voi olla tyhjiä kenttiä!");
        }

        return DBRecipes.SaveRecipe(recipe, types);
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
        Section sec2 = new Section();

        // Create first Paragraph
        Paragraph p1 = new Paragraph();
        Paragraph p2 = new Paragraph();

        // Create and add a new Bold, Italic and Underline
        Bold bld = new Bold();
        bld.Inlines.Add(new Run(r.Name));
        Italic italicBld = new Italic();
        italicBld.Inlines.Add(bld);
        Underline underlineItalicBld = new Underline();
        underlineItalicBld.Inlines.Add(italicBld);

        // Add Bold, Italic, Underline to Paragraph
        p1.Inlines.Add(underlineItalicBld);
        p1.Inlines.Add(new Run("\n" + r.Time));
        p1.Inlines.Add(new Run("\n" + r.Writer));

        p2.Inlines.Add(new Run(r.Instructions));

        // Add Paragraph to Section
        sec.Blocks.Add(p1);
        sec2.Blocks.Add(p2);

        // Add Section to FlowDocument
        doc.Blocks.Add(sec);
        doc.Blocks.Add(sec2);

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
          temp = Convert.ToString(dr["typename"]);

          types.Add(temp);
        }

        return types;
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Reads config file for database connection and sets MySql class properties
    public static void GetConnStr()
    {
      string xmlPath = Path.Combine(Environment.CurrentDirectory, @"xml\conf.xml");
      if (System.IO.File.Exists(xmlPath))
      {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(xmlPath);
        
        XmlNodeList xn = xmldoc.SelectNodes("/Conf");

        // Set MySql properties
        Mysql.Server = xn[0]["Server"].InnerText;
        Mysql.Database = xn[0]["Database"].InnerText;
        Mysql.Username = xn[0]["Username"].InnerText;
        Mysql.Password = xn[0]["Password"].InnerText;
      }

      else
      {
        MessageBox.Show("Tietokannan asetustiedostoa conf.xml ei löydy");
      }

    }

  }
}
