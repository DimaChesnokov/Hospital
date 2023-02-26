using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalWPF
{
    /// <summary>
    /// Логика взаимодействия для Reception.xaml
    /// </summary>
    public partial class Reception : Window
    {
        public Reception()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private List<string> doctors = new List<string> { "Терапевт", "Хирург", "Стоматолог", "Оториноларинголог" };
        private List<string> procedures = new List<string> { "ЭКГ", "Флюрография", "Анализ крови", "Анализ мочи" };

        private void ComboBoxSelectService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxSelectService.SelectedIndex == 0)
            {
                LabelService.Content = "Врач:";
                ComboBoxSelection.ItemsSource = doctors;
            }
            else
            {
                LabelService.Content = "Процедуры:";
                ComboBoxSelection.ItemsSource = procedures;
            }
        }
    }
}
