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

namespace Agency1
{
    /// <summary>
    /// Interaction logic for AddEmployer.xaml
    /// </summary>
    public partial class AddEmployer : Window
    {
       
        EmployerViewModels employer;
        public AddEmployer()
        {
            InitializeComponent();
           
        }
        public AddEmployer(EmployerViewModels employer) : this()
        {
            this.employer = employer;
            this.DataContext = employer;
        }
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbLastName.Text.Length < 3)
            {
                MessageBox.Show("Длина Фамилии должно быть не меньше 3 символов.");
                tbLastName.Focus();
            }
            if (tbName.Text.Length < 3)
            {
                MessageBox.Show("Длина Имени организации должно быть не меньше 3 символов.");
                tbName.Focus();
            }
            else if (tbPatronymic.Text.Length < 3)
            {
                MessageBox.Show("Длина Отчества должно быть не меньше 3 символов.");
                tbPatronymic.Focus();
            }
            else
            {
                try
                {
                    employer.LastNameEmployer = tbLastName.Text;
                    employer.NameEmployer = tbName.Text;
                    employer.PatronymicEmployer = tbPatronymic.Text;
                //    employer.Industry = tbInd.Text;
                    employer.AddressEmployer = tbAdress.Text;
                    employer.Phone = Convert.ToInt32(tbPhone.Text);
                //    employer.FullNameEmployers = tbContract.Text;
                    
                }
                catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }

                this.DialogResult = true;
            }
        }
    }
    
}
