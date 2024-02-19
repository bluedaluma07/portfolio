using System.Security.Claims;

namespace Portfolio.Services
{
    /// <summary>
    /// 認証サービス
    /// </summary>
    public class CertificationService
    {
        readonly SessionStorageAuthenticationStateProvider _authenticationStateProvider;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="authenticationStateProvider"></param>
        public CertificationService(SessionStorageAuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        /// <summary>
        /// ログイン処理
        /// </summary>
        /// <param name="mailAddress">メールアドレス</param>
        /// <param name="password">パスワード</param>
        /// <returns>ログインの結果</returns>
        public async Task<bool> LoginAsync(string mailAddress, string password)
        {
            // パスワード正しいかを確認
            if(mailAddress == "portfolio@sample.com" && password == "Password1234")
            {
                // Blazor上でログイン状態にする
                await _authenticationStateProvider.UpdateLoginStatusAsync
                (
                    new ClaimsPrincipal
                    (
                        new ClaimsIdentity
                        (
                            new Claim[]
                            {
                                new (ClaimTypes.Name, mailAddress!),
                            },
                            "TestUser"
                        )
                    )
                );

                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
