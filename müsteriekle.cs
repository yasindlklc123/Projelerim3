using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace Has___Emlak
{
    public partial class müsteriekle : DevExpress.XtraEditors.XtraForm
    {
        public müsteriekle()
        {
            InitializeComponent();
        }
        public Boolean yeni;
       public hasemlakDataSet.ilanverenmusteriRow ekle;

        private void müsteriekle_Load(object sender, EventArgs e)
        {
            if (yeni)
            {
                mtemizle();
            }
            else
            {
                mekle();
            }
            mnumaratxt.Properties.MaxLength = 11;
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilanverenmusteri' table. You can move, or remove it, as needed.
            this.ilanverenmusteriTableAdapter.Fill(this.hasemlakDataSet.ilanverenmusteri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void mtemizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextEdit)
                {
                    item.ResetText();
                }
            }
        }

        private void mvazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void musterieklebtn_Click(object sender, EventArgs e)
        {
            mekle();
            this.DialogResult = DialogResult.OK;
            
        }
        public void mekle()
        {
            try
            {
                if (!String.IsNullOrEmpty(maditxt.Text) && !String.IsNullOrEmpty(msoyaditxt.Text) && !String.IsNullOrEmpty(mnumaratxt.Text))
                {

                    ekle.musteri_id = int.Parse(midlbl.Text);
                    ekle.musteri_adi = maditxt.Text.ToUpper();
                    ekle.musteri_soyadi = msoyaditxt.Text.ToUpper();
                    ekle.musteri_telefon = mnumaratxt.Text;
                    ekle.musteri_e_posta = mepostatxt.Text;

                    MessageBox.Show(midlbl.Text + " " + "Numaralı Kayıt Başarı İle Eklendi", "Kayıt Ekleme Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz", "Zorunlu Alanları Doldur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //hasemlakDataSet.ilanverenmusteri.AddilanverenmusteriRow(ekle);
                //ilanverenmusteriTableAdapter.Update(ekle);
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void müsteriekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}