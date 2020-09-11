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
    }
}
