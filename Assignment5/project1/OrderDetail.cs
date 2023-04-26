using System;
using System.Collections.Generic;

namespace project1
{
    public class OrderDetail
    {
        public int Index { get; set; }
        public Product Product { get; set; } // 商品
        public int Quantity { get; set; } // 数量
        
        
        public OrderDetail() { }
        public OrderDetail(int index, Product product, int quantity)
        {   
            Index = index;
            Product = product;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                   EqualityComparer<Product>.Default.Equals(Product, detail.Product);
        }

        public override int GetHashCode()
        {
            return 785010553 + EqualityComparer<Product>.Default.GetHashCode(Product);
        }
    }
}