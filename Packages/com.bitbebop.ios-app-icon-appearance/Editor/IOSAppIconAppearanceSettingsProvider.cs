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
                    var settings = IOSAppIconAppearanceSettings.instance;
                    
                    EditorGUILayout.LabelField(new GUIContent("Any Appearance"));
                    settings.AnyAppearance = EditorGUILayout.ObjectField(
                        GUIContent.none,
                        settings.AnyAppearance,
                        typeof(Texture2D),
                        false,
                        GUILayout.Width(ObjectFieldSize),
                        GUILayout.Height(ObjectFieldSize)
                    ) as Texture2D;
                    ValidateIcon(settings.AnyAppearance, "Any Appearance"); 
                    EditorGUILayout.Space(10);

                    EditorGUILayout.LabelField(new GUIContent("Dark"));
                    settings.Dark = EditorGUILayout.ObjectField(
                        GUIContent.none,
                        settings.Dark,
                        typeof(Texture2D),
                        false,
                        GUILayout.Width(ObjectFieldSize),
                        GUILayout.Height(ObjectFieldSize)
                    ) as Texture2D;
                    ValidateIcon(settings.Dark, "Dark"); 
                    EditorGUILayout.Space(10);
                    
                    EditorGUILayout.LabelField(new GUIContent("Tinted"));
                    settings.Tinted = EditorGUILayout.ObjectField(
                        GUIContent.none,
                        settings.Tinted,
                        typeof(Texture2D),
                        false,
                        GUILayout.Width(ObjectFieldSize),
                        GUILayout.Height(ObjectFieldSize)
                    ) as Texture2D;
                    ValidateIcon(settings.Tinted, "Tinted"); 
                },
                
                keywords = new HashSet<string>(new[] { "Any Appearance", "Dark", "Tinted", "iOS AppIcon Xcode Apple" })
            };

            return provider;
        }
        
        private static void ValidateIcon(Texture2D iconTexture, string iconName)
        {
            if (iconTexture != null)
            {
                if (iconTexture.width != 1024 || iconTexture.height != 1024)
                {
                    EditorGUILayout.HelpBox($"{iconName} icon must be 1024x1024. Current size: {iconTexture.width}x{iconTexture.height}.", MessageType.Warning);
                }
            }
        }
    }
}