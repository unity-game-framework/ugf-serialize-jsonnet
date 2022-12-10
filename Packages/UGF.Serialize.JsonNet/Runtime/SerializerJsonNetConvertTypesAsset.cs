using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
        [SerializeField] private List<SerializeTypeCollectionAsset> m_collections = new List<SerializeTypeCollectionAsset>();

        public bool AllowAllTypes { get { return m_allowAllTypes; } set { m_allowAllTypes = value; } }
        public List<SerializeTypeCollectionAsset> Collections { get { return m_collections; } }

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

            var types = new Dictionary<object, Type>();

            for (int i = 0; i < m_collections.Count; i++)
            {
                SerializeTypeCollectionAsset collection = m_collections[i];

                collection.GetTypes(types);
            }

            foreach ((object id, Type type) in types)
            {
                provider.Add(type, id.ToString());
            }
        }
    }
}
