using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TritonTranslator.Arch;

namespace TritonTranslator.Ast
{
    public class MemoryNode : AbstractNode
    {
        public override AstType Type => AstType.MEMORY;

        public MemoryAccess MemoryAccess { get; }

        public AbstractNode AddressNode { get; }

        public MemoryNode(AbstractNode addressNode, uint size)
        {
            AddressNode = addressNode;
            BitvectorSize = size;
            if (addressNode.BitvectorSize != size)
                throw new InvalidOperationException("Address node & provided size do not match.");
            Initialize();
        }

        public override uint ComputeBitvecSize()
        {
            return AddressNode.BitvectorSize;
        }
    }
}
