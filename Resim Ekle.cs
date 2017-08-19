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
    public partial class Resim_Ekle : DevExpress.XtraEditors.XtraForm
    {
        public Resim_Ekle()
        {
            InitializeComponent();
        }
        public Boolean yeni;
         public hasemlakDataSet.rsmRow resim;

        private void Resim_Ekle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hasemlakDataSet.rsm' table. You can move, or remove it, as needed.
            this.rsmTableAdapter.Fill(this.hasemlakDataSet.rsm);
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilant' table. You can move, or remove it, as needed.
            this.ilantTableAdapter.Fill(this.hasemlakDataSet.ilant);
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapibilgii' table. You can move, or remove it, as needed.
            this.yapibilgiiTableAdapter.Fill(this.hasemlakDataSet.yapibilgii);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string yol = @"C:\Users\Administrator\Documents "+ @"\Has-Emlak-Resimler\";
                if (!Directory.Exists(yol))
                {
                    Directory.CreateDirectory(yol);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {


                string kopyalanacakDosya = "", kopyalanacakDosyaIsmi = "",
                                  dosyanınKopyanacagiKlasor = "";
                openFileDialog1.Title = "Kopyalanacak Resmi  Seçiniz...";
                openFileDialog1.FileName = "";
                //op.Filter = "Pdf Dosyaları (*.Pdf)|*.Pdf|Tüm Dosyalar (*.*)|*.*";
                openFileDialog1.InitialDirectory = Application.StartupPath + @"\Has-Emlak-Resimler";
                openFileDialog1.Filter = "Jpg  Dosyaları(*.jpg)|*.jpg|Png Dosyaları(*.png)|*.png|Tüm Dosyalar (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    kopyalanacakDosyaIsmi = openFileDialog1.SafeFileName.ToString();
                    kopyalanacakDosya = openFileDialog1.FileName.ToString();
                    dosyanınKopyanacagiKlasor =@"C:\Users\Administrator\Documents"+ @"\Has-Emlak-Resimler\" + comboBox2.SelectedValue.ToString() + "Numaralı Yapı Resimleri";


                }
                File.Copy(kopyalanacakDosya, dosyanınKopyanacagiKlasor + @"\" + openFileDialog1.SafeFileName);



                
             
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(comboBox2.SelectedValue);

                resim.resim = @"C:\Users\Administrator\Documents" + @"\Has-Emlak-Resimler\" + comboBox2.SelectedValue.ToString()+"Numaralı Yapı Resimleri"+@"\"+ openFileDialog1.SafeFileName;
                resim.yapi_id = a;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

  

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int a = (int)comboBox2.SelectedValue;
                string yol =@"C:\Users\Administrator\Documents" + @"\Has-Emlak-Resimler\" + a.ToString() + "Numaralı Yapı Resimleri";
                if (!Directory.Exists(yol))
                {
                    Directory.CreateDirectory(yol);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Resim_Ekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}