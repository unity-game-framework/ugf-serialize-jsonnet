using UGF.EditorTools.Editor.IMGUI;
using UGF.Serialize.JsonNet.Runtime;
using UnityEditor;

namespace UGF.Serialize.JsonNet.Editor
{
    [CustomEditor(typeof(SerializerJsonNetConvertTypesAsset), true)]
    internal class SerializerJsonNetConvertTypesAssetEditor : SerializerJsonNetConvertNamesAssetEditor
    {
        private SerializedProperty m_propertyAllowAllTypes;
        private ReorderableListDrawer m_listCollections;
        private ReorderableListSelectionDrawerByElement m_listCollectionsSelection;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_propertyAllowAllTypes = serializedObject.FindProperty("m_allowAllTypes");
            m_listCollections = new ReorderableListDrawer(serializedObject.FindProperty("m_collections"));

            m_listCollectionsSelection = new ReorderableListSelectionDrawerByElement(m_listCollections)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listCollections.Enable();
            m_listCollectionsSelection.Enable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            m_listCollections.Disable();
            m_listCollectionsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            m_listCollectionsSelection.DrawGUILayout();
        }

        protected override void OnDrawGUILayout()
        {
            base.OnDrawGUILayout();

            EditorGUILayout.PropertyField(m_propertyAllowAllTypes);

            m_listCollections.DrawGUILayout();
        }
    }
}
