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
    /// Interaction logic for AddApplicant.xaml
    /// </summary>
    public partial class AddApplicant : Window
    {
        ApplicantViewModels applicant;
        public AddApplicant()
        {
            InitializeComponent();
            cbGender.Items.Add(Gender.женщина);
            cbGender.Items.Add(Gender.мужчина);
            cbEducation.Items.Add(Education.без_образования);
            cbEducation.Items.Add(Education.высшее);
            cbEducation.Items.Add(Education.средне_специальное);
            cbEducation.Items.Add(Education.среднее);
            cbForeignLanguage.Items.Add(ForeignLanguage.английский);
            cbForeignLanguage.Items.Add(ForeignLanguage.французский);
            cbForeignLanguage.Items.Add(ForeignLanguage.немецкий);
            cbForeignLanguage.Items.Add(ForeignLanguage.нет);

        }
        public AddApplicant(ApplicantViewModels applicant, ObservableCollection<PositionViewModels> position, ObservableCollection<AgentViewModels> agent) : this()
        {
            this.applicant = applicant;
            cbPosition.ItemsSource = position;
            cbAgent.ItemsSource = agent;
            this.DataContext = applicant;
        }
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbLastNameAp.Text.Length < 3)
            {
                MessageBox.Show("Длина Фамилия должно быть не меньше 3 символов.");
            }
            else if (tbNameAp.Text.Length < 3)
            {
                MessageBox.Show("Длина Имени должно быть не меньше 3 символов.");
            }
            else if (tbPatronymicAp.Text.Length < 5)
            {
                MessageBox.Show("Длина Отчества должно быть не меньше 5 символов");
            }
            else
            {
                try
                {
                    applicant.LastNameAp = tbLastNameAp.Text;
                    applicant.NameAp = tbNameAp.Text;
                    applicant.PatronymicAp = tbPatronymicAp.Text;
                    applicant.DateBirth = Convert.ToDateTime(DatePickerDateBirth.Text);
                    applicant.Gender = (Gender)cbGender.SelectedItem;
                    applicant.Education = (Education)cbEducation.SelectedItem;
                    applicant.ForeignLanguage = (ForeignLanguage)cbForeignLanguage.SelectedItem;
                    applicant.EstimatedSalary = Convert.ToInt32(tbEstimatedSalary.Text);
                    applicant.OtherInformation = tbOtherInformation.Text;
                    //applicant.DateFilling = (DateTime)tbDateFilling.;
                    applicant.DateFilling = Convert.ToDateTime(DatePickerDateFilling.Text);
                    var position = cbPosition.SelectedItem as PositionViewModels;
                    var agent = cbAgent.SelectedItem as AgentViewModels;                  
                    applicant.PositionId = position.PositionId;
                    applicant.AgentId = agent.AgentId;
                    
                }
                catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }

                this.DialogResult = true;
            }
        }
    }
}