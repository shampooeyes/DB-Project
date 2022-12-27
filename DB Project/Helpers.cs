
using System.Runtime.CompilerServices;

namespace DB_Project
{
    public static class Colors
    {
        public static System.Drawing.Color Red = System.Drawing.Color.Red;
        public static System.Drawing.Color Green = System.Drawing.Color.FromArgb(0x4CAF50);
    }

    public static class StringExtensions
    {
        public static bool IsEmpty(this string str)
        {
            return str.Length == 0;
        }
        public static bool Exceeds20(this string str)
        {
            return str.Length > 20;
        }
    }
    
}