using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.IMGUI.Types;
using UGF.JsonNet.Runtime.Converters;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Serialize/Serializer JsonNet Convert Type Collection", order = 2000)]
    public class SerializerJsonNetConvertTypeCollectionAsset : SerializerJsonNetConvertTypeProviderAsset
    {
        [SerializeField] private List<TypeData> m_types = new List<TypeData>();

        public List<TypeData> Types { get { return m_types; } }

        [Serializable]
        public struct TypeData
        {
            [SerializeField] private string m_id;
            [TypeReferenceDropdown]
            [SerializeField] private TypeReference<object> m_type;

            public string Id { get { return m_id; } set { m_id = value; } }
            public TypeReference<object> Type { get { return m_type; } set { m_type = value; } }
        }

        protected override void OnSetupTypes(IConvertTypeProvider provider)
        {
            for (int i = 0; i < m_types.Count; i++)
            {
                TypeData data = m_types[i];
                Type type = data.Type.Get();

                provider.Add(type, data.Id);
            }
        }
    }
}
