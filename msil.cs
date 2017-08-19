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
    public partial class msil : DevExpress.XtraEditors.XtraForm
    {
        public msil()
        {
            InitializeComponent();
        }

        private void msil_Load(object sender, EventArgs e)
        {
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            düzelt();
        }

        private void mvazgecbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void msilbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string mesaj = id.ToString() + " " + "Numaralı Müşteri Bilgilerini Silmek Üzeresiniz Müşteriye Ait Bilgiler Tamamen Kaybolabilir Devam Etmek İstiyor Musunuz ?";
                hasemlakDataSet.ilanverenmusteriRow sil = hasemlakDataSet.ilanverenmusteri.FindBymusteri_id(id);
                if ((MessageBox.Show(mesaj, "Müşteri Silme Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {


                    sil.Delete();
                    ilanverenmusteriTableAdapter.Update(sil);
                    mnoidi.ResetText();
                    maditxt.ResetText();
                    msoyaditxt.ResetText();
                    mtlfntxt.ResetText();
                    mpostatxt.ResetText();
                


                }
                else
                {
                   mnoidi.ResetText();
                   maditxt.ResetText();
                   msoyaditxt.ResetText();
                   mtlfntxt.ResetText();
                   mpostatxt.ResetText();
                    
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string mesaj = id.ToString() + " " + "Numaralı Müşteri Bilgilerini Silmek Üzeresiniz Müşteriye Ait Bilgiler Tamamen Kaybolabilir Devam Etmek İstiyor Musunuz ?";
                hasemlakDataSet.ilanverenmusteriRow sil = hasemlakDataSet.ilanverenmusteri.FindBymusteri_id(id);
                if ((MessageBox.Show(mesaj, "Müşteri Silme Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {


                    sil.Delete();
                    ilanverenmusteriTableAdapter.Update(sil);
                    mnoidi.ResetText();
                    maditxt.ResetText();
                    msoyaditxt.ResetText();
                    mtlfntxt.ResetText();
                    mpostatxt.ResetText();



                }
                else
                {
                    mnoidi.ResetText();
                    maditxt.ResetText();
                    msoyaditxt.ResetText();
                    mtlfntxt.ResetText();
                    mpostatxt.ResetText();

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

        private void msil_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}