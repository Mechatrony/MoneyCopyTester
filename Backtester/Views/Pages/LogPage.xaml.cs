using Microsoft.UI.Xaml.Controls;
using Backtester.ViewModels.Pages;

namespace Backtester.Views.Pages;

public sealed partial class LogPage : Page
{
    public LogPage()
    {
        DataContext = App.GetService<LogPageViewModel>();
        InitializeComponent();
    }
}
