﻿using System;
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
    /// Interaction logic for WordSearch.xaml
    /// </summary>
    public partial class WordSearch : Window
    {
        public WordSearch()
        {
            InitializeComponent();
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            var My_Dictionary = new Dictionary<string, string>()
            {
                {"masă", "O piesă de mobilier pentru luat masa"},
                {"soare", "Sursă principală de lumină și căldură pentru Pământ"},
                {"câine", "Un animal domestic din familia canidelor"},
                {"carte", "Un obiect cu pagini scrise, legate împreună"},
                {"munte", "O înălțime naturală, cu vârf ascuțit"},
                {"computer", "Un dispozitiv electronic pentru prelucrarea informațiilor"},
                {"floare", "O parte a unei plante, adesea colorată și parfumată"},
                {"școală", "O instituție de învățământ"},
                {"râu", "Un curs de apă natural, mai mic decât un fluviu"},
                {"pian", "Un instrument muzical cu clape"},
                {"paraxin", "Bizar, ciudat, curios." }
            };

            string word;
            word = InputBox.Text;

            try
            {
                ResultBox.Text = My_Dictionary[word];
            }
            catch
            {
                ResultBox.Text = "Scuze! Cuvântul nu a fost găsit!";
            }
        }

        private void InputBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
