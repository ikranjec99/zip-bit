using System.Text.Json;
using System.Text;

namespace ZipBit.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the input string with the first char in lowercase
        /// </summary>
        public static string FirstCharToLower(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return $"{input.First().ToString().ToLower()}{input.Substring(1)}";
        }

        /// <summary>
        /// Returns first line of the input string
        /// </summary>
        public static string FirstLine(this string input)
        {
            if (string.IsNullOrEmpty(input) || input.IndexOfAny(new char[] { '\n' }) == -1)
                return input;

            return input.Substring(0, input.IndexOfAny(new char[] { '\n' })).Replace("\r", string.Empty);
        }

        /// <summary>
        /// Decodes a base 64 encoded string
        /// </summary>
        public static string FromBase64(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            byte[] bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Removes characters that are not allowed from string
        /// </summary>
        public static string RemoveUnAllowedCharacters(this string input, char[] unAllowedCharacters) => input.Trim(unAllowedCharacters);

        /// <summary>
        /// Encodes a string to base 64
        /// </summary>
        public static string ToBase64(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Returns string in camel case format
        /// </summary>
        public static string ToCamelCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return JsonNamingPolicy.CamelCase.ConvertName(input);
        }

        /// <summary>
        /// Truncate string if longer than max length
        /// </summary>
        public static string Truncate(this string input, int maxLength)
        {
            if (input.Length > maxLength)
                return input.Substring(0, maxLength);

            return input;
        }
    }
}
