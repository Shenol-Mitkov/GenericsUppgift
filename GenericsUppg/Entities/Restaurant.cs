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
                Console.WriteLine($"- {item}");
            }
        }

        public void createOrder(Order order)
        {
            Orders.Enqueue(order);
            Console.WriteLine($"Order #{order.OrderId} för bord {order.TableNumber} har lagts till i kön");
        }

        // Hanterar (tar bort) endast den FÖRSTA beställningen i kön
        public void HandleOrder()
        {
            if (Orders.Count > 0)
            {
                Order currentOrder = Orders.Dequeue();
                Console.WriteLine($"Order #{currentOrder.OrderId} för bord {currentOrder.TableNumber} har hanterats och tagits bort från kön");
            }
            else
            {
                Console.WriteLine("Det finns inga beställningar att hantera.");
            }
        }

        public void ShowOrders()
        {
            Console.WriteLine("Nuvarande beställningar i kön:");
            if (Orders.Count == 0)
            {
                Console.WriteLine("Kön är tom.");
                return;
            }
            foreach (var order in Orders)
            {
                order.PrintOrder();
            }
        }

        public void ShowNextOrder()
        {
            if (Orders.Count > 0)
            {
                Console.WriteLine("Nästa beställning i kön:");
                Orders.Peek().PrintOrder();
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


        public void StartRestaurant()
        {
            Console.WriteLine("Välkommen till DigiRestaurant!");
            Restaurant DigiRestaurant = new Restaurant();

            DigiRestaurant.AddToMenu(new MenuItem(1, "Pizza", 99.99m));
            DigiRestaurant.AddToMenu(new MenuItem(2, "Pasta", 79.99m));
            DigiRestaurant.AddToMenu(new MenuItem(3, "Sallad", 49.99m));
            DigiRestaurant.AddToMenu(new MenuItem(4, "Soppa", 39.99m));

            DigiRestaurant.ShowMenu();

            DigiRestaurant.createOrder(new Order(new List<MenuItem> { DigiRestaurant.MenuItems[0], DigiRestaurant.MenuItems[1] }, 1));
            DigiRestaurant.createOrder(new Order(new List<MenuItem> { DigiRestaurant.MenuItems[2], DigiRestaurant.MenuItems[3] }, 2));
            DigiRestaurant.createOrder(new Order(new List<MenuItem> { DigiRestaurant.MenuItems[0], DigiRestaurant.MenuItems[2] }, 3));

            DigiRestaurant.ShowOrders();

            DigiRestaurant.ShowOrderCount();

            DigiRestaurant.ShowNextOrder();

            DigiRestaurant.HandleOrder();

            DigiRestaurant.ShowOrders();

            DigiRestaurant.createOrder(new Order(new List<MenuItem> { DigiRestaurant.MenuItems[1], DigiRestaurant.MenuItems[3] }, 4));

            DigiRestaurant.ShowOrders();

            DigiRestaurant.HandleOrder();
            DigiRestaurant.HandleOrder();

            DigiRestaurant.ShowNextOrder();

            DigiRestaurant.HandleOrder();

            DigiRestaurant.ShowOrders();
        }


    }
}
