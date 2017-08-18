using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.IO;


namespace Metin_Belgesi_Şifreleme
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            InitializeRichEditControl();
            ribbonControl.SelectedPage = homeRibbonPage1;
        }
        int sayac = 0;
        password sifre = new password();
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        void InitializeRichEditControl()
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SaveFileDialog sv = new SaveFileDialog();
          
                sifrelimetinlerDataSet.sifrelimetinRow r = sifrelimetinlerDataSet1.sifrelimetin.NewsifrelimetinRow();
                r.normal = richEditControl.Text;

                richEditControl.Text = sifre.sifrele(richEditControl.Text);
                r.sifreli = richEditControl.Text;
              
                richEditControl.SaveDocument();
                richTextBox1.ResetText();
                sifrelimetinlerDataSet1.sifrelimetin.AddsifrelimetinRow(r);
                sifrelimetinTableAdapter1.Update(r);
                sayac++;
            
           
          
        }

       

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void ınsertTableItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void changePageColorItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

            
               // richTextBox1.SaveFile(farklıkaydet.FileName, RichTextBoxStreamType.PlainText);
                //richEditControl.SaveDocument();
              
                richEditControl.SaveDocumentAs();
            
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            richEditControl.SaveDocument();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog aç = new OpenFileDialog();
            aç.Filter = "Tüm Dosyalar|*.*|Metin Dosyaları|*.txt";
            aç.ShowDialog();
            StreamReader sr = new StreamReader(aç.FileName, Encoding.Default);
            //dosya = aç.FileName;
            this.Text = aç.FileName;

            richEditControl.LoadDocument(aç.FileName);
            sr.Close();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (sifrelimetinlerDataSet.sifrelimetinRow item in sifrelimetinlerDataSet1.sifrelimetin.Rows)
            {
                if (item.sifreli ==richEditControl.Text)
                {
                    richEditControl.Text = item.normal;
                }
                else
                {
                    MessageBox.Show("Test");
                }
            }
            //richTextBox1.Text = sifrele.cozumle(richTextBox1.Text);
            richEditControl.Text = sifre.cozumle(richEditControl.Text);
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(richEditControl.Text))
            {
                if (sayac == 0)
                {
                    DialogResult dr = MessageBox.Show("Gerçekten programı kapatmak istiyor musunuz?", "Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                        e.Cancel = true;
                    else
                        e.Cancel = false;
                }
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu Program Dalkılıçlar Tarafından Yazılmıştır Tüm Hakları Sakldır","Hakkında",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }



    }
}