﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Intermediate.Operands
{
    public class TemporaryOperand : IOperand
    {
        public uint Bitsize { get; }

        public bool IsWritable => true;

        public int Uid { get; }

        public string Name => String.Format("t{0}", Uid);

        public TemporaryOperand(uint uid, uint bitSize)
        {

        }
    }
}