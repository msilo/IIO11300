using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace IIO11300HT_Siloaho
{
  public class DBRecipes
  {
    public static DataTable getTestData()
    {
      DataTable dt = new DataTable();
      
      dt.Columns.Add("id", typeof(int));
      dt.Columns.Add("name", typeof(string));
      dt.Columns.Add("time", typeof(string));
      dt.Columns.Add("instructions", typeof(string));

      dt.Rows.Add(1, "Kaalikeitto", "1h", "Keitä kaali \n Työnnä naamaan");
      dt.Rows.Add(2, "Läskisoosi", "2h", "Jauha hevonen myllyssä \n Lisää vesi \n Työnnä naamaan");
      dt.Rows.Add(2, "Jallu", "8h", "Osta pullo \n Kaada lasiin \n Työnnä naamaan");

      return dt;
    }

    public static DataTable GetAll(string searchWord = null)
    {
      // Generate query SELECT should be as array
      string sql = "SELECT id, name, time, instructions FROM recipe";
      if(searchWord != null)
      {
        sql += " WHERE name LIKE '%" + searchWord + "%'";
      }

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

    public static DataTable getData()
    {
      string connStr = Properties.Settings.Default.connstr;
      
      try
      {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
          string sql = "SELECT id, name, time, instructions FROM recipe";

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
          string sql = "UPDATE recipe SET `name`='"+ r.Name.ToString() +"', `time`='"+ r.Time.ToString() +"', `instructions`='"+ r.Instructions.ToString() +"' WHERE `id`='" +r.Id+"'";

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

    public static void UpdateRecipe()
    {
       // Recipe has id. Update existing row
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
