using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Diagnostics;

namespace Has___Emlak
{
    public partial class txtaktarım : DevExpress.XtraEditors.XtraForm
    {
        public txtaktarım()
        {
            InitializeComponent();
        }

        private void txtaktarım_Load(object sender, EventArgs e)
        {
            comboBox1.Hide();
            label1.Hide();
            label2.Hide();
        }

        private void txtaktar_Click(object sender, EventArgs e)
        {
            try
            {
                string[] yapi = new string[] { "Yapı No :", "Yapinin Turu :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat : ", "Banyo Sayisi :", "Ic Ozellikleri : ", "Dis Ozellikleri : ", "Konum Ozellikleri : ", "Isınma Turu : ", "Yapinin Fiyati :", "Fiyat Turu : ", "Cephe : ", "Esya Durumu :", "Yapinin Durumu : ", "Durumu : ", "Il Adi :", "Ilce Adi :", "Semt Adi : ", "Sokak Adi :" };
                string[] musteri2 = new string[] { "Musteri No :", "Musteri Adi : ", "Musteri Soyadi : ", "Musteri Telefon Numarası : ", "Musteri E-Posta Adresi : " };
                string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : ", "Ilanin Tarihi : ", "Müsteri Adi : ", "Musteri Soyadi :", "Musteri Telefon No :", "Musteri E Posta :" };
               // string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : " };
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
                string yol = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri";
                string yol2 = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri\" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "Numaralı İlan.txt";

                if (!Directory.Exists(yol))
                {
                    Directory.CreateDirectory(yol);
                }
                if (!File.Exists(yol2))
                {
                    File.Create(yol2);
                }
                saveFileDialog1.Filter = "Text Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                saveFileDialog1.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri";
                saveFileDialog1.OverwritePrompt = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    if (label2.Text == "ilan")
                    {
                        sw.Write("HAS EMLAK İLAN BİLGİLERİ" + " " + "\n" + "\n");
                        for (int z = 0; z < dizi.Length; z++)
                        {

                            dizi[z] = dizi[z] + comboBox1.Items[z].ToString();
                            sw.WriteLine("\n" + dizi[z].ToString());

                        }
                    }
                    if (label2.Text == "musteri")
                    {
                        sw.Write("HAS EMLAK MÜŞTERİ BİLGİLERİ" + " " + "\n" + "\n");
                        for (int z = 0; z < musteri2.Length; z++)
                        {

                            musteri2[z] = musteri2[z] + comboBox1.Items[z].ToString();
                            sw.WriteLine("\n" + musteri2[z].ToString());

                        }
                    }
                    if (label2.Text == "yapi")
                    {
                        sw.Write("HAS EMLAK EV-BİNA-ARSA-DÜKKAN - BİLGİLERİ" + " " + "\n" + "\n");
                        for (int z = 0; z < yapi.Length; z++)
                        {

                            yapi[z] = yapi[z] + comboBox1.Items[z].ToString();
                            sw.WriteLine("\n" + yapi[z].ToString());

                        }
                    }
             

                   
                    sw.Close();
                    MessageBox.Show("Başarı İle Aktarıldı","Bilgilenidrme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
             
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void vazgectxtbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void aktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] yapi = new string[] { "Yapı No :", "Yapinin Turu :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat : ", "Banyo Sayisi :", "Ic Ozellikleri : ", "Dis Ozellikleri : ", "Konum Ozellikleri : ", "Isınma Turu : ", "Yapinin Fiyati :", "Fiyat Turu : ", "Cephe : ", "Esya Durumu :", "Yapinin Durumu : ", "Durumu : ", "Il Adi :", "Ilce Adi :", "Semt Adi : ", "Sokak Adi :" };
                string[] musteri2 = new string[] { "Musteri No :", "Musteri Adi : ", "Musteri Soyadi : ", "Musteri Telefon Numarası : ", "Musteri E-Posta Adresi : " };
                string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : ", "Ilanin Tarihi : ", "Müsteri Adi : ", "Musteri Soyadi :", "Musteri Telefon No :", "Musteri E Posta :" };
               // string[] dizi = new string[] { "Ilan Kodu :", "Yapinin Türü :", "MetreKare :", "Oda Sayisi :", "Yapinin Yasi :", "Yapidaki Toplam Kat Sayisi :", "Yapinin Bulundugu Kat :", "Banyo Sayisi :", "Ic Ozelikleri :", "Dis Ozellikleri :", "Konum Ozellikleri :", "Fiyati :", "Fiyat Türü :", "Cephe :", "Yapinin Durumu :", "Türü :", "Il Adi : ", "Ilce Adi :", "Semt Adi : ", "Sokak Adi : " };
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
                string yol = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri";
                string yol2 = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri\" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "Numaralı İlan.txt";

                if (!Directory.Exists(yol))
                {
                    Directory.CreateDirectory(yol);
                }
                if (!File.Exists(yol2))
                {
                    File.Create(yol2);
                }
                saveFileDialog1.Filter = "Text Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                saveFileDialog1.InitialDirectory = @"C:\Users\Administrator\Documents\Has-Emlak-MetinBelgeleri";
                saveFileDialog1.OverwritePrompt = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    if (label2.Text == "ilan")
                    {
                        sw.Write("HAS EMLAK İLAN BİLGİLERİ" + " " + "\n" + "\n");
                        for (int z = 0; z < dizi.Length; z++)
                        {

                            dizi[z] = dizi[z] + comboBox1.Items[z].ToString();
                            sw.WriteLine("\n" + dizi[z].ToString());

                        }
                    }
                    if (label2.Text == "musteri")
                    {
                        sw.Write("HAS EMLAK MÜŞTERİ BİLGİLERİ" + " " + "\n" + "\n");
                        for (int z = 0; z < musteri2.Length; z++)
                        {

                            musteri2[z] = musteri2[z] + comboBox1.Items[z].ToString();
                            sw.WriteLine("\n" + musteri2[z].ToString());

                        }
                    }
                    if (label2.Text == "yapi")
                    {
                        sw.Write("HAS EMLAK EV-BİNA-ARSA-DÜKKAN - BİLGİLERİ" + " " + "\n" + "\n");
                        for (int z = 0; z < yapi.Length; z++)
                        {

                            yapi[z] = yapi[z] + comboBox1.Items[z].ToString();
                            sw.WriteLine("\n" + yapi[z].ToString());

                        }
                    }
             

                   
                    sw.Close();
                    MessageBox.Show("Başarı İle Aktarıldı","Bilgilenidrme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
             
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private void txtaktarım_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        }
    }
