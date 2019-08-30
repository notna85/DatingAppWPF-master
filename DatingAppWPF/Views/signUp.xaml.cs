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
using System.Windows.Shapes;

namespace DatingAppWPF.Views
{
    /// <summary>
    /// Interaction logic for signUp.xaml
    /// </summary>
    public partial class signUp : Window
    {
        public signUp()
        {
            DataContext = new vm_signUp();
            InitializeComponent();
            vm_signUp s = new vm_signUp();            
            foreach(string entry in s.vm_selectCombobox("select * from Gender order by 1 asc", "Gender"))
            {
                tb_Gender.Items.Add(entry);
            }
            foreach(string entry in s.vm_selectCombobox("select * from Religion order by 1 asc", "Religion"))
            {
                tb_Religion.Items.Add(entry);
            }        
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            vm_signUp s = new vm_signUp();
            if (s.vm_createProfile(tb_Username.Text, tb_Password.Text, tb_Firstname.Text, tb_Lastname.Text, tb_Age.Text, tb_Gender.Text, tb_Religion.Text, tb_Height.Text, tb_Weight.Text, tb_Zipcode.Text, tb_Description.Text))
            {
                MessageBox.Show("Account Created...");
                this.Hide();
                LoginScreen l = new LoginScreen();
                l.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Creating Account. Check input please...");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginScreen l = new LoginScreen();
            l.Show();
            this.Close();
        }
    }
}
