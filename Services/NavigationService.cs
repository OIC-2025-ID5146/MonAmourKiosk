using CommunityToolkit.Mvvm.ComponentModel;

namespace MonAmourKiosk.Services;

public partial class NavigationService : ObservableObject, INavigationService
{
    private readonly Func<Type, ObservableObject> _viewModelFactory;

    [ObservableProperty]
    private ObservableObject? _currentView;

    public NavigationService(Func<Type, ObservableObject> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<T>() where T : ObservableObject
    {
        CurrentView = _viewModelFactory(typeof(T));
    }
}