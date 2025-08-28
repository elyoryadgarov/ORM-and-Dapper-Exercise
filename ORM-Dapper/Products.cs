namespace ORM_Dapper
{
    public class Products
    {
        public Products()
        {
        }

        public string Name { get; set;  }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public bool OnSale { get; set; }
        public int StockLevel { get; set; }

    }
}

