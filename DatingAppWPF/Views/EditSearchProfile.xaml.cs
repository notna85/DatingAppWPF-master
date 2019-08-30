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
    /// Interaction logic for EditSearchProfile.xaml
    /// </summary>
    public partial class EditSearchProfile : Page
    {
        public EditSearchProfile()
        {
            DataContext = new vm_EditSearchProfile();
            InitializeComponent();
            vm_EditSearchProfile s = new vm_EditSearchProfile();
            esp_Gender.Items.Add("");
            esp_Religion.Items.Add("");
            foreach (string entry in s.vm_selectCombobox("select * from Gender order by 1 asc", "Gender"))
            {
                esp_Gender.Items.Add(entry);
            }
            foreach (string entry in s.vm_selectCombobox("select * from Religion order by 1 asc", "Religion"))
            {
                esp_Religion.Items.Add(entry);
            }
        }

        private void SearchButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Window win = App.Current.Windows[0];
            Frame f = (Frame)win.FindName("Main");
            f.Content = new SearchProfile();
        }
        private void SearchButtonSave_Click(object sender, RoutedEventArgs e)
        {
            vm_EditSearchProfile s = new vm_EditSearchProfile();
            if (s.vm_updateSearchProfile(esp_MinAge.Text, esp_MaxAge.Text, esp_Gender.Text, esp_Religion.Text, esp_Zipcode.Text))
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
