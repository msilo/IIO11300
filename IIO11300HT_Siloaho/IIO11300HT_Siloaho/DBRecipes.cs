using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
  }
}
