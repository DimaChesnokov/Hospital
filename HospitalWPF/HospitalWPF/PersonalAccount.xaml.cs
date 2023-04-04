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
        public int b = EntranceCabinet.i;
        public PersonalAccount()
        {
            InitializeComponent();
            
            textBoxName.IsEnabled = false;
            textBoxFullName.IsEnabled = false;
            textBoxPatronymic.IsEnabled = false;
            textBoxAge.IsEnabled = false;
            textBoxGender.IsEnabled = false;
            TextBoxSave.IsEnabled = false;
                
            //нужно вносить заранее что-то сюда, null не подойдёт.
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            database.oppenConnection();
            int age = 0;
            //string sql = $"Update users set name ='',f_name ='',o_name ='', age = '{age}', gender = '' where id ='{b}'";
            //SqlCommand command = new SqlCommand(sql, database.GetConnection());
            //adapter.SelectCommand = command;
            //adapter.Fill(table);
            //Имя
            string sqlName = $"SELECT name FROM users where id ='{b}'";
            SqlCommand commandName = new SqlCommand(sqlName, database.GetConnection());
            SqlDataReader readerName = commandName.ExecuteReader();
            if (readerName.Read())
                textBoxName.Text = readerName.GetString(0);
            readerName.Close();

            string sqlFullName = $"SELECT f_name FROM users where id ='{b}'";
            SqlCommand commandFullName = new SqlCommand(sqlFullName, database.GetConnection());
            SqlDataReader readerFullName = commandFullName.ExecuteReader();
            if (readerFullName.Read())
                textBoxFullName.Text = readerFullName.GetString(0);
            readerFullName.Close();

            string sqlPatronymic = $"SELECT o_name FROM users where id ='{b}'";
            SqlCommand commandPatronymic = new SqlCommand(sqlPatronymic, database.GetConnection());
            SqlDataReader readerPatronymic = commandPatronymic.ExecuteReader();
            if (readerPatronymic.Read())
                textBoxPatronymic.Text = readerPatronymic.GetString(0);
            readerPatronymic.Close();


            string sqlAge = $"SELECT Age FROM users where id ='{b}'";
            SqlCommand commandAge = new SqlCommand(sqlAge, database.GetConnection());
            SqlDataReader readerAge = commandAge.ExecuteReader();
            if (readerAge.Read())
                textBoxAge.Text = Convert.ToString(readerAge.GetInt32(0));
            readerAge.Close();

            string sqlGender = $"SELECT gender FROM users where id ='{b}'";
            SqlCommand commandGender = new SqlCommand(sqlGender, database.GetConnection());
            SqlDataReader readerGender = commandGender.ExecuteReader();
            if (readerGender.Read())
                textBoxGender.Text = readerGender.GetString(0);
            readerGender.Close();


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
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            int age;
            if (textBoxAge.Text != "")
                age = Convert.ToInt32(textBoxAge.Text);
            else
                age = 0;
            string sql = $"Update users set name ='{textBoxName.Text}',f_name ='{textBoxFullName.Text}',o_name ='{textBoxPatronymic.Text}', age = '{age}', " +
                $"gender = '{textBoxGender.Text}' where id ='{b}'";
            SqlCommand command = new SqlCommand(sql, database.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            //textBoxName.Text = "";
        }

        private void Button_Click_Doctor(object sender, RoutedEventArgs e)
        {
            MedAccount medAccount = new MedAccount();
            medAccount.Show();
            Close();
        }
    }
}
