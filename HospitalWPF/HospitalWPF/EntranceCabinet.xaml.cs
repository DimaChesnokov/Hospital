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
        //ApplicationContext db;

        DataBase dataBase = new DataBase();
        public  static int i;

        
        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
            String login = textBoxLogin.Text.Trim();
            String pass = passBox.Password.Trim();
           

            if (login.Length < 3)
            {
                textBoxLogin.ToolTip = "Ошибка!";
                textBoxLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 3)
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

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                dataBase.oppenConnection();

                string querystring = $"select id from users where login = '{login}' and password = '{pass}' ";
                SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                var u = reader.GetName(0);
                reader.Read();
                i = reader.GetInt32(0);
                

                
                //command = new SqlCommand(querystring, dataBase.GetConnection());
                //adapter.SelectCommand = command;
                //reader.Close();
                //adapter.Fill(table);
                MessageBox.Show("Успешный вход");
                PersonalAccount personalAccount = new PersonalAccount();
                personalAccount.Show();
                Close();

                //if (table.Rows.Count == 1)
                //{
                //    MessageBox.Show("Успешный вход");

                //    PersonalAccount personalAccount = new PersonalAccount();
                //    personalAccount.Show();
                //    Close();
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

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
