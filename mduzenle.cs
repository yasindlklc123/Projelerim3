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
    public partial class mduzenle : DevExpress.XtraEditors.XtraForm
    {
        public mduzenle()
        {
            InitializeComponent();
        }
        public Boolean yeni;
        hasemlakDataSet.ilanverenmusteriRow musteri;
        private void mduzenle_Load(object sender, EventArgs e)
        {
            mtlfntxt.Properties.MaxLength = 11;
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilanverenmusteri' table. You can move, or remove it, as needed.
            this.ilanverenmusteriTableAdapter.Fill(this.hasemlakDataSet.ilanverenmusteri);

        }
        public void düzelt()
        {
            mnoidi.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            maditxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().ToUpper();
            msoyaditxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().ToUpper();
            mtlfntxt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            mpostatxt.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            //    yapiturcombo.Properties.ValueMember  = yapi.yapi_tur_id.ToString();
            //ilanid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //ilandurumcombo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //ilantarihcombo.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //ilansonucombo.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void mvzgecbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void mduzenlebtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(mnoidi.Text);
                musteri = hasemlakDataSet.ilanverenmusteri.FindBymusteri_id(id);
                musteri.musteri_adi = maditxt.Text.ToUpper();
                musteri.musteri_soyadi = msoyaditxt.Text.ToUpper();
                musteri.musteri_telefon = mtlfntxt.Text;
                musteri.musteri_e_posta = mpostatxt.Text;

                ilanverenmusteriTableAdapter.Update(musteri);
              
                MessageBox.Show(mnoidi.Text + " " + "Numaralı Kayıt Düzenlendi","Kayıt Düzenlendi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                mnoidi.ResetText();
                maditxt.ResetText();
                msoyaditxt.ResetText();
                mtlfntxt.ResetText();
                mpostatxt.ResetText();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(),"Hata ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            düzelt();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(mnoidi.Text);
                musteri = hasemlakDataSet.ilanverenmusteri.FindBymusteri_id(id);
                musteri.musteri_adi = maditxt.Text.ToUpper();
                musteri.musteri_soyadi = msoyaditxt.Text.ToUpper();
                musteri.musteri_telefon = mtlfntxt.Text;
                musteri.musteri_e_posta = mpostatxt.Text;

                ilanverenmusteriTableAdapter.Update(musteri);

                MessageBox.Show(mnoidi.Text + " " + "Numaralı Kayıt Düzenlendi", "Kayıt Düzenlendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mnoidi.ResetText();
                maditxt.ResetText();
                msoyaditxt.ResetText();
                mtlfntxt.ResetText();
                mpostatxt.ResetText();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void mduzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}