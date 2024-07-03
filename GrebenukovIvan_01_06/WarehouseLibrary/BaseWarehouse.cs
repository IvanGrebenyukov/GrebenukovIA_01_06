namespace WarehouseLibrary
{
    public class BaseWarehouse
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public BaseWarehouse(string productName, double price, int count)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Название товара не может быть null");
            }
            if(price <= 0) 
            {
                throw new ArgumentException("Цена товара не может быть меньше или равна 0");
            }
            if (count <= 0)
            {
                throw new ArgumentException("Количество товара не может быть меньше 0");
            }
            ProductName = productName;
            Price = price;
            Count = count;
        }

        public virtual double Quality()
        {
            return Price / Count;
        }

        public override string ToString()
        {
            return $"Название: {ProductName}; Цена: {Price}; Количество: {Count}; Качество базового класса: {Quality()}";
        }
    }
}
