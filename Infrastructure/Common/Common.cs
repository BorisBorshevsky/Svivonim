using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure.Common
{
    public static class Common
    {
        public static string GetDescription<T>(this T source)
        {
            string result;
            FieldInfo fieldInfo = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Length > 0)
            {
                result = attributes[0].Description;
            }
            else
            {
                result = source.ToString();
            }

            return result;
        }
    }
}
