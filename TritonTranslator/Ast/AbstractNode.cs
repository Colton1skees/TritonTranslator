using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Expression;

namespace TritonTranslator.Ast
{
    public enum AstType : byte
    {
        /// <summary>
        /// Invalid node.
        /// </summary>
        INVALID = 0,  
        /// <summary>
        /// BVADDx y)
        /// </summary>
        BVADD = 5,    
        /// <summary>
        /// (bvand x y)
        /// </summary>
        BVAND = 7,
        /// <summary>
        /// (bvashr x y)
        /// </summary>
        BVASHR = 12,
        /// <summary>
        /// (bvlshr x y)
        /// </summary>
        BVLSHR = 17,
        /// <summary>
        /// (bvmul x y) 
        /// </summary>
        BVMUL = 19,
        /// <summary>
        /// (bvnand x y)
        /// </summary>
        BVNAND = 23,
        /// <summary>
        /// (bvneg x)
        /// </summary>
        BVNEG = 29,
        /// <summary>
        /// (bvnor x y) 
        /// </summary>
        BVNOR = 31,
        /// <summary>
        /// (bvnot x)
        /// </summary>
        BVNOT = 37,
        /// <summary>
        ///  (bvor x y) 
        /// </summary>
        BVOR = 41,
        /// <summary>
        /// ((_ rotate_left x) y)
        /// </summary>
        BVROL = 43,
        /// <summary>
        /// ((_ rotate_right x) y)
        /// </summary>
        BVROR = 47,
        /// <summary>
        /// (bvsdiv x y)
        /// </summary>
        BVSDIV = 53,
        /// <summary>
        /// (bvsge x y)
        /// </summary>
        BVSGE = 59,
        /// <summary>
        ///  (bvsgt x y)
        /// </summary>
        BVSGT = 61,
        /// <summary>
        /// (bvshl x y)
        /// </summary>
        BVSHL = 67,
        /// <summary>
        /// (bvsle x y) 
        /// </summary>
        BVSLE = 71,
        /// <summary>
        /// (bvslt x y)
        /// </summary>
        BVSLT = 73,
        /// <summary>
        /// (bvsmod x y)
        /// </summary>
        BVSMOD = 79,
        /// <summary>
        /// (bvsrem x y) 
        /// </summary>
        BVSREM = 83,
        /// <summary>
        /// (bvsub x y) 
        /// </summary>
        BVSUB = 89,
        /// <summary>
        /// (bvudiv x y)
        /// </summary>
        BVUDIV = 97,
        /// <summary>
        /// (bvuge x y)
        /// </summary>
        BVUGE = 101,
        /// <summary>
        /// (bvugt x y)
        /// </summary>
        BVUGT = 103,
        /// <summary>
        /// (bvule x y)
        /// </summary>
        BVULE = 107,
        /// <summary>
        /// (bvult x y)
        /// </summary>
        BVULT = 109,
        /// <summary>
        /// (bvurem x y)
        /// </summary>
        BVUREM = 113,
        /// <summary>
        /// (bvxnor x y)
        /// </summary>
        BVXNOR = 127,
        /// <summary>
        /// (bvxor x y)
        /// </summary>
        BVXOR = 131,
        /// <summary>
        /// (_ bvx y)
        /// </summary>
        BV = 137,
        /// <summary>
        /// A compound of nodes
        /// </summary>
        COMPOUND = 139,
        /// <summary>
        /// (concat x y z ...)
        /// </summary>
        CONCAT = 149,
        /// <summary>
        /// (declare-fun <var_name> () (_ BitVec <var_size>))
        /// </summary>
        DECLARE = 151,
        /// <summary>
        /// (distinct x y)
        /// </summary>
        DISTINCT = 157,
        /// <summary>
        /// (= x y)
        /// </summary>
        EQUAL = 163,
        /// <summary>
        /// ((_ extract x y) z)
        /// </summary>
        EXTRACT = 167,
        /// <summary>
        /// (forall ((x (_ BitVec <size>)), ...) body)
        /// </summary>
        FORALL = 173,
        /// <summary>
        /// (iff x y)
        /// </summary>
        IFF = 179,
        /// <summary>
        /// Integer node
        /// </summary>
        INTEGER = 181,
        /// <summary>
        /// (ite x y z)
        /// </summary>
        ITE = 191,
        /// <summary>
        /// (and x y)
        /// </summary>
        LAND = 193,
        /// <summary>
        /// (let ((x y)) z)
        /// </summary>
        LET = 197,
        /// <summary>
        /// (and x y)
        /// </summary>
        LNOT = 199,
        /// <summary>
        /// (or x y)
        /// </summary>
        LOR = 211,
        /// <summary>
        /// (xor x y)
        /// </summary>
        LXOR = 223,
        /// <summary>
        /// Reference node
        /// </summary>
        REFERENCE = 227,
        /// <summary>
        /// String node
        /// </summary>
        STRING = 229,
        /// <summary>
        /// ((_ sign_extend x) y)
        /// </summary>
        SX = 233,
        /// <summary>
        /// ((_ zero_extend x) y)
        /// </summary>
        ZX = 241,   
        /// <summary>
        /// Undefined value
        /// </summary>
        UNDEF = 242,
        /// <summary>
        /// Memory address
        /// </summary>
        MEMORY = 243,
        /// <summary>
        /// Register
        /// </summary>
        REGISTER = 244,

        ZERO = 245,
        CARRY = 246,
        OVERFLOW = 247,
        SIGN = 248,
        PARITY = 249,
    }

    public abstract class AbstractNode
    {
        /// <summary>
        /// Micro optimization to reduce list expansions.
        /// </summary>
        protected virtual int DefaultChildrenCount { get; }

        public abstract AstType Type { get; }

        public uint BitvectorSize { get; set; }

        public uint BitSize => BitvectorSize;

        /// <summary>
        /// Gets a list of child nodes.
        /// </summary>
        public List<AbstractNode> Children { get; protected set; }

        public AbstractNode()
        {
            Children = new List<AbstractNode>(DefaultChildrenCount);
        }

        public virtual uint ComputeBitvecSize()
        {
            // Defer size computation to derived classes.
            return BitvectorSize;
        }

        public void Initialize()
        {
            // Initialize the size of each bit vector.
            BitvectorSize = ComputeBitvecSize();

            // Validate that we received the expected number of children,
            // and none of them are null.
            ValidateChildren();

            // Validate that all of the sizes match up.
            ValidateChildSizes();

            if (Children == null)
                Children = new List<AbstractNode>(0);
        }

        protected virtual void ValidateChildren()
        {

        }

        protected virtual void ValidateChildSizes()
        {

        }

        public virtual string GetOperator()
        {
            return string.Format("{0}(", GetType().Name.Replace("Node", ""));
        }

        public override string ToString()
        {
            int tabCount = 0;
            return ToString(ref tabCount);
        }

        public string ToString(ref int tabCount)
        {
            string strTab = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(GetOperator());


            for (int i = 0; i < Children.Count; i++)
            {
                var child = Children[i];

                tabCount++;
                for (int tab = 0; tab <= tabCount; tab++)
                    sb.Append(strTab);
                sb.Append(child.ToString(ref tabCount));
                tabCount--;
                if (i != Children.Count - 1)
                    sb.Append(",");
            }

            sb.Append(")");
            var result = sb.ToString();
            return result;
        }
    }
}
