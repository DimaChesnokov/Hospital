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
    /// Логика взаимодействия для CurrentDesiese.xaml
    /// </summary>
    public partial class CurrentDesiese : Window
    {
        DataBase database = new DataBase();
        public static int i = 0;
        public CurrentDesiese()
        {
            i = EntranceCabinet.i;
            InitializeComponent();
            WindowState = WindowState.Maximized;
            //DataGridRecord.Columns[1].Header = "Услуга";
            //DataGridRecord.Columns[2].Header = "Врач/Услуга";
            //DataGridRecord.Columns[3].Header = "Дата";
            //DataGridRecord.Columns[4].Header = "Время";
            //DataGridRecord.Columns[5].Header = "Проблема";
            database.oppenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT servies as 'Услуга', secondservies as 'Врач или Услуга', nameDoc AS 'ФИО Врача' ,convert(varchar(10), dataserv, 120) AS 'Дата', timeserv As 'Время', problem as 'Проблема' FROM recordset where id_user ='{i}'", database.GetConnection());
            SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Disease");
            DataGridRecord.ItemsSource = ds.Tables["Disease"].DefaultView;
            DataGridRecord.IsReadOnly = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PersonalAccount personalAccount = new PersonalAccount();
            personalAccount.Show();
            Close();
        }

        private void DataGridRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
