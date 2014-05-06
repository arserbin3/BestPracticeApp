namespace BestPracticeApp.Helpers
{
    using System;
    using System.ComponentModel;

    public static class EnumerationHelper
    {
        /// <summary>
        /// Gets the value of the Description data attribute on an Enum value.
        /// </summary>
        /// <param name="value">Enum value</param>
        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            return (attributes.Length > 0 ? attributes[0].Description : value.ToString());
        }
    }
}