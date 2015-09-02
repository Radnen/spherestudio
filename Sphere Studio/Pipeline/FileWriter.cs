using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jurassic;
using Jurassic.Library;

namespace SphereStudio.Pipeline
{
    class FileWriterConstructor : ClrFunction
    {
        public FileWriterConstructor(ScriptEngine js)
            : base(js.Function.InstancePrototype, "FileWriter", new FileWriter(js.Object.InstancePrototype))
        {
        }

        [JSConstructorFunction]
        public FileWriter Construct(string filename)
        {
            return new FileWriter(InstancePrototype, filename);
        }
    }

    class FileWriter : ObjectInstance
    {
        private StreamWriter _stream;

        public FileWriter(ObjectInstance prototype)
            : base(prototype)
        {
            PopulateFunctions();
        }

        public FileWriter(ObjectInstance prototype, string filename)
            : this(prototype)
        {
            _stream = new StreamWriter(filename, false, new UTF8Encoding(false));
        }

        [JSFunction(Name = "close", IsEnumerable = false, IsConfigurable = false)]
        public void Close()
        {
            _stream.Dispose();
        }

        [JSFunction(Name = "write", IsEnumerable = false, IsConfigurable = false)]
        public void Write(string text)
        {
            _stream.Write(text);
        }
    }
}
