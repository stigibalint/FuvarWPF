using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    public class Fuvar
    {
        string taxiAzonosito;
        string indulasiIdopont;
        int utazasIdotartam;
        double megtettTavolsag;
        double vitelDij;
        double borraValo;
        string fizetesModja;
        public Fuvar(string taxiAzonosito, string indulasiIdopont, int utazasIdotartam, double megtettTavolsag, double vitelDij, double borraValo, string fizetesModja)

        {
            this.taxiAzonosito = taxiAzonosito;
            this.indulasiIdopont = indulasiIdopont;
            this.utazasIdotartam  = utazasIdotartam;
            this.megtettTavolsag = megtettTavolsag;
            this.vitelDij = vitelDij;
            this.borraValo  = borraValo;
            this.fizetesModja = fizetesModja;
        }
        public Fuvar(string CSVSOR)
        {
            var mezo = CSVSOR.Split(";");
            taxiAzonosito = mezo[0];
            indulasiIdopont = mezo[1];
            utazasIdotartam = int.Parse(mezo[2]);
            megtettTavolsag = double.Parse(mezo[3]);
            vitelDij = double.Parse(mezo[4]);
            borraValo = double.Parse(mezo[5]);
            fizetesModja = mezo[6];
        }

        public string TaxiAzonosito { get => taxiAzonosito; set => taxiAzonosito = value; }
        public string IndulasiIdopont { get => indulasiIdopont; set => indulasiIdopont = value; }
        public int UtazasIdotartam { get => utazasIdotartam; set => utazasIdotartam = value; }
        public double MegtettTavolsag { get => megtettTavolsag; set => megtettTavolsag = value; }
        public double VitelDij { get => vitelDij; set => vitelDij = value; }
        public double BorraValo { get => borraValo; set => borraValo = value; }
        public string FizetesModja { get => fizetesModja; set => fizetesModja = value; }
    }
}
