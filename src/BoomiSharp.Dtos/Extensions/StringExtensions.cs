using System;
using System.Text;

namespace BoomiSharp.Dtos.Extensions
{
    internal static class StringExtensions
    {
        internal static string ToCamelCase(this string value)
        {
            if (value == null)
            {
                return null;
            }

            var builder = new StringBuilder(value.Length);
            builder.Append(char.ToLower(value[0]));
            for (int i = 1; i < value.Length; i++)
            {
                builder.Append(value[i]);
            }

            return builder.ToString();
        }

        internal static string ToProperCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var builder = new StringBuilder(value.Length);
            builder.Append(char.ToUpper(value[0]));
            for (int i = 1; i < value.Length; i++)
            {
                builder.Append(char.ToLower(value[i]));
            }

            return builder.ToString();
        }
        
        internal static string ToSnakeCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var builder = new StringBuilder(value.Length);
            builder.Append(value[0]);
            for (int i = 1; i < value.Length; i++)
            {
                if (char.IsUpper(value[i]))
                {
                    builder.Append("_");
                }
                builder.Append(value[i]);
            }

            return builder.ToString();
        }

        internal static string[] Split(this string value, string separator, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            if (value == null)
            {
                return new string[0];
            }

            return value.Split(new string[] { separator }, options);
        }
    }
}
