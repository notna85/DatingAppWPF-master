using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatingAppWPF.Models;
using DatingAppWPF.ViewModels;

namespace DatingAppWPF.Views
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            DataContext = new vm_Login();
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            vm_Login v = new vm_Login();
            if (v.Login(userNameTextBox.Text, passwTextBox.Password))
            {                   
                this.Close();
            }
            else
                MessageBox.Show("Wrong Password or Username");
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            signUp s = new signUp();
            s.Show();
            this.Close();

        }
    }
}