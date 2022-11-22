using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Is_1_20_LazarevVA
{
    public class ConnMySQL
    {
        
        


        static public MySqlConnection Conn1()
        {
            // строка подключения к БД
            //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_18;database=is_1_20_st18_KURS;password=54276237;";
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_18;database=is_1_20_st18_KURS;password=54276237;";
            //Переменная соединения
            MySqlConnection connDB;

            connDB = new MySqlConnection(connStr);

            return connDB;
        }
        




    }
}
