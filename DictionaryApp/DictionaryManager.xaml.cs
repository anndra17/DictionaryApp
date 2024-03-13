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

namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for DictionaryManager.xaml
    /// </summary>
    public partial class DictionaryManager : Window
    {
        private readonly string _adminUsername = "admin";
        public string PlaceholderText { get; set; }
        public DictionaryManager()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            //string password = PasswordBox.Text;

            if (username == _adminUsername && PasswordBox.Password == "0000")
            {
                DictionaryManagerPanel.Visibility = Visibility.Visible;
                AuthentificationPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                ErrorMessageLabel.Visibility = Visibility.Visible;
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
    }
}
