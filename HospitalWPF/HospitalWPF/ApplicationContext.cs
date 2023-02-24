using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity; //сбд sqlite

namespace HospitalWPF
{

    /// <summary>
    /// Класс, который наследует базу данных
    /// </summary>
    class ApplicationContext : DbContext
    {
        //Список, в котором будут находится определенные элементы с какой либо таблицы.
        //public DbSet<User> Users { get; set; }

        //Передача названия подключения,чтобы работать с бд
        //public ApplicationContext() : base("DefaultConnection") { }
    }
}
