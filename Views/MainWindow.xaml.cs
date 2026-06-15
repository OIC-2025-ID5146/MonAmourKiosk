using System.Windows;
using MonAmourKiosk.ViewModels;

namespace MonAmourKiosk.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}