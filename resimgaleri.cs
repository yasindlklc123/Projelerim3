using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.IO;
using System.Diagnostics;

namespace Has___Emlak
{
    public partial class resimgaleri : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public resimgaleri()
        {
            InitializeComponent();
        }

        private void resimgaleri_Load(object sender, EventArgs e)
        {

            
          //  DirectoryInfo di = new DirectoryInfo(Application.StartupPath+);
            // TODO: This line of code loads data into the 'hasemlakDataSet.rsm' table. You can move, or remove it, as needed.
            this.rsmTableAdapter.Fill(this.hasemlakDataSet.rsm);

        }

        private void resimgaleri_Resize(object sender, EventArgs e)
        {
            int yukseklik = this.Height;
            dataGridView1.Height = yukseklik - 50;
            groupControl1.Height = yukseklik;
        }

        private void groupControl1_Resize(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Resim_Ekle ekle = new Resim_Ekle();
                ekle.yeni = true;
                ekle.resim = hasemlakDataSet.rsm.NewrsmRow();
                if (ekle.ShowDialog() == DialogResult.OK)
                {
                    hasemlakDataSet.rsm.AddrsmRow(ekle.resim);
                    rsmTableAdapter.Update(ekle.resim);
                    MessageBox.Show("Resim Başarı İle Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void kontrol()
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gtr();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            pictureEdit1.CutImage();
            //try
            //{
            //    foreach (hasemlakDataSet.rsmRow item in hasemlakDataSet.rsm.Rows)
            //    {
            //        string yol = Application.StartupPath + @"\Has-Emlak-Resimler\" + item.yapi_id.ToString() + "Numaralı Yapı Resimleri";
            //        DirectoryInfo di = new DirectoryInfo(yol);
            //        FileInfo[] fn = di.GetFiles();
            //        foreach (FileInfo item2 in fn)
            //        {
            //            MessageBox.Show(item2.Name);
            //        }
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
       
            try
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string mesaj = id.ToString() + " " + "Numaralı Yapıya Ait Resimi Silmek Üzeresiniz Kayıt Silinecektir Devam Etmek İstiyor Musunuz ?";
                hasemlakDataSet.rsmRow sil = hasemlakDataSet.rsm.FindByresim_id(id);
                if ((MessageBox.Show(mesaj, "Resim Silme Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    //File.Delete(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                    //File.Delete(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                    sil.Delete();
                    rsmTableAdapter.Update(sil);
                    pictureEdit1.Image = null;
             

                   

                   


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

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            hasemlakDataSet.rsmRow resm = hasemlakDataSet.rsm.NewrsmRow();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                string yol = Application.StartupPath + @"\Has-Emlak-Resimler\" + item.Cells[2].Value.ToString() + "Numaralı Yapı Resimleri";
                DirectoryInfo di = new DirectoryInfo(yol);
                FileInfo[] fn = di.GetFiles();
                foreach (FileInfo item2 in fn)
                {
                    if (item.Cells[1].Value.ToString() != item2.FullName.ToString())
                    {
                   
                        resm.yapi_id = (int)item.Cells[2].Value;
                        resm.resim = item2.FullName.ToString();
                        hasemlakDataSet.rsm.AddrsmRow(resm);
                        rsmTableAdapter.Update(resm);
                    }
                }
            }
           // textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void resimEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Resim_Ekle ekle = new Resim_Ekle();
                ekle.yeni = true;
                ekle.resim = hasemlakDataSet.rsm.NewrsmRow();
                if (ekle.ShowDialog() == DialogResult.OK)
                {
                    hasemlakDataSet.rsm.AddrsmRow(ekle.resim);
                    rsmTableAdapter.Update(ekle.resim);
                    MessageBox.Show("Resim Başarı İle Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resimSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                File.Delete(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            zoomTrackBarControl1.Properties.Minimum=0;
            zoomTrackBarControl1.Properties.Maximum=400;
         
            //zoomTrackBarControl1.Properties.Labels = zoomTrackBarControl1.Value.ToString();
          //  pictureEdit1.Properties.ZoomAcceleration = zoomTrackBarControl1.Value;
            pictureEdit1.Properties.ZoomPercent = zoomTrackBarControl1.Value;
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                rsmBindingSource.MoveNext();
                gtr();
               
            }
            if (e.KeyCode == Keys.Down)
            {
                rsmBindingSource.MovePrevious();
                gtr();
            }
        }
        public void gtr()
        {
            // string[] dizi = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Split('\\');
            if (!File.Exists(dataGridView1.SelectedRows[0].Cells[1].Value.ToString()))
            {
                try
                {
                    int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    string mesaj = id.ToString() + " " + "Numaralı Yapıya Ait Resim Mevcut Değil Kayıt Yine De Silinsin Mi ?";
                    hasemlakDataSet.rsmRow sil = hasemlakDataSet.rsm.FindByresim_id(id);
                    if ((MessageBox.Show(mesaj, "Resim Silme Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                    {


                        sil.Delete();
                        rsmTableAdapter.Update(sil);




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
            else
            {

            }
            //try
            //{

            //    string yol = Application.StartupPath + @"\Has-Emlak-Resimler\" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "Numaralı Yapı Resimleri";
            //    DirectoryInfo di = new DirectoryInfo(yol);
            //    FileInfo[] fn = di.GetFiles();
            //    foreach (FileInfo item in fn)
            //    {

            //        //MessageBox.Show(item.Name.ToString());
            //        //if (dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Contains(item.Name))
            //        //{
            //        //    MessageBox.Show("Test");
            //        //}



            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            try
            {
                pictureEdit1.Image = System.Drawing.Image.FromFile(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            //pictureEdit1.Properties.add
            //pictureEdit1.Location =Image.FromFile(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureEdit1.CutImage();
        }

        private void dereceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureEdit1.Image.RotateFlip(RotateFlipType.Rotate180FlipXY);
        }

     

        private void dereceSaatYönüTersineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureEdit1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
           // pictureEdit1.Image.Clone();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            pictureEdit1.PasteImage();
        }

        private void yükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.Title = "Kopyalanacak Resmi  Seçiniz...";
            openFileDialog1.InitialDirectory = @"C:\Users\Administrator\Desktop";
            openFileDialog1.FileName = "";
            //op.Filter = "Pdf Dosyaları (*.Pdf)|*.Pdf|Tüm Dosyalar (*.*)|*.*";
            openFileDialog1.Filter = "Jpg  Dosyaları(*.jpg)|*.jpg|Png Dosyaları(*.png)|*.png|Tüm Dosyalar (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureEdit1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName.ToString());

            }
            
            
           
            //pictureEdit1.LoadImage();
        
        }

    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                openFileDialog2.Title = "Silinecek Resmi  Seçiniz...";
                openFileDialog2.Filter = "Jpg  Dosyaları(*.jpg)|*.jpg|Png Dosyaları(*.png)|*.png|Tüm Dosyalar (*.*)|*.*";
                openFileDialog2.InitialDirectory =  @"C:\Users\Administrator\Documents" + @"\Has-Emlak-Resimler";
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    File.Delete(openFileDialog2.FileName.ToString());
                    MessageBox.Show("Silindi");
                }
           
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void resimgaleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}