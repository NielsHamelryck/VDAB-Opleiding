using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
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

namespace WPFToysForBoys.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            userNameTextBox.Text = "User";
            passwordBox.Password = "user";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Regular admin
            if (userNameTextBox.Text.ToString() == "User" && passwordBox.Password.ToString() == "user")
            {
                MoveOn();
            }
            ////Super admin
            //else if (userNameTextBox.Text.ToString() == "Admin" && passwordBox.Password.ToString() == "admin")
            //{
            //    View.ManagementWindow eenView = new ManagementWindow();
            //    ViewModel.ManagementVM vm = new ViewModel.ManagementVM(true, eenView);

            //    eenView.DataContext = vm;
            //    eenView.Show();
            //    Application.Current.MainWindow.Close();
            else
            {
                IAdminService admin = new AdminService();
                Admin ad = admin.GetAll().ToList().FindLast(a => a.username.Trim() == userNameTextBox.Text.ToString());
                if (ad != null)
                    if (userNameTextBox.Text.ToString() == ad.username.Trim() && passwordBox.Password.ToString() == ad.password.Trim())
                    {
                        MoveOn();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Login!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                else
                {
                    MessageBox.Show("Incorrect Login!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }


        }

        private void MoveOn()
        {
            View.ManagementWindow eenView = new ManagementWindow();
            ViewModel.ManagementVM vm = new ViewModel.ManagementVM(false, eenView);

            eenView.DataContext = vm;
            eenView.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            View.RegisterWindow registerview = new RegisterWindow();
            this.Close();
            registerview.Show();
        }
    }
}
