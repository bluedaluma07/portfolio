using Portfolio.Components.Validation.Base;
using System.Text.RegularExpressions;

namespace Portfolio.Components.Validation
{
    public class CustomPasswordValidator : FieldValidatorBase<string>
    {
        protected override bool ValidateValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                // 半角英数字 + 記号のみで構成されているかどうか
                if (!Regex.IsMatch(value!, @"^[!-~]*$"))
                {
                    return false;
                }

                // 8文字以上を満たしているか？
                if (!Regex.IsMatch(value!, @"[!-~]{8,}"))
                {
                    return false;
                }

                if (!Regex.IsMatch(value!, @"[A-Z]"))
                {
                    return false;
                }

                if (!Regex.IsMatch(value!, @"[a-z]"))
                {
                    return false;
                }

                if (!Regex.IsMatch(value!, @"[0-9]"))
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
