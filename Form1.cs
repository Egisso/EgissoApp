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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // заголовки для DGV из класса Mera
            Mera mera = new Mera();
            System.Reflection.FieldInfo[] fi = mera.GetType().GetFields();
            dataGridView1.ColumnCount = fi.Length;
            for (int i = 0; i < fi.Length; i++) dataGridView1.Columns[i].HeaderText = fi[i].Name;
        }

        private void импортИзCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строки
            string[] fileTextLine = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(1251));
            string[] headers = fileTextLine[0].Split(';');
            // заполняем строки DGV
            for (int i = 1; i < fileTextLine.Count(); i++)
            {
                Mera mera = new Mera();
                string[] items = fileTextLine[i].Split(';');
                foreach (string item in items)
                {
                    mera.SetField(headers[Array.IndexOf(items, item)], item);
                }
                // теперь эту меру как то нужно проверить

                // новая строка из класса Mera
                dataGridView1.Rows.Add(mera.MassivForWrite());
            }
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                //listView1.FocusedItem = listView1.Items[0];
                //listView1.Items[0].Selected = true;
            }
            Form1.ActiveForm.ActiveControl = dataGridView1;
        }
    }
}
