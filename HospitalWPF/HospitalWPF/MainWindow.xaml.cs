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

        //ApplicationContext db;
        DataBase database = new DataBase();
        
        public MainWindow()
        {
            InitializeComponent();
            //db = new ApplicationContext();
            //database.oppenConnection();


            //List<User> user = db.Users.ToList();
        }
       

        //Регистрация
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //String login = textBoxLogin.Text.Trim();
            String pass = passBox.Password.Trim();
            String email = textBoxEmail.Text.Trim().ToLower();
            //String age = textBoxAge.Text.Trim();

            
             if (pass.Length < 4)
            {
                passBox.ToolTip = "Ошибка!";
                passBox.Background = Brushes.Red;
            }
            else if (email.Length < 4 /*|| !email.Contains("@") || !email.Contains(".")*/)
            {
                textBoxEmail.ToolTip = "Ошибка!";
                textBoxEmail.Background = Brushes.Red;
            }
            //else if (Convert.ToInt32(age) <= 18)
            //{
            //    textBoxAge.ToolTip = "Ошибка!";
            //    textBoxAge.Background = Brushes.Red;
            //}
            else
            {
                //пустые поля 
                //textBoxLogin.ToolTip = "";
                //textBoxLogin.Background = Brushes.Transparent;



                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;



            }
            string f = "dimon";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();

            string querystring = ""; 
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
          
            querystring = $"insert into users(login, password,name,f_name,o_name,age,gender) values ('{email}', '{pass}','','','','{0}','')";
            command = new SqlCommand(querystring, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);    
            

            MessageBox.Show("УСПЕШНАЯ РЕГИСТРАЦИЯ", "Успешно!");
            // User user = new User("",email, pass, "");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            EntranceCabinet entranceCabinet = new EntranceCabinet();
            entranceCabinet.Show();
            Close();
            //Hide();
        }
    }
}
