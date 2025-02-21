﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Backtester.Contracts.Services;
using Backtester.Views;

namespace Backtester.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool isBackEnabled;
    [ObservableProperty]
    private object? selectedNavigationViewItem;

    public INavigationService NavigationService { get; }
    public INavigationViewService NavigationViewService { get; }

    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        if (e.SourcePageType == typeof(SettingsPage))
        {
            SelectedNavigationViewItem = NavigationViewService.SettingsItem;
            return;
        }

        NavigationViewItem? selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem != null)
        {
            SelectedNavigationViewItem = selectedItem;
        }
    }
}
