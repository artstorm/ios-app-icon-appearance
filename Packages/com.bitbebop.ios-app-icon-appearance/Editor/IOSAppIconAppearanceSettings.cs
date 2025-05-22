using UnityEditor;
using UnityEngine;

namespace Bitbebop.Editor
{
    [FilePath("ProjectSettings/IOSAppIconAppearanceSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    public class IOSAppIconAppearanceSettings : ScriptableSingleton<IOSAppIconAppearanceSettings>
    {
        [SerializeField] private Texture2D _anyAppearance;
        [SerializeField] private Texture2D _dark;
        [SerializeField] private Texture2D _tinted;
        
        public Texture2D AnyAppearance
        {
            get => _anyAppearance;
            set { _anyAppearance = value; Save(true); } 
        }
        
        public Texture2D Dark
        {
            get => _dark;
            set { _dark = value; Save(true); }
        }
        
        public Texture2D Tinted
        {
            get => _tinted;
            set { _tinted = value; Save(true); }
        }
    }
}