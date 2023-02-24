using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для EntranceCabinet.xaml
    /// </summary>
    public partial class EntranceCabinet : Window
    {
        public EntranceCabinet()
        {
            InitializeComponent();
           
        }
        ApplicationContext db;

        DataBase dataBase = new DataBase();
        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
            String login = textBoxLogin.Text.Trim();
            String pass = passBox.Password.Trim();
           

            if (login.Length < 3)
            {
                textBoxLogin.ToolTip = "Ошибка!";
                textBoxLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 4)
            {
                passBox.ToolTip = "Ошибка!";
                passBox.Background = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;


                //SqlDataAdapter adapter = new SqlDataAdapter();
                //DataTable table = new DataTable();
                //string querystring = $"select id_user, login_user, password_user from register where login_user = '{login}' and password_user = '{pass}' ";
                //SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
                //adapter.SelectCommand = command;
                //adapter.Fill(table);
                
                //if(table.Rows.Count == 1)
                //{
                //    MessageBox.Show("Успешный вход");

                //    PersonalAccount personalAccount = new PersonalAccount();
                //    //personalAccount.Show();
                //    //this.Hide();
                //    //personalAccount.ShowDialog();
                //    //this.Show();
                //}
                //else
                //{
                //    MessageBox.Show("Такого пользователя не существует");
                //}

               
                User EntryUser = null;


                //using (ApplicationContext db = new ApplicationContext())
                //{
                //    EntryUser = db.Users.Where(entry => entry.login == login && entry.pass == pass).FirstOrDefault();
                //}
                //if (EntryUser != null)
                //    MessageBox.Show("Успешный вход");
                //else
                //{
                //    MessageBox.Show("Неправильно введены данные или такого пользователя не существует");
                //}
            }
        }
    }
}
