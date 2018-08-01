using System;
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
            if (tbLastNameAgent.Text.Length < 3)
            {
                MessageBox.Show("Длина Фамилии должно быть не меньше 3 символов.");

            }
            else if (tbNameAgent.Text.Length < 3)
            {
                MessageBox.Show("Длина Имени должно быть не меньше 3 символов.");

            }else if (!(tbPhoneAgent.Text.Length == 7))
            {
                MessageBox.Show("длина телефона состоит из 7 цифр");
            }else
            {
                try
                {
                    agent.LastNameAgent = tbLastNameAgent.Text;
                    agent.NameAgent = tbNameAgent.Text;
                    agent.Phone = Convert.ToInt32(tbPhoneAgent.Text);
                }catch (Exception ex)
                { MessageBox.Show("Ошибка" + ex.Message); }
                this.DialogResult = true;
            }
        }
    }
}
