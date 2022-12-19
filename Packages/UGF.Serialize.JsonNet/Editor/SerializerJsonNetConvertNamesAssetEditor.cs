using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Serialize.JsonNet.Runtime;
using UnityEditor;

namespace UGF.Serialize.JsonNet.Editor
{
    [CustomEditor(typeof(SerializerJsonNetConvertNamesAsset), true)]
    internal class SerializerJsonNetConvertNamesAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyReadable;
        private SerializedProperty m_propertyIndent;
        private SerializedProperty m_propertySettings;
        private ReorderableListKeyAndValueDrawer m_listSerializeNames;
        private ReorderableListKeyAndValueDrawer m_listDeserializeNames;

        protected virtual void OnEnable()
        {
            m_propertyReadable = serializedObject.FindProperty("m_readable");
            m_propertyIndent = serializedObject.FindProperty("m_indent");
            m_propertySettings = serializedObject.FindProperty("m_settings");

            m_listSerializeNames = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_serializeNames"), "m_from", "m_to")
            {
                DisplayLabels = true
            };

            m_listDeserializeNames = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_deserializeNames"), "m_from", "m_to")
            {
                DisplayLabels = true
            };

            m_listSerializeNames.Enable();
            m_listDeserializeNames.Enable();
        }

        protected virtual void OnDisable()
        {
            m_listSerializeNames.Disable();
            m_listDeserializeNames.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                OnDrawGUILayout();
            }
        }

        protected virtual void OnDrawGUILayout()
        {
            EditorIMGUIUtility.DrawScriptProperty(serializedObject);
            EditorGUILayout.PropertyField(m_propertyReadable);
            EditorGUILayout.PropertyField(m_propertyIndent);
            EditorGUILayout.PropertyField(m_propertySettings);

            m_listSerializeNames.DrawGUILayout();
            m_listDeserializeNames.DrawGUILayout();
        }
    }
}
