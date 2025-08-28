namespace ORM_Dapper
{
    public interface IProductsRepository
    {
        public IEnumerable<Products> GetAllProducts();

        void CreateProduct(string name, int productID, double price, int CategoryID);
        public Products GetProduct(int productID);
        void UpdateProduct(Products products);
        
        void DeleteProduct(int id);
        
        void DeleteProduct2(Products products);
    }
}

