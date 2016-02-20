using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Maze.Drawing.Common
{
    internal static class StreamExtensionMethods
    {
        public static void CopyTo(this Stream input, Stream output)
        {
            var buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
    }
}
