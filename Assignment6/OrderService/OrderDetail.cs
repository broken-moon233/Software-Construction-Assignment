using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp 
{

  public class OrderDetail 
  {

    public int Index { get; set; } //序号

    public Product Product { get; set; }

    public String ProductName { get => Product!=null? this.Product.Name:""; }
    

    public int Quantity { get; set; }

    public OrderDetail() { }

    public OrderDetail(int index, Product product, int quantity) 
    {
      this.Index = index;
      this.Product = product;
      this.Quantity = quantity;
    }

    public double TotalAmount 
    {
      get => Product == null ? 0.0 : Product.Price * Quantity;
    }

    public override string ToString() 
    {
      return $"[No.:{Index},product:{ProductName},quantity:{Quantity},TotalAmount:{TotalAmount}]";
    }

    public override bool Equals(object obj) 
    {
      var item = obj as OrderDetail;
      return item != null && Index == item.Index;
    }

    public override int GetHashCode()
    {
      return 785010553 + EqualityComparer<Product>.Default.GetHashCode(Product);
    }
  }
}
