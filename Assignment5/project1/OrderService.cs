using System;
using System.Collections.Generic;
using System.Linq;

namespace project1
{
    public class OrderService
    {
        private readonly List<Order> orderList = new List<Order>();

        public OrderService() {}

// 添加订单
        public void AddOrder(Order order)
        {
            if (orderList.Contains(order))
            {
                throw new Exception($"Order {order.OrderId} already exists!");
            }
            orderList.Add(order);
        }

// 删除订单
        public void RemoveOrder(int orderId)
        {
            var order = orderList.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new Exception($"Order {orderId} not exists!");
            }

            orderList.Remove(order);
        }

// 修改订单
        public void ModifyOrder(Order order)
        {
            var oldOrder = orderList.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (oldOrder == null)
            {
                throw new Exception($"Order {order.OrderId} not exists!");
            }

            orderList.Remove(oldOrder);
            orderList.Add(order);
        }
        
        public Order GetById(int orderId) {
            return orderList.FirstOrDefault(o => o.OrderId == orderId);
        }

// 查询订单
        public List<Order> QueryOrdersByOrderNum(int orderNum)
        {
            var query = from order in orderList
                where order.OrderId == orderNum
                orderby order.TotalAmount
                select order;
            return query.ToList();
        }

        public List<Order> QueryOrdersByProductName(string productName)
        {
            var query = from order in orderList
                where order.OrderDetails.Any(detail => detail.Product.Name == productName)
                orderby order.TotalAmount
                select order;
            return query.ToList();
        }

        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            var query = from order in orderList
                where order.Customer.Name == customerName
                orderby order.TotalAmount
                select order;
            return query.ToList();
        }

        public List<Order> QueryOrdersByTotalAmount(double totalAmount)
        {
            var query = from order in orderList
                where Math.Abs(order.TotalAmount - totalAmount) < 0.0001
                orderby order.TotalAmount
                select order;
            return query.ToList();
        }

// 排序订单
        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }

        public void Sort()
        {
            orderList.Sort();
        }
        
        public List<Order> QueryAll()
        {
            return orderList;
        }

// 显示所有订单
        public void ShowAllOrders()
        {
            Console.WriteLine("All Orders:");
            foreach (var order in orderList)
            {
                Console.WriteLine(order);
            }
        }
    }
}