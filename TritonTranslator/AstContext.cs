using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Ast;

namespace TritonTranslator.Ast
{
    // This is analogous to an LLVMContext.
    // The AstContext keeps hash conses and keeps track of all instantiated nodes.
    public class AstContext
    {
        // The ast context hash conses all nodes.
        public HashSet<AbstractNode> uniqueNodes = new();

        private AbstractNode HashConse(AbstractNode node)
        {
            // return node;
            // If a node of this eclass already exists, return it and throw away the node that 
            // was just passed in.
            bool exists = uniqueNodes.TryGetValue(node, out AbstractNode result);
            if (exists)
                return result;

            // Otherwise this is a new eclass that we've never seen it before.
            // Add it to the set and return it.
            uniqueNodes.Add(node);
            return node;
        }

        public IntegerNode bv(ulong value, uint size) => (IntegerNode)HashConse(new IntegerNode(this, value, size));

        public AbstractNode bvadd(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvaddNode(this, expr1, expr2));

        public AbstractNode bvsub(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvsubNode(this, expr1, expr2));

        public EqualNode equal(AbstractNode expr1, AbstractNode expr2) => (EqualNode)HashConse(new EqualNode(this, expr1, expr2));

        public AbstractNode bvand(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvandNode(this, expr1, expr2));

        public AbstractNode bvxor(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvxorNode(this, expr1, expr2));

        public AbstractNode bvugt(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvugtNode(this, expr1, expr2));

        public AbstractNode extract(uint high, uint low, AbstractNode expr) => HashConse(new ExtractNode(this, high, low, expr));

        public AbstractNode extract(IntegerNode high, IntegerNode low, AbstractNode expr) => HashConse(new ExtractNode(this, high, low, expr));

        public AbstractNode bvlshr(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvlshrNode(this, expr1, expr2));

        public AbstractNode bvrol(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvrolNode(this, expr1, expr2));

        public AbstractNode bvror(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvrorNode(this, expr1, expr2));

        public AbstractNode bvtrue() => HashConse(new BvNode(this, 1, 1));

        public AbstractNode bvfalse() => HashConse(new BvNode(this, 0, 1));

        public AbstractNode bvmul(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvmulNode(this, expr1, expr2));

        public AbstractNode bvudiv(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvudivNode(this, expr1, expr2));

        public AbstractNode bvsrem(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvsremNode(this, expr1, expr2));

        public AbstractNode bvurem(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvuremNode(this, expr1, expr2));

        public AbstractNode bvshl(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvshlNode(this, expr1, expr2));

        public AbstractNode ite(AbstractNode ifExpr, AbstractNode thenExpr, AbstractNode elseExpr) => HashConse(new IteNode(this, ifExpr, thenExpr, elseExpr));

        public AbstractNode bvsmod(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvsmodNode(this, expr1, expr2));

        public AbstractNode bvor(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvorNode(this, expr1, expr2));

        public AbstractNode bvnot(AbstractNode expr1) => HashConse(new BvnotNode(this, expr1));

        public AbstractNode bvsdiv(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvsdivNode(this, expr1, expr2));

        public AbstractNode bvneg(AbstractNode expr1) => HashConse(new BvnegNode(this, expr1));

        public AbstractNode bvsge(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvsgeNode(this, expr1, expr2));

        public AbstractNode bvsle(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvsleNode(this, expr1, expr2));

        public AbstractNode bvslt(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvsltNode(this, expr1, expr2));

        public AbstractNode bvuge(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvugeNode(this, expr1, expr2));

        public AbstractNode bvsgt(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvsgtNode(this, expr1, expr2));

        public AbstractNode bvule(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvuleNode(this, expr1, expr2));

        public AbstractNode bvult(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvultNode(this, expr1, expr2));

        public AbstractNode bvashr(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvashrNode(this, expr1, expr2));

        public AbstractNode concat(AbstractNode expr1, AbstractNode expr2) => HashConse(new ConcatNode(this, expr1, expr2));

        public AbstractNode concat(List<AbstractNode> expressions) => HashConse(new ConcatNode(this, expressions));

        // Replace all usages of logical with bvand
        public AbstractNode land(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvandNode(this, expr1, expr2));


        // Replace all usages of logical OR with bvor.
        public AbstractNode lor(AbstractNode expr1, AbstractNode expr2) => HashConse(new BvorNode(this, expr1, expr2));

        // TODO: (Maybe?) refactor out reference nodes.
        public AbstractNode reference(AbstractNode expr1) => HashConse(new ReferenceNode(this, expr1));

        public AbstractNode sx(AbstractNode expr1, AbstractNode expr2) => HashConse(new SxNode(this, expr1, expr2));

        public AbstractNode sx(uint sizeExt, AbstractNode expr1) => HashConse(new SxNode(this, sizeExt, expr1));

        public AbstractNode zx(AbstractNode sizeExt, AbstractNode expr2) => HashConse(new ZxNode(this, sizeExt, expr2));

        public AbstractNode zx(uint sizeExt, AbstractNode expr2) => HashConse(new ZxNode(this, sizeExt, expr2));

        public AbstractNode undef(uint size) => HashConse(new UndefNode(this, size));

        public TemporaryNode temporary(uint id, uint size, string name) => (TemporaryNode)HashConse(new TemporaryNode(this, id, size, name));
    }
}
