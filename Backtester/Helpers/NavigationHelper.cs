﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Backtester.Helpers;

// Helper class to set the navigation target for a NavigationViewItem.
//
// Usage in XAML:
// <NavigationViewItem x:Uid="Shell_Main" Icon="Document" helpers:NavigationHelper.NavigateTo="AppName.ViewModels.MainViewModel" />
//
// Usage in code:
// NavigationHelper.SetNavigateTo(navigationViewItem, typeof(MainViewModel).FullName);
public class NavigationHelper
{
    public static Type GetNavigateTo(NavigationViewItem item)
        => (Type)item.GetValue(NavigateToProperty);

    public static void SetNavigateTo(NavigationViewItem item, Type value)
        => item.SetValue(NavigateToProperty, value);

    public static readonly DependencyProperty NavigateToProperty =
        DependencyProperty.RegisterAttached(
            "NavigateTo",
            typeof(Type),
            typeof(NavigationHelper),
            new PropertyMetadata(null));
}
