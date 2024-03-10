using System.Reflection;

namespace LevisV2.Levis_logic
{
    public static class Levis
    {
        public static string FileExtension = ".lvs";
        public static string Name = "Levis";
        public static string Author = "Timur \"RABB1T\"";
        public static string Version = "0.2 alpha";
        public static string WebSite = "(COMING SOON)";
        public static bool Debug = false;
        public static bool IsModded()
        {
            if (Assembly.GetExecutingAssembly().GetType("MonoMod.WasHere") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
