using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EgissoApp
{
    public partial class Editform : Form
    {
        public Editform()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label29.Visible = true;
            label29.ForeColor = Color.Black;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label29.Visible = true;
            label29.ForeColor = Color.Black;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void doctype_recip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doctype_recip.SelectedIndex == 0)
            {
                doc_IssueDate_recip.Enabled = false;
                doc_Series_recip.Enabled = false;
                doc_Number_recip.Enabled = false;
                doc_Issuer_recip.Enabled = false;
            }
            else
            {
                doc_IssueDate_recip.Enabled = true;
                doc_Series_recip.Enabled = true;
                doc_Number_recip.Enabled = true;
                doc_Issuer_recip.Enabled = true;
            }

        }

        private void Editform_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label29.Visible == true) label29.Visible = false;
            else label29.Visible = true;
        }

        private void doctype_reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doctype_recip.SelectedIndex == 0)
            {
                doc_IssueDate_reason.Enabled = false;
                doc_Series_reason.Enabled = false;
                doc_Number_reason.Enabled = false;
                doc_Issuer_reason.Enabled = false;
            }
            else
            {
                doc_IssueDate_reason.Enabled = true;
                doc_Series_reason.Enabled = true;
                doc_Number_reason.Enabled = true;
                doc_Issuer_reason.Enabled = true;
            }
        }

        private void amount_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void SNILS_recip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SNILS_recip.Text.Length == 14)
            {
                
            }
        }
    }
}
