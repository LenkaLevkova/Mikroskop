using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikroskop
{
    public partial class OknoMikroskop : Form
    {
        Mikroskop mikroskop;
        public OknoMikroskop()
        {
            InitializeComponent();
            mikroskop = new Mikroskop();
        }
        private void OknoMikroskop_Load(object sender, EventArgs e)
        {
            mikroskop.UvodniStav();
            pictureBoxVizualizace.Image = Properties.Resources.mikroskop_se_vzduchem;
            labelTlakVKomoreHodnota.Text = mikroskop.ZmerTlakVKomore().ToString();
            labelTlakVTubusuHodnota.Text = mikroskop.ZmerTlakVTubusu().ToString();
            buttonVycerpatVzduch.Enabled = mikroskop.JeKomoraZavrena; 
            buttonNacerpatVzduch.Enabled = mikroskop.JeKomoraZavrena; 
            buttonSED.Enabled = mikroskop.JeKomoraZavrena;
            buttonBSED.Enabled = mikroskop.JeKomoraZavrena;
            buttonOtevritKomoru.Enabled = mikroskop.JeKomoraZavrena;
            trackBarUrychlovaciNapeti.Enabled = mikroskop.JeKomoraZavrena;
            trackBarPracovniVzdalenost.Enabled = mikroskop.JeKomoraZavrena;
            checkBoxNapajeni.Enabled = mikroskop.JeKomoraZavrena;
            labelUrychlovaciNapetiHodnota.Text = trackBarUrychlovaciNapeti.Value.ToString();
            labelPracovniVzdalenostHodnota.Text = trackBarPracovniVzdalenost.Value.ToString();
        }
        private void buttonZavritKomoru_Click(object sender, EventArgs e)
        {
            mikroskop.ZavriKomoru();
            buttonVycerpatVzduch.Enabled = mikroskop.JeKomoraZavrena;
            buttonOtevritKomoru.Enabled = mikroskop.JeKomoraZavrena;
            buttonZavritKomoru.Enabled = !mikroskop.JeKomoraZavrena;
            checkBoxNapajeni.Enabled = !mikroskop.JeKomoraZavrena;
            trackBarUrychlovaciNapeti.Enabled = !mikroskop.JeKomoraZavrena;
            trackBarPracovniVzdalenost.Enabled = !mikroskop.JeKomoraZavrena;
            buttonSED.Enabled = !mikroskop.JeKomoraZavrena;
            buttonBSED.Enabled = !mikroskop.JeKomoraZavrena;
        }
        private void buttonOtevritKomoru_Click(object sender, EventArgs e)
        {
            mikroskop.OtevriKomoru();
            buttonVycerpatVzduch.Enabled = mikroskop.JeKomoraZavrena; 
            buttonNacerpatVzduch.Enabled = mikroskop.JeKomoraZavrena; 
            buttonSED.Enabled = mikroskop.JeKomoraZavrena; 
            buttonBSED.Enabled = mikroskop.JeKomoraZavrena; 
            buttonOtevritKomoru.Enabled = mikroskop.JeKomoraZavrena;
            buttonZavritKomoru.Enabled = !mikroskop.JeKomoraZavrena;
            checkBoxNapajeni.Enabled = mikroskop.JeKomoraZavrena;
            trackBarUrychlovaciNapeti.Enabled = mikroskop.JeKomoraZavrena;
            trackBarPracovniVzdalenost.Enabled = mikroskop.JeKomoraZavrena;
        }
        private void buttonVycerpatVzduch_Click(object sender, EventArgs e)
        {
            mikroskop.VycerpejVzduch();
            pictureBoxVizualizace.Image = Properties.Resources.mikroskop_bez_vzduchu;
            labelTlakVKomoreHodnota.Text = mikroskop.ZmerTlakVKomore().ToString();
            labelTlakVTubusuHodnota.Text = mikroskop.ZmerTlakVTubusu().ToString();
            buttonVycerpatVzduch.Enabled = !mikroskop.JeKomoraZavrena;
            buttonNacerpatVzduch.Enabled = mikroskop.JeKomoraZavrena;
            buttonOtevritKomoru.Enabled = !mikroskop.JeKomoraZavrena;
            checkBoxNapajeni.Enabled = mikroskop.JeKomoraZavrena;
            trackBarUrychlovaciNapeti.Enabled = !mikroskop.JeKomoraZavrena;
            trackBarPracovniVzdalenost.Enabled = !mikroskop.JeKomoraZavrena;
            buttonSED.Enabled = !mikroskop.JeKomoraZavrena;
            buttonBSED.Enabled = !mikroskop.JeKomoraZavrena;
        }
        private void buttonNacerpatVzduch_Click(object sender, EventArgs e)
        {
            mikroskop.NacerpejVzduch();
            pictureBoxVizualizace.Image = Properties.Resources.mikroskop_se_vzduchem;
            labelTlakVKomoreHodnota.Text = mikroskop.ZmerTlakVKomore().ToString();
            labelTlakVTubusuHodnota.Text = mikroskop.ZmerTlakVTubusu().ToString();
            buttonNacerpatVzduch.Enabled = mikroskop.JeVzduchVycerpan;
            buttonVycerpatVzduch.Enabled = !mikroskop.JeVzduchVycerpan;
            buttonOtevritKomoru.Enabled = !mikroskop.JeVzduchVycerpan;
            buttonZavritKomoru.Enabled = mikroskop.JeVzduchVycerpan;
            checkBoxNapajeni.Enabled = mikroskop.JeVzduchVycerpan;
            trackBarUrychlovaciNapeti.Enabled = mikroskop.JeVzduchVycerpan;
            trackBarPracovniVzdalenost.Enabled = mikroskop.JeVzduchVycerpan;
            buttonSED.Enabled = mikroskop.JeVzduchVycerpan;
            buttonBSED.Enabled = mikroskop.JeVzduchVycerpan;
        }
        private void checkBoxNapajeni_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxNapajeni.Checked)
            {
                mikroskop.ZapnoutNapajeni();
                trackBarUrychlovaciNapeti.Enabled = mikroskop.JeNapajeniZapnuto;
                trackBarPracovniVzdalenost.Enabled = mikroskop.JeNapajeniZapnuto;
                pictureBoxObraz.Image = mikroskop.NaskenujVzorek();
            }

            else
            {
                mikroskop.VypnoutNapajeni();
                trackBarUrychlovaciNapeti.Enabled = mikroskop.JeNapajeniZapnuto;
                trackBarPracovniVzdalenost.Enabled = mikroskop.JeNapajeniZapnuto;
                trackBarPracovniVzdalenost.Value = 0;
                trackBarUrychlovaciNapeti.Value = 0;
                labelUrychlovaciNapetiHodnota.Text = trackBarUrychlovaciNapeti.Value.ToString();
                labelPracovniVzdalenostHodnota.Text = trackBarPracovniVzdalenost.Value.ToString();
            }
        }
        private void trackBarUrychlovaciNapeti_Scroll(object sender, EventArgs e)
        {
            mikroskop.NastavUrychlovaciNapeti(trackBarUrychlovaciNapeti.Value);
            labelUrychlovaciNapetiHodnota.Text = trackBarUrychlovaciNapeti.Value.ToString();
            buttonBSED.Enabled = (mikroskop.JeUrychlovaciNapetiNastaveno) && (mikroskop.JePracovniVzalenostNastavena);
            buttonSED.Enabled = (mikroskop.JeUrychlovaciNapetiNastaveno) && (mikroskop.JePracovniVzalenostNastavena);
        }

        private void trackBarPracovniVzdalenost_Scroll(object sender, EventArgs e)
        {
            mikroskop.NastavPracovniVzdalenost(trackBarPracovniVzdalenost.Value);
            labelPracovniVzdalenostHodnota.Text = trackBarPracovniVzdalenost.Value.ToString();
            buttonBSED.Enabled = (mikroskop.JeUrychlovaciNapetiNastaveno) && (mikroskop.JePracovniVzalenostNastavena);
            buttonSED.Enabled = (mikroskop.JeUrychlovaciNapetiNastaveno) && (mikroskop.JePracovniVzalenostNastavena);
            pictureBoxObraz.Image = mikroskop.NaskenujVzorek();
        }

        private void buttonSED_Click(object sender, EventArgs e)
        {
            mikroskop.VyberDetektor("SED");
            pictureBoxVizualizace.Image = Properties.Resources.mikroskop_se_svazkem_SED;
            pictureBoxObraz.Image = mikroskop.NaskenujVzorek();
        }

        private void buttonBSED_Click(object sender, EventArgs e)
        {
            mikroskop.VyberDetektor("BSED");
            pictureBoxVizualizace.Image = Properties.Resources.mikroskop_se_svazkem_BSED;
            pictureBoxObraz.Image = mikroskop.NaskenujVzorek();
        }
    }
}
