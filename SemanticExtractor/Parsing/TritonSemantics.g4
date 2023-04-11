grammar TritonSemantics;

func_declaration : func_prototype CURLY_START (statement)* CURLY_END
    | EOF;

// Match the prototype(e.g.): void xchg_s(Instruction inst)
func_prototype : type ID '::' ID LPARAM (type ID (COMMA)?)* RPARAM;

// Match any line of code which may exist within a method.
statement : comment # CommentExpression
    | assignment #AssignmentExpression
    | for_loop #ForLoopExpression
    | ('return;') #ReturnExpression
    | ('break;') #BreakExpression
    | 'throw triton::exceptions::Semantics' LPARAM STRING RPARAM ';' #ThrowSemanticExceptionExpression
    | control_flow_body #ControlFlowExpression
    | func_call #Evaluatable;

// Match all types of comments
comment: LINE_COMMENT | COMMENT;

for_increment_operator:
    ID '++' #PostIncrementOperator
    | '++' #PreIncrementOperator;

for_loop:
    'for' LPARAM assignment any_evaluatable (';')? for_increment_operator RPARAM CURLY_START (statement)* CURLY_END;

control_flow_body:
    'if' LPARAM any_evaluatable RPARAM CURLY_START (statement)* CURLY_END #IfStatement
    | 'if' LPARAM any_evaluatable RPARAM statement #InlineIfStatement
    | 'else if' LPARAM any_evaluatable RPARAM CURLY_START (statement)* CURLY_END #ElseIfStatement
    | 'else if' LPARAM any_evaluatable RPARAM statement #InlineElseIfStatement
    | 'else' CURLY_START (statement)* CURLY_END #ElseStatement
    | 'else' statement #InlineElseStatement
    | switch_body #SwitchStatement
    ;

switch_body:
    'switch' LPARAM any_evaluatable RPARAM CURLY_START ((comment)? case_body)* CURLY_END
    ;

case_body:
    'case' (NUMBER | TRITON_BITSIZE | TRITON_BYTESIZE) ':' (statement)* #InlineCase
    | 'case' (NUMBER | TRITON_BITSIZE | TRITON_BYTESIZE | TRITON_PREFIX) ':' CURLY_START (statement)* CURLY_END #Case
    | 'default:' (CURLY_START)? statement* (CURLY_END)? #DefaultCase
    ;


// Match: type name = [variable_name | call()]
assignment :
    assignment_destination (EQUALS | '|=') any_evaluatable (';')? #StandardAssignment
    // Match instantiation of vectors. Note: This does not handle the vpbroadcastb_s case.
    | 'std::vector<triton::ast::SharedAbstractNode>' ID ';' #AbstractNodeVectorInstantiationAssignment
    | 'triton::arch::OperandWrapper' ID func_body #OperandWrapperInstantiationAssignment
    ;

assignment_destination : new_var_def #NewAssignmentDestination
    | existing_var_def #ExistingAssignmentDestination;

existing_var_def : ID | 'this->exception' | (ID '->isTainted');

new_var_def : type ID;

// Match any expression which evaluates to a value.
any_evaluatable :
    'inst.operands[' NUMBER ']' (';')? #GetOperandWrapperByIndex
    | ID '->isTainted' #GetIsTaintedField
    | func_call (func_call)+ #ChainedCall
    | func_call #FunctionCall
    | any_evaluatable '?' any_evaluatable ':' any_evaluatable #TernaryExpression
    | NUMBER #NumberExpression
    | STRING #StringExpression
    | ID #VariableExpression
    | TRITON_BITSIZE #BitSizeExpression
    | TRITON_BYTESIZE #ByteSizeExpression
    | TRITON_TAINT_ID #TritonTaintIdExpression
    | TRITON_OP_TYPE #TritonOpTypeExpression
    | TRITON_ARCH_ID #TritonArchIdExpression
    | TRITON_PREFIX #TritonPrefixExpression
    | LPARAM any_evaluatable RPARAM #ParenthesizedEvaluatable
    | '!' any_evaluatable #NegatedEvaluatable
    | any_evaluatable OPERATOR any_evaluatable #OperatorExpression
    ;

