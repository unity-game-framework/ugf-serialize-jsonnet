﻿using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Serialize/Serializer JsonNet", order = 2000)]
    public class SerializerJsonNetAsset : SerializerAsset<string>
    {
        [SerializeField] private bool m_readable;
        [SerializeField] private int m_indent = 2;

        public bool Readable { get { return m_readable; } set { m_readable = value; } }
        public int Indent { get { return m_indent; } set { m_indent = value; } }

        protected override ISerializer<string> OnBuildTyped()
        {
            return new SerializerJsonNet(m_readable, m_indent);
        }
    }
}
