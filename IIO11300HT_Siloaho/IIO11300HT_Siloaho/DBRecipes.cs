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

    public static void SaveRecipe()
    {
      // Recipe has no id. Create new row in database
      string connStr = Properties.Settings.Default.connstr;
      MessageBox.Show("save");
      try
      {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
          string sql = "SELECT id, name, time, instructions FROM recipe";

          MySqlDataAdapter adapter = new MySqlDataAdapter();
          adapter.InsertCommand = new MySqlCommand("INSERT INTO recipe VALUES('Roskaa', 'Testi', 'Jees'", conn);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static void UpdateRecipe()
    {
       // Recipe has id. Update existing row
    }

    public static void DeleteRecipe()
    {
      // Remove recipe from database
    }
  }
}
