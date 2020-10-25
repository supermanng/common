using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Etechnosoft.Common.Data;

namespace Etechnosoft.Common.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attribs.Length > 0)
            {
                return ((DescriptionAttribute)attribs[0]).Description;
            }
            return value.ToString();
        }
        public static NameAndIdData[] GetItems(this Type enumType)
        {
            return (from name in Enum.GetNames(enumType)
                let enumValue = Enum.Parse(enumType, name)
                select new NameAndIdData
                {
                    Name = ((Enum)enumValue).GetDescription(),
                    Id = Convert.ToInt64(enumValue)
                }).ToArray();
        }
        public static string GetMesage(this ServiceResponseCode value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(MessageAttribute), true);
            return ((MessageAttribute)attribs[0]).Message;
        }
    }
}