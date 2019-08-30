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
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Page
    {
        public EditProfile()
        {
            DataContext = new vm_EditProfile();
            InitializeComponent();
            vm_EditProfile s = new vm_EditProfile();
            foreach (string entry in s.vm_selectCombobox("select * from Gender order by 1 asc", "Gender"))
            {
                ep_Gender.Items.Add(entry);
            }
            foreach (string entry in s.vm_selectCombobox("select * from Religion order by 1 asc", "Religion"))
            {
                ep_Religion.Items.Add(entry);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Window win = App.Current.Windows[0];
            Frame f = (Frame)win.FindName("Main");
            f.Content = new ProfileOwner();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            vm_EditProfile s = new vm_EditProfile();
            if (s.vm_updateProfile(ep_Firstname.Text, ep_Lastname.Text, ep_Age.Text, ep_Gender.Text, ep_Religion.Text, ep_Height.Text, ep_Weight.Text, ep_Zipcode.Text, ep_Description.Text))
            {
                MessageBox.Show("Profile updated...");
            }
            else
            {
                MessageBox.Show("Error updating Account. Check input please...");
            }
        }
    }
}
