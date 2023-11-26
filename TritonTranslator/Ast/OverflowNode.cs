﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class OverflowNode : AbstractBinaryNode
    {
        public override AstType Type => AstType.OVERFLOW;

        public OverflowNode(AstContext ctx, AbstractNode expr1) : base(ctx,expr1)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
