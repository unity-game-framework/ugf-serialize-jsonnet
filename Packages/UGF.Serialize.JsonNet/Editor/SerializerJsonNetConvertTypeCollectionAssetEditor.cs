using System;
using System.Collections.Generic;
using System.Reflection;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Serialize.JsonNet.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Editor
{
    [CustomEditor(typeof(SerializerJsonNetConvertTypeCollectionAsset), true)]
    public class SerializerJsonNetConvertTypeCollectionAssetEditor : UnityEditor.Editor
    {
        private SerializerJsonNetConvertTypeCollectionListDrawer m_listTypes;

        private void OnEnable()
        {
            m_listTypes = new SerializerJsonNetConvertTypeCollectionListDrawer(serializedObject.FindProperty("m_types"));
            m_listTypes.Enable();
        }

        private void OnDisable()
        {
            m_listTypes.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listTypes.DrawGUILayout();
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Collect"))
                {
                    OnCollect();
                }

                EditorGUILayout.Space();
            }
        }

        protected virtual void OnCollectTypes(IDictionary<string, Type> types)
        {
            TypeCache.TypeCollection collection = TypeCache.GetTypesWithAttribute<SerializerJsonNetTypeAttribute>();

            foreach (Type type in collection)
            {
                var attribute = type.GetCustomAttribute<SerializerJsonNetTypeAttribute>();

                if (!types.ContainsKey(attribute.Id))
                {
                    types.Add(attribute.Id, type);
                }
            }
        }

        private void OnCollect()
        {
            SerializedProperty propertyArray = m_listTypes.SerializedProperty;
            var types = new Dictionary<string, Type>();

            for (int i = 0; i < propertyArray.arraySize; i++)
            {
                SerializedProperty propertyElement = propertyArray.GetArrayElementAtIndex(i);
                SerializedProperty propertyId = propertyElement.FindPropertyRelative("m_id");
                SerializedProperty propertyValue = propertyElement.FindPropertyRelative("m_type.m_value");

                var type = Type.GetType(propertyValue.stringValue);

                if (type != null)
                {
                    types.Add(propertyId.stringValue, type);
                }
            }

            OnCollectTypes(types);

            propertyArray.ClearArray();

            foreach ((string key, Type value) in types)
            {
                propertyArray.InsertArrayElementAtIndex(propertyArray.arraySize);

                SerializedProperty propertyElement = propertyArray.GetArrayElementAtIndex(propertyArray.arraySize - 1);
                SerializedProperty propertyId = propertyElement.FindPropertyRelative("m_id");
                SerializedProperty propertyValue = propertyElement.FindPropertyRelative("m_type.m_value");

                propertyId.stringValue = key;
                propertyValue.stringValue = value.AssemblyQualifiedName;
            }

            propertyArray.serializedObject.ApplyModifiedProperties();
        }
    }
}
