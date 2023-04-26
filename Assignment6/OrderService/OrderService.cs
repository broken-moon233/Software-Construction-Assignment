using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp 
{

    public class OrderService 
    {
        
        private readonly List<Order> orders;


        public OrderService() 
        {
            orders = new List<Order>();
        }


        public List<Order> GetAllOrders() 
        {
            return orders;
        }


        public Order GetOrder(int id) 
        {
            return orders.Where(o => o.OrderId == id).FirstOrDefault();
        }

        public void AddOrder(Order order) 
        {
            if (orders.Contains(order))
                throw new Exception($"Order {order.OrderId} already exists!");
            orders.Add(order);
        }

        public void RemoveOrder(int orderId) 
        {
            Order order = GetOrder(orderId);
            if (order == null)
            {
                throw new Exception($"Order {orderId} not exists!");
            }

            orders.Remove(order);
        }
        
        public void ModifyOrder(Order newOrder) 
        {
            Order oldOrder = GetOrder(newOrder.OrderId);
            if (oldOrder == null)
                throw new Exception($"Order {newOrder.OrderId} not exists!");
            orders.Remove(oldOrder);
            orders.Add(newOrder);
        }
        
        
        public List<Order> QueryOrdersByGoodsName(string goodsName) {
            var query = orders
                    .Where(order => order.Details.Exists(item => item.ProductName == goodsName))
                    .OrderBy(o => o.TotalAmount);
            return query.ToList();
        }

        public List<Order> QueryOrdersByCustomerName(string customerName) {
            return orders
                .Where(order => order.CustomerName == customerName)
                .OrderBy(o => o.TotalAmount)
                .ToList();
        }
        

        public object QueryByTotalAmount(float amout) {
            return orders
               .Where(order => order.TotalAmount >= amout)
               .OrderByDescending(o => o.TotalAmount)
               .ToList();
        }
    }
}
