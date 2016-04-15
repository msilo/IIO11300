using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Tehtava5
{
  class BLPelaajat
  {
    XElement xe;
    public BLPelaajat()
    {

    }

    public List<string> GetSeurat(string file)
    {
      List<string> seuraNimet = new List<string>();
      try
      {
        xe = XElement.Load(file);

        var nimet = from ele in xe.Elements()
                    select ele.Element("nimi");

        foreach (var item in nimet)
        {
          seuraNimet.Add(item.Value);
        }

        return seuraNimet;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public List<Pelaaja> GetPelaajat(string file)
    {
      List<Pelaaja> pelaajat = new List<Pelaaja>();
      try
      {
        xe = XElement.Load(file);

        var pelaajats = xe.Elements();

        foreach (var item in pelaajats)
        {
          var etunimi = item.Element("etunimi").Value;
          var sukunimi = item.Element("sukunimi").Value;
          var hinta = item.Element("siirtohinta").Value;
          var seura = item.Element("seura").Value;

          pelaajat.Add(new Pelaaja(etunimi, sukunimi, int.Parse(hinta), seura));
        }
        return pelaajat;
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Serialize object collection to XML file
    public void serializeXML(List<Pelaaja> pelaajat, string tbPath)
    {
      try
      {
        //string path = @"d:\G8499\PelaajatXML.xml";
        XmlSerializer x = new XmlSerializer(pelaajat.GetType());
        StreamWriter writer = new StreamWriter(tbPath);
        x.Serialize(writer, pelaajat);
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Deserialize object collection from XML file
    public List<Pelaaja> DeserializeXML(string tbPath)
    {
      try
      {
        List<Pelaaja> pelaajat = new List<Pelaaja>();

        XmlSerializer x = new XmlSerializer(typeof(List<Pelaaja>));
        StreamReader reader = new StreamReader(tbPath);
        pelaajat = (List<Pelaaja>)x.Deserialize(reader);
        return pelaajat;
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Serialize object collection to TEXT file
    public void serializeTEXT(List<Pelaaja> pelaajat, string tbPath)
    {
      try
      {
        using (Stream fileStream = new FileStream(tbPath, FileMode.Create,
                               FileAccess.Write, FileShare.None))
        {
          IFormatter formatter = new BinaryFormatter();
          formatter.Serialize(fileStream, pelaajat);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    // Deserialize object collection from TEXT file
    public List<Pelaaja> DeserializeTEXT(string tbPath)
    {
      try
      {
        List<Pelaaja> pelaajat = new List<Pelaaja>();
        using (Stream fileStream = new FileStream(tbPath, FileMode.Open,
                             FileAccess.Read, FileShare.Read))
        {
          IFormatter formatter = new BinaryFormatter();
          pelaajat = (List<Pelaaja>)formatter.Deserialize(fileStream);
        }
        return pelaajat;
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
