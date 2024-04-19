using System.Text.Json;
using EnigmaAPI.Entities;

namespace EnigmaAPI.Extensions;

public static class IStringExtensions
{
    public static string AnonymizeByConfig(this string value, FieldVisibilityValues config)
    {
        if (config == FieldVisibilityValues.Masked) return "######";
        if (config == FieldVisibilityValues.Hashed)
        {
            var hashedValue = System.Text.Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(hashedValue);
        }

        return value;
    }

    public static bool IsValidJSON(this string value)
    {
        try
        {
            JsonDocument.Parse(value);

            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}
