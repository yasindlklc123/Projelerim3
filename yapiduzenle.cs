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
    public partial class yapiduzenle : DevExpress.XtraEditors.XtraForm
    {
        public yapiduzenle()
        {
            InitializeComponent();
        }

        private void yapiduzenle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapibilgii' table. You can move, or remove it, as needed.
            this.yapibilgiiTableAdapter.Fill(this.hasemlakDataSet.yapibilgii);
            // TODO: This line of code loads data into the 'hasemlakDataSet.yapitur' table. You can move, or remove it, as needed.
            this.yapiturTableAdapter.Fill(this.hasemlakDataSet.yapitur);

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
                string mesaj = id.ToString() + " " + "Numaralı Müşteri Bilgilerini Silmek Üzeresiniz Müşteriye Ait Bilgiler Tamamen Kaybolabilir Devam Etmek İstiyor Musunuz ?";
                hasemlakDataSet.yapibilgiiRow sil = hasemlakDataSet.yapibilgii.FindByyapi_id(id);
                if ((MessageBox.Show(mesaj, "Müşteri Silme Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {


                    sil.Delete();
                    yapibilgiiTableAdapter.Update(sil);
                 



                }
                else
                {
                   

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
                hasemlakDataSet.yapibilgiiRow sil = hasemlakDataSet.yapibilgii.FindByyapi_id(id);
                if ((MessageBox.Show(mesaj, "Müşteri Silme Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {


                    sil.Delete();
                    yapibilgiiTableAdapter.Update(sil);




                }
                else
                {


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

        private void yapiduzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}