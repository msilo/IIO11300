using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tehtava3
{
  public class BLfiles
  {
    public static List<string> GetFiles(string folder)
    {
      try
      {
        // Tarkasta onko kansiota olemassa
        if (Directory.Exists(folder))
        {
          List<string> files = new List<string>();

          string[] filut = Directory.GetFiles(folder);
          foreach (string filename in filut)
          {
            files.Add(filename);
          }

          return files;
        }
        else
        {
          throw new DirectoryNotFoundException();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public static void CombineFiles(string folder, List<string> files)
    {
      try
      {
        // Jos tiedosto on uusi
        if (!System.IO.File.Exists(folder))
        {

          // Open file
          using (StreamWriter sw = File.CreateText(folder))
          {
            foreach (var file in files) {
              using (StreamReader sr = File.OpenText(file))
              {
                string rivi = "";
                while ((rivi = sr.ReadLine()) != null)
                {
                  MessageBox.Show(rivi);
                  sw.WriteLine(rivi);
                }
                  
              }
            }
          }
        }
        // Jos tiedosto on olemassa
        else
        {
          throw new FileNotFoundException();
        }

      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
