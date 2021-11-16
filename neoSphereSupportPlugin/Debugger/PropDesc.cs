﻿using System;

namespace SphereStudio.Plugins.Debugger
{
    struct PropDesc
    {
        public PropDesc(KiAtom value, PropFlags flags)
        {
            Value = value;
            Getter = Setter = null;
            Flags = flags;
        }

        public PropDesc(KiAtom getter, KiAtom setter, PropFlags flags)
        {
            Value = null;
            Getter = getter;
            Setter = setter;
            Flags = flags;
        }

        public KiAtom Value;
        public KiAtom Getter;
        public KiAtom Setter;
        public PropFlags Flags;
    }

    [Flags]
    enum PropFlags
    {
        None = 0x0000,
        Writable = 0x0001,
        Enumerable = 0x0002,
        Configurable = 0x0004,
        Accessor = 0x0008,
        Virtual = 0x0010,
        Internal = 0x0100,
    }
}
