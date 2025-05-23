using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Bitbebop.Editor
{
    public class IOSAppIconAppearanceProcessBuild : IPostprocessBuildWithReport
    {
        public int callbackOrder => 0;
        
        public void OnPostprocessBuild(BuildReport report)
        {
            if (report.summary.platform != BuildTarget.iOS)
                return;

            var settings = IOSAppIconAppearanceSettings.instance;

            // If no icons are set at all, skip processing.
            if (!settings.AnyAppearance && !settings.Dark && !settings.Tinted)
               return;

            var xcodeProjectPath = report.summary.outputPath;
            var appIconSetPath = FindAppIconSetPath(xcodeProjectPath);

            if (string.IsNullOrEmpty(appIconSetPath))
            {
                Debug.LogError($"IOSAppIconAppearanceProcessBuild: Could not find AppIcon.appiconset in Xcode project at {xcodeProjectPath}. Icon processing aborted.");
                return;
            }

            ClearExistingIcons(appIconSetPath);

            var newContents = new AppIconSetContents();

            // Process "Any Appearance" icon
            if (settings.AnyAppearance != null)
            {
                var sourcePath = AssetDatabase.GetAssetPath(settings.AnyAppearance);
                var copiedFilename = CopyIcon(sourcePath, appIconSetPath);
                if (!string.IsNullOrEmpty(copiedFilename))
                {
                    newContents.images.Add(new AppIconImage(copiedFilename));
                }
            }

            // Process "Dark" icon
            if (settings.Dark != null)
            {
                var sourcePath = AssetDatabase.GetAssetPath(settings.Dark);
                var copiedFilename = CopyIcon(sourcePath, appIconSetPath);
                if (!string.IsNullOrEmpty(copiedFilename))
                {
                    newContents.images.Add(new AppIconImage(copiedFilename, "luminosity", "dark"));
                }
            }

            // Process "Tinted" icon
            if (settings.Tinted != null)
            {
                var sourcePath = AssetDatabase.GetAssetPath(settings.Tinted);
                var copiedFilename = CopyIcon(sourcePath, appIconSetPath);
                if (!string.IsNullOrEmpty(copiedFilename))
                {
                    newContents.images.Add(new AppIconImage(copiedFilename, "luminosity", "tinted"));
                }
            }

            // Write new Contents.json file.
            var contentsJsonPath = Path.Combine(appIconSetPath, "Contents.json");
            var jsonString = JsonUtility.ToJson(newContents, true);
            File.WriteAllText(contentsJsonPath, jsonString);
        }

        private string FindAppIconSetPath(string xcodeProjectPath)
        {
            var potentialIconSetPaths = Directory.GetDirectories(xcodeProjectPath, "AppIcon.appiconset", SearchOption.AllDirectories);
            if (potentialIconSetPaths.Length > 0)
            {
                foreach (string path in potentialIconSetPaths)
                {
                    if (path.Contains("Images.xcassets")) return path;
                }
                return potentialIconSetPaths[0];
            }
            return null;
        }

        private void ClearExistingIcons(string appIconSetPath)
        {
            if (!Directory.Exists(appIconSetPath))
            {
                Debug.LogWarning($"IOSAppIconAppearanceProcessBuild: Directory to clear does not exist: {appIconSetPath}");
                return;
            }

            // Delete all files directly within the appIconSetPath
            var files = Directory.GetFiles(appIconSetPath, "*", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning($"IOSAppIconAppearanceProcessBuild: Could not delete file '{file}'. Error: {ex.Message}");
                }
            }
        }

        private string CopyIcon(string sourceAssetPath, string appIconSetDir)
        {
            if (string.IsNullOrEmpty(sourceAssetPath))
            {
                Debug.LogWarning($"IOSAppIconAppearanceProcessBuild: Source asset path is empty. Skipping.");
                return null;
            }

            if (!File.Exists(sourceAssetPath))
            {
                Debug.LogWarning($"IOSAppIconAppearanceProcessBuild: Source icon at '{sourceAssetPath}' not found. Skipping.");
                return null;
            }

            var originalFilename = Path.GetFileName(sourceAssetPath);
            var destinationPath = Path.Combine(appIconSetDir, originalFilename);

            try
            {
                File.Copy(sourceAssetPath, destinationPath, true);
                return originalFilename;
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"IOSAppIconAppearanceProcessBuild: Failed to copy icon from '{sourceAssetPath}' to '{destinationPath}'. Error: {ex.Message}");
                return null;
            }
        }
    }
}
