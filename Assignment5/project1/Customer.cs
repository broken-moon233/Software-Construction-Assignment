using System.Collections.Generic;

namespace project1
{
    public class Customer
    {
        public int Id { get; set; } // 客户ID
        public string Name { get; set; } // 客户名称
        
        public Customer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null &&
                   Id == customer.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

 
    }
}