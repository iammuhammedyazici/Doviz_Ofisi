using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Doviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDolarAlis.Text = dolaralis;

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSatis.Text = dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroAlis.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSatis.Text = eurosatis;

            string sterlinalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            lblSterlinAlis.Text = sterlinalis;

            string sterlinsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            lblSterlinSatis.Text = sterlinsatis;

           
        }

        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarAlis.Text;
        }

        private void BtnDolarSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarSatis.Text;
        }

        private void BtnEuroAlis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroAlis.Text;

        }

        private void BtnEuroSatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroSatis.Text;

        }

        private void BtnSterlinAlis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblSterlinAlis.Text;

        }

        private void BtnSterlinSatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblSterlinSatis.Text;

        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(txtKur.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = kur * miktar;
            txtToplam.Text = tutar.ToString();
        }

        private void txtKur_TextChanged(object sender, EventArgs e)
        {
            txtKur.Text = txtKur.Text.Replace(".", ",");
        }

        private void BtnHesap_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(txtKur.Text);
            int miktar = Convert.ToInt32(txtMiktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            txtToplam.Text = tutar.ToString();

            double kalan;
            kalan = miktar % kur;
            txtKalan.Text = kalan.ToString();
            
        }
    }
}
