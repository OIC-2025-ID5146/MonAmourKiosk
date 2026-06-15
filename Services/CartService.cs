using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using MonAmourKiosk.Models;

namespace MonAmourKiosk.Services;

public partial class CartService : ObservableObject, ICartService
{
    public ObservableCollection<OrderItem> Items { get; } = new();

    public decimal SubTotal => Items.Sum(item => item.Price * item.Quantity);
    public decimal Tax => SubTotal * 0.10m; // TVA Restauration Standard Kiosque 10%
    public decimal Total => SubTotal + Tax;

    public void AddProduct(Product product, int quantity = 1)
    {
        var existing = Items.FirstOrDefault(i => i.ProductId == product.Id);
        if (existing != null)
        {
            existing.Quantity += quantity;
        }
        else
        {
            Items.Add(new OrderItem { ProductId = product.Id, Product = product, Quantity = quantity, Price = product.Price });
        }
        NotifyCartProperties();
    }

    public void RemoveProduct(Product product)
    {
        var existing = Items.FirstOrDefault(i => i.ProductId == product.Id);
        if (existing != null)
        {
            existing.Quantity--;
            if (existing.Quantity <= 0) Items.Remove(existing);
        }
        NotifyCartProperties();
    }

    public void ClearCart()
    {
        Items.Clear();
        NotifyCartProperties();
    }

    private void NotifyCartProperties()
    {
        OnPropertyChanged(nameof(SubTotal));
        OnPropertyChanged(nameof(Tax));
        OnPropertyChanged(nameof(Total));
        OnPropertyChanged(nameof(Items));
    }
}