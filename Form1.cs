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
            dataGridView1.Columns[0].Visible = false;
            conn.Close();//Закрываем соединение
            double amountDGV = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                amountDGV += Double.Parse(row.Cells[33].Value.ToString());
            }
            toolStripStatusLabel1.Text = $"Всего записей: {dataGridView1.Rows.Count} на сумму {amountDGV}.";

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

            int rowCount = 0;
            double amountExport = 0;

            // get the rows data
            for (int currentRow = 0; currentRow < RowCount; currentRow++)
            {
                if (!dataGridView1.Rows[currentRow].IsNewRow)
                {
                    for (int currentCol = 1; currentCol < ColumnCount; currentCol++)
                    {
                        if (currentCol == 33) amountExport += Double.Parse(dataGridView1.Rows[currentRow].Cells[currentCol].Value.ToString());
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
                            rowCount++;
                        }
                    }
                }
            }
            saveFileDialog1.FileName = $"Export_{DateTime.Now.ToString().Replace(".", "_").Replace(":", "_").Replace(" ", "_")}";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            File.WriteAllText(filename, sb.ToString(), Encoding.GetEncoding(1251));
            MessageBox.Show($"Файл сохранен!\nЧисло строк: {rowCount}\nСумма:  {amountExport}");

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Editform f = new Editform();
            //f.Show();
            //f.FormClosed += (obj, arg) =>
            //{
            //    UpdateDGV();

            //};
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SQLiteConnection conn = new SQLiteConnection("Data Source=egissodb.db;Version=3;New=True;Compress=True;");
                conn.Open();
                SQLiteCommand sQLiteCmd = new SQLiteCommand($"DELETE FROM [table] WHERE id = {id}", conn);
                sQLiteCmd.ExecuteNonQuery();
                conn.Close();
                UpdateDGV();
            }
            catch
            {
                MessageBox.Show("Не удалось удалить строку!");
            }
            
        }
    }
}
