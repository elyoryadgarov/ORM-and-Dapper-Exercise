using System.Data;
using Dapper;

namespace ORM_Dapper
{
    public class DapperProductsRepository : IProductsRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductsRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM PRODUCTS;");
        }

        public void CreateProduct(string name, int productID, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, ProductID, Price, CategoryID) VALUES (@name, @productID, @price, @categoryID);",
                new { Name = name, ProductID = productID, Price = price, CategoryID=categoryID });
        }

        public Products GetProduct(int productID)
        {
            return _connection.QuerySingle<Products>("select * from products where ProductID=@productID;",new {productID=productID}); 
        }
        
        public Products GetProductMax()
        {
            return _connection.QuerySingle<Products>("select max(ProductID) as ProductID from products;"); 
        }

        public void UpdateProduct(Products products)
        {
            _connection.Execute("UPDATE Products" +
                                       " SET Name=@name, " +
                                       " Price=@price, " +
                                       " CategoryID=@categoryID, " +
                                       " OnSale=@onSale, " +
                                       " StockLevel=@stockLevel"+
                                       " WHERE ProductID=@productID;", 
            new{  name=products.Name, 
                        price=products.Price, 
                        categoryID=products.CategoryID, 
                        productID=products.ProductID, 
                        onSale=products.OnSale, 
                        stockLevel=products.StockLevel});
        }

        public void DeleteProduct(int id)
        {
            _connection.Execute("DELETE FROM Sales WHERE ProductId=@id;", new { id = id });
            _connection.Execute("DELETE FROM Reviews WHERE ProductId=@id;", new { id = id });
            _connection.Execute("DELETE FROM Products WHERE ProductId=@id;", new { id = id });

        }
        
        public void DeleteProduct2(Products products)
        {
            _connection.Execute("DELETE FROM Sales WHERE ProductId=@id;", new { id = products.ProductID });
            _connection.Execute("DELETE FROM Reviews WHERE ProductId=@id;", new { id = products.ProductID });
            _connection.Execute("DELETE FROM Products WHERE ProductId=@id;", new { id = products.ProductID });

        }
    }
}

