using Microsoft.Win32;
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
        public string imagePath {  get; set; }
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
            accounts = Account.ReadCredentialsFromFile("C:\\Users\\andra\\Documents\\Facultate\\II\\sem II\\MVP\\Teme\\RezolvariTeme\\DictionaryApp\\DictionaryApp\\Resources\\files\\AdminsAccounts.txt");

           
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

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            dialog.Filter = "Imagini (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Toate fișierele (*.*)|*.*";

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    imagePath = dialog.FileName;
                    string destinationFolder = @"C:\Users\andra\Documents\Facultate\II\sem II\MVP\Teme\RezolvariTeme\DictionaryApp\DictionaryApp\Resources\images";
                    string destinationPath = System.IO.Path.Combine(destinationFolder, System.IO.Path.GetFileName(imagePath));
                    File.Copy(imagePath, destinationPath, true);
                    imagePath = destinationPath;
                
                    BitmapImage image = new BitmapImage(new Uri(imagePath));
                    WordsImage.Source = image;
                    WordsImage.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A apărut o eroare: " + ex.Message, "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void UploadWordButton_Click(object sender, RoutedEventArgs e)
        {
            string word = WordTextBox.Text;
            string description = DescriptionTextBox.Text;
            string category = CategoryTextBox.Text;
            string image = imagePath;

            WordsManager manager = new WordsManager();
            manager.AddWord(category,word,description,image);

            WordTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
            imagePath = string.Empty;
            WordsImage.Visibility = Visibility.Hidden;
            CategoryTextBox.Text = string.Empty;

            System.Windows.MessageBox.Show("Felicitări! Cuvântul a fost adăugat.", "Mesaj de Validare", MessageBoxButton.OK);
        }

        private void CategoryTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            WordsManager manager = new WordsManager();
            CategoryComboBox.ItemsSource = manager.GetExistingCategories(); // Metoda pentru a obține categoriile disponibile
            CategoryComboBox.Visibility = Visibility.Visible;
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CategoryComboBox.SelectedItem != null)
            {
                if (CategoryComboBox.SelectedItem.ToString() == "Adaugă categorie")
                {
                    CategoryTextBox.Visibility = Visibility.Visible;
                    CategoryTextBox.Focus(); // Adu textbox-ul in fata pentru introducerea categoriei
                }
                else
                {
                    CategoryTextBox.Visibility = Visibility.Collapsed;
                    CategoryTextBox.Text = CategoryComboBox.SelectedItem.ToString();
                }
            }
            // Ascunde ComboBox-ul după selectare
            CategoryComboBox.Visibility = Visibility.Collapsed;
        }

        private void CategoryTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        
        }
    }
}
