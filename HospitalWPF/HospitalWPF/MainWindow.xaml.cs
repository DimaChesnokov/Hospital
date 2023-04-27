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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace HospitalWPF
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int dd;
        DataBase database = new DataBase();
        
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
       

        //Регистрация
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String pass = passBox.Password.Trim();
            String email = textBoxEmail.Text.Trim().ToLower();

            
             if (pass.Length < 4)
            {
                passBox.ToolTip = "Ошибка!";
                passBox.Background = Brushes.Red;
            }
            else if (email.Length < 4)
            {
                textBoxEmail.ToolTip = "Ошибка!";
                textBoxEmail.Background = Brushes.Red;
            }

            else
            {
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
            }
            

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            dataBase.oppenConnection(); //Подключение к БД
            string querystring = ""; 
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            querystring = $"select count(id) from users where login = '{email}'"; // SQL - запрос
            command = new SqlCommand(querystring, dataBase.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();



            if (count > 0)
                MessageBox.Show("Такой аккаунт уже существет в системе. Придумайте другой логин!", "Внимание!");
            else
            {
                querystring = $"insert into users(login, password,name,f_name,o_name,age,gender) values ('{email}', '{pass}','','','','{0}','')";
                command = new SqlCommand(querystring, dataBase.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);


                MessageBox.Show("Вы успешно зарегистрировались в системе!", "Подверждение");
                EntranceCabinet entranceCabinet = new EntranceCabinet();
                entranceCabinet.Show();
                Close();
            }
        }

        //Переход в окно регистрации
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            EntranceCabinet entranceCabinet = new EntranceCabinet();
            entranceCabinet.Show();
            Close();
        }
    }
}
