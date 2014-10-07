using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class EnumDescriptionConverter 
    {

        public static IDictionary<string, object> GetDict(Type enumType)
        {
            var typeList = new Dictionary<string, object>();

            //get the description attribute of each enum field
            DescriptionAttribute descriptionAttribute;
            foreach (var value in Enum.GetValues(enumType))
            {
                FieldInfo fieldInfo = enumType.GetField((value.ToString()));
                descriptionAttribute =
        (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo,
        typeof(DescriptionAttribute));
                if (descriptionAttribute != null)
                {
                    typeList.Add(descriptionAttribute.Description, value);
                }
            }

            return typeList;
        }

    }
}
