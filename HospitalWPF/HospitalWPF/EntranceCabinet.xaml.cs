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
            WindowState = WindowState.Maximized;
        }
        //ApplicationContext db;

        DataBase dataBase = new DataBase();
        public static int i;

        
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

                string querystring = $"select count(id) from users where login = '{login}' and password = '{pass}'";
                SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                //var u = reader.GetName(0);
                reader.Read();
                int count = reader.GetInt32(0);
                reader.Close();
                if (count !=0)
                {
                    querystring = $"select id from users where login = '{login}' and password = '{pass}' ";
                    command = new SqlCommand(querystring, dataBase.GetConnection());
                    reader = command.ExecuteReader();
                    var u = reader.GetName(0);
                    reader.Read();
                    MessageBox.Show("Вы успешно вошли в аккаунт!", "Подтверждение");
                    i = reader.GetInt32(0);
                    PersonalAccount personalAccount = new PersonalAccount();
                    personalAccount.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка");
                }
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
