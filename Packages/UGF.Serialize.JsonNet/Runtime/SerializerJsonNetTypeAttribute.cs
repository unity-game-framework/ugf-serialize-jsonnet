using System;

namespace UGF.Serialize.JsonNet.Runtime
{
    public class SerializerJsonNetTypeAttribute : Attribute
    {
        public string Id { get; }

        public SerializerJsonNetTypeAttribute()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public SerializerJsonNetTypeAttribute(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            Id = id;
        }
    }
}
