using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
  public class MittausData
  {
    private string kello;

    #region PROPERTIES 
    public string Kello
    {
      get { return kello; }
      set { kello = value; }
    }

    private string mittaus;

    public string Mittaus
    {
      get { return mittaus; }
      set { mittaus = value; }
    }

    public MittausData()
    {
      this.kello = "0:00";
      this.mittaus = "Ei dataa";
    }

    public MittausData(string kello, string mittaus)
    {
      this.kello = kello;
      this.mittaus = mittaus;
    }

    public string DataMuoto
    {
      get { return kello + ";" + mittaus; }
    
    }

    #endregion
    // Ylikirjoitetaan ToString metodi

    public override string ToString()
    {
      //return base.ToString();
      return kello + " = " + mittaus;
    }

    #region METHODS
    public static void SaveDataToFile(List<MittausData> dataa, string file)
    {
      // Kirjoitetaan data tiedostoon, jos tiedosto on olemassa, niin liitetään se olemassa olevaan
      try
      {
        // Tutkitaan onko tiedosto olemassa
        if(!System.IO.File.Exists(file))
        {
          // Luodaan uusi tiedosto
          using (StreamWriter sw = File.CreateText(file))
          {
            // Käydään kokokelma läpi ja kirjoitetaan jokainen kokoelman alkio omalle riville
            foreach (var item in dataa)
            {
              sw.WriteLine(item.DataMuoto);
            }
          }
        }
        // Lisätään olemassa olevaan tiedostoon
        else
        {
          using (StreamWriter sw = File.AppendText(file))
          {
            foreach (var item in dataa)
            {
              sw.WriteLine(item.DataMuoto);
            }
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static List<MittausData> ReadDataFromFile(string file)
    {
      // Luetaan käyttäjän antamasta tiedostosta tekstirivejä ja muutetaan ne mittausdataksi
      try
      {
        if(File.Exists(file))
        {
          using (StreamReader sr = File.OpenText(file))
          {
            // luetaan rivi kerrallaan tiedostoa
            MittausData md;
            List<MittausData> luetut = new List<MittausData>();
            string rivi = "";
            while((rivi = sr.ReadLine()) != null)
            {
              // tutkitaan löytyykö sovittu erotinmerkki ; etupuolella on kellonaika ja jälkeen mittausarvo
              if ((rivi.Length > 3) && rivi.Contains(";"))
              {
                string[] split = rivi.Split(new char[] { ';' });
                // Luodaan tekstinpätkistä olio
                md = new MittausData(split[0], split[1]);
                luetut.Add(md);
              }
            }
            // Palautetaan lista
            return luetut;
          }
        }
        else
        {
          throw new FileNotFoundException();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    #endregion

  }
}
