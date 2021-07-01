using System;
using System.Linq;

namespace CGZT.School.Demo.Common
{
    /// <summary>
    /// remove spaces
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Trims the string properties.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static T TrimStringProperties<T>(this T input)
        {
            var stringProperties = input.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProperty in stringProperties)
            {
                string currentValue = (string)stringProperty.GetValue(input, null);
                if (currentValue != null)
                    stringProperty.SetValue(input, currentValue.Trim(), null);
            }
            return input;
        }

    }

}
