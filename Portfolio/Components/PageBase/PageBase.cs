using Portfolio.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace Portfolio.Components.PageBase;

public class PageBase : ComponentBase
{
    [Inject]
    SessionStorageAuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected BrowserHistoryService BrowserHistoryService { get; set; }

    // ローディング状態の管理
    protected bool IsLoading { get; set; } = true;

    protected string MailAddress { get; set; }

    protected string AccessToken { get; set; }

    protected int MemberNo { get; set; }

    protected sealed override void OnInitialized()
    {
        try
        {
            OnInitializedPre();
        }
        catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }

    protected virtual void OnInitializedPre()
    {
        
    }

    protected override sealed async Task OnInitializedAsync()
    {
        try
        {
            IsLoading = true; // ローディング開始

            var result = await AuthenticationStateProvider.LoadAuthenticationStateAsync();

            await OnInitializedPreAsync();

            IsLoading = false; // ローディング終了
        }
        catch (Exception e)
        {
            IsLoading = false; // ローディング終了
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }

    protected virtual async Task OnInitializedPreAsync()
    {
        await Task.Run(() => { });
    }

    protected override sealed async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            if (firstRender)
            {
                // ハンバーガーメニューの設定
                await JSRuntime.InvokeVoidAsync("setupHamburgerMenu");
            }

            await OnAfterRenderFirstAsync();

            // モーダルの設定
            await JSRuntime.InvokeVoidAsync("setupModal");

            // セレクトボックスの動作設定
            await JSRuntime.InvokeVoidAsync("setupSelectBoxes");

            // タブの動作設定
            await JSRuntime.InvokeVoidAsync("setupTabs");
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }

    protected virtual async Task OnAfterRenderFirstAsync()
    {
        await Task.Run(() => { });
    }


    protected RenderFragment RenderLoading() => builder =>
    {
        if (IsLoading)
        {
            builder.OpenComponent(0, typeof(Loading));
            builder.CloseComponent();
        }
    };

    /// <summary>
    /// ログアウト処理
    /// </summary>
    /// <returns></returns>
    protected async Task LogoutAsync()
    {
        await AuthenticationStateProvider.UpdateLoginStatusAsync(null);
    }

    /// <summary>
    /// マイページに戻る
    /// </summary>
    protected void NavigateToMyPage()
    {
        NavigationManager.NavigateTo("/");
    }
}
