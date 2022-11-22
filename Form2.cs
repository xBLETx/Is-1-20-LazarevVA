using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Is_1_20_LazarevVA
{
    public partial class Auth2 : Form
    {
        MySqlConnection conn;

        public void ShadowPass()
        {

            if(guna2ToggleSwitch1.Checked) guna2TextBox2.UseSystemPasswordChar = true;
            else guna2TextBox2.UseSystemPasswordChar = false;




        }
      

        public Auth2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Инициализируем соединение с подходящей строкой
            conn = ConnMySQL.Conn1();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            //Запрос в БД на предмет того, если ли строка с подходящим логином и паролем
            string sql = "SELECT * FROM Role WHERE Login = @un and  Password= @up";
            //Открытие соединения
            conn.Open();
            //Объявляем таблицу
            DataTable table = new DataTable();
            //Объявляем адаптер
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //Объявляем команду
            MySqlCommand command = new MySqlCommand(sql, conn);
            //Определяем параметры
            command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            //Присваиваем параметрам значение
            command.Parameters["@un"].Value = guna2TextBox1.Text;
            command.Parameters["@up"].Value = AuthF2.sha256(guna2TextBox2.Text);
            //Заносим команду в адаптер
            adapter.SelectCommand = command;
            //Заполняем таблицу
            adapter.Fill(table);
            //Закрываем соединение
            conn.Close();
            //Если вернулась больше 0 строк, значит такой пользователь существует
            if (table.Rows.Count > 0)
            {
                //Присваеваем глобальный признак авторизации
                AuthF2.Auth.auth = true;
                //Достаем данные пользователя в случае успеха
                AuthF2.GetUserInfo(guna2TextBox1.Text);
                //Закрываем форму
                this.Close();
            }
            else
            {
                //Отобразить сообщение о том, что авторизаия неуспешна
                MessageBox.Show("Неверные данные авторизации!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            ShadowPass();
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
