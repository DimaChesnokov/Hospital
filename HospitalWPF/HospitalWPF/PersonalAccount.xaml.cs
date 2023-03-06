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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Window
    {
        public PersonalAccount()
        {
            InitializeComponent();
            textBoxName.IsEnabled = false;
            textBoxFullName.IsEnabled = false;
            textBoxPatronymic.IsEnabled = false;
            textBoxAge.IsEnabled = false;
            textBoxGender.IsEnabled = false;
            TextBoxSave.IsEnabled = false;
        }

        private void Button_Click_Reception(object sender, RoutedEventArgs e)
        {
            Reception reception = new Reception();
            reception.Show();
            Close();
            
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            textBoxName.IsEnabled = true;
            textBoxFullName.IsEnabled = true;
            textBoxPatronymic.IsEnabled = true;
            textBoxAge.IsEnabled = true;
            textBoxGender.IsEnabled = true;
            TextBoxSave.IsEnabled = true;
            TextBoxEdit.IsEnabled = false;
        }

        private void TextBoxSave_Click(object sender, RoutedEventArgs e)
        {
            textBoxName.IsEnabled = false;
            textBoxFullName.IsEnabled = false;
            textBoxPatronymic.IsEnabled = false;
            textBoxAge.IsEnabled = false;
            textBoxGender.IsEnabled = false;
            TextBoxSave.IsEnabled = false;
            TextBoxEdit.IsEnabled = true;
        }

        private void Button_Click_Doctor(object sender, RoutedEventArgs e)
        {
            MedAccount medAccount = new MedAccount();
            medAccount.Show();
            Close();
        }
    }
}
