using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookCollection = new List<Book>();
            int size = 10;
            
            string path = @"C:\data";

            for(int i=0; i < size; i++)
            {
                Book book = new Book();
                book.Name = "asd";
                book.Price = 100*i+0.5;
                book.Author = "asd";
                book.Year = 1990+i;

                bookCollection.Add(book);
            }

            FileStream stream = new FileStream(path + @"\book.dat", FileMode.Create);
            
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(stream, bookCollection);
            }
            catch(SerializationException ex)
            {
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
