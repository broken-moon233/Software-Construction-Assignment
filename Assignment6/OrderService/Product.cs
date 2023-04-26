using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp 
{
  public class Product 
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Product() {}

    public Product(string id, string name, double price) 
    {
      ID = id;
      Name = name;
      Price = price;
    }

    public override bool Equals(object obj) 
    {
      var goods = obj as Product;
      return goods != null && ID == goods.ID;
    }

    public override int GetHashCode()
    {
      return 2108858624 + EqualityComparer<string>.Default.GetHashCode(ID);
    }
    
  }
}
