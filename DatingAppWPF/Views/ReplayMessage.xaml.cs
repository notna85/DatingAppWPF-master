using DatingAppWPF.Models;
using DatingAppWPF.ViewModels;
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


namespace DatingAppWPF.Views
{
    /// <summary>
    /// Interaction logic for ReplayMessage.xaml
    /// </summary>
    public partial class ReplayMessage : Page
    {
        public ReplayMessage()
        {
            DataContext = new vm_ReplayMessage();
            InitializeComponent();

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window win = App.Current.Windows[0];
            Frame f = (Frame)win.FindName("Main");
            f.Content = new ViewMessages();            
        }
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            SQL.sqlCommand("Insert into messages(content, sender, receiver, isread) select '" + MessageWindow.Text + "', " + App.Current.Resources["UserID"] + ", " + App.Current.Resources["MatchID"] + ", 0");
            MessageBox.Show("Message Sent...");
        }
    }
}
