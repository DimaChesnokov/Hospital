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
    /// Логика взаимодействия для RecordDesiese.xaml
    /// </summary>
    public partial class RecordDesiese : Window
    {
        DataBase database = new DataBase();
        public static int i = 0;
        public RecordDesiese()
        {
            i = EntranceCabinet.i;
            InitializeComponent();
            database.oppenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT servies as 'Услуга', secondservies as 'Врач или Услуга', convert(varchar(10), dataserv, 120) AS 'Дата', timeserv As 'Время', problem as 'Проблема' FROM recordsetold where id_user ='{i}'", database.GetConnection());
            SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Disease");
            DataGridRecord1.ItemsSource = ds.Tables["Disease"].DefaultView;
            DataGridRecord1.IsReadOnly = true;
            //DataGridRecord1.Columns[0].Header = "Услуга";
            //DataGridRecord1.Columns[1].Header = "Врач/Услуга";
            //DataGridRecord1.Columns[2].Header = "Дата";
            //DataGridRecord1.Columns[3].Header = "Время";
            //DataGridRecord1.Columns[4].Header = "Проблема";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PersonalAccount personalAccount = new PersonalAccount();
            personalAccount.Show();
            Close();
        }
    }
}
