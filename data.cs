using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Is_1_20_LazarevVA
{
    public partial class data : Form
    {
        //Переменная соединения
        MySqlConnection conn;
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содержит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
        //Выделение всей строки по ПКМ
        private void guna2DataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                guna2DataGridView2.CurrentCell = guna2DataGridView2[e.ColumnIndex, e.RowIndex];
                //guna2DataGridView2.CurrentRow.Selected = true;
                guna2DataGridView2.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }
        //Метод получения ID выделенной строки, для последующего вызова его в нужных методах
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = guna2DataGridView2.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = guna2DataGridView2.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
        }
        //Метод обновления DataGreed
        public void reload_list()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetListUsers();
        }
        public void GetListUsers()
        {
            //Запрос для вывода строк в БД
            string commandStr = "SELECT * FROM Employee";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            guna2DataGridView2.DataSource = bSource;
            //Закрываем соединение
            conn.Close();
            //Отражаем количество записей в ДатаГриде
            int count_rows = guna2DataGridView2.RowCount - 1;
        }
        public data()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn = ConnMySQL.Conn1();
            //Вызываем метод для заполнение дата Грида
            GetListUsers();
            //Видимость полей в гриде
            guna2DataGridView2.Columns[0].Visible = true;
            guna2DataGridView2.Columns[1].Visible = true;

            //Ширина полей
            guna2DataGridView2.Columns[0].FillWeight = 20;
            guna2DataGridView2.Columns[1].FillWeight = 40;
            //Режим для полей "Только для чтения"
            guna2DataGridView2.Columns[0].ReadOnly = true;
            guna2DataGridView2.Columns[1].ReadOnly = true;
            //Растягивание полей грида
            guna2DataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            guna2DataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Убираем заголовки строк
            guna2DataGridView2.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            guna2DataGridView2.ColumnHeadersVisible = true;
        }

        private void data_Load(object sender, EventArgs e)
        {
            conn = ConnMySQL.Conn1();
            
        }
    }
}
