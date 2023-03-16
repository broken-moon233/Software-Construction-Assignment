using System;

namespace project1
{
    internal class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;


        public GenericList()
        {
            tail = head = null;
        }
        
        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
        }
        
        public T Getitem(int index)
        {
            Node<T> p = head;
            for (int i = 0; i < index; i++)
            {
                p = p.Next;
            }
            return p.Data;
        }
        
        public void ForEach(Action<T> action)
        {
            for (Node<T> p = head; p != null; p = p.Next)
            {
                action(p.Data);
            }
        }
        
        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            
            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            GenericList<int> list = new GenericList<int>();
            for(int i = 0; i < 10; i++)
            {
                list.Add(random.Next(1,10));
            }
            list.ForEach(Console.WriteLine);
            int max = list.Getitem(0);
            int min = list.Getitem(0);
            int sum = 0;
            list.ForEach(x => max = x > max ? x : max);
            list.ForEach(x => min = x < min ? x : min);
            list.ForEach(x => sum += x);
            Console.WriteLine("max = {0}", max);
            Console.WriteLine("min = {0}", min);
            Console.WriteLine("sum = {0}", sum);
        }
    }
    

    
        
    
}