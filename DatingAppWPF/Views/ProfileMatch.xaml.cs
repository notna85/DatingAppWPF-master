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
    /// Interaction logic for ProfileMatch.xaml
    /// </summary>
    public partial class ProfileMatch : Page
    {
        public ProfileMatch()
        {
            DataContext = new vm_ProfileMatch();
            InitializeComponent();
        }

        private void Send_Message(object sender, RoutedEventArgs e)
        {
            Window win = App.Current.Windows[0];
            Frame f = (Frame)win.FindName("Main");
            f.Content = new ReplayMessage();
        }

        private void ProfileMatch_Like(object sender, RoutedEventArgs e)
        {
            vm_ProfileMatch pm = new vm_ProfileMatch();
            
            int messagebox = pm.vm_LikeProcess();
            if (messagebox == 1)
                MessageBox.Show("Person liked! :)");
            else if (messagebox == 2)
                MessageBox.Show("Person liked back! :-)");
            else if (messagebox == 3)
                MessageBox.Show("You already like this person!");
            else
                MessageBox.Show("Something went horribly wrong :'(");
        }
    }
}
