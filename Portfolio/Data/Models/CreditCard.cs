namespace Portfolio.Data.Models
{
    /// <summary>
    /// クレジットカード
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// カード番号
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 有効日付
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// セキュリティ番号
        /// </summary>
        public string SecurityNumber { get; set; }
    }
}
