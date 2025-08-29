using System.Data;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json").Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var DepartRepo = new DapperDepartmentRepository(conn);
            
            // Console.WriteLine("Please enter Department Name you would like to add!");
            // var userNewDepartInput = Console.ReadLine();
            // DepartRepo.InsertDepartmentMethod(userNewDepartInput);
            // DepartRepo.GetAllDepartments().ToList().ForEach(x=>Console.WriteLine($"{x.DepartmentID} {x.Name}"));

            var productsRepo = new DapperProductsRepository(conn);

            var maxCount = productsRepo.GetProductMax().ProductID;
            Console.WriteLine(maxCount);
            
            Console.WriteLine($"{productsRepo.GetProduct(maxCount).Name} | {productsRepo.GetProduct(maxCount).Price} | {productsRepo.GetProduct(maxCount).ProductID}");
            productsRepo.DeleteProduct(maxCount);
            
            // Products prodNumber = productsRepo.GetProduct(maxCount);
            //
            // productsRepo.DeleteProduct2(prodNumber);
            Random rand = new Random();
            int randomNumber = rand.Next(1, maxCount);
            Console.WriteLine($"Random Number is: {randomNumber}");
            var checkNull = productsRepo.GetProduct(randomNumber).Name;

            while (checkNull==null)
            {
                Console.WriteLine($"{productsRepo.GetProduct(maxCount).Name}");
                randomNumber = rand.Next(1, maxCount);
            }

            var productToUpdate = productsRepo.GetProduct(randomNumber);
            Console.WriteLine($"{productToUpdate.Name} | {productToUpdate.Price} | {productToUpdate.ProductID}");
            
            // productToUpdate.Name="UPDATED";
            // productToUpdate.Price = 100.00;
            // productToUpdate.StockLevel = 99;
            // productToUpdate.CategoryID = 2;
            // productToUpdate.OnSale = true;
            //
            // productsRepo.UpdateProduct(productToUpdate);
            //
            // productsRepo.GetAllProducts().ToList()
            //     .ForEach(x=>Console.WriteLine($"{x.Name} | {x.ProductID} | {x.Price} | {x.CategoryID} | {x.StockLevel}"));

        }
    }
}
