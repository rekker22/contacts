using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Contacts.Core.Interfaces;
using Contacts.Desktop.ViewModels;
using Contacts.Desktop.Views;
using Contacts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Desktop;

public class App : Application
{
    public override void Initialize()
    {
        Services = ConfigureServices();
        AvaloniaXamlLoader.Load(this);
    }
    
    public new static App Current => (App)Application.Current!;
    
    public IServiceProvider Services { get; private set; } = null!;

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<IContactsService, ContactsService>();

        return services.BuildServiceProvider();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}