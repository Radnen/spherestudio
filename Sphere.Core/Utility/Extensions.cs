using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Core.Utility
{
    static class Extensions
    {
        public static Stream ToStream(this string value)
        {
            var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
            {
                writer.Write(value);
                writer.Flush();
            }
            stream.Position = 0;
            return stream;
        }
    }
}
