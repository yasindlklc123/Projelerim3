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
    public partial class ilandüzenle : DevExpress.XtraEditors.XtraForm
    {
        public ilandüzenle()
        {
            InitializeComponent();
        }
        public Boolean yeni;
  
        public hasemlakDataSet.ilantRow ilan;
        public hasemlakDataSet.ilanverenmusteriRow musteri;

        private void ilandüzenle_Load(object sender, EventArgs e)
        {
          
            
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilant' table. You can move, or remove it, as needed.
            this.ilantTableAdapter.Fill(this.hasemlakDataSet.ilant);
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
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilce' table. You can move, or remove it, as needed.
            this.ilceTableAdapter.Fill(this.hasemlakDataSet.ilce);
            // TODO: This line of code loads data into the 'hasemlakDataSet.il' table. You can move, or remove it, as needed.
            this.ilTableAdapter.Fill(this.hasemlakDataSet.il);
            // TODO: This line of code loads data into the 'hasemlakDataSet.fiyatcins' table. You can move, or remove it, as needed.
            this.fiyatcinsTableAdapter.Fill(this.hasemlakDataSet.fiyatcins);
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapitur' table. You can move, or remove it, as needed.
            this.yapiturTableAdapter.Fill(this.hasemlakDataSet.yapitur);
            //this.WindowState = FormWindowState.Maximized;
        }

       

     
        public void düzelt()
        {
        //    yapiturcombo.Properties.ValueMember  = yapi.yapi_tur_id.ToString();
            ilanid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ilandurumcombo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ilantarihcombo.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            ilansonucombo.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
      

   

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(ilanid.Text);
                ilan = hasemlakDataSet.ilant.FindByilan_id(id);
                ilan.ilan_durumu = ilandurumcombo.Text.ToUpper();
                ilan.ilan_tarihi = DateTime.Parse(ilantarihcombo.Text.ToString());
                ilan.ilan_sonuc = ilansonucombo.Text.ToUpper();
                ilantTableAdapter.Update(ilan);
                MessageBox.Show(ilanid.Text + " " + "Numaralı Kayıt Düzenlendi");
                ilanid.ResetText();
                ilandurumcombo.ResetText();
                ilantarihcombo.ResetText();
                ilansonucombo.ResetText();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

   
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            düzelt();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            try
            {
                mduzenle mduzen = new mduzenle();
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                mduzen.mnoidi.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string sorgu = "select * from ilanverenmusteri where musteri_id=@p ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                komutt.Parameters.AddWithValue("@p", (int)dataGridView1.SelectedRows[0].Cells[4].Value);
                SqlDataReader dr = komutt.ExecuteReader();
                while (dr.Read())
                {
                    mduzen.maditxt.Text = dr[1].ToString().ToUpper();
                    mduzen.msoyaditxt.Text = dr[2].ToString().ToUpper();
                    mduzen.mtlfntxt.Text = dr[3].ToString();
                    mduzen.mpostatxt.Text = dr[4].ToString();
                }
                //SqlDataAdapter ap = new SqlDataAdapter(komutt);
                //DataTable dt = new DataTable();
                //ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;

                bagla.Close();
                mduzen.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ilantBindingSource.MoveNext();
                ilantBindingSource1.MoveNext();
                düzelt();
            }
            if (e.KeyCode == Keys.Up)
            {
                
                ilantBindingSource.MovePrevious();
                ilantBindingSource1.MovePrevious();
                düzelt();
            }
        }

        private void hyperlinkLabelControl2_Click(object sender, EventArgs e)
        {
           
            try
            {
                YAPİDUZENLE dzn = new YAPİDUZENLE();
                dzn.yapiidlbl.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii where yapi_id =@p";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                komutt.Parameters.AddWithValue("@p", (int)dataGridView1.SelectedRows[0].Cells[1].Value);
                SqlDataReader dr = komutt.ExecuteReader();
                while (dr.Read())
                {
                    dzn.yapiturcombo.EditValue = dr[1];
                    dzn.metrekaretxt.Text = dr[2].ToString();
                    dzn.odasayicombo.EditValue = dr[3].ToString();
                    dzn.yapiyasicombo.EditValue = dr[4].ToString();
                    dzn.yapikatsayicombo.EditValue = dr[5];
                    dzn.yapibulundugutxt.Text = dr[6].ToString();
                    dzn.banyocombo.EditValue = dr[7];
                    dzn.ısıcombo.EditValue = dr[11];
                    dzn.fiyattxt.Text = dr[12].ToString();
                    dzn.fiyatcinscombo.EditValue = dr[13];
                    dzn.cephecombo.EditValue = dr[14];
                    dzn.esyacombo.EditValue = dr[15];
                    dzn.yapidurumcombo.EditValue = dr[16];
                    dzn.kirasatılıkcombo.EditValue = dr[17];
                    dzn.ilcombo.EditValue = dr[18];
                    dzn.ilcecomboo.EditValue = dr[19];
                   // dzn.semtcomb.EditValue = dr[21];
                    //dzn.sokakcombo.EditValue = dr[21];
                
                }
                bagla.Close();
                dzn.ShowDialog();
                //int id = int.Parse(yapiidlbl.Text);
                //yapi = hasemlakDataSet.yapibilgii.FindByyapi_id(id);
                //yapi.yapi_tur_id = int.Parse(yapiturcombo.EditValue.ToString());
                //yapi.metrekare = metrekaretxt.Text.ToUpper();
                //yapi.oda_sayisi = odasayicombo.EditValue.ToString().ToUpper();
                //yapi.yapi_yasi = yapiyasicombo.EditValue.ToString().ToUpper();
                //yapi.yapidaki_kat_sayisi = yapikatsayicombo.EditValue.ToString().ToUpper();
                //yapi.yapinin_kati = yapibulundugutxt.Text.ToUpper();
                //yapi.banyo_sayisi = banyocombo.EditValue.ToString().ToUpper();
                //yapi.isi_id = int.Parse(ısıcombo.EditValue.ToString());
                //yapi.yapi_fiyati = fiyattxt.Text.ToUpper();
                //yapi.cins_id = int.Parse(fiyatcinscombo.EditValue.ToString());
                //yapi.cephe_id = int.Parse(cephecombo.EditValue.ToString());
                //yapi.esya_id = int.Parse(esyacombo.EditValue.ToString());
                //yapi.durum_id = int.Parse(yapidurumcombo.EditValue.ToString());
                //yapi.tur_id = int.Parse(kirasatılıkcombo.EditValue.ToString());
                //yapi.il_id = int.Parse(ilcombo.EditValue.ToString());
                //yapi.ilce_id = int.Parse(ilcecomboo.EditValue.ToString());
                //yapi.semt_id = int.Parse(semtcomb.EditValue.ToString());
                //yapi.sokak_id = int.Parse(sokakcombo.EditValue.ToString());
                //yapibilgiiTableAdapter.Update(yapi);

               // MessageBox.Show(id + " " + "Numaralı Kayıt Düzenlendi", "Kayıt Ekleme Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //temizle();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(ilanid.Text);
                ilan = hasemlakDataSet.ilant.FindByilan_id(id);
                ilan.ilan_durumu = ilandurumcombo.Text.ToUpper();
                ilan.ilan_tarihi = DateTime.Parse(ilantarihcombo.Text.ToString());
                ilan.ilan_sonuc = ilansonucombo.Text.ToUpper();
                ilantTableAdapter.Update(ilan);
                MessageBox.Show(ilanid.Text + " " + "Numaralı Kayıt Düzenlendi");
                ilanid.ResetText();
                ilandurumcombo.ResetText();
                ilantarihcombo.ResetText();
                ilansonucombo.ResetText();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ilandüzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}