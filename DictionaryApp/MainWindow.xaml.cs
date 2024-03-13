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

namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Admin_Button_Click(object sender, RoutedEventArgs e)
        {
            DictionaryManager dm = new DictionaryManager();
            dm.Show();
            this.Close();
        }

        private void WordSearch_Button_Click(object sender, RoutedEventArgs e)
        {
            WordSearch ws = new WordSearch();
            ws.Show();
            this.Close();
        }

        private void Entertainment_Button_Click(object sender, RoutedEventArgs e)
        {
            Entertainment ent = new Entertainment();
            ent.Show();
            this.Close();
        }
    }
}
