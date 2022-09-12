using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    /*
        bv
        bvadd
        bvsub
        equal
        bvand
        bvxor
        bvugt
        extract
        bvlshr
        bvrol
        bvror
        bvtrue
        bvfalse
        bvmul
        bvudiv
        bvurem
        bvshl
        ite
        bvsmod
        bvor
        bvnot
        bvsdiv
        bvneg
        bvsge
        bvsle
        bvuge
        bvsgt
        bvule
        bvashr
    */
    public class AstContext
    {
        public AbstractNode bv(ulong value, uint size) => new BvNode(value, size);

        public AbstractNode bvadd(AbstractNode expr1, AbstractNode expr2) => new BvaddNode(expr1, expr2);

        public AbstractNode bvsub(AbstractNode expr1, AbstractNode expr2) => new BvsubNode(expr1, expr2);

        public AbstractNode equal(AbstractNode expr1, AbstractNode expr2) => new EqualNode(expr1, expr2);

        public AbstractNode bvand(AbstractNode expr1, AbstractNode expr2) => new BvandNode(expr1, expr2);

        public AbstractNode bvxor (AbstractNode expr1, AbstractNode expr2) => new BvxorNode(expr1, expr2);

        public AbstractNode bvugt (AbstractNode expr1, AbstractNode expr2) => new BvugtNode(expr1, expr2);

        public AbstractNode extract(uint high, uint low, AbstractNode expr) => new ExtractNode(high, low, expr);

        public AbstractNode extract(IntegerNode high, IntegerNode low, AbstractNode expr) => new ExtractNode(high, low, expr);

        public AbstractNode bvlshr(AbstractNode expr1, AbstractNode expr2) => new BvlshrNode(expr1, expr2);

        public AbstractNode bvrol(AbstractNode expr1, AbstractNode expr2) => new BvrolNode(expr1, expr2);

        public AbstractNode bvror(AbstractNode expr1, AbstractNode expr2) => new BvrorNode(expr1, expr2);

        public AbstractNode bvtrue() => new BvNode(1, 1);

        public AbstractNode bvfalse() => new BvNode(1, 0);

        public AbstractNode bvmul(AbstractNode expr1, AbstractNode expr2) => new BvmulNode(expr1, expr2);

        public AbstractNode bvudiv(AbstractNode expr1, AbstractNode expr2) => new BvudivNode(expr1, expr2);

        public AbstractNode bvurem(AbstractNode expr1, AbstractNode expr2) => new BvuremNode(expr1, expr2);

        public AbstractNode bvshl(AbstractNode expr1, AbstractNode expr2) => new BvshlNode(expr1, expr2);

        public AbstractNode ite(AbstractNode ifExpr, AbstractNode thenExpr, AbstractNode elseExpr) => new IteNode(ifExpr, thenExpr, elseExpr);

        public AbstractNode bvsmod(AbstractNode expr1, AbstractNode expr2) => new BvsmodNode(expr1, expr2);

        public AbstractNode bvor(AbstractNode expr1, AbstractNode expr2) => new BvorNode(expr1, expr2);

        public AbstractNode bvnot(AbstractNode expr1) => new BvnotNode(expr1);

        public AbstractNode bvsdiv(AbstractNode expr1, AbstractNode expr2) => new BvsdivNode(expr1, expr2);

        public AbstractNode bvneg(AbstractNode expr1) => new BvnegNode(expr1);

        public AbstractNode bvsge(AbstractNode expr1, AbstractNode expr2) => new BvsgeNode(expr1, expr2);

        public AbstractNode bvsle(AbstractNode expr1, AbstractNode expr2) => new BvsleNode(expr1, expr2);

        public AbstractNode bvuge(AbstractNode expr1, AbstractNode expr2) => new BvugeNode(expr1, expr2);

        public AbstractNode bvsgt(AbstractNode expr1, AbstractNode expr2) => new BvsgtNode(expr1, expr2);

        public AbstractNode bvule(AbstractNode expr1, AbstractNode expr2) => new BvuleNode(expr1, expr2);

        public AbstractNode bvashr(AbstractNode expr1, AbstractNode expr2) => new BvashrNode(expr1, expr2);

        public AbstractNode concat(AbstractNode expr1, AbstractNode expr2) => new ConcatNode(expr1, expr2);

        public AbstractNode concat(List<AbstractNode> expressions) => new ConcatNode(expressions);

        // Replace all usages of logical with bvand
        public AbstractNode land(AbstractNode expr1, AbstractNode expr2) => new BvandNode(expr1, expr2);


        // Replace all usages of logical OR with bvor.
        public AbstractNode lor(AbstractNode expr1, AbstractNode expr2) => new BvorNode(expr1, expr2);

        // TODO: (Maybe?) refactor out reference nodes.
        public AbstractNode reference(AbstractNode expr1) => new ReferenceNode(expr1);

        public AbstractNode sx(AbstractNode expr1, AbstractNode expr2) => new SxNode(expr1, expr2);

        public AbstractNode sx(uint sizeExt, AbstractNode expr1) => new SxNode(sizeExt, expr1);

        public AbstractNode zx(AbstractNode sizeExt, AbstractNode expr2) => new ZxNode(sizeExt, expr2);

        public AbstractNode zx(uint sizeExt, AbstractNode expr2) => new ZxNode(sizeExt, expr2);

        public AbstractNode undef(uint size) => new UndefNode(size);
    }
}
