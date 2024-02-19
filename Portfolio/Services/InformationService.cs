using Amazon.SecurityToken.Model;
using Portfolio.Data.Models;

namespace Portfolio.Services
{
    /// <summary>
    /// お知らせ情報用のサービス
    /// </summary>
    public class InformationService
    {
        /// <summary>
        /// お知らせ情報取得
        /// </summary>
        /// <returns></returns>
        public InformationModel GetInformation()
        {
            // 情報アイテムのリストを作成
            var informationItems = new List<InformationItem>
        {
            new InformationItem
            {
                InformationTitle = "重要なお知らせ",
                InformationText = "システムメンテナンスのため、明日10:00から12:00までサービスを停止します。",
                RegistDate = new DateTime(2024, 2, 15),
                UpdateDate = new DateTime(2024, 2, 16)
            },
            new InformationItem
            {
                InformationTitle = "新機能のリリース",
                InformationText = "新しい機能が追加されました。詳細はこちらをご覧ください。",
                RegistDate = new DateTime(2024, 2, 10),
                UpdateDate = new DateTime(2024, 2, 11)
            }
        };

            // 情報モデルを作成
            var informationModel = new InformationModel
            {
                InformationList = informationItems
            };

            return informationModel;
        }
    }
}
