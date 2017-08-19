using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.IO;
using System.Drawing.Design;
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.Charts.ChartData;
using DevExpress.Charts.Model.Native;
using DevExpress.Charts.Native;
using System.Diagnostics;


namespace Has___Emlak
{
    public partial class yapilar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public yapilar()
        {
            InitializeComponent();
        }
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
        private void yapilar_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapibilgii' table. You can move, or remove it, as needed.
            this.yapibilgiiTableAdapter.Fill(this.hasemlakDataSet.yapibilgii);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

               
                int id1 = hasemlakDataSet.yapibilgii.Rows.Count + 8;
                yapieklecs ekle = new yapieklecs();
                ekle.yapiidlbl.Text = id1.ToString();
                


                ekle.yeni = true;
                ekle.yapi = hasemlakDataSet.yapibilgii.NewyapibilgiiRow();
                
               
                

            
                if (ekle.ShowDialog() == DialogResult.OK)
                {

                    hasemlakDataSet.yapibilgii.AddyapibilgiiRow(ekle.yapi);

                   
                    yapibilgiiTableAdapter.Update(ekle.yapi);
                   
                    MessageBox.Show("Kayıt Başarı İle Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                //button1_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            YAPİDUZENLE dzn = new YAPİDUZENLE();
            dzn.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            yapiduzenle sil = new yapiduzenle();
            sil.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            excel.Application dosya = new excel.Application();//excel acar
            dosya.Visible = true;//exceli gösterir 
            object a = Type.Missing;
            excel.Workbook kitap = dosya.Workbooks.Add(a);//calısma sayfası olusturur.
            excel.Worksheet sayfa = (excel.Worksheet)kitap.Sheets[1];//calısma alanı çalısma sayfası 1 rakamı kacıncı sayfada calısacaksak
            int sutun = 1;//excele yazdıracagımız satır
            int satır = 1;//excele yazdıracagımız sutun
            for (int i = 0; i < dataGridView1.Columns.Count; i++)//5 alan varsa 5 dönecek
            {
                excel.Range hücre = (excel.Range)sayfa.Cells[satır, sutun + i];//alan hangi alan hücre biri sıfırdan digeri biroldugu için +2
                hücre.Value2 = dataGridView1.Columns[i].HeaderText;//alanın o degerine
            }
            satır++;
            for (int z = 0; z < dataGridView1.Rows.Count; z++)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    try
                    {
                        excel.Range hücre = (excel.Range)sayfa.Cells[satır + z, sutun + i];
                        hücre.Value2 = dataGridView1[i, z].Value;
                    }
                    catch (Exception bb)
                    {

                        MessageBox.Show(bb.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ilanword wordaktar = new ilanword();
                wordaktar.label2.Text = "yapi";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select yapi_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi ,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,isitma_turu,yapi_fiyati,cinsi,cephe,esya_durumu,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from yapibilgii y JOIN yapitur f on f.yapi_tur_id=y.yapi_tur_id JOIN fiyatcins t on t.cins_id =y.cins_id JOIN cephe p on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id = x.durum_id JOIN kstur w on y.tur_id =w.tur_id JOIN il ö on y.il_id=ö.il_id  JOIN ilce j on y.ilce_id =j.ilce_id JOIN semt r on y.semt_id =r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ısınma k on y.isi_id=k.isi_id JOIN esya i on y.esya_id=i.esya_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                wordaktar.dataGridView1.DataSource = dt;
                wordaktar.ShowDialog();
                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ilanpdf pdfaktar = new ilanpdf();
                pdfaktar.label2.Text = "yapi";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select yapi_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi ,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,isitma_turu,yapi_fiyati,cinsi,cephe,esya_durumu,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from yapibilgii y JOIN yapitur f on f.yapi_tur_id=y.yapi_tur_id JOIN fiyatcins t on t.cins_id =y.cins_id JOIN cephe p on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id = x.durum_id JOIN kstur w on y.tur_id =w.tur_id JOIN il ö on y.il_id=ö.il_id  JOIN ilce j on y.ilce_id =j.ilce_id JOIN semt r on y.semt_id =r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ısınma k on y.isi_id=k.isi_id JOIN esya i on y.esya_id=i.esya_id ";
               // string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;


                pdfaktar.dataGridView1.DataSource = dt;
                pdfaktar.ShowDialog();
                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                txtaktarım txt = new txtaktarım();
                txt.label2.Text = "yapi";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select yapi_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi ,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,isitma_turu,yapi_fiyati,cinsi,cephe,esya_durumu,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from yapibilgii y JOIN yapitur f on f.yapi_tur_id=y.yapi_tur_id JOIN fiyatcins t on t.cins_id =y.cins_id JOIN cephe p on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id = x.durum_id JOIN kstur w on y.tur_id =w.tur_id JOIN il ö on y.il_id=ö.il_id  JOIN ilce j on y.ilce_id =j.ilce_id JOIN semt r on y.semt_id =r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ısınma k on y.isi_id=k.isi_id JOIN esya i on y.esya_id=i.esya_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                txt.dataGridView1.DataSource = dt;
                bagla.Close();
                txt.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                mailmenu mail = new mailmenu();
                mail.labelControl1.Text = "yapi";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select yapi_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi ,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,isitma_turu,yapi_fiyati,cinsi,cephe,esya_durumu,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from yapibilgii y JOIN yapitur f on f.yapi_tur_id=y.yapi_tur_id JOIN fiyatcins t on t.cins_id =y.cins_id JOIN cephe p on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id = x.durum_id JOIN kstur w on y.tur_id =w.tur_id JOIN il ö on y.il_id=ö.il_id  JOIN ilce j on y.ilce_id =j.ilce_id JOIN semt r on y.semt_id =r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ısınma k on y.isi_id=k.isi_id JOIN esya i on y.esya_id=i.esya_id ";
              //  string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
                //SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                mail.mailgrd.DataSource = dt;
                mail.ShowDialog();
                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                PrintPreviewDialog onizleme = new PrintPreviewDialog();
                onizleme.Document = printDocument1;
                onizleme.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                PrintDialog yazdir = new PrintDialog();
                yazdir.Document = printDocument1;
                yazdir.UseEXDialog = true;
                if (yazdir.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                bFirstPage = true;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;


                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];

                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;

                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {

                            e.Graphics.DrawString("Çıktı Başlığı", new System.Drawing.Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("HAS EMLAK İLAN BİLGİLERİ", new System.Drawing.Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new System.Drawing.Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new System.Drawing.Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("HAS EMLAK İLAN BİLGİLERİ", new System.Drawing.Font(new System.Drawing.Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new System.Drawing.Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new System.Drawing.Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;

                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }

                            e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }


                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                pdfac pdf = new pdfac();
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Pdf Dosyaları (*.Pdf)|*.Pdf|Tüm Dosyalar (*.*)|*.*";
                op.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-Pdf-Dökümanları";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    pdf.pdfViewer1.DocumentFilePath = op.FileName.ToString();
                    pdf.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                metinac txtword = new metinac();
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Word Dosyaları (*.docx/.dox)|*.docx|Txt Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                op.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (op.FileName.EndsWith(".txt"))
                    {

                        StreamReader sr = new StreamReader(op.FileName, Encoding.Default, true);
                        while (!sr.EndOfStream)
                        {
                            txtword.richEditControl1.Text = sr.ReadToEnd();
                        }
                        sr.Close();
                        txtword.ShowDialog();
                    }
                    else if (op.FileName.EndsWith(".docx") || op.FileName.EndsWith(".doc"))
                    {
                        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                        object nullObject = System.Reflection.Missing.Value;
                        object file = op.FileName.ToString();
                        Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(ref file, ref nullObject, ref nullObject,
                                 ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject,
                                 ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject,
                                 ref nullObject);
                        doc.ActiveWindow.Selection.WholeStory();
                        doc.ActiveWindow.Selection.Copy();
                        IDataObject data = Clipboard.GetDataObject();
                        string text = data.GetData(DataFormats.Text).ToString();

                        txtword.richEditControl1.Text = text;
                        txtword.ShowDialog();
                        doc.Close(ref nullObject, ref nullObject, ref nullObject);
                        app.Quit(ref nullObject, ref nullObject, ref nullObject);
                    }
                }



            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                excelac excel = new excelac();
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Excel Dosyaları(*.xlsx/.xls)|*.xlsx|Tüm Dosyalar (*.*)|*.*";
                op.InitialDirectory = @"C:\Users\Administrator\Documents";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (op.FileName.EndsWith(".xlsx"))
                    {
                        excel.spreadsheetControl1.LoadDocument(op.FileName.ToString());
                    }
                }
                excel.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
        istatistik();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                MessageBox.Show("Bilgileri Alma Şu Şekildedir" + Environment.NewLine + "Yapi No,Yapı tur no,metrekare,odasayisi,yapinin yaşı,yapıdaki kat sayısı,yapının katı ,banyo sayısı,ic özellikler ,dış özellikler,konum özellikleri,ısı no,fiyatı,fiyat cinsi,cephe no,eşya no,ev durum no,tur no,il no ,ilce no ,semt no ,sokak no" + Environment.NewLine + "Örnek :" + Environment.NewLine + "1,1,200,3+1,10,5,5,1,klima yangın merdıveni, guvenlık otopark,okula yakın hastaneye yakın,1,1000,1,1,1,1,1,1,1,1,1", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenFileDialog op = new OpenFileDialog();
                if (op.ShowDialog() == DialogResult.OK)
                {
                    op.Filter = "Metin Belgesi (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                    op.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri";
                    StreamReader sr = new StreamReader(op.FileName, Encoding.Default, true);


                    while (!sr.EndOfStream)
                    {
                        hasemlakDataSet.yapibilgiiRow r = hasemlakDataSet.yapibilgii.NewyapibilgiiRow();
                        String[] kayit = sr.ReadLine().Split(',');
                        if (!r.yapi_id.ToString().Contains(kayit[0]))
                        {
                            r.yapi_id = int.Parse(kayit[0]);
                        }
                        r.yapi_tur_id = int.Parse(kayit[1]);
                        r.metrekare = kayit[2].ToString();
                        r.oda_sayisi = kayit[3].ToString();
                        r.yapi_yasi=kayit[4].ToString();
                        r.yapidaki_kat_sayisi = kayit[5].ToString();
                        r.yapinin_kati = kayit[6].ToString();
                        r.banyo_sayisi = kayit[7].ToString();
                        r.ic_özellikleri=kayit[8].ToString();
                            r.dis_özellikleri=kayit[9].ToString();
                            r.konum_özellikleri = kayit[10].ToString();
                        r.isi_id=int.Parse(kayit[11]);
                            r.yapi_fiyati=kayit[12].ToString();
                            r.cins_id = int.Parse(kayit[13]);
                        r.cephe_id=int.Parse(kayit[14]);
                        r.esya_id = int.Parse(kayit[15]);
                        r.durum_id = int.Parse(kayit[16]);
                        r.tur_id = int.Parse(kayit[17]);
                        r.il_id=int.Parse(kayit[18]);
                            r.ilce_id=int.Parse(kayit[19]);
                            r.semt_id=int.Parse(kayit[20]);
                            r.sokak_id = int.Parse(kayit[21]);
                        //r.musteri_adi = kayit[1].ToUpper();
                        //r.musteri_soyadi = kayit[2].ToUpper();
                        //if (kayit[3].Length < 11)
                        //{
                        //    r.musteri_telefon = kayit[3];
                        //}

                        //r.musteri_e_posta = kayit[4];
                        //hasemlakDataSet.ilanverenmusteri.AddilanverenmusteriRow(r);
                        //ilanverenmusteriTableAdapter.Update(r);
                        //vt1aDataSet.ogrencilerRow r = vt1aDataSet1.ogrenciler.NewogrencilerRow();
                        //String[] cumle = sr.ReadLine().Split(',');
                        //r.ad = cumle[1];
                        //r.soyad = cumle[2];
                        //r.bolum_id = Convert.ToInt32(cumle[3]);

                        //vt1aDataSet1.ogrenciler.AddogrencilerRow(r);
                        //ogrencilerTableAdapter.Update(r);
                            hasemlakDataSet.yapibilgii.AddyapibilgiiRow(r);
                            yapibilgiiTableAdapter.Update(r);
                    }
                
                MessageBox.Show("Kayıt Başarı İle Aktarıldı", "Kayıt Aktarım Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void istatistik()
        {
            try
            {
                yapidetay detay = new yapidetay();
                detay.ilansayilbl.Text = hasemlakDataSet.yapibilgii.Rows.Count.ToString();
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
              //  SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand kmt = new SqlCommand("select yapi_tur_id,count(yapi_id) from yapibilgii group by(yapi_tur_id) HAVING yapi_tur_id=1", bagla);
                SqlDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {

                    DevExpress.XtraCharts.Series ss = new DevExpress.XtraCharts.Series();


                    ss.LegendText = "Ev  ";

                    ss.Name = "Ev  Sayısı";

                    detay.chartControl1.Series.Add(ss);

                    detay.chartControl1.Series[1].Points.AddPoint(DateTime.Now.ToShortDateString() + " " + "Tarihli Ev  Sayısı", double.Parse(oku[1].ToString()));

                    detay.evilanlbl.Text = oku[1].ToString();
                }
                bagla.Close();

                SqlConnection bagla2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                //SqlConnection bagla2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla2.Open();
                SqlCommand kmt2 = new SqlCommand("select yapi_tur_id,count(yapi_id) from yapibilgii group by(yapi_tur_id) HAVING yapi_tur_id=2", bagla2);
                SqlDataReader oku2 = kmt2.ExecuteReader();
                while (oku2.Read())
                {

                    DevExpress.XtraCharts.Series ss = new DevExpress.XtraCharts.Series();


                    ss.LegendText = "Bina  ";

                    ss.Name = "Bina  Sayısı";

                    detay.chartControl1.Series.Add(ss);

                    detay.chartControl1.Series[2].Points.AddPoint(DateTime.Now.ToShortDateString() + " " + "Tarihli Bina  Sayısı", double.Parse(oku2[1].ToString()));

                    detay.binailanlbl.Text = oku2[1].ToString();
                }

                bagla2.Close();
                /////////

                SqlConnection bagla3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                //SqlConnection bagla3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla3.Open();
                SqlCommand kmt3 = new SqlCommand("select yapi_tur_id,count(yapi_id) from yapibilgii group by(yapi_tur_id) HAVING yapi_tur_id=3", bagla3);
                SqlDataReader oku3 = kmt3.ExecuteReader();
                while (oku3.Read())
                {

                    DevExpress.XtraCharts.Series ss = new DevExpress.XtraCharts.Series();


                    ss.LegendText = "Dükkan  ";

                    ss.Name = "Dükkan  Sayısı";

                    detay.chartControl1.Series.Add(ss);

                    detay.chartControl1.Series[3].Points.AddPoint(DateTime.Now.ToShortDateString() + " " + "Tarihli Dükkan  Sayısı", double.Parse(oku3[1].ToString()));

                    detay.dukkanilanlbl.Text = oku3[1].ToString();
                }

                bagla3.Close();

                //////////////
                SqlConnection bagla4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla4.Open();
                SqlCommand kmt4 = new SqlCommand("select yapi_tur_id,count(yapi_id) from yapibilgii group by(yapi_tur_id) HAVING yapi_tur_id=4", bagla4);
                SqlDataReader oku4 = kmt4.ExecuteReader();
                while (oku4.Read())
                {

                    DevExpress.XtraCharts.Series ss = new DevExpress.XtraCharts.Series();


                    ss.LegendText = "Arsa ";

                    ss.Name = "Arsa  Sayısı";

                    detay.chartControl1.Series.Add(ss);

                    detay.chartControl1.Series[4].Points.AddPoint(DateTime.Now.ToShortDateString() + " " + "Tarihli Arsa  Sayısı", double.Parse(oku4[1].ToString()));

                    detay.arsailanlbl.Text = oku4[1].ToString();
                }

                bagla4.Close();
                detay.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            resimgaleri resim = new resimgaleri();
      
            resim.ShowDialog();
        }

        private void yapıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
            {

               
                int id1 = hasemlakDataSet.yapibilgii.Rows.Count + 8;
                yapieklecs ekle = new yapieklecs();
                ekle.yapiidlbl.Text = id1.ToString();
                


                ekle.yeni = true;
                ekle.yapi = hasemlakDataSet.yapibilgii.NewyapibilgiiRow();
                
               
                

            
                if (ekle.ShowDialog() == DialogResult.OK)
                {

                    hasemlakDataSet.yapibilgii.AddyapibilgiiRow(ekle.yapi);

                   
                    yapibilgiiTableAdapter.Update(ekle.yapi);
                   
                    MessageBox.Show("Kayıt Başarı İle Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                //button1_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void yapıDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YAPİDUZENLE dzn = new YAPİDUZENLE();
            dzn.ShowDialog();
        }

        private void yapıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yapiduzenle sil = new yapiduzenle();
            sil.ShowDialog();
        }

        private void yapıDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            istatistik();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.Application dosya = new excel.Application();//excel acar
            dosya.Visible = true;//exceli gösterir 
            object a = Type.Missing;
            excel.Workbook kitap = dosya.Workbooks.Add(a);//calısma sayfası olusturur.
            excel.Worksheet sayfa = (excel.Worksheet)kitap.Sheets[1];//calısma alanı çalısma sayfası 1 rakamı kacıncı sayfada calısacaksak
            int sutun = 1;//excele yazdıracagımız satır
            int satır = 1;//excele yazdıracagımız sutun
            for (int i = 0; i < dataGridView1.Columns.Count; i++)//5 alan varsa 5 dönecek
            {
                excel.Range hücre = (excel.Range)sayfa.Cells[satır, sutun + i];//alan hangi alan hücre biri sıfırdan digeri biroldugu için +2
                hücre.Value2 = dataGridView1.Columns[i].HeaderText;//alanın o degerine
            }
            satır++;
            for (int z = 0; z < dataGridView1.Rows.Count; z++)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    try
                    {
                        excel.Range hücre = (excel.Range)sayfa.Cells[satır + z, sutun + i];
                        hücre.Value2 = dataGridView1[i, z].Value;
                    }
                    catch (Exception bb)
                    {

                        MessageBox.Show(bb.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ilanword wordaktar = new ilanword();
                wordaktar.label2.Text = "yapi";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select yapi_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi ,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,isitma_turu,yapi_fiyati,cinsi,cephe,esya_durumu,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from yapibilgii y JOIN yapitur f on f.yapi_tur_id=y.yapi_tur_id JOIN fiyatcins t on t.cins_id =y.cins_id JOIN cephe p on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id = x.durum_id JOIN kstur w on y.tur_id =w.tur_id JOIN il ö on y.il_id=ö.il_id  JOIN ilce j on y.ilce_id =j.ilce_id JOIN semt r on y.semt_id =r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ısınma k on y.isi_id=k.isi_id JOIN esya i on y.esya_id=i.esya_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                wordaktar.dataGridView1.DataSource = dt;
                wordaktar.ShowDialog();
                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ilanpdf pdfaktar = new ilanpdf();
                pdfaktar.label2.Text = "yapi";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select yapi_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi ,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,isitma_turu,yapi_fiyati,cinsi,cephe,esya_durumu,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from yapibilgii y JOIN yapitur f on f.yapi_tur_id=y.yapi_tur_id JOIN fiyatcins t on t.cins_id =y.cins_id JOIN cephe p on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id = x.durum_id JOIN kstur w on y.tur_id =w.tur_id JOIN il ö on y.il_id=ö.il_id  JOIN ilce j on y.ilce_id =j.ilce_id JOIN semt r on y.semt_id =r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ısınma k on y.isi_id=k.isi_id JOIN esya i on y.esya_id=i.esya_id ";
                // string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;


                pdfaktar.dataGridView1.DataSource = dt;
                pdfaktar.ShowDialog();
                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtaktarım txt = new txtaktarım();
                txt.label2.Text = "yapi";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select yapi_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi ,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,isitma_turu,yapi_fiyati,cinsi,cephe,esya_durumu,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from yapibilgii y JOIN yapitur f on f.yapi_tur_id=y.yapi_tur_id JOIN fiyatcins t on t.cins_id =y.cins_id JOIN cephe p on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id = x.durum_id JOIN kstur w on y.tur_id =w.tur_id JOIN il ö on y.il_id=ö.il_id  JOIN ilce j on y.ilce_id =j.ilce_id JOIN semt r on y.semt_id =r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ısınma k on y.isi_id=k.isi_id JOIN esya i on y.esya_id=i.esya_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                txt.dataGridView1.DataSource = dt;
                bagla.Close();
                txt.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mailmenu mail = new mailmenu();
                mail.labelControl1.Text = "yapi";
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
                string sorgu = "select yapi_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi ,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,isitma_turu,yapi_fiyati,cinsi,cephe,esya_durumu,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from yapibilgii y JOIN yapitur f on f.yapi_tur_id=y.yapi_tur_id JOIN fiyatcins t on t.cins_id =y.cins_id JOIN cephe p on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id = x.durum_id JOIN kstur w on y.tur_id =w.tur_id JOIN il ö on y.il_id=ö.il_id  JOIN ilce j on y.ilce_id =j.ilce_id JOIN semt r on y.semt_id =r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ısınma k on y.isi_id=k.isi_id JOIN esya i on y.esya_id=i.esya_id ";
                //  string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi,ilan_tarihi,musteri_adi,musteri_soyadi,musteri_telefon,musteri_e_posta from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id JOIN ilanverenmusteri ç on ç.musteri_id=e.musteri_id ";
                //string sorgu = "select ilan_id,yapi_turu,metrekare,oda_sayisi,yapi_yasi,yapidaki_kat_sayisi,yapinin_kati,banyo_sayisi,ic_özellikleri,dis_özellikleri,konum_özellikleri,yapi_fiyati,cinsi,cephe,mevcut_durum,tur_adi,il_adi,ilce_adi,semt_adi,sokak_adi from ilant e JOIN yapibilgii y on e.yapi_id=y.yapi_id JOIN yapitur f on f.yapi_tur_id = y.yapi_tur_id JOIN fiyatcins t on t.cins_id = y.cins_id JOIN cephe p  on y.cephe_id = p.cephe_id JOIN evdurum x on y.durum_id=x.durum_id JOIN kstur w on y.tur_id=w.tur_id JOIN il ö on y.il_id=ö.il_id JOIN ilce j on y.ilce_id=j.ilce_id JOIN semt r on y.semt_id=r.semt_id JOIN sokakk n on y.sokak_id=n.sokak_id ";
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand komutt = new SqlCommand(sorgu, bagla);
                SqlDataAdapter ap = new SqlDataAdapter(komutt);
                DataTable dt = new DataTable();
                ap.Fill(dt);
                mail.mailgrd.DataSource = dt;
                mail.ShowDialog();
                bagla.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog yazdir = new PrintDialog();
                yazdir.Document = printDocument1;
                yazdir.UseEXDialog = true;
                if (yazdir.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pdfToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                pdfac pdf = new pdfac();
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Pdf Dosyaları (*.Pdf)|*.Pdf|Tüm Dosyalar (*.*)|*.*";
                op.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-Pdf-Dökümanları";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    pdf.pdfViewer1.DocumentFilePath = op.FileName.ToString();
                    pdf.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wordTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                metinac txtword = new metinac();
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Word Dosyaları (*.docx/.dox)|*.docx|Txt Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                op.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (op.FileName.EndsWith(".txt"))
                    {

                        StreamReader sr = new StreamReader(op.FileName, Encoding.Default, true);
                        while (!sr.EndOfStream)
                        {
                            txtword.richEditControl1.Text = sr.ReadToEnd();
                        }
                        sr.Close();
                        txtword.ShowDialog();
                    }
                    else if (op.FileName.EndsWith(".docx") || op.FileName.EndsWith(".doc"))
                    {
                        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                        object nullObject = System.Reflection.Missing.Value;
                        object file = op.FileName.ToString();
                        Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(ref file, ref nullObject, ref nullObject,
                                 ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject,
                                 ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject, ref nullObject,
                                 ref nullObject);
                        doc.ActiveWindow.Selection.WholeStory();
                        doc.ActiveWindow.Selection.Copy();
                        IDataObject data = Clipboard.GetDataObject();
                        string text = data.GetData(DataFormats.Text).ToString();

                        txtword.richEditControl1.Text = text;
                        txtword.ShowDialog();
                        doc.Close(ref nullObject, ref nullObject, ref nullObject);
                        app.Quit(ref nullObject, ref nullObject, ref nullObject);
                    }
                }



            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                excelac excel = new excelac();
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Excel Dosyaları(*.xlsx/.xls)|*.xlsx|Tüm Dosyalar (*.*)|*.*";
                op.InitialDirectory = @"C:\Users\Administrator\Documents";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    if (op.FileName.EndsWith(".xlsx"))
                    {
                        excel.spreadsheetControl1.LoadDocument(op.FileName.ToString());
                    }
                }
                excel.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resimlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resimgaleri resim = new resimgaleri();

            resim.ShowDialog();
        }

        private void yapilar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        }
    }
