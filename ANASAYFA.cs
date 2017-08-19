using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Has___Emlak
{
    public partial class ANASAYFA : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ANASAYFA()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            İLANLAR ilan = new İLANLAR();

            ilan.ShowDialog();
        }
        public void getir()
        {
            string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
            //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
            SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024");
            bagla.Open();
            SqlCommand komutt = new SqlCommand(sorgu, bagla);
            SqlDataAdapter ap = new SqlDataAdapter(komutt);
            DataTable dt = new DataTable();
            ap.Fill(dt);
            //gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            bagla.Close();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            MUSTERİLER musteri = new MUSTERİLER();
            musteri.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            webtarayici tarayici = new webtarayici();

            tarayici.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

            yapilar yapilarim = new yapilar();
            yapilarim.ShowDialog();
        }

        private void ANASAYFA_Load(object sender, EventArgs e)
        {
            try
            {
                getir();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void ANASAYFA_Resize(object sender, EventArgs e)
        {
            int genislik = this.Width;
            int yukseklik = this.Height - 400;
            gridControl1.Width = genislik;
        }

        private void iLANLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            İLANLAR ilan = new İLANLAR();

            ilan.ShowDialog();
        }

        private void mÜŞTERİLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MUSTERİLER musteri = new MUSTERİLER();
            musteri.ShowDialog();
        }

        private void wEBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webtarayici tarayici = new webtarayici();

            tarayici.Show();
        }

        private void yAPILARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yapilar yapilarim = new yapilar();
            yapilarim.ShowDialog();
        }

        private void ANASAYFA_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
                {
                    Process.Start("shutdown", "-a");
                    MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (e.CloseReason == System.Windows.Forms.CloseReason.UserClosing)
                {
                    if ((MessageBox.Show("Has Emlak Programını  Kapatmak İstiyor Musunuz ?", "Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No))
                    {
                        e.Cancel = true;
                    }
                }
                if (e.CloseReason == System.Windows.Forms.CloseReason.ApplicationExitCall)
                {
                    e.Cancel = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}