func_call:
    'this->symbolicEngine->getOperandAst' func_body #CallGetOperandAst
    | 'this->symbolicEngine->getRegisterAst' func_body #CallGetArchitecture
    | 'this->architecture->getArchitecture' func_body #CallGetArchitecture
    | 'this->astCtxt->' ID func_body #CallAstCtxtFunction
    | 'this->symbolicEngine->createSymbolicExpression' func_body #CallCreateSymbolicExpression
    | 'this->symbolicEngine->createSymbolicVolatileExpression' func_body #CallCreateSymbolicVolatileExpression
    | 'this->symbolicEngine->StoreSymbolicAssignment' func_body #CallStoreSymbolicAssignment
    | 'this->symbolicEngine->createSymbolicRegisterExpression' func_body #CreateSymbolicRegisterExpression
    | 'this->taintEngine->taintUnion' func_body #CallTaintUnion
    | 'this->taintEngine->taintAssignment' func_body #CallTaintAssignment
    | 'this->taintEngine->isTainted' func_body #CallIsTainted
    | 'this->taintEngine->setTaint' func_body #CallSetTaint
    | 'this->taintEngine->setTaintRegister' func_body #CallSetTaintRegister
    | 'this->taintEngine->isRegisterTainted' func_body #CallIsRegisterTainted
    | 'this->' FLAG_HELPER_FUNCTIONS func_body #CallFlagHelper
    | 'this->controlFlow_s' func_body #CallControlFlowS
    | (ID)? '.getMemory' func_body #CallGetMemory
    | (ID)? '.getBitSize' func_body #CallGetBitSize
    | (ID)? '.getConstRegister' func_body #CallGetConstantRegister
    | (ID)? '.getNextAddress' func_body #CallGetNextAddress
    | (ID)? '.getAddress' func_body #CallGetAddress
    | (ID)? '.setConditionTaken' func_body #CallSetConditionTaken
    | (ID)? '.getType' func_body #CallGetType
    | (ID)? '.getSize' func_body #CallGetSize
    | (ID)? '->getBitvectorSize' func_body #CallGetBitvectorSize
    | (ID)? '.getRegister' func_body #CallGetRegister
    | (ID)? '.setRegister' func_body #CallSetRegister
    | (ID)? '->evaluate' func_body #CallEvaluate
    | (ID)? '.getPrefix' func_body #CallGetPrefix
    | (ID)? '.setPrefix' func_body #CallGetPrefix
    | (ID)? '.getLow' func_body #CallGetLow
    | (ID)? '.getHigh' func_body #CallGetHigh
    | '.is_zero' func_body #CallGetIsZero
    | (ID)? '.removeWrittenRegister' func_body #CallGetIsZero
    | '->getBitvectorSize' func_body #CallGetBitvectorSize
    | 'triton::arch::OperandWrapper' func_body #CallOperandWrapperCtor
    | 'triton::arch::MemoryAccess' func_body #CallMemoryAccessCtor
    | ('arch::Register' | 'Register') func_body #CallRegisterCtor
    | 'this->architecture->getRegister' func_body #CallGetArchRegister
    | 'this->architecture->getParentRegister' func_body #CallGetParentRegister
    | 'this->architecture->getProgramCounter' func_body #CallGetProgramCounter
    | 'this->undefined_s' func_body #CallUndefined
    | 'this->clearFlag_s' func_body #CallClearFlag

    // Vector operations
    | (ID) '.reserve' func_body #CallVecReserve
    | (ID) '.push_back' func_body #CallVecPushBack
    ;

func_body: LPARAM (any_evaluatable (COMMA)? (comment?))* RPARAM (';')?;

type: 'void' # VoidType
    | 'bool' #BoolType
    | ('auto&' | 'auto') #AutoType
    | ('const triton::engines::symbolic::SharedSymbolicExpression&' |'triton::engines::symbolic::SharedSymbolicExpression') #SymbolicExpressionType
    | 'const triton::ast::SharedAbstractNode&' #AbstractNodeType
    | 'triton::arch::OperandWrapper&' #OperandWrapperType
    | 'triton::arch::Instruction&' #InstType
    | 'triton::uint32' #Uint32Type
    | 'size_t' #Size
    ;

FLAG_HELPER_FUNCTIONS :
    'af_s'
    | 'cfAdd_s'
    | 'ofAdd_s'
    | 'cfSub_s'
    | 'ofSub_s'
    | 'pf_s'
    | 'sf_s'
    | 'zf_s'
    | 'cfShl_s'
    | 'ofShl_s'
    | 'pfShl_s'
    | 'sfShl_s'
    | 'zfShl_s'
    | 'cfShld_s'
    | 'ofShld_s'
    | 'sfShld_s'
    | 'cfPtest_s'
    ;

ID          : ([_a-zA-Z][_a-zA-Z0-9]+);


fragment CALL_END: ';'?;


CURLY_START: '{';
CURLY_END : '}';

LPARAM : '(';
RPARAM : ')';
COMMA : ',';
EQUALS : '=';

OPERATOR: '-' | '+' | '*' | '==' | '!=' | '&&' | '&' | '||' | '|' | '>' | '<' | '<=' | '/';

TRITON_PREFIX:
    'triton::arch::x86::ID_PREFIX_INVALID'
    | 'triton::arch::x86::ID_PREFIX_REPE'
    | 'triton::arch::x86::ID_PREFIX_REP'
    | 'triton::arch::x86::ID_PREFIX_REPNE';

TRITON_ARCH_ID: 'triton::arch::architecture_e::' ID;
TRITON_BITSIZE: 'triton::bitsize::' ID;
TRITON_BYTESIZE: 'triton::size::' ID;
TRITON_TAINT_ID: 'triton::engines::taint::' ID;
TRITON_OP_TYPE: 'triton::arch::' ID;

NUMBER      : [0-9]+ | '0x' [a-fA-F0-9]+;
STRING      : ('"' ~["]* '"') | '%' STRING;
WS : [ \t\r\n]+ -> skip ;

COMMENT
    : '/*' .*? '*/'
    ;

LINE_COMMENT
    : '//' ~[\r\n]*
    ;


root: func_declaration;
