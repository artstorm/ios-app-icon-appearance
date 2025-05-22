using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Bitbebop.Editor
{
    public static class IOSAppIconAppearanceSettingsProvider
    {
        private const float ObjectFieldSize = 76f;

        [SettingsProvider]
        public static SettingsProvider CreateIOSAppIconAppearanceSettingsProvider()
        {
            var provider = new SettingsProvider("Project/iOS App Icon", SettingsScope.Project)
            {
                guiHandler = (searchContext) =>
                {
                    EditorGUILayout.LabelField(new GUIContent("Any Appearance"));
                    IOSAppIconAppearanceSettings.instance.AnyAppearance = EditorGUILayout.ObjectField(
                        GUIContent.none,
                        IOSAppIconAppearanceSettings.instance.AnyAppearance,
                        typeof(Texture2D),
                        false,
                        GUILayout.Width(ObjectFieldSize),
                        GUILayout.Height(ObjectFieldSize)
                    ) as Texture2D;
                    EditorGUILayout.Space(10);

                    EditorGUILayout.LabelField(new GUIContent("Dark"));
                    IOSAppIconAppearanceSettings.instance.Dark = EditorGUILayout.ObjectField(
                        GUIContent.none,
                        IOSAppIconAppearanceSettings.instance.Dark,
                        typeof(Texture2D),
                        false,
                        GUILayout.Width(ObjectFieldSize),
                        GUILayout.Height(ObjectFieldSize)
                    ) as Texture2D;
                    EditorGUILayout.Space(10);
                    
                    EditorGUILayout.LabelField(new GUIContent("Tinted"));
                    IOSAppIconAppearanceSettings.instance.Tinted = EditorGUILayout.ObjectField(
                        GUIContent.none,
                        IOSAppIconAppearanceSettings.instance.Tinted,
                        typeof(Texture2D),
                        false,
                        GUILayout.Width(ObjectFieldSize),
                        GUILayout.Height(ObjectFieldSize)
                    ) as Texture2D;
                },
                
                keywords = new HashSet<string>(new[] { "Any Appearance", "Dark", "Tinted", "iOS AppIcon Xcode Apple" })
            };

            return provider;
        }
    }
}