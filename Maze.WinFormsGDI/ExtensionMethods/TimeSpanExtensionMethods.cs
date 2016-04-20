using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.WinFormsGDI.ExtensionMethods
{
    static class TimeSpanExtensionMethods
    {
        public static string ToSuffixedString(this TimeSpan span)
        {
            if (span.TotalSeconds > 1)
            {
                return span.TotalSeconds.ToString("0.00") + " s.";
            }
            if (span.TotalMilliseconds > 1)
            {
                return span.TotalMilliseconds.ToString("0.0") + " ms.";
            }
            return (span.TotalMilliseconds * 1000).ToString("000") + " μs.";
        }
    }
}
