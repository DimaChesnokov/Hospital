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
    /// Логика взаимодействия для MedDentist.xaml
    /// </summary>
    public partial class MedDentist : Window
    {
        public MedDentist()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PersonalAccount personalAccount = new PersonalAccount();
            personalAccount.Show();
            Close();
        }
    }
}
