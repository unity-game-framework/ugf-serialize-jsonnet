using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace UGF.Serialize.JsonNet.Editor
{
    public static class SerializerJsonNetEditorUtility
    {
        public static bool IsValidSerializableType(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return !type.IsAbstract
                   && !type.IsArray
                   && !type.IsEnum
                   && !type.IsInterface
                   && !type.IsGenericTypeDefinition
                   && !type.IsGenericType
                   && type.GetConstructor(Type.EmptyTypes) != null
                   && type.GetCustomAttribute<CompilerGeneratedAttribute>() == null;
        }
    }
}
