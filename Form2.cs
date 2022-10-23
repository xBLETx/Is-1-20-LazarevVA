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
        // строка подключения к БД
        //string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_18;database=is_1_20_st18_KURS;password=54276237;";
        string connStr = "server=10.90.12.110;port=33333;user=st_1_20_18;database=is_1_20_st18_KURS;password=54276237;";
        //Переменная соединения
        MySqlConnection conn;
        //Логин и пароль к данной форме Вы сможете посмотреть в БД db_test таблице t_user
        //Вычисление хэша строки и возрат его из метода
        static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        //Метод запроса данных пользователя по логину для запоминания их в полях класса
        public void GetUserInfo(string login_user)
        {
            //Объявлем переменную для запроса в БД
                //string selected_id_stud = metroTextBox1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT id_role,fio_empl,rol,Login,`Password` FROM Role,Employee WHERE Login='{login_user}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Auth.auth_id = reader[0].ToString();
                Auth.auth_fio = reader[1].ToString();
                Auth.auth_role = Convert.ToInt32(reader[2].ToString());
            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
        public Auth2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Инициализируем соединение с подходящей строкой
            conn = new MySqlConnection(connStr);
        }

        
    }
}
