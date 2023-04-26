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

        private List<string> doctors = new List<string> { "Терапевт", "Хирург", "Стоматолог", "Дерматолог" };
        private List<string> procedures = new List<string> { "ЭКГ", "Флюрография", "Анализ крови", "Анализ мочи" };
        private List<string> timesFirst;
        private List<string> timesSecond;
        private List<string> Doctors = new List<string>();
        private List<string> timeStr = new List<string> { "C 8:00 до 13:00" };
        private List<string> NulStr = new List<string> {"Свободного времени нет!"};



        private void ComboBoxSelectService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxSelectService.SelectedIndex == 0)
            {
                LabelService.Content = "Врач:";
                ComboBoxSelection.ItemsSource = doctors;
                ComboBoxSelection_Copy.ItemsSource = "";
                ComboBox_Time.ItemsSource = "";
                ComboBoxSelection_Copy.ItemsSource = Doctors;
            }
            else
            {
                LabelService.Content = "Процедуры:";
                ComboBoxSelection.ItemsSource = procedures;
                ComboBoxSelection_Copy.ItemsSource = "-";
                ComboBox_Time.ItemsSource = "";
            }
        }
        private void RecDoctors()
        {
            ComboBoxSelection_Copy.ItemsSource = "";
            Doctors.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            database.oppenConnection();
            string sqlName = $"SELECT fullName_med FROM MedAccount where spec ='{ComboBoxSelection.SelectedItem}'";
            SqlCommand commandName = new SqlCommand(sqlName, database.GetConnection());
            SqlDataReader readerName = commandName.ExecuteReader();
            while (readerName.Read())
                Doctors.Add(readerName.GetString(0));
            readerName.Close();
            if (Doctors.Count == 0)
            {
                ComboBoxSelection_Copy.ItemsSource ="-";
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
            //if ((ComboBoxSelectService.Text==null)|(ComboBoxSelection.Text==null)| (ComboBoxSelection_Copy.Text==null)|(dataPicker1.SelectedDate.Value.Date.ToShortDateString()==null)|(ComboBox_Time.Text==null)|(problem==null))
            //{
            //    MessageBox.Show("Заполните все поля!", "Внимание!");
            //}
            //else
            try
            {
                if (dataPicker1.SelectedDate.Value.Date.DayOfWeek.ToString() != "Sunday")
                {
                    if (CheckOneMore() == true)
                    {
                    querystring = $"insert into recordset(id_user, servies, secondservies,nameDoc ,dataserv,timeserv,problem) values ('{i}', '{ComboBoxSelectService.Text}','{ComboBoxSelection.Text}','{ComboBoxSelection_Copy.Text}','{dataPicker1.SelectedDate.Value.Date.ToShortDateString()}','{ ComboBox_Time.Text}','{problem}')";
                    command = new SqlCommand(querystring, dataBase.GetConnection());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    Close();
                    }
                    else
                    {
                    MessageBox.Show("Вы уже записались в этот день!", "Внимание!");
                    }
                }
                else
                    MessageBox.Show("В воскресение выходной день!", "Внимание!");
            }
            catch
            {
                MessageBox.Show("Заполните все поля!", "Внимание!");
            }
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
            if (ComboBoxSelectService.SelectedIndex == 0)
            {
                if ((dataPicker1.SelectedDate.Value.Date.DayOfWeek.ToString() == "Monday") | (dataPicker1.SelectedDate.Value.Date.DayOfWeek.ToString() == "Tuesday") | (dataPicker1.SelectedDate.Value.Date.DayOfWeek.ToString() == "Friday"))
                {
                    timesFirst = new List<string> { "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00" };

                    RecTime(timesFirst);
                }
                else if ((dataPicker1.SelectedDate.Value.Date.DayOfWeek.ToString() == "Wednesday") | (dataPicker1.SelectedDate.Value.Date.DayOfWeek.ToString() == "Thursday") | (dataPicker1.SelectedDate.Value.Date.DayOfWeek.ToString() == "Saturday"))
                {
                    timesSecond = new List<string> { "8:00", "8:30", "9:00", "9:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30" };
                    RecTime(timesSecond);
                }
            }
            else
            {
                ComboBox_Time.ItemsSource=timeStr;
            }
        }
        private void RecTime(List<string> str)
        {
            int bit = 0;
            List<int> listindex = new List<int>();
            for (int i = 0; i < str.Count; i++)
            {
                database.oppenConnection();
                string querystring = $"select count(id) from recordset where timeserv = '{str[i]}' and dataserv = '{dataPicker1.SelectedDate.Value.Date.ToShortDateString()}' and nameDoc = '{ComboBoxSelection_Copy.Text}'";
                SqlCommand command = new SqlCommand(querystring, database.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = reader.GetInt32(0);
                reader.Close();
                int yt = str.IndexOf(ComboBoxSelection_Copy.Text);
                if (count > 0)
                {
                    listindex.Add(i);
                }
            }
            for (i = 0; i < listindex.Count; i++)
            {
                str.RemoveAt(listindex[i-bit]);
                bit++;
            }
            bit = 0;
            if (str.Count == 0)
            {
                ComboBox_Time.ItemsSource= NulStr;
            }
            else
                ComboBox_Time.ItemsSource = str; ;
        }
        private void ComboBoxSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxSelection_Copy.IsReadOnly = false;
            RecDoctors();
            if (Doctors.Count == 0)
            {
                ComboBoxSelection_Copy.ItemsSource = "-";
                ComboBox_Time.ItemsSource = "";
            }
            else
            {
                ComboBox_Time.ItemsSource = "";
                ComboBoxSelection_Copy.ItemsSource = Doctors;
            }
        }

        private bool CheckOneMore()
        {
            database.oppenConnection();
            string querystring = $"select count(id) from recordset where id_user ='{i}' and dataserv = '{dataPicker1.SelectedDate.Value.Date.ToShortDateString()}' and nameDoc = '{ComboBoxSelection_Copy.Text}' and secondservies = '{ComboBoxSelection.Text}'";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Close();
            if (count > 0)
            {
                return false;
            }
            else
                return true;
        }
    }
}
