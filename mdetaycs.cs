using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Has___Emlak
{
    public partial class mdetaycs : DevExpress.XtraEditors.XtraForm
    {
        public mdetaycs()
        {
            InitializeComponent();
        }

        private void mdetaycs_Load(object sender, EventArgs e)
        {
          
            textBox1.Hide();
            button3.Hide();
            textBox2.Enabled = false;
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilant' table. You can move, or remove it, as needed.
            this.ilantTableAdapter.Fill(this.hasemlakDataSet.ilant);
            
               
            // TODO: This line of code loads data into the 'hasemlakDataSet.ilanverenmusteri' table. You can move, or remove it, as needed.
            this.ilanverenmusteriTableAdapter.Fill(this.hasemlakDataSet.ilanverenmusteri);
            labelControl3.Text = dataGridView1.Rows.Count.ToString();
            button3_Click(sender, e);
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            adagore();
            soyadagore();
            telefonagore();
            epostagore();
           
                }
        public void adagore()
        {
            if (checkEdit1.Checked == true)
            {
               
                //gridControl1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                //gridControl1.DataSource = dt;

                ilanverenmusteriBindingSource.Filter = "musteri_adi Like '" + textEdit1.Text.ToUpper() + "%'";
                labelControl3.Text = dataGridView1.Rows.Count.ToString();
               
                //dataGridView1.DataSource = tmkyt;
            }
        }
        public void soyadagore()
        {
            if (checkEdit2.Checked == true)
            {
                ilanverenmusteriBindingSource.Filter = "musteri_soyadi Like '" + textEdit1.Text.ToUpper() + "%'";
                labelControl3.Text = dataGridView1.Rows.Count.ToString();
               
            }
        }
        public void telefonagore()
        {
            if (checkEdit3.Checked == true)
            {
                ilanverenmusteriBindingSource.Filter = "musteri_telefon Like '" + textEdit1.Text + "%'";
                labelControl3.Text = dataGridView1.Rows.Count.ToString();
               
            }
        }
        public void epostagore()
        {
            if (checkEdit4.Checked == true)
            {
                ilanverenmusteriBindingSource.Filter = "musteri_e_posta Like '" + textEdit1.Text + "%'";
                labelControl3.Text = dataGridView1.Rows.Count.ToString();
               
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int a = textBox1.Lines.Count() - 1;
                int b = dataGridView1.Rows.Count;
                SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True; pooling=true; connection timeout=30; packet size=1024"); 
               // SqlConnection bagla = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\abcemlak.mdf;Integrated Security=True;User Instance=True");
                bagla.Open();
                SqlCommand kmt = new SqlCommand("select musteri_id,count(ilan_id) from ilant group by(musteri_id)", bagla);
                SqlDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    textBox2.Text = textBox2.Text + Environment.NewLine + oku[1].ToString();
                }
                bagla.Close();
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        if (textBox1.Lines[i].ToString() == dataGridView1.Rows[j].Cells[0].Value.ToString())
                        {
                            textBox2.Text = dataGridView1.Rows[j].Cells[1].Value.ToString() + " " + dataGridView1.Rows[j].Cells[2].Value.ToString() + Environment.NewLine + textBox2.Text;
                            // MessageBox.Show(dataGridView1.Rows[j].Cells[1].Value.ToString());
                        }
                    }
                }


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(),"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void mdetaycs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.WindowsShutDown)
            {
                Process.Start("shutdown", "-a");
                MessageBox.Show("Bilgisayarı Kapatma İptal Edildi Program Açık", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        

       
    }
}