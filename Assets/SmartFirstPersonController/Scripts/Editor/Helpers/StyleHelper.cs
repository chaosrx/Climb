/*******************************************************
 * 													   *
 * Asset:		 Smart First Person Controller 		   *
 * Script:		 StyleHelper.cs                        *
 * 													   *
 * Copyright(c): Victor Klepikov					   *
 * Support: 	 http://bit.ly/vk-Support			   *
 * 													   *
 * mySite:       http://vkdemos.ucoz.org			   *
 * myAssets:     http://u3d.as/5Fb                     *
 * myTwitter:	 http://twitter.com/VictorKlepikov	   *
 * 													   *
 *******************************************************/


using UnityEngine;
using UnityEditor;

namespace SmartFirstPersonController.Inspector
{
    public static class StyleHelper
    {
        private static GUIStyle foldOutStyle = new GUIStyle( EditorStyles.foldout );
        private static GUIStyle labelStyle = new GUIStyle( EditorStyles.largeLabel );
        private static Color textColor = Color.red;

        // FoldOut Stile
        public static GUIStyle FoldOutStyle
        {
            get
            {
                foldOutStyle.fontStyle = FontStyle.Bold;
                foldOutStyle.fontSize = 13;
                foldOutStyle.stretchWidth = false;
                foldOutStyle.onActive.textColor = textColor;
                foldOutStyle.onFocused.textColor = textColor;
                foldOutStyle.onHover.textColor = textColor;
                foldOutStyle.onNormal.textColor = textColor;
                foldOutStyle.active.textColor = textColor;
                foldOutStyle.focused.textColor = textColor;
                foldOutStyle.hover.textColor = textColor;
                foldOutStyle.normal.textColor = textColor;

                return foldOutStyle;
            }
        }

        // Label Stile
        public static GUIStyle LabelStyle
        {
            get
            {
                labelStyle.fontStyle = FontStyle.Bold;
                labelStyle.fontSize = 14;
                labelStyle.stretchWidth = false;
                labelStyle.onActive.textColor = textColor;
                labelStyle.onFocused.textColor = textColor;
                labelStyle.onHover.textColor = textColor;
                labelStyle.onNormal.textColor = textColor;
                labelStyle.active.textColor = textColor;
                labelStyle.focused.textColor = textColor;
                labelStyle.hover.textColor = textColor;
                labelStyle.normal.textColor = textColor;

                return labelStyle;
            }
        }
    }
}