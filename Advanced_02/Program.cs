using Advanced_02;
using System;
#nullable disable
public class Program
{
    static List<Product> Catalog = new List<Product>
    {
         new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
        new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
        new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
        new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
        new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
        new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
        new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
        new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
        new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
        new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
    };
    //================================SearchProducts=================================
    public static List<Product> SearchProducts (List<Product> products, Func<Product, bool>flag)
    {
        List<Product> result = new List<Product>();
        foreach (var item in products)
        {
            if (flag(item))
                result.Add(item);
        }
        return result;
    }
    public static void Print(List<Product> products)
    {
        foreach (var item in products)
        {
            Console.WriteLine($"{item.Name} - ${item.Price} - {{ Stock : {item.Stock} }}");
        }
    }
    //================================ PrintReport =================================

    public static void PrintReport(List<Product> products , Action<Product> action)
    {
        foreach (var item in products)
        {
            action(item);
        }
    }
    public static void Main()
    {
        // ==============================Task1=====================================
        Console.WriteLine("================== Electronics===================");
        Console.WriteLine();
        var Electronics = SearchProducts(Catalog, p => p.Category == "Electronics");
        Print(Electronics);
        Console.WriteLine();


        Console.WriteLine("================== Under $50===================");
        Console.WriteLine();
              var cheaper = SearchProducts(Catalog, p => p.Price < 50);
        Print(cheaper);
        Console.WriteLine();

        Console.WriteLine("================== In Stock===================");
        Console.WriteLine();
        var Stock = SearchProducts(Catalog, p => p.Stock > 0);
        Print(Stock);
        Console.WriteLine();

        Console.WriteLine("================== In Stock===================");
        Console.WriteLine();
        var Clothes = SearchProducts(Catalog, p => p.Category == "Clothing" && p.Price < 100);
        Print(Clothes);
        Console.WriteLine();

        //===================================== Task 3.1: Print Reports=====================================

        Console.WriteLine("\n=== Short Report ===");
        PrintReport(Catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

        Console.WriteLine("\n=== Detailed Report ===");
        PrintReport(Catalog, p =>
            Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

    }
    #region Comments
    /*
     Func is a Delegate that return <T> type , used for return functions 
    Action is a Delegate of void type that return nothing 
     */
    #endregion
}
