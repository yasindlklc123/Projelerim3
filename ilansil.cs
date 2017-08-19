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
    public partial class ilansil : DevExpress.XtraEditors.XtraForm
    {
        public ilansil()
        {
            InitializeComponent();
        }

        private void ilansil_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilant' table. You can move, or remove it, as needed.
            this.ilantTableAdapter.Fill(this.hasemlakDataSet.ilant);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string mesaj = id.ToString() + " " + "Numaralı İlanı Silmek Üzeresiniz İlana Ait Bilgiler Tamamen Kaybolabilir Devam Etmek İstiyor Musunuz ?";
                hasemlakDataSet.ilantRow sil = hasemlakDataSet.ilant.FindByilan_id(id);
                if ((MessageBox.Show(mesaj, "İlan Silme Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {

                   
                    sil.Delete();
                    ilantTableAdapter.Update(sil);
                   

                }
                else
                {
                    ilanid.ResetText();
                    ilandurumcombo.ResetText();
                    ilantarihcombo.ResetText();
                    ilansonucombo.ResetText();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
           
        }
        public void düzelt()
        {
            //    yapiturcombo.Properties.ValueMember  = yapi.yapi_tur_id.ToString();
            ilanid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ilandurumcombo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ilantarihcombo.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            ilansonucombo.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            düzelt();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string mesaj = id.ToString() + " " + "Numaralı İlanı Silmek Üzeresiniz İlana Ait Bilgiler Tamamen Kaybolabilir Devam Etmek İstiyor Musunuz ?";
                hasemlakDataSet.ilantRow sil = hasemlakDataSet.ilant.FindByilan_id(id);
                if ((MessageBox.Show(mesaj, "İlan Silme Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {


                    sil.Delete();
                    ilantTableAdapter.Update(sil);


                }
                else
                {
                    ilanid.ResetText();
                    ilandurumcombo.ResetText();
                    ilantarihcombo.ResetText();
                    ilansonucombo.ResetText();
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

        private void ilansil_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {


                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
      
    }
}