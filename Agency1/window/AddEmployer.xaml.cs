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
            if (tbName.Text.Length < 3)
            {
                MessageBox.Show("Длина названия организации должно быть не меньше 3 символов.");

            }
            else if (tbName.Text.Length < 3)
            {
                MessageBox.Show("Длина отрасли должно быть не меньше 3 символов.");

            }
            else
            {
                try
                {
                    employer.NameEmployer = tbName.Text;
                    employer.Industry = tbInd.Text;
                    employer.AddressEmployer = tbAdress.Text;
                    employer.Phone = Convert.ToInt32(tbPhone.Text);
                    employer.FullNameEmployers = tbContract.Text;
                    
                }
                catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }

                this.DialogResult = true;
            }
        }
    }
    
}
