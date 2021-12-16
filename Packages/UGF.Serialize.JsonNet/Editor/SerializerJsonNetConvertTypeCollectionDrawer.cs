using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
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
            SerializedProperty propertyType = serializedProperty.FindPropertyRelative("m_type");

            float space = EditorGUIUtility.standardVerticalSpacing * 2F;
            float labelWidth = EditorGUIUtility.labelWidth + EditorIMGUIUtility.IndentPerLevel;

            var rectId = new Rect(position.x, position.y, labelWidth, position.height);
            var rectType = new Rect(rectId.xMax + space, position.y, position.width - rectId.width - space, position.height);

            using (new LabelWidthScope(15F))
            {
                EditorGUI.PropertyField(rectId, propertyId);
            }

            using (new LabelWidthScope(35F))
            {
                EditorGUI.PropertyField(rectType, propertyType);
            }
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
