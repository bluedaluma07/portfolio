using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Models
{
    public class CreditCardInputModel
    {
        /// <summary>
        /// カード番号
        /// </summary>
        [Required(ErrorMessage = "カード番号は必須です。")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "カード番号は16桁の数字である必要があります。")]
        public string CardNumber { get; set; }

        /// <summary>
        /// 有効日付月
        /// </summary>
        [Required(ErrorMessage = "有効期限（月）は必須です。")]
        public string ExpireDateMonth { get; set; }

        /// <summary>
        /// 有効日付年
        /// </summary>
        [Required(ErrorMessage = "有効期限（年）は必須です。")]
        public string ExpireDateYear { get; set; }

        /// <summary>
        /// セキュリティ番号
        /// </summary>
        [RegularExpression(@"^\d{3}$", ErrorMessage = "カード番号は3桁の数字である必要があります。")]
        public string SecurityNumber { get; set; }

        /// <summary>
        /// 有効期限のDateTimeを生成するヘルパーメソッド
        /// </summary>
        /// <returns></returns>
        public DateTime GetExpireDate()
        {
            try
            {
                var year = int.Parse(ExpireDateYear);
                var month = int.Parse(ExpireDateMonth);
                return new DateTime(year, month, 1);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
    }
}
