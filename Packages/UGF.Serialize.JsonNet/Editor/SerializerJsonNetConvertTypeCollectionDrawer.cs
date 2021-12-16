using UGF.EditorTools.Editor.IMGUI;
using UnityEditor;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Editor
{
    internal class SerializerJsonNetConvertTypeCollectionListDrawer : ReorderableListDrawer
    {
        public SerializerJsonNetConvertTypeCollectionListDrawer(SerializedProperty serializedProperty) : base(serializedProperty)
        {
        }

        protected override void OnDrawElementContent(Rect position, SerializedProperty serializedProperty, int index, bool isActive, bool isFocused)
        {
            SerializedProperty propertyId = serializedProperty.FindPropertyRelative("m_id");
            SerializedProperty propertyType = serializedProperty.FindPropertyRelative("m_type.m_value");

            EditorGUI.LabelField(position, $"{propertyId.stringValue}:{propertyType.stringValue}");
        }

        protected override float OnElementHeightContent(SerializedProperty serializedProperty, int index)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        protected override bool OnElementHasVisibleChildren(SerializedProperty serializedProperty)
        {
            return false;
        }
    }
}
