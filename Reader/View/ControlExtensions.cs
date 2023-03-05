using System.Reflection;

namespace Reader.View
{
    internal static class ControlExtensions
    {
        internal static void DoubleBuffered(this Control control, bool enable)
        {
            control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(control, enable, null);
        }
    }
}
