using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Agency1.BusinessLayer.Interfaces;
using Agency1.BusinessLayer.Models;
using Agency1.BusinessLayer.Services;
using System.Collections.ObjectModel;
using Agency1.DataLayer.Entities;
using Agency1.DataLayer.Interfases;
using Agency1.DataLayer.Repositories;
using AutoMapper;

namespace Agency1.window
{
    /// <summary>
    /// Interaction logic for Authentication.xaml
    /// </summary>
    public partial class Authentication : Window
    {
        IUnitOfWork dataBase;
        ObservableCollection<AgentViewModels> agentsModel;

        IAgentService agentService;


        public Authentication()
        {
            InitializeComponent();
            dataBase = new EntityUnitOfWork("AgencyDB");

            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Agent, AgentViewModels>();
                
            });
            
            agentService = new AgentService(dataBase);
            agentsModel = agentService.GetAll();
        }
        
       
        private void Button_Click_LogIn(object sender, RoutedEventArgs e)
        {
            AgentViewModels agentUser = new AgentViewModels() ;
          //  MainWindow mainWindow = new MainWindow(agentUser);
            if (tb_login.Text.Length ==0)
            {
                MessageBox.Show("Поле Логин не может быть пустым.");
                tb_login.Focus();
            }
            else
            {
                string login = tb_login.Text;
                string password = tb_password.Password;
                SqlConnection con = new SqlConnection("Data Source = ACER-SERG\\SQLEXPRESS; ; Initial Catalog = AgencyDB1; MultipleActiveResultSets = true; Integrated Security = True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Agents where Login='" + login + "' and Password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
               SqlCommand user =new SqlCommand("Select AgentId from Agents where Login='" + login + "' and Password='" + password + "'", con);
                user.CommandType = CommandType.Text;
                SqlDataAdapter a = new SqlDataAdapter();
                a.SelectCommand = user;
               

                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    //AgentViewModels agentUser;
                    string userid = dataset.Tables[0].Rows[0]["AgentId"].ToString();
                    int k = Convert.ToInt32(userid);
                    string username = dataset.Tables[0].Rows[0]["LastNameAgent"].ToString() + " " + dataset.Tables[0].Rows[0]["NameAgent"].ToString();
                    
                    MessageBox.Show(userid);
                    foreach (AgentViewModels agent in agentService.GetAll())
                    {
                        if (agent.AgentId == k)
                        {
                            agentUser = agent;
                        }
                    }
                   // AgentViewModels agentUser =
                    MainWindow mainWindow = new MainWindow(agentUser);
                    mainWindow.textblock_login.Text = username;
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пожалуйста введите правильные логин/пароль");
                }
                con.Close();
            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}