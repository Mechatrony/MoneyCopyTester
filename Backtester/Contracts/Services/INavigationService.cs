using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace Backtester.Contracts.Services;

public interface INavigationService
{
    event NavigatedEventHandler Navigated;

    bool CanGoBack { get; }

    Frame? Frame { get; set; }

    bool NavigateTo(Type toPageType, object? parameter = null, bool clearNavigation = false);

    bool GoBack();

    void SetListDataItemForNextConnectedAnimation(object item);
}
