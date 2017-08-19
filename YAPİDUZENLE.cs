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
    public partial class YAPİDUZENLE : DevExpress.XtraEditors.XtraForm
    {
        public YAPİDUZENLE()
        {
            InitializeComponent();
        }
        hasemlakDataSet.yapibilgiiRow yapi;
        private void YAPİDUZENLE_Load(object sender, EventArgs e)
        {
            dataGridView1.Focus();
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
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
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapibilgii' table. You can move, or remove it, as needed.
            this.yapibilgiiTableAdapter.Fill(this.hasemlakDataSet.yapibilgii);

        }

        private void yvazgecbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void yduzenlebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(yapiidlbl.Text);
                yapi = hasemlakDataSet.yapibilgii.FindByyapi_id(id);
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
                yapibilgiiTableAdapter.Update(yapi);
             
                MessageBox.Show(id + " " + "Numaralı Kayıt Düzenlendi","Kayıt Ekleme Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                temizle();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(),"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void duzelt()
        {
                yapiidlbl.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                yapiturcombo.EditValue = dataGridView1.SelectedRows[0].Cells[1].Value;
                metrekaretxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                odasayicombo.EditValue = dataGridView1.SelectedRows[0].Cells[3].Value;
                yapiyasicombo.EditValue = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                yapikatsayicombo.EditValue = dataGridView1.SelectedRows[0].Cells[5].Value;
                yapibulundugutxt.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            //yapiyasicombo.EditValue= dataGridView1.SelectedRows[0].Cells[6].Value;
                banyocombo.EditValue = dataGridView1.SelectedRows[0].Cells[7].Value;
                ısıcombo.EditValue = dataGridView1.SelectedRows[0].Cells[11].Value;
                fiyattxt.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                fiyatcinscombo.EditValue = dataGridView1.SelectedRows[0].Cells[13].Value;
                cephecombo.EditValue = dataGridView1.SelectedRows[0].Cells[14].Value;
                esyacombo.EditValue = dataGridView1.SelectedRows[0].Cells[15].Value;
                yapidurumcombo.EditValue = dataGridView1.SelectedRows[0].Cells[16].Value;
                kirasatılıkcombo.EditValue = dataGridView1.SelectedRows[0].Cells[17].Value;
                ilcombo.EditValue = dataGridView1.SelectedRows[0].Cells[18].Value;
                ilcecomboo.EditValue = dataGridView1.SelectedRows[0].Cells[19].Value;



                int id =(int)ilcecomboo.EditValue;
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select semt_id,semt_adi from semt where ilce_id=@p", bagla);
                komutt.Parameters.AddWithValue("@p", id);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                semtcomb.Properties.DataSource = dt;
                semtcomb.Properties.ValueMember = "semt_id";
                semtcomb.Properties.DisplayMember = "semt_adi";

                semtcomb.EditValue = dataGridView1.SelectedRows[0].Cells[20].Value;

                bagla.Close();




               //// int semtid = (int)dataGridView1.SelectedRows[0].Cells[20].Value;
               // int skid = (int)dataGridView1.SelectedRows[0].Cells[21].Value; ;

               // SqlConnection bagla2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
               // bagla2.Open();
               // SqlCommand komutt2 = new SqlCommand("select  sokak_id ,sokak_adi from sokakk where  sokak_id=@p2 ", bagla2);
              
               // komutt2.Parameters.AddWithValue("@p2", skid);
               // SqlDataAdapter ap2 = new SqlDataAdapter(komutt2);
               // DataTable dt2 = new DataTable();
               // ap2.Fill(dt);
               // //gridControl1.DataSource = dt;
               // //dataGridView1.DataSource = dt;
               // //gridControl1.DataSource = dt;
               // sokakcombo.Properties.DataSource = dt2;
               // sokakcombo.Properties.ValueMember = "sokak_id";
               // sokakcombo.Properties.DisplayMember = "sokak_adi";

               // sokakcombo.EditValue = dataGridView1.SelectedRows[0].Cells[21].Value;

               // bagla2.Close();
             


               
            
           


        }

        private void YAPİDUZENLE_Resize(object sender, EventArgs e)
        {
            int genislik = this.Width;
            dataGridView1.Width = genislik;
            yapiözellk.Width = genislik - 100;
        }

        private void semtcomb_EditValueChanged(object sender, EventArgs e)
        {
            int semtid = int.Parse(semtcomb.EditValue.ToString());
            int skid = (int)dataGridView1.SelectedRows[0].Cells[21].Value;
            SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
            //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
            bagla.Open();
            SqlCommand komutt = new SqlCommand("select sokak_id,sokak_adi from sokakk where semt_id=@p and sokak_id=@g", bagla);
            komutt.Parameters.AddWithValue("@p", semtid);
            komutt.Parameters.AddWithValue("@g", skid);
            SqlDataAdapter ap = new SqlDataAdapter(komutt);
            DataTable dt = new DataTable();
            ap.Fill(dt);
            //gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            //gridControl1.DataSource = dt;
            sokakcombo.Properties.DataSource = dt;
            sokakcombo.Properties.ValueMember = "sokak_id";
            sokakcombo.Properties.DisplayMember = "sokak_adi";
            sokakcombo.EditValue = skid;
            bagla.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            duzelt();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                yapibilgiiBindingSource.MoveNext();
                duzelt();
            }
            if(e.KeyCode==Keys.Up)
            {
                yapibilgiiBindingSource.MovePrevious();
                duzelt();
        }
        }
        public void temizle()
        {
            metrekaretxt.ResetText();
            
            yapiyasicombo.ResetText();
            yapibulundugutxt.ResetText();
            yapikatsayicombo.ResetText();
            fiyattxt.ResetText();
            
        }

        private void ilcecomboo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void YAPİDUZENLE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}