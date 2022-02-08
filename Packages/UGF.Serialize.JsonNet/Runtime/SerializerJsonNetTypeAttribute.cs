using System;

namespace UGF.Serialize.JsonNet.Runtime
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class SerializerJsonNetTypeAttribute : Attribute
    {
        public string Id { get; }

        public SerializerJsonNetTypeAttribute(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            Id = id;
        }
    }
}
