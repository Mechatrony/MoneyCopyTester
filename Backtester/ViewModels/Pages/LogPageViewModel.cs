using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester.ViewModels.Pages;

public partial class LogPageViewModel : ObservableObject
{
    [ObservableProperty]
    public partial string Title { get; set; } = "Log Page";
}
