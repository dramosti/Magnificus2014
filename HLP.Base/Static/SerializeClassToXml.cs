using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HLP.Base.Static
{
    public class SerializeClassToXml
    {
        public static void SerializeClasse<T>(T classe, string sPathSave) where T : class
        {
            TextWriter textWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                textWriter = new StreamWriter(sPathSave);
                serializer.Serialize(textWriter, classe);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                textWriter.Close();
                textWriter.Dispose();
            }
        }
        public static T DeserializeClasse<T>(string PathSave) where T : class
        {
            TextReader textReader = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                textReader = new StreamReader(PathSave);
                T config;
                config = (T)deserializer.Deserialize(textReader);
                return config;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                textReader.Close();
                textReader.Dispose();
            }

        }

    }

}
