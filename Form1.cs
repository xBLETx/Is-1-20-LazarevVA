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

namespace Is_1_20_LazarevVA
{
    public partial class Auth1 : MetroForm
    {


        public Auth1()
        {
            InitializeComponent();
        }
        //Метод расстановки функционала формы взависимости от роли пользователя, которая передается посредством  поля класса,
        //в которое данное значени в свою очередь попало из запроса
        public void ManagerRole(int role)
        {
            switch (role)
            {
                case 1:
                    metroLabel1.Text = "Сотрудник";
                    metroLabel1.ForeColor = Color.DeepPink;
                    metroButton1.Enabled = true;
                    metroButton2.Enabled = true;
                    metroButton3.Enabled = false;
                    break;
                case 2:
                    metroLabel1.Text = "Администратор";
                    metroLabel1.ForeColor = Color.Green;
                    metroButton1.Enabled = true;
                    metroButton2.Enabled = true;
                    metroButton3.Enabled = true;
                    break;
                case 3:
                    metroLabel1.Text = "Помошник";
                    metroLabel1.ForeColor = Color.Gold;
                    metroButton1.Enabled = true;
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = false;
                    break;
                default:
                    metroLabel1.Text = "Неизвестный пользователь";
                    metroLabel1.ForeColor = Color.Red;
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = false;
                    metroButton3.Enabled = false;
                    break;


            }




        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Сокрытие текущей формы
            this.Hide();
            //Инициализируем и вызываем форму диалога авторизации
            Auth2 auth2 = new Auth2();
            //Вызов формы в режиме диалога
            auth2.ShowDialog();
            //Если авторизации была успешна и в поле класса хранится истина, то делаем движуху:
            if (Auth.auth)
            {
                //Отображаем рабочую форму
                this.Show();
                //Вытаскиваем из класса поля в label'ы
                metroLabel2.Text = Auth.auth_id;
                metroLabel3.Text = Auth.auth_fio;
                metroLabel4.Text = "Лецензированый пользователь";
                //Красим текст в label в зелёный цвет
                metroLabel4.ForeColor = Color.Green;
                //Вызываем метод управления ролями
                ManagerRole(Auth.auth_role);
            }
            else
            {
                this.Show();
                metroLabel2.Text = "неизвестный пользователь";
                metroLabel3.Text = "Отсутствует информация о пользователе";
                metroLabel4.Text = "Тебе сдесь не рады!ц";
                metroLabel4.ForeColor = Color.Red;
                ManagerRole(Auth.auth_role);
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
