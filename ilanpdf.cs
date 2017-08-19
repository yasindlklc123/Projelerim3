using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace Has___Emlak
{
    public partial class ilanpdf : DevExpress.XtraEditors.XtraForm
    {
        public ilanpdf()
        {
            InitializeComponent();
        }
       
        private void ilanpdf_Load(object sender, EventArgs e)
        {
            comboBox1.Hide();
            label1.Hide();
            label2.Hide();
        }

        private void pdfbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string yol = @"C:\Users\Administrator\Documents\Has-Emlak-Pdf-Dökümanları";
               

                if (!Directory.Exists(yol))
                {
                    Directory.CreateDirectory(yol);
                }
                string[] yapi = new string[] { "Yapı No :", "Yapinin Turu :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat : ", "Banyo Sayisi :", "Ic Ozellikleri : ", "Dis Ozellikleri : ", "Konum Ozellikleri : ", "Isınma Turu : ", "Yapinin Fiyati :", "Fiyat Turu : ", "Cephe : ", "Esya Durumu :", "Yapinin Durumu : ", "Durumu : ", "Il Adi :", "Ilce Adi :", "Semt Adi : ", "Sokak Adi :" };
                string[] musteri2 = new string[] { "Musteri No :", "Musteri Adi : ", "Musteri Soyadi : ", "Musteri Telefon Numarası : ", "Musteri E-Posta Adresi : " };
                string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : ","Ilanin Tarihi : ","Müsteri Adi : ","Musteri Soyadi :","Musteri Telefon No :", "Musteri E Posta :" };
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Pdf Dosyaları (*.Pdf)|*.Pdf|Tüm Dosyalar (*.*)|*.*";
                sv.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-Pdf-Dökümanları";
                int sayi = dataGridView1.SelectedRows.Count;

                for (int i = 0; i < sayi; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        comboBox1.Items.Add(dataGridView1.SelectedRows[i].Cells[j].Value.ToString());



                    }

                }
                for (int k = 0; k < comboBox1.Items.Count; k++)
                {
                    label1.Text = label1.Text + "," + comboBox1.Items[k].ToString();

                }

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document belge = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(belge, new FileStream(sv.FileName + ".Pdf", FileMode.Create));
                    belge.AddAuthor("Has-Emlak");
                    belge.AddHeader("Has- Emlak", "İlanlar");
                    belge.AddLanguage("Turkish");
                    belge.AddLanguage("Turkey");
                    belge.AddTitle("HAS -EMLAK");
                    belge.AddProducer();

                    belge.AddCreationDate();
                    belge.AddCreator("Has - Emlak");
                    belge.AddSubject("Has - Emlak İlan Bilgileri");
                    belge.AddKeywords("Has - Emlak");
                    if (belge.IsOpen() == false)
                    {
                        belge.Open();
                    }
                    if (label2.Text == "ilan")
                    {
                        belge.Add(new Paragraph("                                        HAS EMLAK ILAN BILGILERI "));
                        for (int z = 0; z < dizi.Length; z++)
                        {
                            dizi[z] = dizi[z] + comboBox1.Items[z].ToString();
                            belge.Add(new Paragraph(dizi[z].ToString()));
                        }
                    }
                    if (label2.Text == "musteri")
                    {
                        belge.Add(new Paragraph("                                        HAS EMLAK MUSTERI BILGILERI "));
                        for (int z = 0; z < musteri2.Length; z++)
                        {
                            musteri2[z] = dizi[z] + comboBox1.Items[z].ToString();
                            belge.Add(new Paragraph(musteri2[z].ToString()));
                        }
                    }
                    if (label2.Text == "yapi")
                    {
                        belge.Add(new Paragraph("                                        HAS EMLAK EV-ARSA-DUKKAN-BINA BILGILERI "));
                        for (int z = 0; z < yapi.Length; z++)
                        {
                            
                            yapi[z] = yapi[z] + comboBox1.Items[z].ToString();
                            belge.Add(new Paragraph(yapi[z].ToString()));
                        }
                    }


                    belge.Close();
                    MessageBox.Show("Başarı İle Aktarıldı","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                   
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vazgecbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void kaydıAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string yol = @"C:\Users\Administrator\Documents\Has-Emlak-Pdf-Dökümanları";


                if (!Directory.Exists(yol))
                {
                    Directory.CreateDirectory(yol);
                }
                string[] yapi = new string[] { "Yapı No :", "Yapinin Turu :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat : ", "Banyo Sayisi :", "Ic Ozellikleri : ", "Dis Ozellikleri : ", "Konum Ozellikleri : ", "Isınma Turu : ", "Yapinin Fiyati :", "Fiyat Turu : ", "Cephe : ", "Esya Durumu :", "Yapinin Durumu : ", "Durumu : ", "Il Adi :", "Ilce Adi :", "Semt Adi : ", "Sokak Adi :" };
                string[] musteri2 = new string[] { "Musteri No :", "Musteri Adi : ", "Musteri Soyadi : ", "Musteri Telefon Numarası : ", "Musteri E-Posta Adresi : " };
                string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : ", "Ilanin Tarihi : ", "Müsteri Adi : ", "Musteri Soyadi :", "Musteri Telefon No :", "Musteri E Posta :" };
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Pdf Dosyaları (*.Pdf)|*.Pdf|Tüm Dosyalar (*.*)|*.*";
                sv.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-Pdf-Dökümanları";
                int sayi = dataGridView1.SelectedRows.Count;

                for (int i = 0; i < sayi; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        comboBox1.Items.Add(dataGridView1.SelectedRows[i].Cells[j].Value.ToString());



                    }

                }
                for (int k = 0; k < comboBox1.Items.Count; k++)
                {
                    label1.Text = label1.Text + "," + comboBox1.Items[k].ToString();

                }

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document belge = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(belge, new FileStream(sv.FileName + ".Pdf", FileMode.Create));
                    belge.AddAuthor("Has-Emlak");
                    belge.AddHeader("Has- Emlak", "İlanlar");
                    belge.AddLanguage("Turkish");
                    belge.AddLanguage("Turkey");
                    belge.AddTitle("HAS -EMLAK");
                    belge.AddProducer();

                    belge.AddCreationDate();
                    belge.AddCreator("Has - Emlak");
                    belge.AddSubject("Has - Emlak İlan Bilgileri");
                    belge.AddKeywords("Has - Emlak");
                    if (belge.IsOpen() == false)
                    {
                        belge.Open();
                    }
                    if (label2.Text == "ilan")
                    {
                        belge.Add(new Paragraph("                                        HAS EMLAK ILAN BILGILERI "));
                        for (int z = 0; z < dizi.Length; z++)
                        {
                            dizi[z] = dizi[z] + comboBox1.Items[z].ToString();
                            belge.Add(new Paragraph(dizi[z].ToString()));
                        }
                    }
                    if (label2.Text == "musteri")
                    {
                        belge.Add(new Paragraph("                                        HAS EMLAK MUSTERI BILGILERI "));
                        for (int z = 0; z < musteri2.Length; z++)
                        {
                            musteri2[z] = dizi[z] + comboBox1.Items[z].ToString();
                            belge.Add(new Paragraph(musteri2[z].ToString()));
                        }
                    }
                    if (label2.Text == "yapi")
                    {
                        belge.Add(new Paragraph("                                        HAS EMLAK EV-ARSA-DUKKAN-BINA BILGILERI "));
                        for (int z = 0; z < yapi.Length; z++)
                        {

                            yapi[z] = yapi[z] + comboBox1.Items[z].ToString();
                            belge.Add(new Paragraph(yapi[z].ToString()));
                        }
                    }


                    belge.Close();
                    MessageBox.Show("Başarı İle Aktarıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
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

        private void ilanpdf_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    
    }
}