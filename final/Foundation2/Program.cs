using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, string productId, double price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
}

public class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public string GetFullAddress()
    {
        return $"{StreetAddress}, {City}, {StateProvince}, {Country}";
    }
}

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.Country == "USA";
    }
}

public class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.Price * product.Quantity;
        }
        totalPrice += Customer.IsInUSA() ? 5 : 35; // Shipping cost
        return totalPrice;
    }

    public string GeneratePackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"- {product.Name}, ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GenerateShippingLabel()
    {
        return $"Shipping Label:\n{Customer.Name}\n{Customer.Address.GetFullAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating products
        Product product1 = new Product("Product 1", "P001", 10.50, 2);
        Product product2 = new Product("Product 2", "P002", 15.75, 1);

        // Creating customer
        Address address = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer = new Customer("John Doe", address);

        // Creating order
        List<Product> products = new List<Product> { product1, product2 };
        Order order = new Order(products, customer);

        // Displaying order information
        Console.WriteLine(order.GeneratePackingLabel());
        Console.WriteLine(order.GenerateShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalPrice()}");

    }
}