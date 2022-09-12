﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public class BvandNode : AbstractUnaryNode
    {
        public override AstType Type => AstType.BVAND;

        public BvandNode(AbstractNode expr1, AbstractNode expr2) : base(expr1, expr2)
        {

        }
    }
}
