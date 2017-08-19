using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Net;
using System.Xml;
using System.Diagnostics;

namespace Has___Emlak
{

    public partial class ilanekle : DevExpress.XtraEditors.XtraForm
    {
        public ilanekle()
        {
            InitializeComponent();
        }
        double alis = 0;
        double adet = 0;
        double sonuc = 0;
        public Boolean yeni;
        public hasemlakDataSet.yapibilgiiRow yapi;
        public hasemlakDataSet.ilantRow ilan;
        public hasemlakDataSet.ilanverenmusteriRow musteri;
        //public pqemlakDataSet.yapibilgiRow yapi;
        //public pqemlakDataSet.ilanverenmusteriRow musteri;
        //public pqemlakDataSet.ilantRow ilan;
        public int ilanid;
        public int musteriid;
        //string adres = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True";


        private void yapiturcombo_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void ilcecomboo_EditValueChanged(object sender, EventArgs e)
        {
            int ilceid = int.Parse(ilcecomboo.EditValue.ToString());

            SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
            bagla.Open();
            SqlCommand komutt = new SqlCommand("select semt_id,semt_adi from semt where ilce_id=@p", bagla);
            komutt.Parameters.AddWithValue("@p", ilceid);
            SqlDataAdapter ap = new SqlDataAdapter(komutt);
            DataTable dt = new DataTable();
            ap.Fill(dt);
            //gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            //gridControl1.DataSource = dt;
            semtcomb.Properties.DataSource = dt;
            semtcomb.Properties.ValueMember = "semt_id";
            semtcomb.Properties.DisplayMember = "semt_adi";
            bagla.Close();
        }

        private void semtcomb_EditValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(semtcomb.EditValue.ToString());
            int semtid = int.Parse(semtcomb.EditValue.ToString());

            SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
            bagla.Open();
            SqlCommand komutt = new SqlCommand("select sokak_id,sokak_adi from sokakk where semt_id=@p", bagla);
            komutt.Parameters.AddWithValue("@p", semtid);
            SqlDataAdapter ap = new SqlDataAdapter(komutt);
            DataTable dt = new DataTable();
            ap.Fill(dt);
            //gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            //gridControl1.DataSource = dt;
            sokakcombo.Properties.DataSource = dt;
            sokakcombo.Properties.ValueMember = "sokak_id";
            sokakcombo.Properties.DisplayMember = "sokak_adi";
            bagla.Close();
        }

        private void sokakcombo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ilanekle_Load(object sender, EventArgs e)
        {
           
            if (yeni)
            {
                temizle();
            }
            else
            {
                düzelt();
            }

        }
        //public void icözellikleri()
        //{
        //    foreach (Control item in icözellik.Controls)
        //    {
        //        if (item is CheckEdit)
        //        {
        //            if (((CheckEdit)item).Checked == true)
        //            {

        //                yapi.ic_özellikleri = item.Text.ToUpper();
        //            }
        //        }

        //    }

        //}
        //public void disözellikleri()
        //{
        //    foreach (Control item in disözellik.Controls)
        //    {
        //        if (item is CheckEdit)
        //        {
        //            if (((CheckEdit)item).Checked == true)
        //            {
        //                yapi.dis_özellikleri = item.Text.ToUpper();
        //            }
        //        }
        //    }
        //}
        //public void konumözellikleri()
        //{
        //    foreach (Control item in konum.Controls)
        //    {
        //        if (item is CheckEdit)
        //        {
        //            if (((CheckEdit)item).Checked == true)
        //            {
        //                yapi.konum_özellikleri = item.Text.ToUpper();
        //            }
        //        }
        //    }

