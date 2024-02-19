using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Models
{
    public class LoginInputVerificationModel
    {
        [Required(ErrorMessage = "メールアドレスは必須です。")]
        public string? MailAddress { get; set; } = "portfolio@sample.com";

        [Required(ErrorMessage = "パスワードは必須です。")]
        public string? Password { get; set; } = "Password1234";
    }
}
