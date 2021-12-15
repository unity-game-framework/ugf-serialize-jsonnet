using System;
using UGF.JsonNet.Runtime.Converters;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Runtime
{
    public abstract class SerializerJsonNetConvertTypeProviderAsset : ScriptableObject
    {
        public void SetupTypes(IConvertTypeProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            OnSetupTypes(provider);
        }

        protected abstract void OnSetupTypes(IConvertTypeProvider provider);
    }
}
