using Newtonsoft.Json;
using UGF.JsonNet.Runtime;
using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Serialize/Serializer JsonNet", order = 2000)]
    public class SerializerJsonNetAsset : SerializerAsset<string>
    {
        [SerializeField] private bool m_readable;
        [SerializeField] private int m_indent = 2;
        [SerializeField] private SerializerJsonNetSettings m_settings = new SerializerJsonNetSettings();

        public bool Readable { get { return m_readable; } set { m_readable = value; } }
        public int Indent { get { return m_indent; } set { m_indent = value; } }
        public SerializerJsonNetSettings Settings { get { return m_settings; } }

        protected override ISerializer<string> OnBuildTyped()
        {
            JsonSerializerSettings settings = OnCreateSettings();

            return new SerializerJsonNet(settings, m_readable, m_indent);
        }

        protected virtual JsonSerializerSettings OnCreateSettings()
        {
            JsonSerializerSettings settings = JsonNetUtility.CreateDefault();

            settings.ReferenceLoopHandling = m_settings.ReferenceLoopHandling;
            settings.MissingMemberHandling = m_settings.MissingMemberHandling;
            settings.ObjectCreationHandling = m_settings.ObjectCreationHandling;
            settings.NullValueHandling = m_settings.NullValueHandling;
            settings.DefaultValueHandling = m_settings.DefaultValueHandling;
            settings.PreserveReferencesHandling = m_settings.PreserveReferencesHandling;
            settings.TypeNameHandling = m_settings.TypeNameHandling;
            settings.MetadataPropertyHandling = m_settings.MetadataPropertyHandling;
            settings.TypeNameAssemblyFormatHandling = m_settings.TypeNameAssemblyFormatHandling;
            settings.ConstructorHandling = m_settings.ConstructorHandling;
            settings.Formatting = m_settings.Formatting;
            settings.DateFormatHandling = m_settings.DateFormatHandling;
            settings.DateTimeZoneHandling = m_settings.DateTimeZoneHandling;
            settings.DateParseHandling = m_settings.DateParseHandling;
            settings.FloatFormatHandling = m_settings.FloatFormatHandling;
            settings.FloatParseHandling = m_settings.FloatParseHandling;
            settings.StringEscapeHandling = m_settings.StringEscapeHandling;
            settings.DateFormatString = m_settings.DateFormatString;
            settings.CheckAdditionalContent = m_settings.CheckAdditionalContent;

            if (m_settings.MaxDepth > 0)
            {
                settings.MaxDepth = m_settings.MaxDepth;
            }

            return settings;
        }
    }
}
