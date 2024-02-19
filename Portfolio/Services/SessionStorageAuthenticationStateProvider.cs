using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace Portfolio.Services
{
    /// <summary>
    /// 認証状態管理クラス
    /// </summary>
    public class SessionStorageAuthenticationStateProvider : AuthenticationStateProvider
    {
        /// <summary>
        /// 非認証時の遷移状態
        /// </summary>
        private static readonly AuthenticationState UnauthorizedAuthenticationState = new AuthenticationState(new ClaimsPrincipal());

        /// <summary>
        /// 認証情報
        /// </summary>
        private ClaimsPrincipal? principal;

        /// <summary>
        /// セッションストレージ
        /// </summary>
        private readonly ProtectedSessionStorage protectedSessionStorage;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="protectedSessionStorage"></param>
        public SessionStorageAuthenticationStateProvider(ProtectedSessionStorage protectedSessionStorage)
        {
            this.protectedSessionStorage = protectedSessionStorage;
        }

        /// <summary>
        /// 認証遷移状態を取得
        /// </summary>
        /// <returns></returns>
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (principal is null)
            {
                return Task.FromResult(UnauthorizedAuthenticationState);
            }

            return Task.FromResult(new AuthenticationState(principal));
        }

        /// <summary>
        /// セッションストレージから認証情報を読み込み
        /// </summary>
        /// <returns>読み込み成功有無 true:成功 false:失敗</returns>
        public async Task<bool> LoadAuthenticationStateAsync()
        {
            try
            {
                var resultAccessToken = await protectedSessionStorage.GetAsync<string>("accessToken");
                var resultMailAddress = await protectedSessionStorage.GetAsync<List<string>>("mailaddress");

                if (resultAccessToken.Success && resultMailAddress.Success)
                {
                    var accessToken = resultAccessToken.Value!;
                    var mailAddress = resultMailAddress.Value!;

                    List<Claim> claimList = new();

                    // 名前追加
                    claimList.Add(new Claim(ClaimTypes.Name, accessToken));
                    foreach (var value in mailAddress)
                    {
                        claimList.Add(new Claim(ClaimTypes.Email, value));
                    }

                    await UpdateLoginStatusAsync(new ClaimsPrincipal(
                        new ClaimsIdentity(
                            claimList.ToArray(),
                            "Custom"
                        )
                    ));

                    return true;
                }

                return false;
            }
            catch (Exception ex) 
            {
                return false;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            
        }

        /// <summary>
        /// メールアドレス取得
        /// </summary>
        /// <returns></returns>
        public string GetEmail()
        {
            if (principal == null)
            {
                return string.Empty;
            }

            var emailClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            return emailClaim?.Value ?? string.Empty;
        }


        /// <summary>
        /// ログイン情報更新
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public async Task UpdateLoginStatusAsync(ClaimsPrincipal? principal)
        {
            this.principal = principal;
            if (principal?.Identity?.IsAuthenticated ?? false)
            {
                await protectedSessionStorage.SetAsync("accessToken", principal.Identity.Name!);
                var mailClaims = principal.FindAll(ClaimTypes.Email);
                var mailValues = mailClaims.Select(claim => claim.Value).ToList();
                await protectedSessionStorage.SetAsync("mailaddress", mailValues);
            }
            else
            {
                await protectedSessionStorage.DeleteAsync("accessToken");
                await protectedSessionStorage.DeleteAsync("mailaddress");
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        /// <summary>
        /// アクセストークンを取得
        /// </summary>
        /// <returns></returns>
        public string GetAccessToken()
        {
            if (principal == null)
            {
                return string.Empty;
            }

            var userName = principal?.Identity?.Name ?? string.Empty;

            return userName;
        }
    }
}
