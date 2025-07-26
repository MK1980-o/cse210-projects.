using System.Collections.Generic;
using System.Text;

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

    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (Product p in _products)
        {
            total += p.TotalCost();
        }
        total += ShippingCost();
        return total;
    }

    private double ShippingCost()
    {
        return _customer.LivesInUSA() ? 5.0 : 35.0;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Product p in _products)
        {
            sb.AppendLine($"{p.Name} (ID: {p.ProductId})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address}";
    }
}