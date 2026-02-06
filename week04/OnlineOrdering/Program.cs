using System;
using System.Collections.Generic;

// Product class
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}

// Address class
public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country == "USA";
    }

    public string GetAddress()
    {
        return _street + "\n" + _city + ", " + _state + "\n" + _country;
    }
}

// Customer class
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return _name + "\n" + _address.GetAddress();
    }
}

// Order class
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product product in _products)
        {
            label += product.GetName() + " - " + product.GetProductId() + "\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetShippingLabel();
    }
}

// Program class
class Program
{
    static void Main(string[] args)
    {
        // First order (USA)
        Address address1 = new Address("123 Main St", "Phoenix", "AZ", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "A100", 3.50, 4));
        order1.AddProduct(new Product("Pen", "A101", 1.25, 6));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalCost());
        Console.WriteLine();

        // Second order (International)
        Address address2 = new Address("45 King Street", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Emily Chen", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "B200", 45.00, 1));
        order2.AddProduct(new Product("Water Bottle", "B201", 12.99, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalCost());
    }
}
