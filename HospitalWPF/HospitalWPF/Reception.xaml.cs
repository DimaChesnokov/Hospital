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
    /// Логика взаимодействия для Reception.xaml
    /// </summary>
    public partial class Reception : Window
    {
        DataBase database = new DataBase();
        public static int i = 0;
        public Reception()
        {
            InitializeComponent();
            //ComboBoxSelection.Items.Add("Соколов Александр Иванович"); 
            //ComboBoxSelection.Items.Add("Пыжова Наталья Владимировна");
            dataPicker1.BlackoutDates.AddDatesInPast();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private List<string> doctors = new List<string> { "Терапевт", "Хирург", "Стоматолог", "Оториноларинголог", "Дерматолог" };
        private List<string> procedures = new List<string> { "ЭКГ", "Флюрография", "Анализ крови", "Анализ мочи" };
        private List<string> timesPn = new List<string> { "14:00-21", "Флюрография", "Анализ крови", "Анализ мочи" };

        private void ComboBoxSelectService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxSelectService.SelectedIndex == 0)
            {
                LabelService.Content = "Врач:";
                ComboBoxSelection.ItemsSource = doctors;
            }
            else
            {
                LabelService.Content = "Процедуры:";
                ComboBoxSelection.ItemsSource = procedures;
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            //PersonalAccount personalAccount = new PersonalAccount();
            //personalAccount.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            problem1.SelectAll();
            i = EntranceCabinet.i;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataBase dataBase = new DataBase();
            DataTable table = new DataTable();
            string querystring = "";
            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
            string problem = problem1.Selection.Text;
            querystring = $"insert into recordset(id_user, servies, secondservies, dataserv,timeserv,problem) values ('{i}', '{ComboBoxSelectService.Text}','{ComboBoxSelection.Text}','{dataPicker1.SelectedDate.Value.Date.ToShortDateString()}','','{problem}')";
            MessageBox.Show(dataPicker1.SelectedDate.Value.Date.ToShortDateString());
            command = new SqlCommand(querystring, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            //TimeAdd();
            //PersonalAccount personalAccount = new PersonalAccount();
            //personalAccount.Show();
            Close();
        }
        
        //private void TimeAdd()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    DataBase dataBase = new DataBase();
        //    DataTable table = new DataTable();
        //    string querystring = "";
        //    SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
        //    string problem = problem1.Selection.Text;
        //    querystring = $"insert into timebufer(dataserv,timeserv) values ('{dataPicker1}','')";
        //    command = new SqlCommand(querystring, dataBase.GetConnection());
        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);
        //}

        private void dataPicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(dataPicker1.FirstDayOfWeek.ToString());
        }
    }
}
