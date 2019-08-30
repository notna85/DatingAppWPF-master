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
    /// Interaction logic for ProfileOwner.xaml
    /// </summary>
    public partial class ProfileOwner : Page
    {
        public ProfileOwner()
        {
            DataContext = new vm_Profile();
            InitializeComponent();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            Window win = App.Current.Windows[0];
            Frame f = (Frame) win.FindName("Main");
            f.Content = new EditProfile();
        }
    }
}
