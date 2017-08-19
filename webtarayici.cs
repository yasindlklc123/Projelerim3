using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Has___Emlak
{
    public partial class webtarayici : Form
    {
        public webtarayici()
        {
            InitializeComponent();
        }
        WebBrowser web = new WebBrowser();
        CheckedListBox clb = new CheckedListBox();
        ListBox lb = new ListBox();
        int i = 0;
        
        private void webtarayici_Load(object sender, EventArgs e)
        {
            try
            {

                // TODO: This line of code loads data into the 'gecmisDataSet.gecmisweb' table. You can move, or remove it, as needed.
                this.gecmiswebTableAdapter.Fill(this.gecmisDataSet.gecmisweb);

                web = new WebBrowser();
                web.ScriptErrorsSuppressed = true;
                web.Dock = DockStyle.Fill;
                web.Visible = true;
                web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);

                //web.ProgressChanged += new WebBrowserProgressChangedEventHandler(web_ProgressChanged);
                web.Navigated += new WebBrowserNavigatedEventHandler(web_Navigated);
                web.Navigating += new WebBrowserNavigatingEventHandler(web_Navigating);
                tabControl1.TabPages.Add("Yeni Sekme");
                tabControl1.SelectTab(i);
                tabControl1.SelectedTab.Controls.Add(web);
                i += 1;
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("www.google.com");
                foreach (gecmisDataSet.gecmiswebRow item in gecmisDataSet.gecmisweb.Rows)
                {
                    string[] dizi = new
                        [] { item.site_adi.ToString() };
                    //MessageBox.Show(dizi[0].ToString());
                    object[] a = new object[] { dizi[0].ToString() };
                    toolStripComboBox1.Items.AddRange(a);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        void web_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
           // progressBar1.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar1.Value  = 0;
            toolStripStatusLabel1.Text = "";
             toolStripComboBox1. Text = e.Url.ToString();
        }

        void web_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Value = 10;
            toolStripStatusLabel1.Text = e.Url.ToString() + " yükleniyor...";
        }

        //void web_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        //{
        //    try
        //    {
        //        toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
        //        toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress);
        //    }
        //    catch(Exception ee)
        //    {
        //        MessageBox.Show(ee.Message.ToString());
        //    }
        //}

        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
          
                if (yeniSekmeToolStripMenuItem.CheckOnClick == true)
                {
                    
                        tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
                        toolStripComboBox1.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Url.ToString();
                    
                }
                else
                {
                    toolStripComboBox1.Text = "";
                }
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);

               // toolStripComboBox1.Text = "http://www." + toolStripComboBox1.Text + ".com";
               // ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
                toolStripComboBox1.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Url.ToString();
                    
            }
         
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
            gecmisDataSet.gecmiswebRow gecmisim = gecmisDataSet.gecmisweb.NewgecmiswebRow();
            gecmisim.int_id = gecmisDataSet.gecmisweb.Rows.Count + 3;
            gecmisim.site_adi = toolStripComboBox1.Text.ToString();
            gecmisim.tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            gecmisim.saat = DateTime.Now.ToShortTimeString();
            gecmisDataSet.gecmisweb.AddgecmiswebRow(gecmisim);
            gecmiswebTableAdapter.Update(gecmisim);
           // ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("https://www.google.com.tr/search?sourceid=chrome&ie=UTF-8&q=" + toolStripComboBox1.Text);
           // web.Refresh();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void durToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Stop();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void yeniSekmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
            tabControl1.TabPages.Add("Yeni Sekme");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            i++;
        }

        private void sekmeyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
         
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
        }

        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
             
           
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
                //((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("https://www.google.com.tr/search?sourceid=chrome&ie=UTF-8&q=" + toolStripComboBox1.Text);
               
                e.SuppressKeyPress = true;
                //gitToolStripMenuItem_Click(sender, e);
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
                if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
                {
                    toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
                    toolStripComboBox1.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Url.ToString();
                    // toolStripComboBox1.Text = "http://www." + toolStripComboBox1.Text + ".com";
                   // ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
                    //toolStripComboBox1.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Url.ToString();
                    gecmisDataSet.gecmiswebRow gecmisim = gecmisDataSet.gecmisweb.NewgecmiswebRow();
                    gecmisim.int_id = gecmisDataSet.gecmisweb.Rows.Count + 3;
                    gecmisim.site_adi = toolStripComboBox1.Text.ToString();
                    gecmisim.tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    gecmisim.saat = DateTime.Now.ToShortTimeString();
                    gecmisDataSet.gecmisweb.AddgecmiswebRow(gecmisim);
                    gecmiswebTableAdapter.Update(gecmisim);

                }
               
            
              
            }
        }

     
        private void webtarayici_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                yenileToolStripMenuItem_Click(sender, e);
            }
        }

        private void webtarayici_Resize(object sender, EventArgs e)
        {
            int genislik = this.Width;
           
            toolStripComboBox1.Width = genislik - 100;
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("www.facebook.com");
            toolStripComboBox1.Text = "www.facebook.com";
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
            }
        }

       

        private void geçiciKısayolOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip2.Items.Add(toolStripComboBox1.Text);
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(e.ClickedItem.Text.ToString());
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("www.google.com.tr");
            toolStripComboBox1.Text = "www.google.com.tr";
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
            }
        }

        private void twitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("https://twitter.com/?lang=tr");
            toolStripComboBox1.Text = " https://twitter.com/?lang=tr";
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
            }
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("www.youtube.com");
            toolStripComboBox1.Text = "www.youtube.com";
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
            }
        }

        private void instagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("www.instagram.com.tr");
            toolStripComboBox1.Text = "www.instagram.com";
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
            }
        }

        private void outlookToolStripMenuItem_Click(object sender, EventArgs e)
        {
             ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("https://outlook.live.com/owa/");
             toolStripComboBox1.Text = "https://outlook.live.com/owa/";
             ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
             if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
             {
                 toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
             }
        }

        private void gmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("https://accounts.google.com/signin/v2/identifier?service=mail&passive=true&rm=false&continue=https%3A%2F%2Fmail.google.com%2Fmail%2F%3Fhl%3Dtr&ss=1&scc=1&ltmpl=default&ltmplcache=2&hl=tr&emr=1&osid=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
            toolStripComboBox1.Text = "https://accounts.google.com";
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
            if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //((WebBrowser)tabControl1.SelectedTab.Controls[0]).ShowPrintDialog()
                ;
            //((WebBrowser)tabControl1.SelectedTab.Controls[0]).ShowPrintPreviewDialog();
        
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoHome();
        }

        private void kaynağıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentText.ToString();
            rtb.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add("Yeni Sekme");
            rtb.Visible = true;
            tabControl1.SelectTab(i);
        
            tabControl1.SelectedTab.Controls.Add(rtb);
            i++;
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).ShowPrintPreviewDialog();
        }

        private void sayfayıYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).ShowPrintDialog();
        }

        private void sayfayıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).ShowSaveAsDialog();
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).ShowPageSetupDialog();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).ShowPropertiesDialog();
        }

        private void geçmişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        
            //else
            //{
            //    geçmişToolStripMenuItem.Enabled = false;
            //    sayac = 0;
            //}
                
                lb.Items.Clear();


                lb.Dock = DockStyle.Fill;
                lb.Visible = true;
                //clb.Sorted = true;
                lb.SelectionMode = SelectionMode.MultiSimple;
                //clb.SelectionMode = SelectionMode.MultiSimple;
                // clb.MultiColumn = true;
                lb.BackColor = Color.DarkRed;
                lb.ForeColor = Color.Blue;

                foreach (gecmisDataSet.gecmiswebRow item in gecmisDataSet.gecmisweb.Rows)
                {
                    string[] saat = new string[] { item.saat.ToString() };
                    string[] dizi = new
                        [] { item.site_adi.ToString() };
                    string[] tarih = new string[] { item.tarih.ToShortDateString() };
                    //MessageBox.Show(dizi[0].ToString());
                    object[] a = new object[] { dizi[0].ToString() };

                    // object[] b = new object[] { tarih[0].ToString() };
                    if (!lb.Items.Contains(a))
                    {
                        lb.Items.AddRange(a);
                    }
                    //lb.Items.AddRange(b);
                }

                //lb.KeyDown += new KeyEventHandler(clb_KeyDown);


                tabControl1.TabPages.Add("Geçmiş");
                tabControl1.SelectTab(i);
                tabControl1.SelectedTab.Controls.Add(lb);
                i++;


            
            //else
            //{
            //    geçmişToolStripMenuItem.Enabled = false;
            //}
                    //if (tabControl1.TabPages.Count > 2)
                    //{
                    //    tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                    //    tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                    //}
       
        }

      

    

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {

            //toolStripComboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //toolStripComboBox1.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
            //toolStripComboBox1.AutoCompleteSource = AutoCompleteSource.AllUrl;
            //toolStripComboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            //toolStripComboBox1.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
            //toolStripComboBox1.AutoCompleteSource = AutoCompleteSource.HistoryList;
            //toolStripComboBox1.AutoCompleteSource = AutoCompleteSource.AllUrl;
           // toolStripComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
           // toolStripComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            //toolStripComboBox1.AutoCompleteCustomSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            
        }

        private void webtarayici_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      

    
    
       
    }
}
