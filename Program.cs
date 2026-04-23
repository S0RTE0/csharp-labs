namespace Program
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public Address(string city, string street, string zipCode)
        {
            City = city;
            Street = street;
            ZipCode = zipCode;
        }

        public string GetFullAddress()
        {
            return $"{Street}, {City}, {ZipCode}";
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
    
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address DeliveryAddress { get; set; }

        public Customer(string firstName, string lastName, string email, Address deliveryAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DeliveryAddress = deliveryAddress;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
    
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        
        private List<Product> _products;

        public Order(int orderNumber, Customer customer)
        {
            OrderNumber = orderNumber;
            Date = DateTime.Now;
            Customer = customer;
            _products = new List<Product>();
        }
        
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (Product product in _products)
            {
                total += product.Price;
            }
            return total;
        }

        public void PrintReceipt()
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Order Number: {OrderNumber}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine("----------------------------------------");
            
            Console.WriteLine("CUSTOMER DETAILS:");
            Console.WriteLine($"Name: {Customer.GetFullName()}");
            Console.WriteLine($"Email: {Customer.Email}");
            Console.WriteLine($"Delivery Address: {Customer.DeliveryAddress.GetFullAddress()}");
            Console.WriteLine("----------------------------------------");
            
            Console.WriteLine("ITEMS ORDERED:");
            foreach (Product product in _products)
            {
                Console.WriteLine($"- {product.Name} ({product.Category}): ${product.Price}");
            }
            Console.WriteLine("----------------------------------------");
            
            Console.WriteLine($"TOTAL TO PAY: ${CalculateTotal()}");
            Console.WriteLine("========================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Address myAddress = new Address("Lviv", "Builders St. 22", "15000");
            
            Customer myCustomer = new Customer("Babrian", "Bibuh", "bibuh@email.com", myAddress);
            
            Order myOrder = new Order(1001, myCustomer);
            
            Product p1 = new Product("Wireless Mouse", 25.50m, "Electronics");
            Product p2 = new Product("Mechanical Keyboard", 80.00m, "Electronics");
            Product p3 = new Product("Mousepad", 15.00m, "Accessories");

            myOrder.AddProduct(p1);
            myOrder.AddProduct(p2);
            myOrder.AddProduct(p3);
            
            myOrder.PrintReceipt();

        }
    }
}
