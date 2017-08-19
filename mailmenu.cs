using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.Diagnostics;

namespace Has___Emlak
{
    public partial class mailmenu : DevExpress.XtraEditors.XtraForm
    {
        public mailmenu()
        {
            InitializeComponent();
        }
        string cmle;
        private void mailmenu_Load(object sender, EventArgs e)
        {
            labelControl1.Hide();
        }

        private void gonderbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (alıcıtxt.Text != "")
                {
                    MailMessage mesaj = new MailMessage();
                    SmtpClient sunucu = new SmtpClient();
                    sunucu.Credentials = new System.Net.NetworkCredential("postaadresi@hotmail.com", "gerceksifren");
                    sunucu.Port = 587;
                    sunucu.Host = "smtp.live.com";
                    sunucu.EnableSsl = true;
                    mesaj.To.Add(alıcıtxt.Text);
                    mesaj.From = new MailAddress("postaadresi@hotmail.com");
                    mesaj.Subject = konutxt.Text;
                    mesaj.Body = richTextBox1.Text;
                    sunucu.Send(mesaj);
                    MessageBox.Show("Mesaj Başarıyla Gönderildi");
                    alıcıtxt.ResetText();
                    konutxt.ResetText();
                    richTextBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Lütfen Alıcı Kişiye Ait E-Posta Adresini Giriniz","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vazgecbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public void maililan()
        {
           
            cmle = "İlan No : " + mailgrd.SelectedRows[0].Cells[0].Value.ToString();
            richTextBox1.Text = cmle;
            
        }
        public void msilan()
        {
            if (labelControl1.Text == "mst")
            {
                alıcıtxt.Text = mailgrd.SelectedRows[0].Cells[4].Value.ToString();
                cmle = "Müşteri No : " + mailgrd.SelectedRows[0].Cells[0].Value.ToString();
                richTextBox1.Text = cmle;
            }
        }
        private void mailgrd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maililan();
            msilan();
            ypi();
        }
        public void ypi()
        {
            if (labelControl1.Text == "yapi")
            {
                cmle = "Yapi No : " + mailgrd.SelectedRows[0].Cells[0].Value.ToString();
                richTextBox1.Text = cmle;
            }
        }

        private void mailmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}