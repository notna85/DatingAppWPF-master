using DatingAppWPF.Models;
using DatingAppWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ViewMessages.xaml
    /// </summary>
    public partial class ViewMessages : Page
    {
        public ViewMessages()
        {
            DataContext = new vm_ShowMatches();
            InitializeComponent();
            DataTable dt = SQL.ShowProfile("exec P_messages @userID =" + App.Current.Resources["UserID"]);
            ShowMatchesGrid.ItemsSource = dt.DefaultView;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowview = ShowMatchesGrid.SelectedItem as DataRowView;
            int messageID = Convert.ToInt32(rowview.Row[0]);
            DataTable dt = new DataTable();
            dt = SQL.ShowProfile("select sender from messages where messagesid="+messageID);
            App.Current.Resources["MatchID"] = Convert.ToInt32(dt.Rows[0]["sender"]);
            SQL.sqlCommand("update messages set isread = 1 where messagesid =" + messageID);

            Window win = App.Current.Windows[0];
            Frame f = (Frame)win.FindName("Main");
            f.Content = new ReadMessage(messageID);
        }
    }
}
