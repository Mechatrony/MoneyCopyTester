﻿using CommunityToolkit.Mvvm.ComponentModel;
using Meziantou.Framework.WPF.Collections;
using Backtester.Models;

namespace Backtester.ViewModels;

public class LogViewerViewModel : ObservableObject
{
    public static IReadOnlyObservableCollection<LogEntry> LogEntries => Logger.LogEntries.AsObservable;

    public LogViewerViewModel()
    {
    }
}
