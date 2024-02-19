using Portfolio.Data.Models;
using System.Diagnostics;

namespace Portfolio.Services
{
    /// <summary>
    /// クレジットカード用サービス
    /// </summary>
    public class CreditCardService
    {
        public List<CreditCard> CreditCards { get; private set; } = new List<CreditCard>(); 

        public CreditCardService()
        {
            CreditCards.Add(
                new CreditCard()
                {
                    CardNumber = "1234-5678-1234-5678",
                    ExpireDate = DateTime.Now.AddYears(3),
                    SecurityNumber = "123"
                }
            );
        }

        /// <summary>
        /// クレジットカード追加
        /// </summary>
        public bool AddCard(CreditCardInputModel input)
        {
            try
            {
                var cardFormat = string.Join("-", Enumerable.Range(0, input.CardNumber.Length / 4)
                                          .Select(i => input.CardNumber.Substring(i * 4, 4)));

                CreditCard creditCard = new CreditCard()
                {
                    CardNumber = cardFormat,
                    ExpireDate = input.GetExpireDate(),
                    SecurityNumber = input.SecurityNumber,
                };

                CreditCards.Add(creditCard);

                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// クレジットカード除去
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool RemoveCard(CreditCard card)
        {
            try
            {
                return CreditCards.Remove(card);
            }
            catch(Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 伏字用に-で区切った4番目の値を取得
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public string? GetFourthNumber(CreditCard card)
        {
            var fourthNumber = card.CardNumber.Split('-')[3];

            return fourthNumber;
        }
    }
}
