using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using wordApp = Microsoft.Office.Interop.Word;
using System.Drawing.Printing;
using System.Diagnostics;


namespace Has___Emlak
{
    public partial class metinac : DevExpress.XtraEditors.XtraForm
    {
        public metinac()
        {
            InitializeComponent();
        }
        int sayfa=1;
         bool devamiVar = false;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                devamiVar = true;
                printDocument1.Print();
            }
        }
         void pDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Bundan sonra X, Y, Genislik, Yukseklik gibi olculerde
            // Pixel degil Milimetre kullanicahiz
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
 
            // Bu sekilde sabit bir printer'a yonlendire biliriz
            // e.PageSettings.PrinterSettings.PrinterName = "Bir Printer Adi";
 
            // yazdirmada kullanilacak bir font olusturalim.
            Font aFont = new System.Drawing.Font("Arial", 11);
 
            // stringi pDoc nesnemize yazdiralim.
            // string olarak "Deneme" verdik.
            // renk olarak brushes.black verdik ve X,Y olarak noktalarimizi belirttik.
            // ben genelde point kullanmaktan yana degilimdir gerci
            // bu yuzden tanimlamayi pointsiz yapalim.
            e.Graphics.DrawString("Deneme", aFont, Brushes.Black, 10f,10f);
 
            Image aImg = Image.FromFile(@"C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Blue hills.jpg");
 
            // Resim ekleme sol'dan 10 mm, yukardan 25 mm atliyarak
            // resmi resize etmek isterseniz bunuda bunuda
            // genislik 30 mm yukseklik 42 mm olarak atadik.
            e.Graphics.DrawImage(aImg, 10, 25,30,42);
 
            // Her baskida sayfa sayisini artiralim.
            sayfa++;
 
            // baski 10 sayfa ise son sayfada devami olmayacagini belirtelim.
            if (sayfa == 10)
                devamiVar = false;
 
            // devami varsa sonraki sayfaya gecelim.
            if (devamiVar)
                e.HasMorePages = true;
        }

         private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
         {
             // Bundan sonra X, Y, Genislik, Yukseklik gibi olculerde
             // Pixel degil Milimetre kullanicahiz
             e.Graphics.PageUnit = GraphicsUnit.Millimeter;

             // Bu sekilde sabit bir printer'a yonlendire biliriz
             // e.PageSettings.PrinterSettings.PrinterName = "Bir Printer Adi";

             // yazdirmada kullanilacak bir font olusturalim.
             Font aFont = new System.Drawing.Font("Arial", 11);

             // stringi pDoc nesnemize yazdiralim.
             // string olarak "Deneme" verdik.
             // renk olarak brushes.black verdik ve X,Y olarak noktalarimizi belirttik.
             // ben genelde point kullanmaktan yana degilimdir gerci
             // bu yuzden tanimlamayi pointsiz yapalim.
             e.Graphics.DrawString("Deneme", aFont, Brushes.Black, 10f, 10f);

             Image aImg = Image.FromFile(@"C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Blue hills.jpg");

             // Resim ekleme sol'dan 10 mm, yukardan 25 mm atliyarak
             // resmi resize etmek isterseniz bunuda bunuda
             // genislik 30 mm yukseklik 42 mm olarak atadik.
             e.Graphics.DrawImage(aImg, 10, 25, 30, 42);

             // Her baskida sayfa sayisini artiralim.
             sayfa++;

             // baski 10 sayfa ise son sayfada devami olmayacagini belirtelim.
             if (sayfa == 10)
                 devamiVar = false;

             // devami varsa sonraki sayfaya gecelim.
             if (devamiVar)
                 e.HasMorePages = true;
         }

         private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
            
         }


         private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             pageSetupDialog1.ShowDialog();
         }

         private void metinac_FormClosing(object sender, FormClosingEventArgs e)
         {
             if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
             {
                 Process.Start("shutdown", "-a");
                 MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
         }



     
   //PageSetupDialog'un görüntülenmesi için bir PageSettings nesnesi gerekir. PageSetupDialog.Document (tercih edilen), PageSetupDialog.PrinterSettings veya PageSetupDialog.PageSettings'i ayarlayın.

       
    }
}