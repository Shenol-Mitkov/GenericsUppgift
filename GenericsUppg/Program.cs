using GenericsUppg.Entities;
using System.Security.Cryptography.X509Certificates;

namespace GenericsUppg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurant Menu = new Restaurant();
            Menu.AddToMenu(new MenuItem(1, "Pizza", 99.99m));

            Restaurant Request = new Restaurant();
            Request.createOrder(new Order(new List<MenuItem> { new MenuItem(1, "Pizza", 99.99m) }, 1));


            Restaurant restaurant = new Restaurant();
            restaurant.ShowOrderCount();




            Console.ReadLine();
        }



    }

}
