using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsUppg.Entities
{
    internal class Restaurant
    {
        public List<MenuItem> MenuItems { get; set; }
        public Queue<Order> Orders { get; set; }

        public Restaurant()
        {
            MenuItems = new List<MenuItem>();
            Orders = new Queue<Order>();

        }

        public void AddToMenu(MenuItem menuItem)
        {
            MenuItems.Add(menuItem);
            Console.WriteLine($"{menuItem.Name} Har lagts till i menyn");
        }

        public void ShowMenu()
        {
            Console.WriteLine("Dagens meny:");
            foreach (var item in MenuItems)
            {
                Console.WriteLine($"- {item}: {item.Price:C}");
            }
        }

        public void createOrder(Order order)
        {
            Orders.Enqueue(order);
            Console.WriteLine($"Order med id {order} har lagts till i kön");
        }

        public void HandleOrders()
        {
            while (Orders.Count > 0)
            {
                Order currentOrder = Orders.Dequeue();
                Console.WriteLine($"Hanterar beställning med id {currentOrder}");
                
            }
        }

        public void ShowOrders()
        {
            Console.WriteLine("Nuvarande beställningar i kön:");
            foreach (var order in Orders)
            {
                Console.WriteLine($"- Order med id {order}");
            }
        }

        public void ShowNextOrder()
        {
            if (Orders.Count > 0)
            {
                Order nextOrder = Orders.Peek();
                Console.WriteLine($"Nästa beställning i kön  är {nextOrder} med id {nextOrder}");
            }
            else
            {
                Console.WriteLine("Det finns inga beställningar i kön.");
            }
        }

        public void ShowOrderCount()
        {
            Console.WriteLine($"Antal beställningar i kön: {Orders.Count}");
        }


    }
}
