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

namespace HospitalWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //ApplicationContext db;
        //DataBase database = new DataBase();
        public MainWindow()
        {
            InitializeComponent();
            //db = new ApplicationContext();


            //List<User> user = db.Users.ToList();
        }


        //Регистрация
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String login = textBoxLogin.Text.Trim();
            String pass = passBox.Password.Trim();
            String email = textBoxEmail.Text.Trim().ToLower();
            String age = textBoxAge.Text.Trim();

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
            else if (email.Length < 4 || !email.Contains("@") || !email.Contains(".") )
            {
                textBoxEmail.ToolTip = "Ошибка!";
                textBoxEmail.Background = Brushes.Red;  
            }
            else if (Convert.ToInt32(age) <= 18)
            {
                textBoxAge.ToolTip = "Ошибка!";
                textBoxAge.Background = Brushes.Red;
            }
            else
            {
                //пустые поля 
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

   
                
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                textBoxAge.ToolTip = "Ошибка!";
                textBoxAge.Background = Brushes.Transparent;

                //User user = new User(login, email, pass, age);
                //Обращаемся к табличке Users
                //db.Users.Add(user);

                //Сохраним объект в бд
                //db.SaveChanges();


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //EntranceCabinet entranceCabinet = new EntranceCabinet();
            //entranceCabinet.Show();
            //Hide();
        }
    }
}
