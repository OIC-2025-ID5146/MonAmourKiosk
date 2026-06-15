using System.Collections.ObjectModel;
using MonAmourKiosk.Models;

namespace MonAmourKiosk.Services;

public interface ICartService
{
    ObservableCollection<OrderItem> Items { get; }
    decimal SubTotal { get; }
    decimal Tax { get; }
    decimal Total { get; }
    void AddProduct(Product product, int quantity = 1);
    void RemoveProduct(Product product);
    void ClearCart();
}