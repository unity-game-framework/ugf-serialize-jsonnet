using UGF.EditorTools.Editor.IMGUI;
using UGF.Serialize.JsonNet.Runtime;
using UnityEditor;

namespace UGF.Serialize.JsonNet.Editor
{
    [CustomEditor(typeof(SerializerJsonNetConvertTypesAsset), true)]
    internal class SerializerJsonNetConvertTypesAssetEditor : SerializerJsonNetConvertNamesAssetEditor
    {
        private SerializedProperty m_propertyAllowAllTypes;
        private ReorderableListDrawer m_listTypes;
        private ReorderableListDrawer m_listTypeProviders;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_propertyAllowAllTypes = serializedObject.FindProperty("m_allowAllTypes");
            m_listTypes = new ReorderableListDrawer(serializedObject.FindProperty("m_types"));
            m_listTypes.Enable();
            m_listTypeProviders = new ReorderableListDrawer(serializedObject.FindProperty("m_typeProviders"));
            m_listTypeProviders.Enable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            m_listTypes.Disable();
            m_listTypeProviders.Disable();
        }

        protected override void OnDrawGUILayout()
        {
            base.OnDrawGUILayout();

            EditorGUILayout.PropertyField(m_propertyAllowAllTypes);

            m_listTypes.DrawGUILayout();
            m_listTypeProviders.DrawGUILayout();
        }
    }
}
