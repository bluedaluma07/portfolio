using Portfolio.Components.Validation.Base;

namespace Portfolio.Components.Validation
{
    public class RequiredValidator : FieldValidatorBase<string>
    {
        protected override bool ValidateValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
