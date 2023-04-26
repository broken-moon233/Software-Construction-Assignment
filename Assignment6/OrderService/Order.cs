using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderApp 
{

  public class Order:IComparable<Order>
  {

    private List<OrderDetail> details;

    public int OrderId { get; set; }

    public Customer Customer { get; set; }

    public string CustomerName { get=> (Customer!=null)? Customer.Name:""; }

    public DateTime CreateTime { get; set; }


    public Order() {details = new List<OrderDetail>(); CreateTime = DateTime.Now; }

    public Order(int orderId, Customer customer, List<OrderDetail> items) {
      this.OrderId = orderId;
      this.Customer = customer;
      this.CreateTime = DateTime.Now;
      this.details = (items == null) ? new List<OrderDetail>() : items;
    }

    public List<OrderDetail> Details => details;

    public double TotalAmount 
    {
      get => details.Sum(d => d.TotalAmount);
    }

    public void AddItem(OrderDetail orderItem) 
    {
      if(Details.Contains(orderItem))
        throw new ApplicationException($"ERROR：Order{orderItem.ProductName} is already existed!");
      Details.Add(orderItem);
    }

    public void RemoveDetail(OrderDetail orderItem)
    {
      Details.Remove(orderItem);
    }

    public override string ToString() 
    {
      StringBuilder strBuilder = new StringBuilder();
      strBuilder.Append($"Id:{OrderId}, customer:{Customer},orderTime:{CreateTime},totalPrice：{TotalAmount}");
      details.ForEach(od => strBuilder.Append("\n\t" + od));
      return strBuilder.ToString() ;
    }

    public override bool Equals(object obj) 
    {
      var order = obj as Order;
      return order != null && OrderId == order.OrderId;
    }

    public int CompareTo(Order other) 
    {
      if (other == null) return 1;
      return OrderId - other.OrderId;
    }
    
    public override int GetHashCode()
    {
      return OrderId.GetHashCode();
    }
  }
}
