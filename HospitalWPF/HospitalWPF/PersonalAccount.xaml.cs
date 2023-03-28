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
using System.Data.SqlClient;
using System.Data;

namespace HospitalWPF
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Window
    {
        DataBase database = new DataBase();
        public PersonalAccount()
        {
            InitializeComponent();
            var b = EntranceCabinet.i;
            textBoxName.IsEnabled = false;
            textBoxFullName.IsEnabled = false;
            textBoxPatronymic.IsEnabled = false;
            textBoxAge.IsEnabled = false;
            textBoxGender.IsEnabled = false;
            TextBoxSave.IsEnabled = false;
                
            //нужно вносить заранее что-то сюда, null не подойдёт.
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            int age = 0;
            string sql = $"Update users set name ='',f_name ='',o_name ='', age = '{age}', gender = '' where id ='{b}'";
            //string querystring = $"select  from users name = '{textBoxName}' and f_name = '{textBoxFullName}' and o_name = '{textBoxPatronymic}' and age = '{textBoxAge}'  and age = '{ textBoxGender}' ";
            SqlCommand command = new SqlCommand(sql, database.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            
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


            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataBase dataBase = new DataBase();
            //DataTable table = new DataTable();
            ////string querystring = $"insert into personal_account(name) values ('d')";
            //SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            //adapter.SelectCommand = command;
            //string querystring = $"insert into users(login, password) values ('{email}', '{pass}')";
            //command = new SqlCommand(querystring, dataBase.GetConnection());
            //adapter.SelectCommand = command;
            //adapter.Fill(table);
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
