using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilgisayarAlarm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
    
            this.DialogResult = DialogResult.OK;
         
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(DateTime.Now.Minute.ToString());

                if (comboBox1.SelectedItem.ToString() == DateTime.Now.Hour.ToString())
                {
                    for (int i = a + 2; i <= 59; i++)
                    {
                        // comboBox2.Items.Clear();
                        comboBox2.Items.Add(i.ToString());
                        //double dk = double.Parse(comboBox2.SelectedItem.ToString());
                        //DateTime.Now.AddMinutes(dk);
                    }
                }
                else
                {
                    for (int i = 0; i <= 59; i++)
                    {
                        comboBox2.Items.Add(i.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
