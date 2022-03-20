using System;

namespace UGF.Serialize.JsonNet.Runtime
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class SerializerJsonNetTypeAttribute : Attribute
    {
        public string Id { get; }

        public SerializerJsonNetTypeAttribute(string id = "")
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
