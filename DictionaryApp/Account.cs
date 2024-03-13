using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp
{
    internal class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public static List<Account> ReadCredentialsFromFile(string filePath)
        {
            var credentials = new List<Account>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(' '); // Se presupune că spațiul este separatorul
                    if (parts.Length == 2)
                    {
                        credentials.Add(new Account
                        {
                            Username = parts[0],
                            Password = parts[1]
                        });
                    }
                }
            }

            return credentials;
        }
    }
}