        //}
        public void doldur()
        {

            yapi.yapi_tur_id = int.Parse(yapiturcombo.EditValue.ToString());
            yapi.metrekare = metrekaretxt.Text.ToUpper();
            yapi.oda_sayisi = odasayicombo.EditValue.ToString().ToUpper();
            yapi.yapi_yasi = yapiyasicombo.EditValue.ToString().ToUpper();
            yapi.yapidaki_kat_sayisi = yapikatsayicombo.EditValue.ToString().ToUpper();
            yapi.yapinin_kati = yapibulundugutxt.Text.ToUpper();
            yapi.banyo_sayisi = banyocombo.EditValue.ToString().ToUpper();
            yapi.isi_id = int.Parse(ısıcombo.EditValue.ToString());
            yapi.yapi_fiyati = fiyattxt.Text.ToUpper();
            yapi.cins_id = int.Parse(fiyatcinscombo.EditValue.ToString());
            yapi.cephe_id = int.Parse(cephecombo.EditValue.ToString());
            yapi.esya_id = int.Parse(esyacombo.EditValue.ToString());
            yapi.durum_id = int.Parse(yapidurumcombo.EditValue.ToString());
            yapi.tur_id = int.Parse(kirasatılıkcombo.EditValue.ToString());
            yapi.il_id = int.Parse(ilcombo.EditValue.ToString());
            yapi.ilce_id = int.Parse(ilcecomboo.EditValue.ToString());
            yapi.semt_id = int.Parse(semtcomb.EditValue.ToString());
            yapi.sokak_id = int.Parse(sokakcombo.EditValue.ToString());

            foreach (Control item in icözellik.Controls)
            {
                if (item is CheckEdit)
                {
                    if (((CheckEdit)item).Checked == true)
                    {
                        string[] dizi = new string[] { item.Text };
                        for (int i = 0; i < dizi.Length; i++)
                        {
                            comboBox1.Items.Add(dizi[i]);
                        }
                    }
                }

            }
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                icözelliklbl.Text = comboBox1.Items[i].ToString() + "," + icözelliklbl.Text;
                yapi.ic_özellikleri = icözelliklbl.Text.ToUpper();
            }
            foreach (Control item in disözellik.Controls)
            {
                if (item is CheckEdit)
                {
                    if (((CheckEdit)item).Checked == true)
                    {
                        string[] dizi = new string[] { item.Text };
                        for (int i = 0; i < dizi.Length; i++)
                        {
                            comboBox2.Items.Add(dizi[i]);
                        }
                    }
                }

            }
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                disözelliklbl.Text = comboBox2.Items[i].ToString() + "," + disözelliklbl.Text;
                yapi.dis_özellikleri= disözelliklbl.Text.ToUpper();
            }
            foreach (Control item in konum. Controls)
            {
                if (item is CheckEdit)
                {
                    if (((CheckEdit)item).Checked == true)
                    {
                        string[] dizi = new string[] { item.Text };
                        for (int i = 0; i < dizi.Length; i++)
                        {
                            comboBox3.Items.Add(dizi[i]);
                        }
                    }
                }

            }
            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                konumlbl.Text = comboBox3.Items[i].ToString() + "," + konumlbl.Text;
                yapi.konum_özellikleri = konumlbl.Text.ToUpper();
            }
            musteri.musteri_adi = aditxt.Text.ToUpper();
            musteri.musteri_soyadi = soyadtxt.Text.ToUpper();
            musteri.musteri_telefon = telefontxt.Text.ToUpper();
            musteri.musteri_e_posta = epostatxt.Text.ToUpper();
            ilan.ilan_tarihi = DateTime.Parse(tarihcombo.SelectedText);
            ilan.ilan_durumu = "AKTİF";
            ilan.ilan_sonuc = "DEVAM EDİYOR";
            musteri.musteri_id = int.Parse(idilbltxt.Text);
            ilan.musteri_id = int.Parse(idilbltxt.Text);
            yapi.yapi_id = int.Parse(yapiidlbl.Text);
            ilan.yapi_id = int.Parse(yapiidlbl.Text);
            
            

        }
        public void temizle()
        {
            metrekaretxt.ResetText();
            telefontxt.ResetText();
            yapiyasicombo.ResetText();
            yapibulundugutxt.ResetText();
            yapikatsayicombo.ResetText();
            fiyattxt.ResetText();
            foreach (Control item in icözellik.Controls)
            {
                if (item is CheckEdit)
                {
                    if (((CheckEdit)item).Checked == true)
                    {
                        ((CheckEdit)item).Checked = false;
                    }
                }

            }
            foreach (Control item in disözellik.Controls)
            {
                if (item is CheckEdit)
                {
                    if (((CheckEdit)item).Checked == true)
                    {
                        ((CheckEdit)item).Checked = false;
                    }
                }
            }
            foreach (Control item in konum.Controls)
            {
                if (item is CheckEdit)
                {
                    if (((CheckEdit)item).Checked == true)
                    {
                        ((CheckEdit)item).Checked = false;
                    }
                }

            }
            aditxt.ResetText();
            telefontxt.ResetText();
            epostatxt.ResetText();
            soyadtxt.ResetText();
            tarihcombo.ResetText();
          
        }
        public void düzelt()
        {
            yapiturcombo.EditValue = yapi.yapi_tur_id;
            metrekaretxt.Text = yapi.metrekare.ToUpper();
            odasayicombo.EditValue = yapi.oda_sayisi;
            //yapiyasitxt.Text = yapi.yapi_yasi.ToUpper();
            //yapikatsayitxt.Text = yapi.yapidaki_kat_sayisi.ToUpper();
            yapibulundugutxt.Text = yapi.yapinin_kati.ToUpper();
            banyocombo.EditValue = yapi.banyo_sayisi;
            fiyattxt.Text = yapi.yapi_fiyati.ToUpper();
            fiyatcinscombo.EditValue = yapi.cins_id;
            cephecombo.EditValue = yapi.cephe_id;
            esyacombo.EditValue = yapi.esya_id;
            yapidurumcombo.EditValue = yapi.durum_id;
            ısıcombo.EditValue = yapi.isi_id;
            kirasatılıkcombo.EditValue = yapi.tur_id;
            ilcombo.EditValue = yapi.il_id;
            ilcecomboo.EditValue = yapi.ilce_id;
            semtcomb.EditValue = yapi.semt_id;
            sokakcombo.EditValue = yapi.sokak_id;
            tarihcombo.EditValue = ilan.ilan_tarihi;
            aditxt.Text = musteri.musteri_adi.ToUpper();
            soyadtxt.Text = musteri.musteri_soyadi.ToUpper();
            telefontxt.Text = musteri.musteri_telefon.ToUpper();
            epostatxt.Text = musteri.musteri_e_posta.ToUpper();
        }

        private void eklebtn_Click(object sender, EventArgs e)
        {
            doldur();
            this.DialogResult = DialogResult.OK;
         
           
        }

        private void ilanekle_Load_1(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            icözelliklbl.Hide();
            disözelliklbl.Hide();
            konumlbl.Hide();
            telefontxt.Properties.MaxLength = 11;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilce' table. You can move, or remove it, as needed.
            this.ilceTableAdapter.Fill(this.hasemlakDataSet.ilce);
            // TODO: This line of code loads data into the 'hasemlakDataSet.il' table. You can move, or remove it, as needed.
            this.ilTableAdapter.Fill(this.hasemlakDataSet.il);
            // TODO: This line of code loads data into the 'hasemlakDataSet.kstur' table. You can move, or remove it, as needed.
            this.ksturTableAdapter.Fill(this.hasemlakDataSet.kstur);
            // TODO: This line of code loads data into the 'hasemlakDataSet.ısınma' table. You can move, or remove it, as needed.
            this.ısınmaTableAdapter.Fill(this.hasemlakDataSet.ısınma);
            // TODO: This line of code loads data into the 'hasemlakDataSet.evdurum' table. You can move, or remove it, as needed.
            this.evdurumTableAdapter.Fill(this.hasemlakDataSet.evdurum);
            // TODO: This line of code loads data into the 'hasemlakDataSet.esya' table. You can move, or remove it, as needed.
            this.esyaTableAdapter.Fill(this.hasemlakDataSet.esya);
            // TODO: This line of code loads data into the 'hasemlakDataSet.cephe' table. You can move, or remove it, as needed.
            this.cepheTableAdapter.Fill(this.hasemlakDataSet.cephe);
            // TODO: This line of code loads data into the 'hasemlakDataSet.fiyatcins' table. You can move, or remove it, as needed.
            this.fiyatcinsTableAdapter.Fill(this.hasemlakDataSet.fiyatcins);
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapitur' table. You can move, or remove it, as needed.
            this.yapiturTableAdapter.Fill(this.hasemlakDataSet.yapitur);

        }

        private void ilcecomboo_EditValueChanged_1(object sender, EventArgs e)
        {

            int ilceid = int.Parse(ilcecomboo.EditValue.ToString());

            SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
            bagla.Open();
            SqlCommand komutt = new SqlCommand("select semt_id,semt_adi from semt where ilce_id=@p", bagla);
            komutt.Parameters.AddWithValue("@p", ilceid);
            SqlDataAdapter ap = new SqlDataAdapter(komutt);
            DataTable dt = new DataTable();
            ap.Fill(dt);
            //gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            //gridControl1.DataSource = dt;
            semtcomb.Properties.DataSource = dt;
            semtcomb.Properties.ValueMember = "semt_id";
            semtcomb.Properties.DisplayMember = "semt_adi";
            bagla.Close();
        }

        private void semtcomb_EditValueChanged_1(object sender, EventArgs e)
        {
            int semtid = int.Parse(semtcomb.EditValue.ToString());

            SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
            bagla.Open();
            SqlCommand komutt = new SqlCommand("select sokak_id,sokak_adi from sokakk where semt_id=@p", bagla);
            komutt.Parameters.AddWithValue("@p", semtid);
            SqlDataAdapter ap = new SqlDataAdapter(komutt);
            DataTable dt = new DataTable();
            ap.Fill(dt);
            //gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            //gridControl1.DataSource = dt;
            sokakcombo.Properties.DataSource = dt;
            sokakcombo.Properties.ValueMember = "sokak_id";
            sokakcombo.Properties.DisplayMember = "sokak_adi";
            bagla.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
           
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            alis = double.Parse(alisfiyati.Text);
            adet = double.Parse(textBox2.Text);
            sonuc = alis * adet;
            textBox3.Text = sonuc.ToString()+" "+"TL";
            alisfiyati.ResetText();
            textBox2.ResetText();
            cinsadilbl.ResetText();
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] diz = listBox1.SelectedItem.ToString().Split(',');
        alisfiyati.Text= diz[2].Replace('.',',');
           if (diz[0].Contains("US DOLLAR"))
           {
               cinsadilbl.Text = "Dolar";
           }
           if (diz[0].Contains("AUSTRALIAN DOLLAR"))
           {
               cinsadilbl.Text = "Avustralya Doları";
           }
           if (diz[0].Contains("DANISH KRONE"))
           {
               cinsadilbl.Text = "Danimarka Kronu";
           }
            if(diz[0].Contains("POUND STERLING"))
            {
                cinsadilbl.Text="İngiliz Sterlini";
            }
            if (diz[0].Contains("SWISS FRANK"))
            {
                cinsadilbl.Text="İsviçre Frangı";
            }
            if (diz[0].Contains("SWEDISH KRONA"))
            {
                cinsadilbl.Text = "İsveç Kronu";
            }
            if (diz[0].Contains("CANADIAN DOLLAR"))
            {
                cinsadilbl.Text = "Kanda Doları";
            }
            if (diz[0].Contains("KUWAITI DINAR"))
            {
                cinsadilbl.Text = "Kuveyt Dinarı";
            }
            if (diz[0].Contains("NORWEGIAN KRONE"))
            {
                cinsadilbl.Text = "Norveç Kronu";
            }
            if (diz[0].Contains("SAUDI RIYAL"))
            {
                cinsadilbl.Text = "Suudi Arabistan Riyali";
            }
            if (diz[0].Contains("JAPENESE YEN"))
            {
                cinsadilbl.Text = "Japon Yeni";
            }
            if (diz[0].Contains("BULGARIAN LEV"))
            {
                cinsadilbl.Text = "Bulgar Levası";
            }
            if (diz[0].Contains("NEW LEU"))
            {
                cinsadilbl.Text = "Rumen Leyi";
            }
            if (diz[0].Contains("RUSSIAN ROUBLE"))
            {
                cinsadilbl.Text = "Rus Rublesi";
            }
            if (diz[0].Contains("IRANIAN RIAL"))
            {
                cinsadilbl.Text = "İran Riyali";
            }
            if (diz[0].Contains("CHINESE RENMINBI"))
            {
                cinsadilbl.Text = "Çin Yuanı";
            }
            if (diz[0].Contains("PAKISTANI RUPEE"))
            {
                cinsadilbl.Text = "Pakistan Rupisi";
            }
            if (diz[0].Contains("SPECIAL DRAWING RIGHT"))
            {
                cinsadilbl.Text = "Özel Çekme Hakkı";
            }
            if (diz[0].Contains("EURO"))
            {
                cinsadilbl.Text = "Euro";
            }




        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doldur();
            this.DialogResult = DialogResult.OK;
         
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void hesaplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alis = double.Parse(alisfiyati.Text);
            adet = double.Parse(textBox2.Text);
            sonuc = alis * adet;
            textBox3.Text = sonuc.ToString() + " " + "TL";
            alisfiyati.ResetText();
            textBox2.ResetText();
            cinsadilbl.ResetText();
        }

        private void ilanekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
     

       
    }
}