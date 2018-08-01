using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Agency1.window
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        Authentication loginwindow = new Authentication();
        public Registration()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, RoutedEventArgs e)
        {
            Authentication login = new Authentication();
            login.Show();
            this.Close();
        }

        private void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            if (tb_login1.Text.Length == 0)
            {
                MessageBox.Show("Поле логин не может быть пустым.");
                tb_login1.Focus();
            }
            else if (tb_last_name1.Text.Length == 0)
            {
                MessageBox.Show("Поле фамилия не может быть пустым.");
                tb_last_name1.Focus();
            }
            else if (tb_name1.Text.Length == 0)
            {
                MessageBox.Show("Поле имя не может быть пустым.");
                tb_name1.Focus();
            }
            else if (tb_phone1.Text.Length == 0)
            {
                MessageBox.Show("Поле телефон не может быть пустым.");
                tb_phone1.Focus();
            }
            else if (tb_email1.Text.Length == 0)
            {
                MessageBox.Show("Поле email не может быть пустым.");
                tb_email1.Focus();
            }
            else if (!Regex.IsMatch(tb_email1.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
               MessageBox.Show("Введите действительный адрес электронной почты.");
                tb_email1.Select(0, tb_email1.Text.Length);
                tb_email1.Focus();
            }
            else
            {
                string login = tb_login1.Text;
                string last_name = tb_last_name1.Text;
                string name = tb_name1.Text;
                string password = tb_password1.Password;
                int phone = Convert.ToInt32(tb_phone1.Text);
                string email = tb_email1.Text;
                int roleId = 3;
                if (tb_password1.Password.Length == 0)
                {
                    MessageBox.Show("Введите пароль.");
                    tb_password1.Focus();
                }
                else if (tb_password_confirm1.Password.Length == 0)
                {
                    MessageBox.Show("Введите повторно пароль.");
                    tb_password_confirm1.Focus();
                }
                else if (tb_password1.Password != tb_password_confirm1.Password)
                {
                    MessageBox.Show("Подтверждение пароля должно совпадать с паролем.");
                    tb_password_confirm1.Focus();
                }
                else
                {
                    //try
                    //{
                    SqlConnection con = new SqlConnection("Data Source = ACER-SERG\\SQLEXPRESS; ; Initial Catalog = AgencyDB1; MultipleActiveResultSets = true; Integrated Security = True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Agents (Login, Password, LastNameAgent, NameAgent, Phone, Email, RoleId) values('" + login + "','" + password + "','" + last_name + "','" + name + "','" + phone + "','" + email + "','" + roleId + "')",con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Регистрация успешна!");
                        loginwindow.Show();
                    this.Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("Ошибка" + ex.Message);
                    //}
                }
            }

        }
    }
}