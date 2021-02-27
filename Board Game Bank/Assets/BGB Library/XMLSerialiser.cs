using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace BoardGameBank.Serialisation
{
    public static class XMLSerialiser
    {
        public static void Serialise<T>(T file, string path)
        {
            using (var fs = new FileStream(path, FileMode.Create))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(T));
                dcs.WriteObject(fs, file);
            }
        }
        public static T Deserialise<T>(string path)
        {
            T ret;
            using (var fs = new FileStream(path, FileMode.Open))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(T));
                ret = (T)dcs.ReadObject(fs);
            }
            return ret;
        }
    }
}

