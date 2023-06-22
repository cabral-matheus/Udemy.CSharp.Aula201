using System.Globalization;
using Udemy.CSharp.Aula201.Entities;

namespace Udemy.CSharp.Aula201
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file full path");
            string sourceFilePath = Console.ReadLine();

            try
            {
                string sourceDirectoryPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceDirectoryPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                string[] sourceFileItens = File.ReadAllLines(sourceFilePath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    ;
                    foreach (string line in sourceFileItens)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product product = new Product(name, price, quantity);

                        sw.WriteLine(product.Name + "," + product.TotalValue().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            } catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}