using System.ComponentModel.DataAnnotations;

namespace Utils.Validators;

public class EnumStringValidationAttribute : ValidationAttribute
{
    private readonly Type _enumType;

    public EnumStringValidationAttribute(Type enumType)
    {
        _enumType = enumType;
    }

    public override bool IsValid(object value)
    {
        if (value == null) return true;

        return Enum.IsDefined(_enumType, value.ToString());
    }
}
