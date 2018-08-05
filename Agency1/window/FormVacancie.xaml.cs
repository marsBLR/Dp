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
using System.Collections.ObjectModel;
using AutoMapper;

namespace Agency1.window
{
    /// <summary>
    /// Interaction logic for FormVacancie.xaml
    /// </summary>
    public partial class FormVacancie : Window
    {
        ApplicantViewModels applicant;
        public VacancieViewModels vacancie;
        DealViewModels deal;
        EmployerViewModels employer;
     //   AgentViewModels agent;

        public FormVacancie()
        {
            
            InitializeComponent();
            
            //var vac = (VacancieViewModels)control.dGridVacancies.SelectedItem;
            //var newmodel = dGridVacancies1;
            //dGridVacancies1.DataContext = vacanciesModel.Where(p => p.PositionId == vac.PositionId).ToList();
        }
        public FormVacancie(ApplicantViewModels applicant, ObservableCollection<VacancieViewModels> vacancies, EmployerViewModels employer, DealViewModels deal/*, AgentViewModels agent*/) : this()
        {
            this.applicant = applicant;
            tbNameAppl.DataContext = this.applicant;
            tbapplicantIdInfo.DataContext = this.applicant;
            tbAgentApp.DataContext = this.applicant;
            dGridVacancies1.DataContext = vacancies.Where(p => p.PositionId == applicant.PositionId).ToList();
            this.deal = deal;
            //this.agent = agent;
            this.employer = employer;
            //                   fd.DataContext = this.applicant;
            this.DataContext = deal;
          
            
        }

        private void Button_click_report_vacancie_applicant(object sender, RoutedEventArgs e)
        {
            try
            {
                //MainWindow control = new MainWindow();          
                vacancie = dGridVacancies1.SelectedItem as VacancieViewModels;

                //deal.Vacancie.VacancieId = vacancieGrid.VacancieId;
                
             //   deal.Commission = Convert.ToInt32(tbCommision.Text);
                deal.DateCompilation = Convert.ToDateTime(DatePickerFromvac.Text);
                deal.Paid = Paid.нет;
                deal.DatePaid = Convert.ToDateTime(DatePickerFromReport.Text);
                deal.ApplicantId = applicant.ApplicantId;

             //   vacancie.Deal = deal;

            }
            catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }

            this.DialogResult = true;
        }

        private void tabControl2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void dGridVacancies1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dGridVacancies1.SelectedIndex > -1)
            {
                dealss.IsEnabled = true;
            }
            
        }
    }
}
