using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonAmourKiosk.Services;

namespace MonAmourKiosk.ViewModels;

public partial class AccueilViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public AccueilViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    private void Commencer()
    {
        _navigationService.NavigateTo<MenuViewModel>();
    }
}