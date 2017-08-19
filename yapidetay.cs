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
    public partial class yapidetay : DevExpress.XtraEditors.XtraForm
    {
        public yapidetay()
        {
            InitializeComponent();
        }

        private void yapidetay_Load(object sender, EventArgs e)
        {
            SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
            //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
            bagla.Open();
            SqlCommand komutt = new SqlCommand("select * from yapibilgii ", bagla);

            SqlDataAdapter ap = new SqlDataAdapter(komutt);
            DataTable dt = new DataTable();
            ap.Fill(dt);
            //gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            //gridControl1.DataSource = dt;
            dataGridView1.DataSource = dt;

            bagla.Close();
            label3.Hide();
            // TODO: This line of code loads data into the 'hasemlakDataSet.kstur' table. You can move, or remove it, as needed.
            this.ksturTableAdapter.Fill(this.hasemlakDataSet.kstur);
            // TODO: This line of code loads data into the 'hasemlakDataSet.evdurum' table. You can move, or remove it, as needed.
            this.evdurumTableAdapter.Fill(this.hasemlakDataSet.evdurum);
            // TODO: This line of code loads data into the 'hasemlakDataSet.esya' table. You can move, or remove it, as needed.
            this.esyaTableAdapter.Fill(this.hasemlakDataSet.esya);
            lookUpEdit2.Hide();
            lookUpEdit3.Hide();
            lookUpEdit1.Hide();
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            // TODO: This line of code loads data into the 'hasemlakDataSet.fiyatcins' table. You can move, or remove it, as needed.
            this.fiyatcinsTableAdapter.Fill(this.hasemlakDataSet.fiyatcins);
            // TODO: This line of code loads data into the 'hasemlakDataSet.cephe' table. You can move, or remove it, as needed.
            this.cepheTableAdapter.Fill(this.hasemlakDataSet.cephe);
            // TODO: This line of code loads data into the 'hasemlakDataSet.ısınma' table. You can move, or remove it, as needed.
            this.ısınmaTableAdapter.Fill(this.hasemlakDataSet.ısınma);
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapibilgii' table. You can move, or remove it, as needed.
            this.yapibilgiiTableAdapter.Fill(this.hasemlakDataSet.yapibilgii);
            label5.Text = dataGridView1.Rows.Count.ToString();
           
        }

        private void ilansayi_Enter(object sender, EventArgs e)
        {

        }
        public void metrekare()
        {
            //if(comboBox1.SelectedItem.ToString()==
      
            //gridControl1.DataSource = dt;
            //dataGridView1.DataSource = dt;
            //gridControl1.DataSource = dt;

         
            lookUpEdit1.Hide();
            lookUpEdit2.Hide();
            lookUpEdit3.Hide();
            lookUpEdit1.Hide();
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                if (checkEdit2.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "metrekare Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                if (checkEdit2.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "metrekare Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                if (checkEdit2.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "metrekare Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {
                if (checkEdit2.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "metrekare Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                if (checkEdit2.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "metrekare Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }

            
        }
        public void fiyat()
        {
            lookUpEdit1.Hide();
            lookUpEdit2.Hide();
            lookUpEdit3.Hide();
            lookUpEdit1.Hide();
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                if (checkEdit6.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "yapifiyati Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                if (checkEdit6.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "yapifiyati Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                if (checkEdit6.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "yapifiyati Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {
                if (checkEdit6.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                  //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "yapifiyati Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                if (checkEdit6.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                  //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "yapifiyati Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
        }
        public void icözellik()
        {
            lookUpEdit1.Hide();
            lookUpEdit2.Hide();
            lookUpEdit3.Hide();
            lookUpEdit1.Hide();
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                if (checkEdit8.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "ic_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                }
            }
            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                if (checkEdit8.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "ic_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                if (checkEdit8.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                  //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "ic_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {
                if (checkEdit8.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "ic_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                if (checkEdit8.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "ic_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
        }
        public void disözellik()
        {
            lookUpEdit1.Hide();
            lookUpEdit2.Hide();
            lookUpEdit3.Hide();
            lookUpEdit1.Hide();
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                if (checkEdit9.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "dis_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                    //  yapibilgiiBindingSource.Filter = "dis_özellikleri Like'" + textEdit1.Text + "%'";
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                if (checkEdit9.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                  //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "dis_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                if (checkEdit9.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "dis_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {
                if (checkEdit9.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "dis_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                if (checkEdit9.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                  //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "dis_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
        }
        public void konumözellik()
        {
            lookUpEdit1.Hide();
            lookUpEdit2.Hide();
            lookUpEdit3.Hide();
            lookUpEdit1.Hide();
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                if (checkEdit10.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "konum_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                    // yapibilgiiBindingSource.Filter = "konum_özellikleri Like'" + textEdit1.Text + "%'";
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                if (checkEdit10.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                  //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "konum_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                if (checkEdit10.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "konum_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {
                if (checkEdit10.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "konum_özellikleriLike '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                if (checkEdit10.Checked == true)
                {
                    SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "konum_özellikleri Like '" + textEdit1.Text + "%'";
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            }
        }
       

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            metrekare();
            fiyat();
            icözellik();
            disözellik();
            konumözellik();
            label5.Text = dataGridView1.Rows.Count.ToString();
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkEdit3_Click(object sender, EventArgs e)
        {
           lookUpEdit1.Visible = true;
            lookUpEdit2.Hide();
            lookUpEdit3.Hide();
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            label3.Visible = true;
        }

        private void checkEdit7_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void checkEdit7_Click(object sender, EventArgs e)
        {
            lookUpEdit3.Visible = true;
            lookUpEdit2.Hide();
            lookUpEdit1.Hide();
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            label3.Visible = true;
        }

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            lookUpEdit1.Hide();
            lookUpEdit3.Hide();
            lookUpEdit2.Visible = true;
            lookUpEdit4.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            label3.Visible = true;
        }

        private void lookUpEdit4_Click(object sender, EventArgs e)
        {
            
        }

        private void checkEdit11_Click(object sender, EventArgs e)
        {
            lookUpEdit4.Visible = true;
            lookUpEdit3.Hide();
            lookUpEdit2.Hide();
            lookUpEdit5.Hide();
            lookUpEdit6.Hide();
            lookUpEdit1.Hide();
            label3.Visible = true;
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkEdit4_Click(object sender, EventArgs e)
        {
            lookUpEdit5.Visible = true;
            lookUpEdit4.Hide();
            lookUpEdit3.Hide();
            lookUpEdit2.Hide();
            lookUpEdit1.Hide();
            lookUpEdit6.Hide();
            label3.Visible = true;

        }

        private void checkEdit5_Click(object sender, EventArgs e)
        {
            lookUpEdit6.Visible = true;
            lookUpEdit5.Hide();
            lookUpEdit4.Hide();
            lookUpEdit3.Hide();
            lookUpEdit2.Hide();
            lookUpEdit1.Hide();
            label3.Visible = true;
        }

        private void lookUpEdit6_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "tur_id =" + lookUpEdit6.EditValue;
                dataGridView1.DataSource = tmkyt;

                label5.Text = dataGridView1.Rows.Count.ToString();
            }
            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                    string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                    //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                    //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                    //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand(sorgu, bagla);
                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                    //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "tur_id =" + lookUpEdit6.EditValue;
                    dataGridView1.DataSource = tmkyt;
                    label5.Text = dataGridView1.Rows.Count.ToString();
                }
            
            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "tur_id = " + lookUpEdit6.EditValue;
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                
            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {

                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "tur_id  =" +lookUpEdit6.EditValue;
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();

                    label5.Text = dataGridView1.Rows.Count.ToString();
                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                
            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                   // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                    bagla.Open();
                    SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                    SqlDataAdapter ap = new SqlDataAdapter(komutt);
                    DataTable dt = new DataTable();
                    ap.Fill(dt);
                    //gridControl1.DataSource = dt;
                    //dataGridView1.DataSource = dt;
                    //gridControl1.DataSource = dt;
                    DataView tmkyt = dt.DefaultView;
                    tmkyt.RowFilter = "tur_id = " + lookUpEdit6.EditValue;
                    dataGridView1.DataSource = tmkyt;

                    bagla.Close();
                    label5.Text = dataGridView1.Rows.Count.ToString();
                
            }
        }

        private void lookUpEdit5_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "durum_id =" + lookUpEdit5.EditValue;
                dataGridView1.DataSource = tmkyt;
                //yapibilgiiBindingSource.Filter = "durum_id =" + lookUpEdit5.EditValue;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }
            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
              //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "durum_id =" + lookUpEdit5.EditValue;
                dataGridView1.DataSource = tmkyt;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }

            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "durum_id = " + lookUpEdit5.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {

                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "durum_id  =" + lookUpEdit5.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "durum_id = " + lookUpEdit5.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
        }

        private void lookUpEdit4_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "esya_id =" + lookUpEdit4.EditValue;
                dataGridView1.DataSource = tmkyt;
                // yapibilgiiBindingSource.Filter = "esya_id =" + lookUpEdit4.EditValue;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }


            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 

                string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "esya_id =" + lookUpEdit4.EditValue;
                dataGridView1.DataSource = tmkyt;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }

            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "esya_id = " + lookUpEdit4.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {

                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "esya_id  =" + lookUpEdit4.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "esya_id = " + lookUpEdit4.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
        }

        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cins_id =" + lookUpEdit3.EditValue;
                dataGridView1.DataSource = tmkyt;
                // yapibilgiiBindingSource.Filter = "cins_id =" + lookUpEdit3.EditValue;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }


            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
              //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cins_id =" + lookUpEdit3.EditValue;
                dataGridView1.DataSource = tmkyt;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }

            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cins_id = " + lookUpEdit3.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {

                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cins_id  =" + lookUpEdit3.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 

                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cins_id = " + lookUpEdit3.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cephe_id =" + lookUpEdit2.EditValue;
                dataGridView1.DataSource = tmkyt;
                //yapibilgiiBindingSource.Filter = "cephe_id =" + lookUpEdit2.EditValue;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }



            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cephe_id =" + lookUpEdit2.EditValue;
                dataGridView1.DataSource = tmkyt;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }

            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cephe_id = " + lookUpEdit2.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {

                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cephe_id  =" + lookUpEdit2.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "cephe_id = " + lookUpEdit2.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
              //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "isi_id =" + lookUpEdit1.EditValue;
                dataGridView1.DataSource = tmkyt;
                // yapibilgiiBindingSource.Filter = "isi_id =" + lookUpEdit1.EditValue;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }


            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select * from yapibilgii where yapi_tur_id=1";
                //string sorgu = "select cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                //yapibilgiiBindingSource.Filter = "metrekare Like'" + textEdit1.Text + "%'";
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "isi_id =" + lookUpEdit1.EditValue;
                dataGridView1.DataSource = tmkyt;
                label5.Text = dataGridView1.Rows.Count.ToString();
            }

            if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "isi_id = " + lookUpEdit1.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {

                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "isi_id  =" + lookUpEdit1.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
            if (comboBox1.SelectedItem.ToString() == "Bina Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                DataView tmkyt = dt.DefaultView;
                tmkyt.RowFilter = "isi_id = " + lookUpEdit1.EditValue;
                dataGridView1.DataSource = tmkyt;

                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmkyt();
            dukknkyt();
            arskyt();
            bnakyt();
            evkyt();
        }
        public void tmkyt()
        {
            if (comboBox1.SelectedItem.ToString() == "Tüm Kayıtlar İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                dataGridView1.DataSource = dt;
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();
            }
        }
        public void evkyt()
        {
            if (comboBox1.SelectedItem.ToString() == "Ev Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
              //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 1 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                dataGridView1.DataSource = dt;
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();
            }
        }
        public void arskyt()
        {
               if (comboBox1.SelectedItem.ToString() == "Arsa Kayıtları İçin  Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 4 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                dataGridView1.DataSource = dt;
                bagla.Close();

                label5.Text = dataGridView1.Rows.Count.ToString();
            }
                                 
        }
        public void bnakyt()
        {
                 if (comboBox1.SelectedItem.ToString() =="Bina Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 2 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                dataGridView1.DataSource = dt;
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();
            }
            
        }
        public void dukknkyt()
        {
            if (comboBox1.SelectedItem.ToString() == "Dükkan Kayıtları İçin Ara")
            {
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
              //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand("select * from yapibilgii where yapi_tur_id = 3 ", bagla);

                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;
                dataGridView1.DataSource = dt;
                bagla.Close();
                label5.Text = dataGridView1.Rows.Count.ToString();
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void yapidetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}