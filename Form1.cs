using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;


namespace Word_Data_Transfer_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            word.Application yeni = new word.Application();
            yeni.Visible = true;
            word.Document sayfa;
            object obj = System.Reflection.Missing.Value;
            sayfa = yeni.Documents.Add(ref obj, ref obj, ref obj, ref obj);
            yeni.Selection.Font.Italic = 33;
            yeni.Caption = "Açıklama";
            yeni.Selection.Font.Name = "Tahoma";
            yeni.Selection.TypeText("aaa");
           
        }
    }
}
