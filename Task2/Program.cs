using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookCollection = new List<Book>();
            string path = @"C:\data";
            FileStream stream = new FileStream(path + @"\book.dat", FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                bookCollection = (List<Book>)formatter.Deserialize(stream);
            }
            catch(SerializationException ex)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + ex.Message);
                throw;
            }

            finally
            {
                stream.Close();
            }

            foreach(Book book in bookCollection)
            {
                Console.WriteLine("Name: {0}", book.Name);
                Console.WriteLine("Price: {0} USD", book.Price);
                Console.WriteLine("Author: {0}", book.Author);
                Console.WriteLine("Year: {0}", book.Year);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
