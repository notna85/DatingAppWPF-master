using DatingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppWPF.Views;

namespace DatingAppWPF.ViewModels
{
    public class vm_Login
    {
        public string _userName { get; set; }
        public string _password { get; set; }

        
        public bool Login(string userName, string password)
        {
            SQL s = new SQL();
            if (s.loginCheck(userName, password))
            {
                SQL.selectID("select userid from users where username='" + userName + "'");
                LoginScreen l = new LoginScreen();
                l.Hide();
                MainWindow win = new MainWindow();
                win.Show();
                l.Close();
                win.Main.Content = new ProfileOwner();
                return true;
            }
            else
                return false;
            //else
            //{
            //    LoginScreen l = new LoginScreen();

            //    ("Wrong username or password...");
            //}
        }
    }
}
