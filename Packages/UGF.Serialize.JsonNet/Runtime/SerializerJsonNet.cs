﻿using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UGF.JsonNet.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.Serialize.Runtime;
using Unity.Profiling;

namespace UGF.Serialize.JsonNet.Runtime
{
    public class SerializerJsonNet : SerializerAsync<string>
    {
        public JsonSerializerSettings Settings { get; }
        public bool Readable { get; }
        public int Indent { get; }

        private static ProfilerMarker m_markerSerialize;
        private static ProfilerMarker m_markerDeserialize;

#if ENABLE_PROFILER
        static SerializerJsonNet()
        {
            m_markerSerialize = new ProfilerMarker("SerializerJsonNet.Serialize");
            m_markerDeserialize = new ProfilerMarker("SerializerJsonNet.Deserialize");
        }
#endif

        public SerializerJsonNet(bool readable = false, int indent = 2) : this(JsonNetUtility.DefaultSettings, readable, indent)
        {
        }

        public SerializerJsonNet(JsonSerializerSettings settings, bool readable = false, int indent = 2)
        {
            if (indent < 0) throw new ArgumentOutOfRangeException(nameof(indent));

            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Readable = readable;
            Indent = indent;
        }

        protected override object OnSerialize(object target, IContext context)
        {
            return InternalSerialize(target);
        }

        protected override object OnDeserialize(Type targetType, string data, IContext context)
        {
            return InternalDeserialize(targetType, data);
        }

        protected override Task<string> OnSerializeAsync(object target, IContext context)
        {
            return Task.Run(() => InternalSerialize(target));
        }

        protected override Task<object> OnDeserializeAsync(Type targetType, string data, IContext context)
        {
            return Task.Run(() => InternalDeserialize(targetType, data));
        }

        protected virtual string OnSerialize(object target)
        {
            string result = JsonNetUtility.ToJson(target, Settings);

            if (Readable)
            {
                result = JsonNetUtility.Format(result, Readable, Indent);
            }

            return result;
        }

        protected virtual object OnDeserialize(Type targetType, string data)
        {
            return JsonNetUtility.FromJson(data, targetType, Settings);
        }

        private string InternalSerialize(object target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            m_markerSerialize.Begin();

            string result = OnSerialize(target);

            m_markerSerialize.End();

            return result;
        }

        private object InternalDeserialize(Type targetType, string data)
        {
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));
            if (data == null) throw new ArgumentNullException(nameof(data));

            m_markerDeserialize.Begin();

            object target = OnDeserialize(targetType, data);

            m_markerDeserialize.End();

            return target;
        }
    }
}
