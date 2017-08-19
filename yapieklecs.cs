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
using System.Diagnostics;
namespace Has___Emlak
{
    public partial class yapieklecs : DevExpress.XtraEditors.XtraForm
    {
        public yapieklecs()
        {
            InitializeComponent();
        }
        public Boolean yeni;
        public hasemlakDataSet.yapibilgiiRow yapi;
     
        private void eklebtn_Click(object sender, EventArgs e)
        {
            doldur();
            this.DialogResult = DialogResult.OK;
        }














        public void temizle()
        {
            metrekaretxt.ResetText();
            
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
           

        }
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
                yapi.dis_özellikleri = disözelliklbl.Text.ToUpper();
            }
            foreach (Control item in konum.Controls)
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
            
           
           
            yapi.yapi_id = int.Parse(yapiidlbl.Text);
          



        }

        private void yapieklecs_Load(object sender, EventArgs e)
        {
           // textBox3.Enabled = false;
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
            icözelliklbl.Hide();
            disözelliklbl.Hide();
            // TODO: This line of code loads data into the 'hasemlakDataSet.fiyatcins' table. You can move, or remove it, as needed.
            this.fiyatcinsTableAdapter.Fill(this.hasemlakDataSet.fiyatcins);
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
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapitur' table. You can move, or remove it, as needed.
            this.yapiturTableAdapter.Fill(this.hasemlakDataSet.yapitur);
            if (yeni)
            {
                temizle();
            }
            else
            {
              
            }
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

        private void ilancikisbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doldur();
            this.DialogResult = DialogResult.OK;
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void yapieklecs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}