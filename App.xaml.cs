using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MonAmourKiosk.Data;
using MonAmourKiosk.Services;
using MonAmourKiosk.ViewModels;
using MonAmourKiosk.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MonAmourKiosk;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var services = new ServiceCollection();

        // Enregistrement de la base de données
        services.AddDbContext<BistroContext>();

        // Enregistrement des services métier de base
        services.AddSingleton<ICartService, CartService>();
        services.AddTransient<IRecommendationService, RecommendationService>();

        // Orchestration du système de navigation MVVM
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ObservableObject>>(provider =>
            viewModelType => (ObservableObject)provider.GetRequiredService(viewModelType));

        // Enregistrement des modèles de vue (ViewModels)
        services.AddSingleton<MainViewModel>();
        services.AddTransient<AccueilViewModel>();
        services.AddTransient<MenuViewModel>();
        services.AddTransient<CheckoutViewModel>();

        // Initialisation de l'interface graphique principale
        services.AddSingleton<MainWindow>();

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        // Initialisation et déploiement des données initiales de démonstration (Seeding)
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BistroContext>();
            SeedData.Initialize(dbContext);
        }

        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }
}