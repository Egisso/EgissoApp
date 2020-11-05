using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;


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
            UpdateDGV();
        }

        private void UpdateDGV ()
        {
            DataSet ds = new DataSet(); //Создаем объект класса DataSet

            string sql = "Select * From [table]"; //Sql запрос (достать все из таблицы table)

            string path = "egissodb.db"; //Путь к файлу БД

            string ConnectionString = "Data Source=" + path + ";Version=3;New=True;Compress=True;"; //Строка соеденения (так хочет sqlite)

            SQLiteConnection conn = new SQLiteConnection(ConnectionString); //Создаем соеденение

            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);//Создаем объект класса DataAdapter (тут мы передаем наш запрос и получаем ответ)

            da.Fill(ds);//Заполняем DataSet cодержимым DataAdapter'a

            dataGridView1.DataSource = ds.Tables[0].DefaultView;//Заполняем созданный на форме dataGridView1

            conn.Close();//Закрываем соединение
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Editform f = new Editform();
            f.Show();
            f.FormClosed += (obj, arg) =>
            {
                UpdateDGV();
            };
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void экспортВXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int RowCount = dataGridView1.RowCount;
            int ColumnCount = dataGridView1.ColumnCount;

            // get column headers
            for (int currentCol = 1; currentCol < ColumnCount; currentCol++)
            {
                sb.Append(dataGridView1.Columns[currentCol].Name);
                if (currentCol < ColumnCount - 1)
                {
                    sb.Append(";");
                }
                else
                {
                    sb.AppendLine();
                }
            }

            // get the rows data
            for (int currentRow = 0; currentRow < RowCount; currentRow++)
            {
                if (!dataGridView1.Rows[currentRow].IsNewRow)
                {
                    for (int currentCol = 1; currentCol < ColumnCount; currentCol++)
                    {
                        if (dataGridView1.Rows[currentRow].Cells[currentCol].Value != null)
                        {
                            sb.Append(dataGridView1.Rows[currentRow].Cells[currentCol].Value.ToString());
                        }
                        if (currentCol < ColumnCount - 1)
                        {
                            sb.Append(";");
                        }
                        else
                        {
                            sb.AppendLine();
                        }
                    }
                }
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, sb.ToString(), Encoding.GetEncoding(1251));
            MessageBox.Show("Файл сохранен");
            //System.IO.File.WriteAllText(@"C:\Users\Администратор\Desktop\DGV_CSV_EXPORT.csv", sb.ToString(), Encoding.GetEncoding(1251));
        }
    }
}
