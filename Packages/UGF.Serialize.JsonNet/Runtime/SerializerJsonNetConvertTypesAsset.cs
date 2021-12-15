using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UGF.EditorTools.Runtime.IMGUI.Types;
using UGF.JsonNet.Runtime.Converters;
using UGF.Serialize.JsonNet.Runtime.Binders;
using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Serialize/Serializer JsonNet Convert Types", order = 2000)]
    public class SerializerJsonNetConvertTypesAsset : SerializerJsonNetConvertNamesAsset
    {
        [SerializeField] private bool m_allowAllTypes = true;
        [SerializeField] private List<ConvertTypeData> m_types = new List<ConvertTypeData>();

        public bool AllowAllTypes { get { return m_allowAllTypes; } set { m_allowAllTypes = value; } }
        public List<ConvertTypeData> Types { get { return m_types; } }

        [Serializable]
        public struct ConvertTypeData
        {
            [SerializeField] private string m_name;
            [SerializeField] private string m_assembly;
            [TypeReferenceDropdown]
            [SerializeField] private TypeReference<object> m_type;

            public string Name { get { return m_name; } set { m_name = value; } }
            public string Assembly { get { return m_assembly; } set { m_assembly = value; } }
            public TypeReference<object> Type { get { return m_type; } set { m_type = value; } }

            public bool IsValid()
            {
                return m_type.HasValue && !string.IsNullOrEmpty(m_name);
            }
        }

        protected override ISerializer<string> OnBuildTyped()
        {
            var binder = new ConvertTypeNameBinder(new ConvertTypeProvider(), m_allowAllTypes ? new DefaultSerializationBinder() : new SerializeJsonNetDisabledBinder());

            SetupTypes(binder.Provider);

            JsonSerializerSettings settings = OnCreateSettings();

            settings.SerializationBinder = binder;

            var serializer = new SerializerJsonNetConvertNames(settings, Readable, Indent);

            SetupNames(serializer);

            return serializer;
        }

        protected virtual void SetupTypes(IConvertTypeProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            for (int i = 0; i < m_types.Count; i++)
            {
                ConvertTypeData data = m_types[i];

                if (!data.IsValid()) throw new ArgumentException("Value should be valid.", nameof(data));

                Type type = data.Type.Get();

                if (!string.IsNullOrEmpty(data.Assembly))
                {
                    provider.Add(type, data.Name, data.Assembly);
                }
                else
                {
                    provider.Add(type, data.Name);
                }
            }
        }
    }
}
