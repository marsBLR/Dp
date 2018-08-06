using Agency1.window;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agency1.BusinessLayer.Interfaces;
using Agency1.BusinessLayer.Models;
using Agency1.BusinessLayer.Services;
using System.Collections.ObjectModel;
using Agency1.DataLayer.Entities;
using Agency1.DataLayer.Interfases;
using Agency1.DataLayer.Repositories;
using AutoMapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using NLog;

//using System.Linq;

namespace Agency1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IUnitOfWork dataBase;
        ObservableCollection<AgentViewModels> agentsModel;
        ObservableCollection<ApplicantViewModels> applicantsModel;
        ObservableCollection<EmployerViewModels> employersModel;
        ObservableCollection<PositionViewModels> positionsModel;
        ObservableCollection<VacancieViewModels> vacanciesModel;
        ObservableCollection<DealViewModels> dealsModel;
        ObservableCollection<RoleViewModels> rolesModel;
        ObservableCollection<ContractViewModel> contractModel;
        ObservableCollection<PaymentAccountViewModel> paymentAccountModel;

        VacancieViewModels v = new VacancieViewModels();
        ApplicantViewModels appli = new ApplicantViewModels();

        IAgentService agentService;
        IApplicantService applicantService;
        IEmployerService employerService;
        IPositionService positionService;
        IVacancieService vacancyService;
        IDealService dealService;
        IRoleService roleService;
        IContractService contractService;
        IPaymentAccountService paymentAccountService;

        Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
             InitializeComponent();         
        }
        public MainWindow(AgentViewModels agentUser) : this()
        {            
            dataBase = new EntityUnitOfWork("AgencyDB");

            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Agent, AgentViewModels>();
                cfg.CreateMap<Applicant, ApplicantViewModels>();//;.PreserveReferences();                
                cfg.CreateMap<Employer, EmployerViewModels>();
                cfg.CreateMap<Position, PositionViewModels>();
                cfg.CreateMap<Vacancie, VacancieViewModels>();
                cfg.CreateMap<Role, RoleViewModels>();
                cfg.CreateMap<Deal, DealViewModels>();
                cfg.CreateMap<Contract, ContractViewModel>();
                cfg.CreateMap<PaymentAccount, PaymentAccountViewModel>();
            });

            agentService = new AgentService(dataBase);
            applicantService = new ApplicantService(dataBase);
            employerService = new EmployerService(dataBase);
            positionService = new PositionService(dataBase);
            vacancyService = new VacancieService(dataBase);
            dealService = new DealService(dataBase);
            roleService = new RoleService(dataBase);
            contractService = new ContractService(dataBase);
            paymentAccountService = new PaymentAccountService(dataBase);

            applicantsModel = applicantService.GetAll();
            employersModel = employerService.GetAll();
            rolesModel = roleService.GetAll();
            agentsModel = agentService.GetAll();
            positionsModel = positionService.GetAll();
            vacanciesModel = vacancyService.GetAll();
            dealsModel = dealService.GetAll();
            contractModel = contractService.GetAll();
            paymentAccountModel = paymentAccountService.GetAll();

            dGridApplicants.DataContext = applicantsModel.Where(p => (p.Deals.Count < 1) & p.AgentId ==  agentUser.AgentId);
            dGridEmployer.DataContext = employersModel;
            dGridPosition.DataContext = positionsModel;
            dGridAgent.DataContext = agentsModel;
            dGridVacancies.DataContext = vacanciesModel;
            dGridDeals.DataContext = dealsModel.Where(p => p.Applicant.AgentId == agentUser.AgentId); ;
            dGridContract.DataContext = contractModel.Where(p => p.AgentId == agentUser.AgentId);
            dGridPaymentAccount.DataContext = paymentAccountModel.Where(p => p.Contracts.AgentId == agentUser.AgentId);

            dGridReportWoman.DataContext = vacanciesModel.Where(p => p.Gender == Gender.женщина || p.Gender == Gender.любой);
            dGridReportMan.DataContext = vacanciesModel.Where(p => p.Gender == Gender.мужчина || p.Gender == Gender.любой);
            cbPositions.ItemsSource = positionsModel;
            if(agentUser.RoleId == 3)
            {
                tabAgents.Visibility = Visibility.Collapsed;
            }

            logger.Info("Application started");
        }
        private void ResetCollection(string type)
        {
            if (type == "EmployerViewModel")
            {
                employersModel.Clear();
                foreach (EmployerViewModels employer in employerService.GetAll())
                {
                    employersModel.Add(employer);
                }
            }
            if (type == "AgentsViewModel")
            {
                agentsModel.Clear();
                foreach (AgentViewModels agent in agentService.GetAll())
                {
                    agentsModel.Add(agent);
                }
            }
            if (type == "PositionViewModel")
            {
                positionsModel.Clear();
                foreach (PositionViewModels position in positionService.GetAll())
                {
                    positionsModel.Add(position);
                }
            }
            if (type == "ApplicantViewModel")
            {
                applicantsModel.Clear();
                foreach(ApplicantViewModels applicant in applicantService.GetAll())
                {
                    applicantsModel.Add(applicant);
                }
            }
            if (type == "VacanciesViewModel")
            {
                vacanciesModel.Clear();
                foreach (VacancieViewModels vac in vacancyService.GetAll())
                {
                    vacanciesModel.Add(vac);
                }
            }
           if (type == "DealsViewModel")
            {
                dealsModel.Clear();
                foreach(DealViewModels del in dealService.GetAll() )
                {
                    dealsModel.Add(del);
                }
            }
        }
        private void ResetCollectionWithFilters(string type)
        {
            if (type == "EmployerViewModel")
            {
                employersModel.Clear();
                foreach (PositionViewModels position in positionService.GetAll())
                {
                    positionsModel.Add(position);
                }
            }
            else ResetCollection("EmployerViewModel");
            if (type == "PositionsViewModel")
            {
                positionsModel.Clear();
                foreach (PositionViewModels position in positionService.GetAll())
                {
                    positionsModel.Add(position);
                }
            }
            else ResetCollection("PositionsViewModel");
            if (type == "AgentsViewModel")
            {
                agentsModel.Clear();
                foreach (AgentViewModels agent in agentService.GetAll())
                {
                    agentsModel.Add(agent);
                }
            }
            else ResetCollection("AgentsViewModel");
            if (type == "VacanciesViewModel")
            {
                vacanciesModel.Clear();
                foreach (VacancieViewModels vac in vacancyService.GetAll())
                {
                    vacanciesModel.Add(vac);
                }
            }
            else ResetCollection("VacanciesViewModel");
           
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

            About about = new About();

            about.Owner = this;
            about.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }     

        private void btnAddEmplouer_Click(object sender, RoutedEventArgs e)
        {
            EmployerViewModels employerModel = new EmployerViewModels();
            AddEmployer ae = new AddEmployer(employerModel);//создаем окно
            ae.Title = "Добавить Работодателя";
            ae.Owner = this;//устанавливаем собственника окна
            var result = ae.ShowDialog();
            if (result == true)
            {
                employerService.CreateEmployer(employerModel);
                ResetCollection("EmployerViewModel");
                int Index = employersModel.Count - 1;
                dGridEmployer.SelectedIndex = Index;
                ae.Close();
            }
           
        }

        private void btEditEmployer_Click(object sender, RoutedEventArgs e)
        {
            EmployerViewModels employerModel = dGridEmployer.SelectedItem as EmployerViewModels;
            int Index = dGridEmployer.SelectedIndex;
            var ae = new EditEmployer(employerModel);
            ae.Title = "Изменить запсиь";
            ae.Owner = this;
            var result = ae.ShowDialog();
            if (result == true)
            {
                employerService.UpdateEmployer(employerModel);
                ResetCollection("EmployerViewModel");
                ResetCollection("VacanciesViewModel");
                ae.Close();
            }          
        }

        private void btDeleteEmployer_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                var employerModel = (EmployerViewModels)dGridEmployer.SelectedItem;
                employerService.DeleteEmployer(employerModel.EmployerId);
                ResetCollectionWithFilters("EmployersViewModel");//нужно ли reset делать для др viewmodel
                ResetCollection("VacanciesViewModel");
                dGridEmployer.SelectedIndex = 0;
            }
        }



        private void addPosition_Click(object sender, RoutedEventArgs e)
        {
            PositionViewModels positionModel = dGridPosition.SelectedItem as PositionViewModels;
            int Index = dGridPosition.SelectedIndex;
            var ae = new AddPosition(positionModel);
            ae.Title = "Добавить должность";
            ae.Owner = this;
            var result = ae.ShowDialog();

            if (result == true)
            {
                positionService.CreatePosition(positionModel);
                ResetCollection("PositionViewModel");
                int index = positionsModel.Count - 1;
                dGridPosition.SelectedItem = index;
                ae.Close();
            }
        }

        private void editPosition_Click(object sender, RoutedEventArgs e)
        {
            PositionViewModels positionModel = dGridPosition.SelectedItem as PositionViewModels;
            // EmployerViewModels employerModel = dGridEmployer.SelectedItem as EmployerViewModels;
            int Index = dGridPosition.SelectedIndex;
            var ae = new EditPosition(positionModel);
            ae.Title = "Изменить запсиь";
            ae.Owner = this;
            var result = ae.ShowDialog();
            if (result == true)
            {
                positionService.UpdatePosition(positionModel);
                ResetCollection("PosotionsViewModel");
                ResetCollection("VacanciesViewModel");
                ResetCollection("ApplicantViewModel");
                ae.Close();
            }
        }

        private void deletePosition_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var positionModel = (PositionViewModels)dGridPosition.SelectedItem;
                positionService.DeletePosition(positionModel.PositionId);
                ResetCollectionWithFilters("PositionsViewModel");//нужно ли reset делать для др viewmodel
                dGridPosition.SelectedIndex = 0;
            }
        }

        private void btnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            AgentViewModels agentModel = new AgentViewModels();
            AddAgent a = new AddAgent(agentModel);           //создаем окно
            a.Title = "Добавить Агента";
            a.Owner = this;//устанавливаем собственника окна
            var result = a.ShowDialog();
            if (result == true)
            {
                agentService.CreateAgent(agentModel);
                ResetCollection("AgentsViewModel");
                int Index = agentsModel.Count - 1;
                dGridAgent.SelectedIndex = Index;
                a.Close();
            }
        }
        //Edit Agent
        private void btEditAgent_Click(object sender, RoutedEventArgs e)
        {
            /* ApplicantViewModels applicantModel = dGridApplicants.SelectedItem as ApplicantViewModels;
            int Index = dGridApplicants.SelectedIndex;
            var ap = new EditApplicant(applicantModel, positionsModel, agentsModel);
            ap.Title = "Изменить запись";
            ap.Owner = this;
            var result = ap.ShowDialog();
            if (result == true)
            {
                applicantService.UpdateApplicant(applicantModel);
                ResetCollection("ApplicantViewModel");
                ap.Close();
            }           */
            AgentViewModels agentModel = dGridAgent.SelectedItem as AgentViewModels;
            int Index = dGridAgent.SelectedIndex;
            var ag = new EditAgent(agentModel);
            ag.Title = "Изменить запись";
            ag.Owner = this;
            var result = ag.ShowDialog();
            if (result == true)
            {
                agentService.UpdateAgent(agentModel);
                ResetCollection("AgentViewModel");
                ag.Close();
            }
        }

        private void btDeleteAgent_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var agentModel = (AgentViewModels)dGridAgent.SelectedItem;
                agentService.DeleteAgent(agentModel.AgentId);
                ResetCollectionWithFilters("AgentsViewModel");//нужно ли reset делать для др viewmodel
                dGridAgent.SelectedIndex = 0;
            }
        }
     
        //закрытие вакансии
        private void Button_Close_Vacancy_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Сделка завершена?", "Закрытие сделки", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var dealModel = (DealViewModels)dGridDeals.SelectedItem;
                vacancyService.CloseVacancy(dealModel);           
                ResetCollection("VacanciesViewModel");
                ResetCollection("DealsViewModel");             
                dGridPosition.SelectedIndex = 0;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {           
            var empl = (EmployerViewModels)dGridEmployer.SelectedItem;          
            var vacancies = empl.Vacancies;
            dGridVacancies.DataContext = vacancies;     
            tabControl.SelectedItem = TabVacancie;          
        }

        private void btAddApplicant_Click(object sender, RoutedEventArgs e)
        {
            ApplicantViewModels applicantModel = new ApplicantViewModels();         
            AddApplicant aa = new AddApplicant(applicantModel,positionsModel,agentsModel);
            aa.Title = "Добавление Соискателя";
            aa.Owner = this;
            var result = aa.ShowDialog();
            if(result == true)
            {
                applicantService.CreateApplicant(applicantModel);
                ResetCollection("ApplicantViewModel");
                ResetCollection("AgentsViewModel");
                int Index = applicantsModel.Count - 1;
                dGridApplicants.SelectedIndex = Index;
                aa.Close();
               
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void AddVacancieEmployer_Click(object sender, RoutedEventArgs e)
        {
            VacancieViewModels vacancieModel = new VacancieViewModels();
            var emplm = (EmployerViewModels)dGridEmployer.SelectedItem;
            AddVacancie av = new AddVacancie(vacancieModel, positionsModel,emplm);    
            av.Title = "Добавление вакансии";
            av.Owner = this;
            var result = av.ShowDialog();
            if (result == true)
            {
                var empl = (EmployerViewModels)dGridEmployer.SelectedItem;
                employerService.AddVacancyToEmployer(empl.EmployerId, vacancieModel);
                int Index = employersModel.IndexOf(empl);
                ResetCollection("VacanciesViewModel");
                ResetCollection("EmployerViewModel");
                dGridEmployer.SelectedIndex = Index;
                //av.Close();
            }
        }
        //отчет в виде таблицы подходящие applicants на vacancie
        private void Button_click_report_vacancie_applicant(object sender, RoutedEventArgs e)
        {
            var appl = (ApplicantViewModels)dGridApplicants.SelectedItem;
            var newmodel = vacanciesModel.Where(p => p.PositionId == appl.PositionId).ToList();
            dGridVacancies_applicant.DataContext = newmodel;
            tabControl.SelectedItem = TabReport;
            tabControl1.SelectedItem = tab_applicant_to_Position;      
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        //агенты -список соискателей
        private void View_Applicant_Click_3(object sender, RoutedEventArgs e)
        {
            ResetCollection("ApplicantViewModel");
            var aplicants_Agent = (AgentViewModels)dGridAgent.SelectedItem;
            
            var apllicants = aplicants_Agent.Applicants;

            dGridApplicants.DataContext = apllicants;
            tabControl.SelectedItem = TabApplicants;
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
        //обновление - показ всех вакансии в dgridvacancies
        private void Button_ALL_Vacancies_Click_4(object sender, RoutedEventArgs e)
        {
            ResetCollection("VacanciesViewModel");
            dGridVacancies.DataContext = vacanciesModel;
        }

        //подходящие соискатель на вакансию
        private void Button_applicant_to_vacanvie_Click(object sender, RoutedEventArgs e)
        {
            //var app_vacancie = (VacancieViewModels)dGridVacancies.SelectedItem;
            //var app = app_vacancie.
            /*  var aplicants_Agent = (AgentViewModels)dGridAgent.SelectedItem;
            var apllicants = aplicants_Agent.Applicants;
            dGridApplicants.DataContext = apllicants;
            tabControl.SelectedItem = TabApplicants;*/
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
        //подходящие соискатели на вакансию отчет
        private void Button_Click_Report_Applicant(object sender, RoutedEventArgs e)
        {
            /* var appl = (ApplicantViewModels)dGridApplicants.SelectedItem;
            var newmodel = vacanciesModel.Where(p => p.PositionId == appl.PositionId).ToList();

            //var newmodel = vacanciesModel.Where(p => p.PositionId == positionCombobox.PositionId).ToList();
           
            dGridVacancies_applicant.DataContext = newmodel;
            tabControl.SelectedItem = TabReport;
            tabControl1.SelectedItem = tab_applicant_to_Position;*/
            var vacancie = (VacancieViewModels)dGridVacancies.SelectedItem;
            var newmodel = applicantsModel.Where(p => p.PositionId == vacancie.PositionId).ToList();
            dGridAp.DataContext = newmodel;
            tabControl.SelectedItem = TabReport;
            tabControl1.SelectedItem = TabVacancieApplicant;


        }
        //кнопка поиск соискателей на должность вкладка отчет
        private void bt_Search_applicant_vacancie_Click(object sender, RoutedEventArgs e)
        {        
            var positionCombobox = (PositionViewModels)cbPositions.SelectedItem;
            var newmodel = vacanciesModel.Where(p => p.PositionId == positionCombobox.PositionId & p.OpenVacancy == OpenVacancy.да).ToList();           
            if((newmodel.Count < 1) )
            {
                MessageBox.Show("Нет открытых вакансий на эту должность");
                
            }else
            {
               dGridReportPosition.DataContext = newmodel;
            }
        }

        private void cbPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
           if (cbPositions.SelectedIndex > -1)
            {
                bt_Search_applicant_vacancie.IsEnabled = true;
            }
        }
        //button reset all applicant
        private void Button_ALL_Applicants_Click_4(object sender, RoutedEventArgs e)
        {
            ResetCollection("ApplicantViewModel");
            dGridApplicants.DataContext = applicantsModel.Where(p => p.Deals.Count < 1);
            dGridApplicants.SelectedIndex = 1;
        }

        private void dGridReportWoman_Loaded(object sender, RoutedEventArgs e)
        {
         
        }

        //form vacancie applicant go deal
        private void Button_Click_Form_Vacancie(object sender, RoutedEventArgs e)
        {
            EmployerViewModels emp = new EmployerViewModels();
            DealViewModels deal = new DealViewModels();
       //     VacancieViewModels vacancieModel = new VacancieViewModels();
            AgentViewModels ag = new AgentViewModels();
            var applic = (ApplicantViewModels)dGridApplicants.SelectedItem;
            
            FormVacancie fv = new FormVacancie(applic,vacanciesModel, emp, deal/*, ag*/);
            fv.Title = "Подходящие вакансии(форма)";
            fv.Owner = this;
            var result = fv.ShowDialog();
            var vac = fv.vacancie;
            if (result == true)
            {
                /*var empl = (EmployerViewModels)dGridEmployer.SelectedItem;
                employerService.AddVacancyToEmployer(empl.EmployerId, vacancieModel);
                int Index = employersModel.IndexOf(empl);
                ResetCollection("VacanciesViewModel");
                ResetCollection("EmployerViewModel");
                dGridEmployer.SelectedIndex = Index;*/
                var deall = (DealViewModels)dGridDeals.SelectedItem;
                applicantService.AddDeal(applic,deal,vac);
                int Index = dealsModel.IndexOf(deall);
                ResetCollection("DealsViewModel");
                dGridDeals.SelectedIndex = Index;
            } 
        }

        private void dGridDeals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dGridDeals_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            if (dGridDeals.SelectedIndex > -1)
            {
                var d =(DealViewModels)dGridDeals.SelectedItem;
                
                
                if ((d.Paid == Paid.да))
                {

                }else
                {
                 CloseVacancie.IsEnabled = true;
                }
                
            }
        }

        private void agency_wnd_Closed(object sender, EventArgs e)
        {
            logger.Info("Application finished");
        }
        //Info Applicant
        private void bt_Info_Applicant_Click(object sender, RoutedEventArgs e)
        {
            ApplicantViewModels applicantModel = dGridApplicants.SelectedItem as ApplicantViewModels;
            int Index = dGridApplicants.SelectedIndex;
            var a = new ResumeApplicant(applicantModel);
            a.Title = "Резюме";
            a.Owner = this;
            var result = a.ShowDialog();
            if (result == true)
            {
                a.Close();
            }
        }


        //Edit applicat
        private void bt_Edit_Applicant_Click(object sender, RoutedEventArgs e)
        {
            ApplicantViewModels applicantModel = dGridApplicants.SelectedItem as ApplicantViewModels;
            int Index = dGridApplicants.SelectedIndex;
            var ap = new EditApplicant(applicantModel, positionsModel, agentsModel);
            ap.Title = "Изменить запись";
            ap.Owner = this;
            var result = ap.ShowDialog();
            if (result == true)
            {
                applicantService.UpdateApplicant(applicantModel);
                ResetCollection("ApplicantViewModel");
                ap.Close();
            }           
        }
        //Print Info Applicant
        private void bt_Print_Info_Applicant_Click(object sender, RoutedEventArgs e)
        {

        }
        //delete applicant
        private void btDeleteApplicant_Click(object sender, RoutedEventArgs e)
        {          
            var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                var applicantModel = (ApplicantViewModels)dGridApplicants.SelectedItem;
                applicantService.DeleteApplicant(applicantModel.ApplicantId);               
                ResetCollection("ApplicantViewModel");
                dGridApplicants.SelectedIndex = 0;
            }
        }
    }
}

