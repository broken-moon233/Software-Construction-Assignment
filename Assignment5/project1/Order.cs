using System;
using System.Collections.Generic;
using System.Linq;

namespace project1
{
    public class Order : IComparable<Order>
    {
        private List<OrderDetail> details = new List<OrderDetail>();
        public int OrderId { get; set; } // 订单号
        public Customer Customer { get; set; } // 客户
        public List<OrderDetail> OrderDetails = new List<OrderDetail>(); // 订单明细
        public DateTime CreateTime { get; set; }

        public double TotalAmount // 订单总金额
        {
            get { return OrderDetails.Sum(item => item.Product.Price * item.Quantity); }
        }

        public Order()
        {
            CreateTime = DateTime.Now;
        }
        
        public List<OrderDetail> Details => details;
        
        public void AddDetails(OrderDetail orderDetail) {
            if (Details.Contains(orderDetail)) {
                throw new ApplicationException($"The goods ({orderDetail.Product.Name}) exist in order {OrderId}");
            }
            Details.Add(orderDetail);
        }


        public Order(int orderId, Customer customer, DateTime createTime)
        {
            OrderId = orderId;
            Customer = customer;
            CreateTime = createTime;
        }


        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return OrderId - other.OrderId;
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderId == order.OrderId &&
                   EqualityComparer<Customer>.Default.Equals(Customer, order.Customer);
        }

        public override int GetHashCode()
        {
            return OrderId.GetHashCode();
        }
    }
}