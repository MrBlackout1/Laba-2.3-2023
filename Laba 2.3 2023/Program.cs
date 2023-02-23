using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Читаємо список продуктів з файлу за шляхом ...\bin\Debug\net6.0
        List<Product> products = new List<Product>();
        using (StreamReader sr = new StreamReader("products.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                Product product = new Product { Name = parts[0], Category = parts[1], Price = decimal.Parse(parts[2]) };
                products.Add(product);
            }
        }

        // Групуємо продукти за категорією
        var groupedProducts = products.GroupBy(p => p.Category);

        // Виводимо результати групування
        Console.WriteLine("Продукти, згрупованi за категорiєю:");
        foreach (var group in groupedProducts)
        {
            Console.WriteLine("{0}:", group.Key);
            foreach (Product product in group)
            {
                Console.WriteLine("- {0}", product.Name);
            }
        }
    }
}