using CommunityToolkit.Mvvm.ComponentModel;
using MonAmourKiosk.Services;

namespace MonAmourKiosk.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private INavigationService _navigation;

    public MainViewModel(INavigationService navigationService)
    {
        _navigation = navigationService;
        _navigation.NavigateTo<AccueilViewModel>();
    }
}