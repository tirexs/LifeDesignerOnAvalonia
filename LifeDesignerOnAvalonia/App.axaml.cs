using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LifeDesignerOnAvalonia.Services;
using LifeDesignerOnAvalonia.ViewModels;
using LifeDesignerOnAvalonia.Views;

namespace LifeDesignerOnAvalonia;

public partial class App : Application
{

    private ItemsCollectionService _service = new ItemsCollectionService();


    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow() { DataContext = new MainWindowViewModel(_service)};
        }
        

        base.OnFrameworkInitializationCompleted();
    }
}
