using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonAmourKiosk.Data;
using MonAmourKiosk.Models;
using MonAmourKiosk.Services;

namespace MonAmourKiosk.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    private readonly BistroContext _context;
    private readonly IRecommendationService _recommendationService;
    private readonly INavigationService _navigationService;

    public ICartService CartService { get; }

    [ObservableProperty] private ObservableCollection<Product> _filteredProducts = new();
    [ObservableProperty] private string _selectedCategory = "☕ Café";
    [ObservableProperty] private bool _isRecommendationPopupOpen;
    [ObservableProperty] private ObservableCollection<Product> _currentRecommendations = new();
    [ObservableProperty] private Product? _selectedCoffeeContext;

    public MenuViewModel(BistroContext context, ICartService cartService, IRecommendationService recommendationService, INavigationService navigationService)
    {
        _context = context;
        CartService = cartService;
        _recommendationService = recommendationService;
        _navigationService = navigationService;
        LoadCategory("Café");
    }

    [RelayCommand]
    public void FilterCategory(string category)
    {
        SelectedCategory = category;
        string raw = category.Replace("☕ ", "").Replace("🥐 ", "").Replace("🍽 ", "").Replace("🧁 ", "");
        LoadCategory(raw);
    }

    private void LoadCategory(string rawCategory)
    {
        var items = _context.Products
            .Where(p => p.Category == rawCategory && p.StockQuantity > 0)
            .ToList();
        FilteredProducts = new ObservableCollection<Product>(items);
    }

    [RelayCommand]
    public void HandleProductSelection(Product product)
    {
        if (product.Category == "Café")
        {
            SelectedCoffeeContext = product;
            var recs = _recommendationService.GetRecommendationsForCoffee(product.Id);
            if (recs.Any())
            {
                CurrentRecommendations = new ObservableCollection<Product>(recs);
                IsRecommendationPopupOpen = true;
                return;
            }
        }
        CartService.AddProduct(product);
    }

    [RelayCommand]
    public void AddRecommendedAndClose(Product product)
    {
        if (SelectedCoffeeContext != null) CartService.AddProduct(SelectedCoffeeContext);
        CartService.AddProduct(product);
        IsRecommendationPopupOpen = false;
    }

    [RelayCommand]
    public void ClosePopupOnly()
    {
        if (SelectedCoffeeContext != null) CartService.AddProduct(SelectedCoffeeContext);
        IsRecommendationPopupOpen = false;
    }

    [RelayCommand]
    public void CompleteCheckout()
    {
        if (CartService.Items.Any()) _navigationService.NavigateTo<CheckoutViewModel>();
    }
}