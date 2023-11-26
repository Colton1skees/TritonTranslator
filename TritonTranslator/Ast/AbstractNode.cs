using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TritonTranslator.Ast
{
    public enum AstClassification
    {
        // Bitwise expression(e.g. a & b)
        Bitwise,
        // Linear expression(e.g. a + b, x * 3434) but never (a * b, x & 3453443)
        Linear,
        // Anything with that has a polynomial   degree greater than one OR contains arithmetic/nonlinear/constant expressions inside
        // of bitwise expressions.
        Nonlinear,
        // Mixed arithmetic and bitwise expressions. These are technically linear.
        // But, they have an important distinction from linear expressions because 
        // mixed expressions cannot be used inside of bitwise expressions.
        // If a mixed expression is used inside of a bitwise operand, the root becomes nonlinear.
        Mixed,
    }

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

        /// <summary>
        /// Temporary variable
        /// </summary>
        TEMPVAR = 245,

        /// <summary>
        /// SSA version of a variable node
        /// </summary>
        SSAVAR = 246,

        ZERO = 247,
        CARRY = 248,
        OVERFLOW = 249,
        SIGN = 250,
        PARITY = 251,
    }

    public abstract class AbstractNode
    {
        private int hash;

        public int astSize;

        public AstContext Context { get; }

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

        public HashSet<TemporaryNode> Variables = new();


        public AstClassification AstClassification { get; protected set; }

        public AbstractNode(AstContext context)
        {
            this.Context = context;
            if (context == null)
                throw new InvalidOperationException($"Asts much be assigned to a context.");

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

            astSize = Children.Count;
            foreach (var child in Children)
            {
                if(astSize >= 15000)
                {
                    astSize = 9999999;
                    continue;
                }
                astSize += child.astSize;;
            }

            foreach(var child in Children)
            {
                if (child is TemporaryNode tempNode)
                    Variables.Add(tempNode);
                else
                    Variables.UnionWith(child.Variables);
            }


            hash = ComputeHash();
            AstClassification = Classify();
        }

        protected virtual void ValidateChildren()
        {

        }

        protected virtual void ValidateChildSizes()
        {

        }

        private AstClassification Classify()
        {
            // If any children are nonlinear, the entire tree is nonlinear.
            if (Children.Any(x => x.AstClassification == AstClassification.Nonlinear))
                return AstClassification.Nonlinear;

            switch(this)
            {
                case BvNode:
                case IntegerNode:
                    return AstClassification.Linear;
                case TemporaryNode:
                    return AstClassification.Linear;
                case BvshlNode:
                    // Shifting left by a constant can be treated as multiplication by a constant.
                    // Anything else is equivalent to exponentation, making it nonlinear.
                    var shlBy = Children[1];
                    return IsConstNode(shlBy) ? AstClassification.Linear : AstClassification.Nonlinear;
                case BvmulNode:
                    // If neither operand is a constant, then the expression must be nonlinear.
                    var constMul = OneOf(Children[0], Children[1], (x) => IsConstNode(x) ? x : null);
                    if (constMul == null)
                    {
                        return AstClassification.Nonlinear;
                    }

                    var other = Children.Single(x => x != constMul);
                    var otherKind = other.AstClassification;
                    // const * bitwise = mixed expression
                    if (otherKind == AstClassification.Bitwise)
                        return AstClassification.Mixed;
                    // const * linear = linear
                    else if (otherKind == AstClassification.Linear)
                        return AstClassification.Linear;
                    // const * nonlinear = nonlinear
                    else if (otherKind == AstClassification.Nonlinear)
                        return AstClassification.Nonlinear;
                    // const * mixed(bitwise and arithmetic) = mixed.
                    else
                        return AstClassification.Mixed;
                case BvaddNode:
                case BvsubNode:
                    if (Children.Any(x => x.AstClassification == AstClassification.Nonlinear))
                        return AstClassification.Nonlinear;
                    else if (Children.Any(x => x.AstClassification == AstClassification.Mixed || x.AstClassification == AstClassification.Bitwise))
                        return AstClassification.Mixed;
                    else if (Children.Any(x => x.AstClassification == AstClassification.Linear))
                        return Children.Any(x => x.AstClassification == AstClassification.Bitwise) ? AstClassification.Mixed : AstClassification.Linear;
                    else
                        return AstClassification.Bitwise;
                case BvandNode:
                case BvorNode:
                case BvxorNode:
                case BvnotNode:
                    bool containsConstantOrArithmetic = Children.Any(x => IsConstNode(x) || x.AstClassification == AstClassification.Linear && x is not TemporaryNode);
                    bool containsMixedOrNonLinear = Children.Any(x => x.AstClassification == AstClassification.Mixed || x.AstClassification == AstClassification.Nonlinear);

                    // If a bitwise expression contains nontrivial constants or arithmetic operations, it is nonlinear.
                    // Alternatively if the bitwise expression has any mixed or nonlinear operations, then it is also nonlinear.
                    // Note that arithmetic or mixed operators are allowed inside of bitwise negation. Nonlinear trees have already been filtered out at this point.
                    if (this is not BvnotNode && (containsConstantOrArithmetic || containsMixedOrNonLinear))
                        return AstClassification.Nonlinear;
                    else if (Children.Any(x => (x.AstClassification == AstClassification.Linear || x.AstClassification == AstClassification.Mixed) && x is not TemporaryNode))
                        return AstClassification.Mixed;
                    else
                        return AstClassification.Bitwise;
                default:
                    return AstClassification.Nonlinear;
            }
        }

        private bool IsConstNode(AbstractNode node)
        {
            return (node is BvNode || node is IntegerNode);
        }

        private static AbstractNode OneOf(AbstractNode a, AbstractNode b, Func<AbstractNode, AbstractNode> predicate)
        {
            var resultA = predicate(a);
            if (resultA != null)
                return resultA;

            var resultB = predicate(b);
            if (resultB != null)
                return resultB;

            return null;
        }

        public virtual string GetOperator()
        {
            return string.Format("{0}", GetType().Name.Replace("Node", ""));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var mapping = new Dictionary<AbstractNode, string>(); 
            ToString(ref sb, ref mapping);
            return sb.ToString();
            // return str;
        }

        internal void ToString(ref StringBuilder sb, ref Dictionary<AbstractNode, string> varMapping)
        {
            // If we've already assigned this expression to a variable, do nothing.
            if (varMapping.ContainsKey(this))
            {
                // Do nothing
                return;
            }

            foreach (var child in this.Children)
            {
                child.ToString(ref sb, ref varMapping);
            }

            //sb.AppendLine($"t{varMapping.Count} = {sb.Ge}");
            var tempName = $"v{varMapping.Count}";
            sb.Append($"{tempName} = {GetOperator()}");

            if (this is not VariableNode && this is not IntegerNode)
                sb.Append("(");

            for (int i = 0; i < Children.Count; i++)
            {
                var op = Children[i];
                sb.Append(varMapping[op]);
                if (i != Children.Count - 1)
                    sb.Append(",");
            }

            if (this is not VariableNode && this is not IntegerNode)
                sb.Append(")");

            sb.Append("\n");
            varMapping[this] = tempName;

            //sb.AppendLine($"t{varMapping.Count} = {}");


            /*
            sb.Append(GetOperator());
            if (this is not VariableNode && this is not IntegerNode)
                sb.Append("(");
            for (int i = 0; i < Children.Count; i++)
            {
                var op = Children[i];
                op.ToString(ref sb);
                if (i != Children.Count - 1)
                    sb.Append(",");
            }

            if (this is not VariableNode && this is not IntegerNode)
                sb.Append(")");
            */
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

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj is not AbstractNode abstractNode)
                return false;

            return EqualityCheck(abstractNode);
        }

        
        private bool EqualityCheck(AbstractNode other)
        {
            // Return true if they're reference equal
            if (ReferenceEquals(this, other))
                return true;
            // Hashes must match
            var thisHash = GetHashCode();
            var otherHash = other.GetHashCode();
            if (thisHash != otherHash)
                return false;
            // Ast sizes(the summation of the number of nodes across the entire ast) must match
            if (astSize != other.astSize) 
                return false;
            if (Type != other.Type)
                return false;
            if (BitSize != other.BitSize)
                return false;

            // If the number of children in both nodes do not match,
            // they cannot be equal.
            if(Children.Count != other.Children.Count) 
                return false;

            if (this is IntegerNode thisInt && other is IntegerNode otherInt)
                return thisInt.Value == otherInt.Value;
            else if (this is TemporaryNode thisTemp && other is TemporaryNode otherTemp)
                return (thisTemp.Uid == otherTemp.Uid) && (thisTemp.Name == otherTemp.Name);
            else if (this is VariableNode)
                throw new InvalidOperationException($"Not supported.");

            // Recursively compare all children.
            for(int i = 0; i < Children.Count; i++)
            {
                bool isEqual = Children[i].EqualityCheck(other.Children[i]);
                if (!isEqual)
                    return false;
            }

            return true;
        }
        
        
        public override int GetHashCode()
        {
            return hash;
        }
        

        private int ComputeHash()
        {
            int hash = 23;
            hash = hash * 23 + Type.GetHashCode();
            hash = hash * 23 + BitSize.GetHashCode();
            foreach(var child in Children)
                hash = hash * 23 + child.GetHashCode();

            if(this is IntegerNode intNode)
                hash = hash * 23 + intNode.Value.GetHashCode();
            if(this is TemporaryNode temporaryNode)
                hash = hash * 23 + temporaryNode.Name.GetHashCode();

            return hash;
        }

        // Arithmetic operators
        public static AbstractNode operator +(AbstractNode a, AbstractNode b) => a.Context.bvadd(a, b);
        public static AbstractNode operator -(AbstractNode a, AbstractNode b) => a.Context.bvsub(a, b);
        public static AbstractNode operator *(AbstractNode a, AbstractNode b) => a.Context.bvmul(a, b);
        public static AbstractNode operator <<(AbstractNode a, AbstractNode b) => a.Context.bvshl(a, b);
        public static AbstractNode operator >>(AbstractNode a, AbstractNode b) => a.Context.bvashr(a, b);

        // Bitwise operators
        public static AbstractNode operator &(AbstractNode a, AbstractNode b) => a.Context.bvand(a, b);
        public static AbstractNode operator |(AbstractNode a, AbstractNode b) => a.Context.bvor(a, b);
        public static AbstractNode operator ^(AbstractNode a, AbstractNode b) => a.Context.bvxor(a, b);
        public static AbstractNode operator ~(AbstractNode a) => a.Context.bvnot(a);

        // Comparisons operators. Note that I don't define greater than or other kinds of comparisons.
        // They have signed and unsigned variants.
        //public static AbstractNode operator ==(AbstractNode a, AbstractNode b) => a.Context.equal(a, b);
        //public static AbstractNode operator !=(AbstractNode a, AbstractNode b) => a.Context.bvnot(a.Context.equal(a, b));
    }
}
