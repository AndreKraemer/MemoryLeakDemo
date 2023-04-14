using System.Security.Permissions;
using System.Windows.Threading;

namespace Ak.MemoryLeakDemo.Tests
{
    public static class DispatcherUtil
    {
        /// <summary>
        /// Hilfsmethode für den WPF Dispatcher. Ohne diesen Aufruf wird das Fenster unnötig im Speicher gehalten.
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
        }

        private static object ExitFrame(object frame)
        {
            ((DispatcherFrame)frame).Continue = false;
            return null;
        }
    }
}