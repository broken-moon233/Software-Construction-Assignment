using System;
using System.Collections.Generic;
using System.Linq;

namespace project1
{
    public class Order : IComparable<Order>
    {
        private List<OrderDetail> details;
        public int OrderId { get; set; } // 订单号
        public Customer Customer { get; set; } // 客户
        public List<OrderDetail> OrderDetails = new List<OrderDetail>(); // 订单明细
        public DateTime CreateTime { get; set; }

        public double TotalAmount // 订单总金额
        {
            get { return OrderDetails.Sum(item => item.Product.Price * item.Quantity); }
        }

        public Order() {details = new List<OrderDetail>(); CreateTime = DateTime.Now; }
        
        public List<OrderDetail> Details => details;
        
        public void AddDetails(OrderDetail orderDetail) {
            if (Details.Contains(orderDetail)) {
                throw new ApplicationException($"The goods ({orderDetail.Product.Name}) exist in order {OrderId}");
            }
            Details.Add(orderDetail);
        }
        
        public void AddItem(OrderDetail orderItem) {
            if(Details.Contains(orderItem))
                throw new ApplicationException($"添加错误：订单项{orderItem.Product} 已经存在!");
            Details.Add(orderItem);
        }
        
        public void RemoveDetail(OrderDetail orderItem) {
            Details.Remove(orderItem);
        }


        public Order(int orderId, Customer customer, List<OrderDetail> items)
        {
            OrderId = orderId;
            Customer = customer;
            CreateTime = DateTime.Now;
            this.details = (items == null) ? new List<OrderDetail>() : items;
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