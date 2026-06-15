using CommunityToolkit.Mvvm.ComponentModel;

namespace MonAmourKiosk.Services;

public interface INavigationService
{
    ObservableObject? CurrentView { get; }
    void NavigateTo<T>() where T : ObservableObject;
}