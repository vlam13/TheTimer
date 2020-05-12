using System.Windows.Input;

namespace TheTimerWPF
{
    public static class KeyExtentions
    {
        public static bool IsDigit(this Key key)
        {
            if ((key >= Key.D0 && key <= Key.D9) ||
                (key >= Key.NumPad0 && key <= Key.NumPad9))
                return true;

            return false;
        }

        public static bool IsAllowed(this Key key)
        {
            if (key == Key.Back || key == Key.Delete)
                return true;

            if (key == Key.Left || key == Key.Right)
                return true;

            return false;
        }
    }
}
