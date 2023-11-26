﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvugeNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVUGE;

        public BvugeNode(AstContext ctx, AbstractNode expr1, AbstractNode expr2) : base(ctx, expr1, expr2)
        {

        }

        public override uint ComputeBitvecSize()
        {
            return 1;
        }
    }
}
