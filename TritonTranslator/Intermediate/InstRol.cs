﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Intermediate.Operands;

namespace TritonTranslator.Intermediate
{
    public class InstRol : AbstractInstUnary
    {
        public override InstructionId Id => InstructionId.Rol;

        public InstRol(IOperand destination, IOperand op1, IOperand op2) : base(destination, op1, op2)
        {

        }
    }
}
