using System;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AddVacancie.xaml
    /// </summary>
    public partial class AddVacancie : Window
    {
        VacancieViewModels vacancie;
        EmployerViewModels employer;
        public AddVacancie()
        {
            InitializeComponent();
            cbGender.Items.Add(Gender.женщина);
            cbGender.Items.Add(Gender.мужчина);
            cbGender.Items.Add(Gender.любой);
            cbEducation.Items.Add(Education.без_образования);
            cbEducation.Items.Add(Education.высшее);
            cbEducation.Items.Add(Education.средне_специальное);
            cbEducation.Items.Add(Education.среднее);
            cbLanguage.Items.Add(ForeignLanguage.английский);
            cbLanguage.Items.Add(ForeignLanguage.французский);
            cbLanguage.Items.Add(ForeignLanguage.немецкий);
            cbLanguage.Items.Add(ForeignLanguage.нет);
        }
        public AddVacancie(VacancieViewModels vacancie, ObservableCollection<PositionViewModels> position, EmployerViewModels employer) : this()
        {
            this.vacancie = vacancie;
            cbPosition.ItemsSource = position;
            this.employer = employer;
            tbemployerId.DataContext = this.employer;
            this.DataContext = vacancie;
        }
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var position = cbPosition.SelectedItem as PositionViewModels;
                vacancie.PositionId = position.PositionId;
                
                vacancie.Gender = (Gender)cbGender.SelectedItem;
                vacancie.Education = (Education)cbEducation.SelectedItem;
                vacancie.DrivingLicence = tbDriving.Text;
                vacancie.ForeignLanguage = (ForeignLanguage)cbLanguage.SelectedItem;
                vacancie.Salary = Convert.ToInt32(tbSalary.Text);
                vacancie.WorkingConditions = tbWorkingConditions.Text;
                vacancie.DateOpen = Convert.ToDateTime(DatePickerAddVacancie.Text);
                vacancie.OpenVacancy = OpenVacancy.да;
                //vacancie.Employer = employer;
                //vacancie.Employer.EmployerId = employer.EmployerId;
                //   var e = employer.EmployerId as EmployerViewModels;
                MessageBox.Show("добавлена вакансия");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }

            this.DialogResult = true;
        }
    }
}
