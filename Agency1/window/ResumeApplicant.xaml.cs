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
    /// Interaction logic for ResumeApplicant.xaml
    /// </summary>
    public partial class ResumeApplicant : Window
    {
        ApplicantViewModels applicant;
        public ResumeApplicant()
        {
            InitializeComponent();
        }

        public ResumeApplicant(ApplicantViewModels applicant) : this()
        {
            //Binding binding = new Binding();

            //binding.ElementName = "last"; // элемент-источник
            //binding.Path = new PropertyPath("NameEmployer"); // свойство элемента-источника
            //tbName.SetBinding(TextBlock.TextProperty, binding); // установка привязки для элемента-приемника
            this.applicant = applicant;
            this.DataContext = applicant;
          //  lastNamePatrApplicant.Text = applicant.LastNameAp + " " + applicant.NameAp + " " + applicant.PatronymicAp;
            int age = DateTime.Now.Year - applicant.DateBirth.Year;
            if (DateTime.Now.Month < applicant.DateBirth.Month ||
                (DateTime.Now.Month == applicant.DateBirth.Month && DateTime.Now.Day < applicant.DateBirth.Day)) age--;
         //   ageAp.Text = Convert.ToString(age);

            /*DateTime birth = new DateTime(1920, 10, 15);
            int age = DateTime.Now.Year - birth.Year;
            if (DateTime.Now.Month < birth.Month ||
                (DateTime.Now.Month == birth.Month && DateTime.Now.Day < birth.Day)) age--;
            Console.WriteLine(age);
*/

        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_Print_Resume_Applicant_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
