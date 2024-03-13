using System;
using System.Collections.Generic;
using System.IO;
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

namespace DictionaryApp
{
    public partial class DictionaryManager : Window
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PlaceholderText { get; set; }
        public DictionaryManager()
        {
            InitializeComponent();
            Account account = new Account();
            
        }



        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Username = UsernameBox.Text;
            Password = PasswordBox.Password;

            List<Account> accounts = new List<Account>();
            accounts = Account.ReadCredentialsFromFile("C:\\Users\\andra\\Documents\\Facultate\\II\\sem II\\MVP\\Teme\\RezolvariTeme\\DictionaryApp\\DictionaryApp\\Resources\\AdminsAccounts.txt");

           
            foreach (Account account in accounts)
            {
                if (account.Username == Username && account.Password == Password)
                {
                    DictionaryManagerPanel.Visibility = Visibility.Visible;
                    AuthentificationPanel.Visibility = Visibility.Hidden;
                    break;
                }
                else
                {
                    ErrorMessageLabel.Visibility = Visibility.Visible;
                }
            }
        }

        private void PasswordBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                textBox.Text = string.Empty;
            }
        }

        private void UsernameBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                textBox.Text = string.Empty;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


    }
}
