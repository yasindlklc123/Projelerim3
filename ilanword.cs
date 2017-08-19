using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using word = Microsoft.Office.Interop.Word;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace Has___Emlak
{
    public partial class ilanword : DevExpress.XtraEditors.XtraForm
    {
        public ilanword()
        {
            InitializeComponent();
        }
       
        private void ilanword_Load(object sender, EventArgs e)
        {
            label2.Hide();
            comboBox1.Hide();
            label1.Hide();
        }

        private void wordbtn_Click(object sender, EventArgs e)
        {
            try
            {
                word.Application yeni = new word.Application();
              
                yeni.Visible = true;
                word.Document sayfa;


                object obj = System.Reflection.Missing.Value;
                sayfa = yeni.Documents.Add(ref obj, ref obj, ref obj, ref obj);
                string[] yapi = new string[] { "Yapı No :", "Yapinin Turu :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat : ", "Banyo Sayisi :", "Ic Ozellikleri : ", "Dis Ozellikleri : ", "Konum Ozellikleri : ", "Isınma Turu : ", "Yapinin Fiyati :", "Fiyat Turu : ", "Cephe : ", "Esya Durumu :", "Yapinin Durumu : ", "Durumu : ", "Il Adi :", "Ilce Adi :", "Semt Adi : ", "Sokak Adi :" };
                string[] musteri2=new string[]{"Musteri No :","Musteri Adi : ","Musteri Soyadi : ","Musteri Telefon Numarası : ", "Musteri E-Posta Adresi : "};
                string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : ", "Ilanin Tarihi : ", "Müsteri Adi : ", "Musteri Soyadi :", "Musteri Telefon No :", "Musteri E Posta :" };
                //string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : " };
                if (label2.Text == "ilan")
                {
                    yeni.Selection.TypeText("                                   HAS EMLAK İLAN BİLGİLERİ " + " " + " \n");
                }
                if (label2.Text == "musteri")
                {
                    yeni.Selection.TypeText("                                   HAS EMLAK MÜŞTERİ BİLGİLERİ " + " " + " \n");
                }
                if (label2.Text == "yapi")
                {
                    yeni.Selection.TypeText("                                   HAS EMLAK EV-BİNA-ARSA-DÜKKAN BİLGİLERİ " + " " + " \n");
                }
                yeni.Selection.Font.Italic = 33;
                yeni.Caption = "İlan Bilgileri..";
                yeni.Selection.Font.Name = "Tahoma";
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
                if (label2.Text == "ilan") 
                for (int z = 0; z < dizi.Length; z++)
                {
                    dizi[z] = dizi[z] + comboBox1.Items[z].ToString();
                    yeni.Selection.TypeText(dizi[z].ToString()+ "  " + " \n" );
                }
                if (label2.Text == "musteri")
                {
                    for (int z = 0; z <musteri2.Length; z++)
                    {
                        musteri2[z] = musteri2[z] + comboBox1.Items[z].ToString();
                        yeni.Selection.TypeText(musteri2[z].ToString() + "  " + " \n");
                    }
                }
                if (label2.Text == "yapi")
                {
                    for (int z = 0; z < yapi.Length; z++)
                    {
                        yapi[z] = yapi[z] + comboBox1.Items[z].ToString();
                        yeni.Selection.TypeText(yapi[z].ToString() + "  " + " \n");
                    }
                }
             



               


                //yeni.Selection.TypeText("İlan Bilgi" + "\n" + label1.Text.ToUpper());
                MessageBox.Show("Başarıyla Aktarıldı","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
          
        }

        private void aktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                word.Application yeni = new word.Application();

                yeni.Visible = true;
                word.Document sayfa;


                object obj = System.Reflection.Missing.Value;
                sayfa = yeni.Documents.Add(ref obj, ref obj, ref obj, ref obj);
                string[] yapi = new string[] { "Yapı No :", "Yapinin Turu :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat : ", "Banyo Sayisi :", "Ic Ozellikleri : ", "Dis Ozellikleri : ", "Konum Ozellikleri : ", "Isınma Turu : ", "Yapinin Fiyati :", "Fiyat Turu : ", "Cephe : ", "Esya Durumu :", "Yapinin Durumu : ", "Durumu : ", "Il Adi :", "Ilce Adi :", "Semt Adi : ", "Sokak Adi :" };
                string[] musteri2 = new string[] { "Musteri No :", "Musteri Adi : ", "Musteri Soyadi : ", "Musteri Telefon Numarası : ", "Musteri E-Posta Adresi : " };
                string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : ", "Ilanin Tarihi : ", "Müsteri Adi : ", "Musteri Soyadi :", "Musteri Telefon No :", "Musteri E Posta :" };
                //string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : " };
                if (label2.Text == "ilan")
                {
                    yeni.Selection.TypeText("                                   HAS EMLAK İLAN BİLGİLERİ " + " " + " \n");
                }
                if (label2.Text == "musteri")
                {
                    yeni.Selection.TypeText("                                   HAS EMLAK MÜŞTERİ BİLGİLERİ " + " " + " \n");
                }
                if (label2.Text == "yapi")
                {
                    yeni.Selection.TypeText("                                   HAS EMLAK EV-BİNA-ARSA-DÜKKAN BİLGİLERİ " + " " + " \n");
                }
                yeni.Selection.Font.Italic = 33;
                yeni.Caption = "İlan Bilgileri..";
                yeni.Selection.Font.Name = "Tahoma";
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
                if (label2.Text == "ilan")
                    for (int z = 0; z < dizi.Length; z++)
                    {
                        dizi[z] = dizi[z] + comboBox1.Items[z].ToString();
                        yeni.Selection.TypeText(dizi[z].ToString() + "  " + " \n");
                    }
                if (label2.Text == "musteri")
                {
                    for (int z = 0; z < musteri2.Length; z++)
                    {
                        musteri2[z] = musteri2[z] + comboBox1.Items[z].ToString();
                        yeni.Selection.TypeText(musteri2[z].ToString() + "  " + " \n");
                    }
                }
                if (label2.Text == "yapi")
                {
                    for (int z = 0; z < yapi.Length; z++)
                    {
                        yapi[z] = yapi[z] + comboBox1.Items[z].ToString();
                        yeni.Selection.TypeText(yapi[z].ToString() + "  " + " \n");
                    }
                }







                //yeni.Selection.TypeText("İlan Bilgi" + "\n" + label1.Text.ToUpper());
                MessageBox.Show("Başarıyla Aktarıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void ilanword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}