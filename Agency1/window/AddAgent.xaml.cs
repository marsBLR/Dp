﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Agency1.BusinessLayer.Models;
using Agency1.DataLayer.Entities;
using System.Text.RegularExpressions;

namespace Agency1.window
{
    /// <summary>
    /// Interaction logic for AddAgent.xaml
    /// </summary>
    public partial class AddAgent : Window
    {
        AgentViewModels agent;
        public AddAgent()
        {
            InitializeComponent();
        }
        public AddAgent(AgentViewModels agent) : this()
        {
            this.agent = agent;
            this.DataContext = agent;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
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
            else if (tb_phone1.Text.Length == 0 )
            {
                MessageBox.Show("Поле телефон не может быть пустым.");
                tb_phone1.Focus();
            }
            //else if (tb_phone1.Text.Length == 7)
            //{
            //    MessageBox.Show("Поле телефон должно быть равно 7 цифрам");
            //    tb_phone1.Focus();
            //}
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
            //else
            //{
            //    //string login = tb_login1.Text;
            //    //string last_name = tb_last_name1.Text;
            //    //string name = tb_name1.Text;
            //    //string password = tb_password1.Password;
            //    //int phone = Convert.ToInt32(tb_phone1.Text);
            //    //string email = tb_email1.Text;
            //    //int roleId = 3;
            //    //if (tb_password1.Password.Length == 0)
            //    //{
            //    //    MessageBox.Show("Введите пароль.");
            //    //    tb_password1.Focus();
            //    //}
            //  }
            else 
            {
                try
                {
                    agent.Login = tb_login1.Text;
                    agent.Password = tb_password1.Password;
                    agent.LastNameAgent = tb_last_name1.Text;
                    agent.NameAgent = tb_name1.Text;
                    agent.Phone = Convert.ToInt32(tb_phone1.Text);
                    agent.Email = tb_email1.Text;
                    agent.RoleId = 3;

                }catch (Exception ex)
                { MessageBox.Show("Ошибка" + ex.Message); }
                this.DialogResult = true;
            }
        }
    }
}
