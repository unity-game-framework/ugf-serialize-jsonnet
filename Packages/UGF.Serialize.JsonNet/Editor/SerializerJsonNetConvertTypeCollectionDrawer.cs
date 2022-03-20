using System;
using System.Collections.Generic;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Dropdown;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.EditorTools.Editor.IMGUI.Types;
using UnityEditor;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Editor
{
    internal class SerializerJsonNetConvertTypeCollectionListDrawer : ReorderableListDrawer
    {
        private readonly DropdownDrawer<DropdownItem<Type>> m_dropdownDrawer;

        public SerializerJsonNetConvertTypeCollectionListDrawer(SerializedProperty serializedProperty) : base(serializedProperty)
        {
            m_dropdownDrawer = new TypesDropdownDrawer(OnTypeItems);
        }

        protected override void OnDrawElementContent(Rect position, SerializedProperty serializedProperty, int index, bool isActive, bool isFocused)
        {
            SerializedProperty propertyId = serializedProperty.FindPropertyRelative("m_id");
            SerializedProperty propertyType = serializedProperty.FindPropertyRelative("m_type.m_value");

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
                m_dropdownDrawer.DrawGUI(rectType, new GUIContent(propertyType.displayName), propertyType);
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

        private IEnumerable<DropdownItem<Type>> OnTypeItems()
        {
            var items = new List<DropdownItem<Type>>();

            TypesDropdownEditorUtility.GetTypeItems(items, SerializerJsonNetEditorUtility.IsValidSerializableType, true, false);

            return items;
        }
    }
}
