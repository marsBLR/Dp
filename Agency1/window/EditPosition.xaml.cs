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
    /// Interaction logic for EditPosition.xaml
    /// </summary>
    public partial class EditPosition : Window
    {
        PositionViewModels position;
        public EditPosition()
        {
            InitializeComponent();
            Binding binding = new Binding();

            binding.ElementName = "namePosition"; // элемент-источник
            binding.Path = new PropertyPath("NamePosition"); // свойство элемента-источника
            tbNamePosition.SetBinding(TextBlock.TextProperty, binding); // установка привязки для элемента-приемника
        }
        public EditPosition(PositionViewModels position) : this()
        {
            this.position = position;


            this.DataContext = position;
        }
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbNamePosition.Text.Length < 3)
            {
                MessageBox.Show("Длина названия организации должно быть не меньше 3 символов.");

            }          
            else
            {
                try
                {
                    position.PositionName = tbNamePosition.Text;
                    

                }
                catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }

                this.DialogResult = true;
            }
        }
    }
}
