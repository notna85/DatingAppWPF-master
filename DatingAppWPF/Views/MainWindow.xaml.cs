using DatingAppWPF.ViewModels;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatingAppWPF.Models;

namespace DatingAppWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new vm_Profile();
            InitializeComponent();
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginScreen log = new LoginScreen();
            log.Show();
            this.Close();
        }
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginScreen log = new LoginScreen();
            log.Show();
            this.Close();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ProfileOwner();
        }
        private void SearchProfileButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SearchProfile();
        }

        private void FindMatches_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ShowMatches();
        }

        private void ViewMatches_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewMatches();
        }

        private void RespondToLikes_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RespondToLikes();
        }

        private void ViewMessages_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewMessages();
        }

        private void EditProfileImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "C:\\Users\\andre\\Source\\Repos\\DatingAppWPF\\DatingAppWPF\\Images";
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +

              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ProfileImage.Source = new BitmapImage(new Uri(op.FileName));
                SQL.sqlCommand("update person set imagepath = '"+op.FileName+"' where userid = "+App.Current.Resources["UserID"]);
            }
        }
    }
}
