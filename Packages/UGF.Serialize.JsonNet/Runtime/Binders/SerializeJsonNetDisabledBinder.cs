using System;
using Newtonsoft.Json.Serialization;

namespace UGF.Serialize.JsonNet.Runtime.Binders
{
    public class SerializeJsonNetDisabledBinder : ISerializationBinder
    {
        public Type BindToType(string assemblyName, string typeName)
        {
            throw new ArgumentException($"Type not found by the specified name: '{typeName}'.");
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            throw new ArgumentException($"Type name not found by the specified type: '{serializedType}'.");
        }
    }
}
