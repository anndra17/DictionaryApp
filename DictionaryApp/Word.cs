using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace DictionaryApp
{
    internal class Word
    {
        public string _word { get; set; }
        public string imagePath { get; set; }
        public string description { get; set; }
        public string category { get; set; }

        public Word(string word, string description, string image, string category)
        {
            this._word = word;
            this.description = description;
            this.imagePath = image;
            this.category = category;
        }

        public void SaveWord()
        {
            string filepath = "C:\\Users\\andra\\Documents\\Facultate\\II\\sem II\\MVP\\Teme\\RezolvariTeme\\DictionaryApp\\DictionaryApp\\Resources\\files\\Words.txt";

            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(category + "*" + _word + "*" + description + "*" + imagePath);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Eroare la salvarea cuvantului! ", ex);
            }
        }

       
    }
} 



