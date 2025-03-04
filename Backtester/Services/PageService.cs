﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Backtester.Contracts.Services;
using Backtester.ViewModels.Pages;
using Backtester.Views.Pages;

namespace Backtester.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> pages = new();

    public PageService()
    {
        Configure<MainPageViewModel, MainPage>();
        Configure<LogPageViewModel, LogPage>();
        Configure<SettingsPageViewModel, SettingsPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (pages)
        {
            if (!pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    public Type GetPageType(Type viewModelType)
    {
        string key = viewModelType.FullName!;
        return GetPageType(key);
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (pages)
        {
            string key = typeof(VM).FullName!;
            if (pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            Type type = typeof(V);
            if (pages.ContainsValue(type))
            {
                throw new ArgumentException($"This type is already configured with key {pages.First(p => p.Value == type).Key}");
            }

            pages.Add(key, type);
        }
    }
}
