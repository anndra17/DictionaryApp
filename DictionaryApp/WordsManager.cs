using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DictionaryApp
{
    internal class WordsManager
    {
        List<Word> Words { get; set; }
        
        public void AddWord(string category, string word, string description, string imagePath)
        {
            if (word == string.Empty || category == string.Empty || description == string.Empty)
            {
                System.Windows.MessageBox.Show("Toate câmpurile trebuie completate!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Word newWord = new Word(word, description, imagePath, category);

            newWord.SaveWord();
        }


        public List<string> GetExistingCategories()
        {
            List<string> categories = new List<string>();
            string filePath = @"C:\Users\andra\Documents\Facultate\II\sem II\MVP\Teme\RezolvariTeme\DictionaryApp\DictionaryApp\Resources\files\Words.txt";

            try
            {
                // Citirea categoriilor din fișierul specificat
                string[] lines = File.ReadAllLines(filePath);

                // Adăugarea categoriilor în listă
                foreach (string line in lines)
                {
                    // Separarea string-urilor din linie folosind virgula ca separator
                    string[] parts = line.Split('*');

                    // Adăugarea categoriei (primul element din array-ul parts) în listă
                    if (parts.Length > 0)
                    {
                        if (!categories.Exists(c => c.Equals(parts[0])))
                        {
                            categories.Add(parts[0]);
                        }
                    }
                }
                categories.Add("Adaugă categorie");
            }
            catch (Exception ex)
            {
                // Tratarea erorilor în cazul în care nu se poate citi fișierul
                MessageBox.Show("A apărut o eroare la citirea categoriilor: " + ex.Message, "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return categories;
        }

    }
}
