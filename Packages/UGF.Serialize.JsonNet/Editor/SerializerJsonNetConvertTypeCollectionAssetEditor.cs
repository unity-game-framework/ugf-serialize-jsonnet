using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Serialize.JsonNet.Runtime;
using UnityEditor;

namespace UGF.Serialize.JsonNet.Editor
{
    [CustomEditor(typeof(SerializerJsonNetConvertTypeCollectionAsset), true)]
    internal class SerializerJsonNetConvertTypeCollectionAssetEditor : UnityEditor.Editor
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
        }
    }
}
