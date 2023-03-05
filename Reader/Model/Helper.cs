namespace Reader.Model
{
    internal class Helper
    {
        internal static bool IsIndexInArray(int index, object[] array)
        {
            return array.Length > index && index >= 0;
        }

        internal static bool IsObjectInArray(object value, object[] array, Type arrayType)
        {
            return array.Contains(Convert.ChangeType(value, arrayType));
        }

        internal static bool IsIntBetween(int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        internal static bool IsStringEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        internal static bool IsStringLengthBetween(string value, int min, int max)
        {
            return value.Length >= min && value.Length <= max;
        }
    }
}
