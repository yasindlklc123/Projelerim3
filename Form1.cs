using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BilgisayarAlarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string yol = "";
        string zilsesi = "";//Application.StartupPath + @"\Zil Sesleri\" + "1.mp3";
        private void oyntbtn_Click(object sender, EventArgs e)
        {
            try
            {
                label7.Text = comboBox1.SelectedItem.ToString() + ":" + comboBox2.SelectedItem.ToString();
                comboBox1.ResetText();
                comboBox2.ResetText();
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                ayarlabtn.Enabled = false;
                label7.Visible = true;
                label8.Visible = true;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Hide();
            label8.Hide();
            label9.Hide();
            textBox1.Hide();
            textBox1.ReadOnly = true;
            try
            {
                if (!Directory.Exists(Application.StartupPath + @"\Zil Sesleri\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\Zil Sesleri\");

                }
                else
                {
                    yol = Application.StartupPath + @"\Zil Sesleri\";
                    DirectoryInfo di = new DirectoryInfo(yol);
                    FileInfo[] fd = di.GetFiles();
                    foreach (FileInfo item in fd)
                    {
                        listBox1.Items.Add(item.Name.ToString());

                    }
                }
                //listBox1.Items.Add(Application.StartupPath+@"\Zil Sesleri\"+"1.mp3");

                //listBox1.Items.Add(Application.StartupPath + @"\Zil Sesleri\" + "2.mp3");
                simpleButton1.Hide();
                simpleButton2.Hide();
                simpleButton3.Hide();
                axWindowsMediaPlayer1.settings.volume = 100;
                timer1.Enabled = true;
                for (int i = 10; i <= 59; i++)
                {
                    comboBox2.Items.Add(i.ToString());
                    comboBox2.Sorted = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (label7.Text == DateTime.Now.ToShortTimeString())
                {
                    label7.ResetText();
                    axWindowsMediaPlayer1.URL = Application.StartupPath + @"\Zil Sesleri\" + listBox1.Items[1].ToString();
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    simpleButton3.Visible = true;
                    simpleButton2.Visible = true;
                    simpleButton1.Visible = true;
                    if (!String.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show(textBox1.Text.ToUpper());
                    }
                    textBox1.ResetText();
                    textBox1.Visible = false;
                    label9.Visible = false;
                   
                }
                label2.Text = DateTime.Now.Hour.ToString();
                label4.Text = DateTime.Now.Minute.ToString();
                label6.Text = DateTime.Now.Second.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                Form2 ertele = new Form2();


                if (ertele.ShowDialog() == DialogResult.OK)
                {
                    label7.Text = ertele.comboBox1.SelectedItem.ToString() + ":" + ertele.comboBox2.SelectedItem.ToString();
                    simpleButton1.Hide();
                    simpleButton2.Hide();
                    simpleButton3.Hide();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                }

                //int a = int.Parse(comboBox2.SelectedItem.ToString());
                //for (int i = a+5; i <= 59; i++)
                //{
                //    comboBox3.Items.Add(i.ToString());
                //}
                //label7.Text = comboBox1.SelectedItem.ToString() + ":" + comboBox3.SelectedItem.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                Application.Exit();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.settings.volume = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                ayarlabtn.Enabled = true;
                label7.ResetText();
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(listBox1.SelectedIndex.ToString());
                //MessageBox.Show(a.ToString());
                string mzk = listBox1.Items[1].ToString();
                listBox1.Items[1] = listBox1.SelectedItem;
                listBox1.Items[a] = mzk;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {


                string kopyalanacakDosya = "", kopyalanacakDosyaIsmi = "",
                                  dosyanınKopyanacagiKlasor = "";
                openFileDialog1.Title = "Kopyalanacak Dosyayı Seçiniz...";
                openFileDialog1.FileName = "";
                //op.Filter = "Pdf Dosyaları (*.Pdf)|*.Pdf|Tüm Dosyalar (*.*)|*.*";
                openFileDialog1.Filter = "Müzik Dosyaları(*.Mp3)|*.Mp3|Tüm Dosyalar (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    kopyalanacakDosyaIsmi = openFileDialog1.SafeFileName.ToString();
                    kopyalanacakDosya = openFileDialog1.FileName.ToString();
                    dosyanınKopyanacagiKlasor = Application.StartupPath + @"\Zil Sesleri\";


                }
                File.Copy(kopyalanacakDosya, dosyanınKopyanacagiKlasor + @"\" + openFileDialog1.SafeFileName);



                simpleButton7_Click(sender, e);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           



        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try
            {
                yol = Application.StartupPath + @"\Zil Sesleri\";
                DirectoryInfo di = new DirectoryInfo(yol);
                FileInfo[] fd = di.GetFiles();
                foreach (FileInfo item in fd)
                {
                    if (!listBox1.Items.Contains(item.Name.ToString()))
                    {
                        listBox1.Items.Add(item.Name.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Bu Müzik Listede Zaten Var","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            File.Delete(Application.StartupPath + @"\Zil Sesleri\" + listBox1.SelectedItem.ToString());
            simpleButton7_Click(sender, e);
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\Zil Sesleri\" + listBox1.SelectedItem.ToString();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            Form3 not = new Form3();
            if (not.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = not.richTextBox1.Text;
                textBox1.Visible = true;
                label9.Visible = true;
            }
        }

   


    }
}
        

      
      
    

