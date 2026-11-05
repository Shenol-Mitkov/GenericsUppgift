namespace GenericsUppg.Entities
{
    internal class Order
    {
        static int orderIdCounter = 1;
        private int _orderId;
        private List<MenuItem> _orderItems;
        private int _tableNumber;

        public Order(List<MenuItem> orderItems, int tableNumber)
        {
            _orderId = orderIdCounter;
            orderIdCounter++;
            _orderItems = orderItems;
            _tableNumber = tableNumber;
        }

        public int OrderId => _orderId;
        public int TableNumber => _tableNumber;
        public List<MenuItem> OrderItems => _orderItems;

        // Räknar ut totalpriset för alla rätter i beställningen
        public decimal TotalPrice()
        {
            decimal total = 0;
            foreach (var item in _orderItems)
            {
                total += item.Price;
            }
            return total;
        }

        // Skriver ut beställningen till konsolen (används av Restaurant)
        public void PrintOrder()
        {
            Console.WriteLine($"Order #{_orderId} - Bord {_tableNumber}");
            foreach (var item in _orderItems)
            {
                Console.WriteLine($"   * {item}");
            }
            Console.WriteLine($"   Totalt: {TotalPrice():C}");
        }
    }
}
