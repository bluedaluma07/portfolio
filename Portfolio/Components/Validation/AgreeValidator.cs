using Portfolio.Components.Validation.Base;

namespace Portfolio.Components.Validation
{
    public class AgreeValidator : FieldValidatorBase<bool>
    {
        protected override bool ValidateValue(bool value)
        {
            return value;
        }
    }
}
