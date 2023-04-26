using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp 
{
  public class Customer 
  {
    public string ID { get; set; }
    public string Name { get; set; }

    public Customer() {}

    public Customer(string id, string name) 
    {
      ID = id;
      Name = name;
    }

    public override bool Equals(object obj) 
    {
      var customer = obj as Customer;
      return customer != null &&
             ID == customer.ID &&
             Name == customer.Name;
    }

    public override int GetHashCode()
    {
      return 2108858624 + EqualityComparer<string>.Default.GetHashCode(ID);
    }

  }
}
