﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace HospitalWPF
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-CJHB6F0D;Initial Catalog=users;Integrated Security=True");

        public void oppenConnection()
        {
            //Если связь с бд  закрыта, то открываем связь
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        //public void closeConnection()
        //{
        //    if(sqlConnection.State == System.Data.ConnectionState.Open)
        //        sqlConnection.Close();
        //}

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
