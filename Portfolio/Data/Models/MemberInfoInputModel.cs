using Portfolio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Models
{
    public class MemberInfoInputModel
    {
        /// <summary>
        /// 氏名
        /// </summary>
        [Required(ErrorMessage = "氏名（姓）は必須です。")]
        public string FirstName { get; set; }

        /// <summary>
        /// 氏名
        /// </summary>
        [Required(ErrorMessage = "氏名（名）は必須です。")]
        public string LastName { get; set; }

        /// <summary>
        /// 氏名（読み）
        /// </summary>
        [Required(ErrorMessage = "ふりがな（姓）は必須です。")]
        public string FirstNameYomi { get; set; }

        /// <summary>
        /// 氏名（読み）
        /// </summary>
        [Required(ErrorMessage = "ふりがな（名）は必須です。")]
        public string LastNameYomi { get; set; }

        /// <summary>
        /// 誕生日
        /// </summary>
        public string Birth { get; set; } = "1990/01/01";

        /// <summary>
        /// 性別
        /// </summary>
        public Gender Gender { get; set; } = Gender.Male;

        /// <summary>
        /// 電話番号
        /// </summary>
        [Required(ErrorMessage = "電話番号は必須です。")]
        public string PhoneNumber { get; set; }

        public string GenderText
        {
            get
            {
                switch(Gender)
                {
                    case Gender.Male:
                        return "男性";
                    case Gender.Female:
                        return "男性";
                    case Gender.PreferNotToSay:
                        return "回答しない";
                    default:
                        return "";
                }
            }
        }
    }
}
