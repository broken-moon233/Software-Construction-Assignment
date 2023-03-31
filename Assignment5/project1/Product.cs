using System.Collections.Generic;

namespace project1
{
    public class Product
    {
        public int Id { get; set; } // 商品ID
        public string Name { get; set; } // 商品名称
        public double Price { get; set; } // 商品价格
        
        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null && Id == product.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

    }
}