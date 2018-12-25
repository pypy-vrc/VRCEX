using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace VRCEX
{
    public static class Utils
    {
        public static void SetDoubleBuffering(Control control)
        {
            var type = control.GetType();
            type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(control, true, null);
            type.GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(control, new object[] { ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true });
        }

        public static void Serialize(string path, object obj)
        {
            try
            {
                using (var file = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    new BinaryFormatter().Serialize(file, obj);
                }
            }
            catch
            {
            }
        }

        public static bool Deserialize<T>(string path, ref T obj)
        {
            try
            {
                using (var file = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    obj = (T)new BinaryFormatter().Deserialize(file);
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }
    }
}