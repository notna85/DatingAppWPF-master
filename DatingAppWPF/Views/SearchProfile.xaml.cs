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

namespace DatingAppWPF.Views
{
    /// <summary>
    /// Interaction logic for SearchProfile.xaml
    /// </summary>
    public partial class SearchProfile : Page
    {
        public SearchProfile()
        {
            DataContext = new vm_SearchProfile();
            InitializeComponent();
        }

        private void Search_Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            Window win = App.Current.Windows[0];
            Frame f = (Frame)win.FindName("Main");
            f.Content = new EditSearchProfile();
        }
    }
}
