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
        }

        private void импортИзCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строки
            string[] fileTextLine = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(1251));
            // получаем коллекцию значений из строки
            string[] items = fileTextLine[0].Split(';');
            // заполняем заголовки
            foreach (string item in items)
            {
                listView1.Columns.Add(item);
            }
            // заполняем строки ЛистВьюера
            for (int i = 1; i < fileTextLine.Count(); i++)
            {
                items = fileTextLine[i].Split(';');
                listView1.Items.Add(new ListViewItem(items));
                // проверим строку и ошибки покрасим
                if (true) listView1.Items[0].BackColor = Color.Empty;
            }
            if (listView1.Items.Count > 0)
            {
                listView1.FocusedItem = listView1.Items[0];
                listView1.Items[0].Selected = true;
            }
            Form1.ActiveForm.ActiveControl = listView1;
        }
    }
}
