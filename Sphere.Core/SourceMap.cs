using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourcemapToolkit.SourcemapParser;

namespace Sphere.Core
{
    public struct SourcePos
    {
        public string FileName;
        public int    LineNumber;
        public int    Column;

        public SourcePos(string fileName, int lineNumber, int column = 0)
        {
            this.FileName = fileName;
            this.LineNumber = lineNumber;
            this.Column = column;
        }
    }
    
    /// <summary>
    /// Allows mapping positions in transpiled JS files to their positions
    /// in the source using a V3 source map.
    /// </summary>
    public class SourceMapper
    {
        private Dictionary<string, SourceMap> maps = new Dictionary<string, SourceMap>();

        public void AddSource(string fileName, string mapJson)
        {
            SourceMapParser parser = new SourceMapParser();
            using (StreamReader reader = new StreamReader(streamFromString(mapJson)))
            {
                SourceMap map = parser.ParseSourceMap(reader);
                maps[fileName] = map;
            }
        }

        public SourcePos LookUp(string fileName, int lineNumber, int column)
        {
            SourceMap map;
            if (!maps.TryGetValue(fileName, out map))
                return new SourcePos(fileName, lineNumber, column);
            SourcePosition pos = new SourcePosition {
                ZeroBasedLineNumber = lineNumber - 1,
                ZeroBasedColumnNumber = column
            };
            MappingEntry ent = map.GetMappingEntryForGeneratedSourcePosition(pos);
            return new SourcePos(ent.OriginalFileName,
                ent.OriginalSourcePosition.ZeroBasedLineNumber + 1,
                ent.OriginalSourcePosition.ZeroBasedColumnNumber);
        }

        private Stream streamFromString(string data)
        {
            MemoryStream stream = new MemoryStream();
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
            {
                writer.Write(data);
                writer.Flush();
            }
            stream.Position = 0;
            return stream;
        }
    }
}
