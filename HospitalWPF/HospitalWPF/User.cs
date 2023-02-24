using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalWPF
{
    class User
    {
        public int id { get; set; }
        private string Login, Pass, Email, Age;
        


        public string login
        {
            get { return Login; }
            set { Login = value; }
        }

        public string pass
        {
            get { return Pass; }
            set { Pass = value; }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        public string age
        {
            get { return Age; }
            set { Age = value; }
        }

        /// <summary>
        /// Конструктор по умолчанию 
        /// </summary>
        public User()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Pass"></param>
        /// <param name="Email"></param>
        /// <param name="Age"></param>
        public User(string Login, string Pass, string Email, string Age)
        {
            this.Login = Login;
            this.Email = Email;
            this.Pass = Pass;
            this.Age = Age;
        }
    }
}
