using System;

class Program
{
    static void Main(string[] args)
    {
        // First customer and address (USA)
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LP1001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MS2002", 25.50, 2));

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Order 1 Total Price: ${order1.CalculateTotalPrice():0.00}\n");

        // Second customer and address (Zimbabwe)
        Address address2 = new Address("45 Samora Machel Ave", "Harare", "Harare Province", "Zimbabwe");
        Customer customer2 = new Customer("Tendai Chikafu", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Electric Kettle", "EK3003", 35.75, 1));
        order2.AddProduct(new Product("Cooking Pot", "CP4004", 25.25, 2));
        order2.AddProduct(new Product("Notebook", "NB5005", 5.99, 3));

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Order 2 Total Price: ${order2.CalculateTotalPrice():0.00}");
    }
}
