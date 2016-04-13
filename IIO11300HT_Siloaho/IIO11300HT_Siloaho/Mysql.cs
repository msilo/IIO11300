using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIO11300HT_Siloaho
{
  public static class Mysql
  {
    #region PROPERTIES
    private static string server;

    public static string Server
    {
      get { return server; }
      set { server = value; }
    }

    private static string database;

    public static string Database
    {
      get { return database; }
      set { database = value; }
    }

    private static string username;

    public static string Username
    {
      get { return username; }
      set { username = value; }
    }

    private static string password;

    public static string Password
    {
      get { return password; }
      set { password = value; }
    }
    #endregion

    #region CONSTRUCTORS
    static Mysql()
    {
      
    }
    #endregion

    #region METHODS
    public static string GetConnStr()
    {
      return "SERVER="+server + ";"+"DATABASE=" + database + ";"+"UID=" + username + ";"+"PASSWORD=" + password + ";";
    }
    #endregion
  }
}
