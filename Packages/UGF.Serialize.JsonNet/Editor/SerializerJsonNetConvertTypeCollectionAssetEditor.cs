using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool m_hadError;

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

                using (new EditorGUI.DisabledScope(!HasSelected()))
                {
                    if (GUILayout.Button("Refresh Selected"))
                    {
                        m_hadError = false;

                        try
                        {
                            OnRefreshSelected();
                        }
                        catch (Exception exception)
                        {
                            Debug.LogException(exception);

                            m_hadError = true;
                        }
                    }
                }

                if (GUILayout.Button("Refresh"))
                {
                    m_hadError = false;

                    try
                    {
                        OnRefresh();
                    }
                    catch (Exception exception)
                    {
                        Debug.LogException(exception);

                        m_hadError = true;
                    }
                }

                EditorGUILayout.Space();
            }

            if (m_hadError)
            {
                EditorGUILayout.Space();
                EditorGUILayout.HelpBox("Previous refresh had errors, see console for more details.", MessageType.Warning);
            }
        }

        protected virtual void OnCollectTypes(IDictionary<string, Type> types)
        {
            TypeCache.TypeCollection collection = TypeCache.GetTypesWithAttribute<SerializerJsonNetTypeAttribute>();

            foreach (Type type in collection)
            {
                if (SerializerJsonNetEditorUtility.IsValidSerializableType(type))
                {
                    var attribute = type.GetCustomAttribute<SerializerJsonNetTypeAttribute>();

                    if (types.All(x => x.Value != type))
                    {
                        string id = !string.IsNullOrEmpty(attribute.Id) ? attribute.Id : Guid.NewGuid().ToString("N");

                        types.Add(id, type);
                    }
                }
            }
        }

        private void OnRefreshSelected()
        {
            SerializedProperty propertyArray = m_listTypes.SerializedProperty;

            foreach (int index in m_listTypes.List.selectedIndices)
            {
                if (index < m_listTypes.List.count)
                {
                    SerializedProperty propertyElement = propertyArray.GetArrayElementAtIndex(index);
                    SerializedProperty propertyId = propertyElement.FindPropertyRelative("m_id");
                    SerializedProperty propertyValue = propertyElement.FindPropertyRelative("m_type.m_value");

                    if (string.IsNullOrEmpty(propertyId.stringValue))
                    {
                        string id = Type.GetType(propertyValue.stringValue)?.GetCustomAttribute<SerializerJsonNetTypeAttribute>()?.Id ?? string.Empty;

                        propertyId.stringValue = !string.IsNullOrEmpty(id) ? id : Guid.NewGuid().ToString("N");
                    }
                }
            }

            propertyArray.serializedObject.ApplyModifiedProperties();
        }

        private void OnRefresh()
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
                    if (string.IsNullOrEmpty(propertyId.stringValue))
                    {
                        propertyId.stringValue = Guid.NewGuid().ToString("N");
                    }

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

        private bool HasSelected()
        {
            foreach (int index in m_listTypes.List.selectedIndices)
            {
                if (index < m_listTypes.List.count)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
