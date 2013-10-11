using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace HLP.Comum.Infrastructure
{
    public class ParameterBase<T> where T : class
    {
        public static object[] SetParameterValue(T classe)
        {
            try
            {
                List<object> list = new List<object>();
                list.Add(HLP.Comum.Infrastructure.Static.UserData.idUser); // IDUSUARIO

                Type type = classe.GetType();
                ModelDefinition modelDefinition =
                    ModelDefinition.GetModelDefinition(type);
                object value;
                foreach (ModelProperty property in modelDefinition.Properties)
                {
                    value = type.GetProperty(property.Name)
                        .GetValue(classe, ModelDefinition.ARRAY_OBJECTS);
                    list.Add(value);
                }

                return list.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
