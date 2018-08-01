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
using Agency1.BusinessLayer.Interfaces;
using Agency1.BusinessLayer.Models;
using Agency1.BusinessLayer.Services;
using System.Collections.ObjectModel;
using Agency1.DataLayer.Entities;
using Agency1.DataLayer.Interfases;
using Agency1.DataLayer.Repositories;
using AutoMapper;


namespace Agency1
{
    /// <summary>
    /// Interaction logic for AddPosition.xaml
    /// </summary>
    public partial class AddPosition : Window
    {
   //     ObservableCollection<PositionViewModels> positionsModel;
        PositionViewModels positions;
     //   IPositionService positionService;

        public AddPosition()
        {
            InitializeComponent();

        }
        public AddPosition(PositionViewModels position) : this()
        {
            this.positions = position;
            this.DataContext = position;
        }
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbPosition.Text.Length < 3)
            {
                MessageBox.Show("Длина названия должности должно быть не меньше 3 символов.");

            }
            else
            {
                try
                {
                    positions.PositionName = tbPosition.Text;
                 //   bool a = false;
                //    positions.PositionName = tbPosition.Text;
                     
                    // if (tbPosition.Text == null)
                    // {
                    //     MessageBox.Show("Поле должности не может быть пустым!!!!");

                    // }
                    //else                 
                    
                       
                    //string s = tbPosition.Text;
                    //MessageBox.Show("s");
 //                       foreach (PositionViewModels position in positionService.GetAll())
 //                       {
 //                          MessageBox.Show("we too1");
 ////                          if(position==tbPosition.Text)
 ////                           {
 
 ////                           }                                                                                   
 //                           /*EmployersViewModels employer in employerService.GetAll())
 //                                           {
 //                                               employersModel.Add(employer);*/
 //                       }                        
                }
                catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }

                this.DialogResult = true;
            }
        }
    }
}
