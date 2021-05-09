using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mikroskop
{
    class Mikroskop
    {
        public bool JeKomoraZavrena;
        public bool JeVzduchVycerpan;
        public bool JeNapajeniZapnuto;
        public bool JePracovniVzalenostNastavena;
        public bool JeUrychlovaciNapetiNastaveno;
        public bool JeVybranyDetektor;
        private double tlakVKomore; 
        private double tlakVTubusu; 
        private int urychlovaciNapeti;
        private int pracovniVzdalenost;
        private string nazevDetektoru;
        private DateTime zacatekVycerpani;

        public void UvodniStav()
        {
            tlakVKomore = 101325;
            tlakVTubusu = 101325;
            pracovniVzdalenost = 0;
            urychlovaciNapeti = 0;
        }
        
        //KOMORA
        public void ZavriKomoru()
        {
            JeKomoraZavrena = true;
        }

        public void OtevriKomoru()
        {
            if(!JeVzduchVycerpan)
            {
                JeKomoraZavrena = false;
            }      
        }

        //VZDUCH
        public void VycerpejVzduch()
        {
            if (JeKomoraZavrena)
            {
                zacatekVycerpani = DateTime.Now;
                tlakVKomore = 10; 
                tlakVTubusu = 10;
                JeVzduchVycerpan = true;
            }
        }

        public void NacerpejVzduch()
        {
            if (JeKomoraZavrena)
            {
                tlakVKomore = 101325;
                tlakVTubusu = 101325;
                JeVzduchVycerpan = false;
            }
        }

        public double ZmerTlakVKomore()
        {
            double uplynulyCasVycerpani = (DateTime.Now - zacatekVycerpani).TotalSeconds;
            return tlakVKomore;
        }

        public double ZmerTlakVTubusu()
        {
            return tlakVTubusu;
        }

        //ZDROJ ELEKTRONOV

        public void ZapnoutNapajeni()
        {
            if(JeVzduchVycerpan)
            {
                JeNapajeniZapnuto = true;
            }
        }

        public void VypnoutNapajeni()
        {
            JeNapajeniZapnuto = false;
        }

        public void NastavUrychlovaciNapeti(int urychlovaciNapetiHodnota)
        {
            if((urychlovaciNapetiHodnota > 0) && (urychlovaciNapetiHodnota <= 25))
            {
                urychlovaciNapeti = urychlovaciNapetiHodnota;
                JeUrychlovaciNapetiNastaveno = true;
            }
        }
        public int ZmerUrychlovaciNapeti()
        {
             return urychlovaciNapeti;
        }

        //PRACOVNA VZDIALENOST

        public void NastavPracovniVzdalenost(int pracovniVzdalenostHodnota)
        {
            if ((pracovniVzdalenostHodnota > 0) && (pracovniVzdalenostHodnota <= 25))
            {
                pracovniVzdalenost = pracovniVzdalenostHodnota;
                JePracovniVzalenostNastavena = true;
            }
        }         
        public int ZmerPracovniVzdalenost()
        {
            return pracovniVzdalenost;
        }

        //DETEKTORY

        public void VyberDetektor(string nazevDetektoruString)
        {
            if((nazevDetektoruString == "SED") || (nazevDetektoruString == "BSED"))
            {
                nazevDetektoru = nazevDetektoruString;
                JeVybranyDetektor = true;
            }
        }
        public string VybranyDetektor()
        {
            if(nazevDetektoru == "SED")
            {
                return "SED";
            }

            else if(nazevDetektoru == "BSED")
            {
                return "BSED";
            }

            else
            {
                return null;
            }
        }

        //SKENOVANIE VZORKU

        public Image NaskenujVzorek()
        {
            if((JeKomoraZavrena) && (JeVzduchVycerpan) && (JeNapajeniZapnuto) && (JeUrychlovaciNapetiNastaveno) && (pracovniVzdalenost > 0) && (pracovniVzdalenost <= 9) && (nazevDetektoru == "SED"))
            {
                return Properties.Resources.obrazek_SED_rozostreny;
            }

            else if ((JeKomoraZavrena) && (JeVzduchVycerpan) && (JeNapajeniZapnuto) && (JeUrychlovaciNapetiNastaveno) && (pracovniVzdalenost > 0) && (pracovniVzdalenost <= 9) && (nazevDetektoru == "BSED"))
            {
                return Properties.Resources.obrazek_BSED_rozostreny;
            }

            else if ((JeKomoraZavrena) && (JeVzduchVycerpan) && (JeNapajeniZapnuto) && (JeUrychlovaciNapetiNastaveno) && (pracovniVzdalenost > 0) && (pracovniVzdalenost == 10) && (nazevDetektoru == "SED"))
            {
                return Properties.Resources.obrazek_SED_ostry;
            }

            else if ((JeKomoraZavrena) && (JeVzduchVycerpan) && (JeNapajeniZapnuto) && (JeUrychlovaciNapetiNastaveno) && (pracovniVzdalenost > 0) && (pracovniVzdalenost == 10) && (nazevDetektoru == "BSED"))
            {
                return Properties.Resources.obrazek_BSED_ostry;
            }

            else
            {
                return null;
            }

        }
    }
}
