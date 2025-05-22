using System.Collections.Generic;

namespace Bitbebop.Editor
{
    [System.Serializable]
    public class AppIconSetContents
    {
        public List<AppIconImage> images = new List<AppIconImage>();
        public AppIconSetInfo info = new AppIconSetInfo();
    }

    [System.Serializable]
    public class AppIconImage
    {
        public string filename;
        public string idiom = "universal";
        public string platform = "ios";
        public string size = "1024x1024";
        public List<AppIconImageAppearance> appearances;

        // Constructor for the base "Any Appearance" icon
        public AppIconImage(string fname)
        {
            filename = fname;
            appearances = null;
        }

        // Constructor for icons with specific appearances (dark, tinted)
        public AppIconImage(string fname, string appearanceType, string appearanceValue)
        {
            filename = fname;
            appearances = new List<AppIconImageAppearance>
            {
                new() { appearance = appearanceType, value = appearanceValue }
            };
        }
    }

    [System.Serializable]
    public class AppIconImageAppearance
    {
        public string appearance;
        public string value;
    }

    [System.Serializable]
    public class AppIconSetInfo
    {
        public string author = "xcode";
        public int version = 1;
    }
}