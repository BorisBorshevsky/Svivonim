using System.ComponentModel;
using System.Reflection;

namespace Infrastructure.Common
{
    public static class Common
    {
        public static string GetDescription<T>(this T i_Source)
        {
            string result;
            FieldInfo fieldInfo = i_Source.GetType().GetField(i_Source.ToString());
            DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Length > 0)
            {
                result = attributes[0].Description;
            }
            else
            {
                result = i_Source.ToString();
            }

            return result;
        }
    }
}