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
using DatingAppWPF.ViewModels;
using System.Data;
using DatingAppWPF.Models;

namespace DatingAppWPF.Views
{
    /// <summary>
    /// Interaction logic for RespondToLikes.xaml
    /// </summary>
    public partial class RespondToLikes : Page
    {
        public RespondToLikes()
        {
            DataContext = new vm_ShowMatches();
            InitializeComponent();
            DataTable dt = SQL.ShowProfile("exec p_potentialmatches @userid =" + App.Current.Resources["UserID"]);
            ShowMatchesGrid.ItemsSource = dt.DefaultView;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowview = ShowMatchesGrid.SelectedItem as DataRowView;
            App.Current.Resources["MatchID"] = Convert.ToInt32(rowview.Row[0]);

            Window win = App.Current.Windows[0];
            Frame f = (Frame)win.FindName("Main");
            f.Content = new ProfileMatch();
        }
    }
}
