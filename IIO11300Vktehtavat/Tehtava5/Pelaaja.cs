using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava5
{
  [Serializable]
  public class Pelaaja
  {
    #region ATTRIBUTES
    private string etunimi;
    private string sukunimi;
    private int siirtohinta;
    private string seura;
    #endregion

    #region PROPERTIES
    public string Etunimi
    {
      get { return etunimi; }
      set { etunimi = value; }
    }

    public string Sukunimi
    {
      get { return sukunimi; }
      set { sukunimi = value; }
    }

    public int SiirtoHinta
    {
      get { return siirtohinta; }
      set { siirtohinta = value; }
    }

    public string Seura
    {
      get { return seura; }
      set { seura = value; }
    }

    public string KokoNimi
    {
      get { return Etunimi + " " + Sukunimi; }
    }

    public string EsitysNimi
    {
      get { return KokoNimi + ", " + Seura; }
    }
    #endregion

    #region CONSTRUCTORS
    public Pelaaja()
    {
      etunimi = " ";
      sukunimi = " ";
      seura = " ";
    }

    public Pelaaja(string etunimi, string sukunimi, int siirtohinta, string seura = " ")
    {
      this.etunimi = etunimi;
      this.sukunimi = sukunimi;
      this.siirtohinta = siirtohinta;
      this.seura = seura;
    }

    #endregion

    #region METHODS
    public override string ToString()
    {
      return EsitysNimi;
    }
    #endregion
  }
}
