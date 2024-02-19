using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Portfolio.Services;

public class BrowserHistoryService : IDisposable
{
    private readonly NavigationManager _navigationManager;
    public List<string> History { get; private set; } = new List<string>();

    public BrowserHistoryService(NavigationManager navigationManager, IJSRuntime jsRuntime)
    {
        _navigationManager = navigationManager;

        // NavigationManagerのLocationChangedイベント
        _navigationManager.LocationChanged += HandleLocationChanged;
    }

    private void HandleLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        // URL履歴に追加
        History.Add(e.Location);
    }

    public void Dispose()
    {
        _navigationManager.LocationChanged -= HandleLocationChanged;
    }
}
