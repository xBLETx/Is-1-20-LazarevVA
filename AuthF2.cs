using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Is_1_20_LazarevVA
{
    public class AuthF2
    {
        static public class Auth
        {
            //Статичное поле, которое хранит значение статуса авторизации
            public static bool auth = false;
            //Статичное поле, которое хранит значения ID пользователя
            public static string auth_id = null;
            //Статичное поле, которое хранит значения ФИО пользователя
            public static string auth_fio = null;
            //Статичное поле, которое хранит количество привелегий пользователя
            public static int auth_role = 0;
        }
        static public string sha256(string randomString)
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
        static public void GetUserInfo(string login_user)
        {
            //Объявлем переменную для запроса в БД
            //string selected_id_stud = metroTextBox1.Text;
            // устанавливаем соединение с БД
            MySqlConnection conn = ConnMySQL.Conn1();
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

       
    }
}
