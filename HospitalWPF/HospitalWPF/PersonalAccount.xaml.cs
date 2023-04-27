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
        DataBase database = new DataBase(); //База данных
        public int b = EntranceCabinet.i; //Айди пользователя
        public PersonalAccount()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
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

            database.oppenConnection();
            string querystring = $"select count(id) from recordset where id_user ='{b}' and dataserv < '{DateTime.Today}'";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            if (count != 0)
            {
                OldDataSet();
            }
        }

        /// <summary>
        /// Метод заполнения прошедшими записями истроии записей из текущей записи
        /// </summary>
        private void OldDataSet()
        {
            database.oppenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            string querystring = "";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            querystring = $"insert into recordsetold (id_user, servies, secondservies, nameDoc, dataserv, timeserv, problem) select id_user, servies, secondservies,nameDoc ,dataserv, timeserv, problem from recordset where id_user ='{b}' and dataserv < '{DateTime.Today}'";
            command = new SqlCommand(querystring, dataBase.GetConnection());
            adapter.SelectCommand = command;

            adapter.Fill(table);
            OldDataDel();
        }

        /// <summary>
        /// Метод удалениия прошедших записей из текущей записи
        /// </summary>
        private void OldDataDel()
        {
            database.oppenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            string querystring = "";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            querystring = $"delete from recordset where id_user ='{b}' and dataserv < '{DateTime.Today}' ";
            command = new SqlCommand(querystring, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
        }

        /// <summary>
        /// Открывает окно записи к врачу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Reception(object sender, RoutedEventArgs e)
        {
            Reception reception = new Reception();
            reception.Show();
        }

        /// <summary>
        /// Редактирование данных пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Сохранение изменённых данных пользователя в бд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }

        /// <summary>
        /// Открытие окна карточек врачей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Doctor(object sender, RoutedEventArgs e)
        {
            MedAccount medAccount = new MedAccount();
            medAccount.Show();
            Close();
        }

        /// <summary>
        /// Открытие окна текущих записей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentDesiese curDisease = new CurrentDesiese();
            curDisease.Show();
            Close();
        }

        /// <summary>
        /// Открыть окно истории записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RecordDesiese RecDisease = new RecordDesiese();
            RecDisease.Show();
            Close();
        }

        /// <summary>
        /// Вывод справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Врачи- Здесь вы можете просмотреть врачей нашей больницы.\n" +
    "История записей- Здесь вы можете просмотреть все свои записи, которые уже не активны на данный момент.\n" +
    "Текущие записи- Здесь вы можете просмотреть все свои активные записи на данный момент.\n" +
    "Кнопка 'Редактировать' позволит Вам редактировать информацию о себе\n" +
    "Кнопка 'Сохранить' подверждает внесённые изменения.\n" +
    "Кнопка 'Записаться к врачу' продоставляет записаться к интересующему вас в специалисту или процедуре в порядке электронной очереди.", "Справка");
        }
    }
}
