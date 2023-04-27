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
    /// Логика взаимодействия для MedAccount.xaml
    /// </summary>
    public partial class MedAccount : Window
    {
        DataBase database = new DataBase(); //База данных
        public int b = EntranceCabinet.i; //Айди пользователя
        public int count_id = 1; //Счётчик пользователей
        public int count; //Счётчик

        /// <summary>
        /// Заполнение окна данными из бд
        /// </summary>
        public MedAccount()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            database.oppenConnection();
            string querystring = $"select count(id) from MedAccount";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            //var u = reader.GetName(0);
            reader.Read();
            count = reader.GetInt32(0);
            reader.Close();
            if (count != 0) //Проверка на пустоту данных
            {
                string sqlName = $"SELECT fullName_med FROM MedAccount where id ='{count_id}'";
                SqlCommand commandName = new SqlCommand(sqlName, database.GetConnection());
                SqlDataReader readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    NameDoctor.Text = readerName.GetString(0);
                readerName.Close();

                sqlName = $"SELECT spec FROM MedAccount where id ='{count_id}'";
                commandName = new SqlCommand(sqlName, database.GetConnection());
                readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    TextBlockSpec.Text = readerName.GetString(0);
                readerName.Close();

                sqlName = $"SELECT bio FROM MedAccount where id ='{count_id}'";
                commandName = new SqlCommand(sqlName, database.GetConnection());
                readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    Biograf.Text = readerName.GetString(0);
                readerName.Close();
            }
            else
            {
                MessageBox.Show("Вречей в больнице нету!", "Вниманиие!");            
            }
        }

        /// <summary>
        /// Переход в окно личного аккаунта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            PersonalAccount personalAccount = new PersonalAccount();
            personalAccount.Show();
            Close();
        }

        /// <summary>
        /// Переход к следующему врачу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            count_id++;
            if (count_id <= count)
            {
                string sqlName = $"SELECT fullName_med FROM MedAccount where id ='{count_id}'";
                SqlCommand commandName = new SqlCommand(sqlName, database.GetConnection());
                SqlDataReader readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    NameDoctor.Text = readerName.GetString(0);
                readerName.Close();

                sqlName = $"SELECT spec FROM MedAccount where id ='{count_id}'";
                commandName = new SqlCommand(sqlName, database.GetConnection());
                readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    TextBlockSpec.Text = readerName.GetString(0);
                readerName.Close();

                sqlName = $"SELECT bio FROM MedAccount where id ='{count_id}'";
                commandName = new SqlCommand(sqlName, database.GetConnection());
                readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    Biograf.Text = readerName.GetString(0);
                readerName.Close();
            }
            else
            {
                count_id--;
                MessageBox.Show("Конец списка.", "Вниманиие!");
            }
        }

        /// <summary>
        /// Переход к прошлому врачу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ClBack(object sender, RoutedEventArgs e)
        {
            count_id--;
            if (count_id > 0)
            {
                string sqlName = $"SELECT fullName_med FROM MedAccount where id ='{count_id}'";
                SqlCommand commandName = new SqlCommand(sqlName, database.GetConnection());
                SqlDataReader readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    NameDoctor.Text = readerName.GetString(0);
                readerName.Close();

                sqlName = $"SELECT spec FROM MedAccount where id ='{count_id}'";
                commandName = new SqlCommand(sqlName, database.GetConnection());
                readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    TextBlockSpec.Text = readerName.GetString(0);
                readerName.Close();

                sqlName = $"SELECT bio FROM MedAccount where id ='{count_id}'";
                commandName = new SqlCommand(sqlName, database.GetConnection());
                readerName = commandName.ExecuteReader();
                if (readerName.Read())
                    Biograf.Text = readerName.GetString(0);
                readerName.Close();
            }
            else
            {
                count_id++;
                MessageBox.Show("Конец списка.", "Вниманиие!");
            }
        }
    }
}
