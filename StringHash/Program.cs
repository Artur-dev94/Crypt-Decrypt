using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StringHash
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string password = ConfigurationManager.AppSettings["Password"];
            StringBuilder sb = new StringBuilder();


            Console.WriteLine("Password generata");
            Console.WriteLine("------------------");

            createTxt(EnryptString(password));

            Console.ReadLine();

            
        }

        static string EnryptString(string password)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        static void createTxt(string textToWrite)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pass.txt");
            File.WriteAllText(path, "Pass.txt".ToString());

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(textToWrite);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
