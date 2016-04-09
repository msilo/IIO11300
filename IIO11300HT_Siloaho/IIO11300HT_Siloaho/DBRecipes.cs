using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Collections;

namespace IIO11300HT_Siloaho
{
  public class DBRecipes
  {
    public static DataTable GetAll(string searchWord, IList types)
    { 
      // Generate query SELECT
      string sql = "SELECT r.id, r.name, r.time, r.instructions, r.writer FROM recipe as r";
      
      // Add JOIN clauses
      sql += " LEFT JOIN recipestype as rt on r.id = rt.recipe_id";
      sql += " LEFT JOIN type as t on t.id = rt.type_id";
      
      // Add WHERE clause
      sql += " WHERE r.name LIKE '%" + searchWord + "%'";

      // If types were given, add all conditions after AND
      if (types.Count > 0)
      {
        sql += " AND (";
        foreach (string s in types)
        {
          if(types.IndexOf(s) > 0)
          {
            sql += " OR";
          }
          sql += " t.typename = '" + s + "'";
        }
        sql += ")";
      }

      // Add Group by clause
      sql += " GROUP BY r.name";

      // TODO move connectionstring to constructor
      string connStr = Properties.Settings.Default.connstr;

      // TODO Remove duplicate code. Impelement private method for SELECT
      try
      {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
          MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
          DataSet ds = new DataSet();
          adapter.Fill(ds);

          return ds.Tables[0];
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static DataTable GetAllTypes()
    {
      // SQL query
      string sql = "SELECT typename FROM type";

      // TODO move connectionstring to constructor
      string connStr = Properties.Settings.Default.connstr;

      try
      {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
          MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
          DataSet ds = new DataSet();
          adapter.Fill(ds);

          return ds.Tables[0];
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static void SaveRecipe(Recipe r)
    {
      // Recipe has no id. Create new row in database
      string connStr = Properties.Settings.Default.connstr;
      MySqlConnection conn = null;
      MySqlTransaction tr = null;

      try
      {
        using (conn = new MySqlConnection(connStr))
        {
          string sql = null;
          if (r.Id > 0)
          {
            sql = "UPDATE recipe SET `name`='" + r.Name.ToString() + "', `time`='" + r.Time.ToString() + "', `instructions`='" + r.Instructions.ToString() + "', `writer`='" + r.Writer.ToString() + "' WHERE `id`='" + r.Id + "'";
          }
          else
          {
            sql = "INSERT INTO recipe (`name`, `time`, `instructions`, `writer`) VALUES('"+r.Name+"', '"+r.Time+"', '"+r.Instructions+"', '"+r.Writer+"')";
          }
          conn.Open();
          tr = conn.BeginTransaction();

          MySqlCommand cmd = new MySqlCommand();
          cmd.Connection = conn;
          cmd.Transaction = tr;

          cmd.CommandText = sql;
          cmd.ExecuteNonQuery();

          tr.Commit();
        }
      }
      catch (Exception)
      {
        //tr.Rollback();
        throw;
      }
    }

    public static void DeleteRecipe(Recipe r)
    {
      // Remove recipe from database
      string connStr = Properties.Settings.Default.connstr;

      // TODO: Ensure that connection close is handled properly
      try
      {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
          conn.Open();
          string sql = "DELETE FROM recipe WHERE id='" + r.Id + "'";

          MySqlCommand cmd = new MySqlCommand();
          cmd.Connection = conn;
          // Delete rows from recipe
          cmd.CommandText = sql;
          cmd.ExecuteNonQuery();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
