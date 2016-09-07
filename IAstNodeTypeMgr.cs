/* M2Sharp -- Modula-2 to C# Translator & Compiler
 *
 * Copyright (c) 2016 The Modula-2 Software Foundation
 *
 * Author & Maintainer: Benjamin Kowarsch <trijezdci@org.m2sf>
 *
 * @synopsis
 *
 * M2Sharp is a multi-dialect Modula-2 to C# translator and via-C# compiler.
 * It supports the dialects described in the 3rd and 4th editions of Niklaus
 * Wirth's book "Programming in Modula-2" (PIM) published by Springer Verlag,
 * and an extended mode with select features from the revised language by
 * B.Kowarsch and R.Sutcliffe "Modula-2 Revision 2010" (M2R10).
 *
 * In translator mode, M2Sharp translates Modula-2 source to C# source files.
 * In compiler mode, M2Sharp compiles Modula-2 source via C# source files
 * to object code or executables using the host system's C# compiler.
 *
 * @repository
 *
 * https://github.com/m2sf/m2sharp
 *
 * @file
 *
 * IAstNodeTypeMgr.cs
 *
 * Public interface for AST node types and node type checks.
 *
 * @license
 *
 * M2Sharp is free software: you can redistribute and/or modify it under the
 * terms of the GNU Lesser General Public License (LGPL) either version 2.1
 * or at your choice version 3 as published by the Free Software Foundation.
 * However, you may not alter the copyright, author and license information.
 *
 * M2Sharp is distributed in the hope that it will be useful,  but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  Read the license for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with M2Sharp. If not, see <https://www.gnu.org/copyleft/lesser.html>.
 *
 * NB: Components in the domain part of email addresses are in reverse order.
 */

namespace org.m2sf.m2sharp {

/* ---------------------------------------------------------------------------
 * type AstNodeType
 * ---------------------------------------------------------------------------
 * Enumerated values representing AST node types.
 * ------------------------------------------------------------------------ */

public enum AstNodeType {

  /* Empty Node Type */

  AST_EMPTY,

  /* Root Node Type */

  AST_ROOT,

  /* Definition Module Non-Terminal Node Types */

  AST_DEFMOD,             /* definition module node type */
  AST_IMPLIST,            /* qualified import list node type */
  AST_IMPORT,             /* qualified import list node type */
  AST_UNQIMP,             /* unqualified import list node type */
  AST_DEFLIST,            /* definition list node type */

  AST_CONSTDEF,           /* constant definition node type */
  AST_TYPEDEF,            /* type definition node type */
  AST_PROCDEF,            /* procedure definition node type */

  AST_SUBR,               /* subrange type node type */
  AST_ENUM,               /* enumeration type node type */
  AST_SET,                /* set type node type */
  AST_ARRAY,              /* array type node type */
  AST_RECORD,             /* simple record type node type */
  AST_POINTER,            /* pointer type node type */
  AST_PROCTYPE,           /* procedure type node type */

  AST_EXTREC,             /* extensible record type node type */
  AST_VRNTREC,            /* variant record type node type */

  AST_INDEXLIST,          /* array index type list node type */

  AST_FIELDLISTSEQ,       /* field list sequence node type */
  AST_FIELDLIST,          /* field list node type */
  AST_VFLISTSEQ,          /* variant field list sequence node type */
  AST_VFLIST,             /* variant field list node type */
  AST_VARIANTLIST,        /* variant list node type */
  AST_VARIANT,            /* variant node type */
  AST_CLABELLIST,         /* case label list node type */
  AST_CLABELS,            /* case labels node type */

  AST_FTYPELIST,          /* formal type list node type */
  AST_ARGLIST,            /* variadic parameter list formal type node type */
  AST_OPENARRAY,          /* open array formal type node type */
  AST_CONSTP,             /* CONST formal type node type */
  AST_VARP,               /* VAR formal type node type */
  AST_FPARAMLIST,         /* formal parameter list node type */
  AST_FPARAMS,            /* formal parameters node type */

  /* Implementation/Program Module AST Node Types */

  AST_IMPMOD,             /* implementation/program module node type */
  AST_BLOCK,              /* block node type */
  AST_DECLLIST,           /* declaration list node type */

  AST_TYPEDECL,           /* type declaration node type */
  AST_VARDECL,            /* variable declaration node type */
  AST_PROC,               /* procedure declaration node type */
  AST_MODDECL,            /* local module declaration node type */

  AST_VSREC,              /* variable size record type node type */
  AST_VSFIELD,            /* variable size field node type */

  AST_EXPORT,             /* unqualified export list node type */
  AST_QUALEXP,            /* qualified export list node type */

  AST_STMTSEQ,            /* statement sequence node type */

  AST_ASSIGN,             /* assignment node type */
  AST_PCALL,              /* procedure call node type */
  AST_RETURN,             /* RETURN statement node type */
  AST_WITH,               /* WITH statement node type */
  AST_IF,                 /* IF statement node type */
  AST_SWITCH,             /* CASE statement node type */
  AST_LOOP,               /* LOOP statement node type */
  AST_WHILE,              /* WHILE statement node type */
  AST_REPEAT,             /* REPEAT statement node type */
  AST_FORTO,              /* FOR TO statement node type */
  AST_EXIT,               /* EXIT statement node type */

  AST_ARGS,               /* actual parameter list node type */

  AST_ELSIFSEQ,           /* ELSIF branch sequence node type */
  AST_ELSIF,              /* ELSIF branch node type */
  AST_CASELIST,           /* case list node type */
  AST_CASE,               /* case branch node type */
  AST_ELEMLIST,           /* element list node type */
  AST_RANGE,              /* expression range node type */

  /* Designator Subnode Types */

  AST_FIELD,              /* record field selector node type */
  AST_INDEX,              /* array subscript node type */

  /* Expression Node Types */

  AST_DESIG,              /* designator node type */
  AST_DEREF,              /* pointer dereference node type */

  AST_NEG,                /* arithmetic negation sub-expression node */
  AST_NOT,                /* logical negation sub-expression node */

  AST_EQ,                 /* equality sub-expression node */
  AST_NEQ,                /* inequality sub-expression node */
  AST_LT,                 /* less-than sub-expression node */
  AST_LTEQ,               /* less-than-or-equal sub-expression node */
  AST_GT,                 /* greater-than sub-expression node */
  AST_GTEQ,               /* greater-than-or-equal sub-expression node */
  AST_IN,                 /* set membership sub-expression node */
  AST_PLUS,               /* plus sub-expression node */
  AST_MINUS,              /* minus sub-expression node */
  AST_OR,                 /* logical disjunction sub-expression node */
  AST_ASTERISK,           /* asterisk sub-expression node */
  AST_SOLIDUS,            /* solidus sub-expression node */
  AST_DIV,                /* euclidean division sub-expression node */
  AST_MOD,                /* modulus sub-expression node */
  AST_AND,                /* logical conjunction expression node */

  AST_FCALL,              /* function call node */
  AST_SETVAL,             /* set value node */

  /* Identifier Node Types */

  AST_IDENT,              /* identifier node type */
  AST_QUALIDENT,          /* qualified identifier node type */

  /* Literal Value Node Types */

  AST_INTVAL,             /* whole number value node */
  AST_REALVAL,            /* real number value node */
  AST_CHRVAL,             /* character code value node */
  AST_QUOTEDVAL,          /* quoted literal value node */

  AST_IDENTLIST,          /* identifier list node type */

  /* Compilation Parameter Node Types */

  AST_FILENAME,           /* filename node type */
  AST_OPTIONS,            /* compiler option list node type */

  /* Invalid Node Type */

  AST_INVALID             /* for use as failure indicator */

} /* AstNodeType */


/* ---------------------------------------------------------------------------
 * AST node type groupings.
 * ---------------------------------------------------------------------------
 * first valid node type : AST_EMPTY
 * last valid node type : AST_QUOTEDVAL
 *
 * first non-terminal node type : AST_EMPTY
 * last non-terminal node type : AST_SETVAL
 *
 * first terminal node type :  AST_INTVAL
 * last terminal node type : AST_OPTIONS
 *
 * first definition node type : AST_CONSTDEF
 * last definition node type : AST_PROCDEF
 *
 * first type definition node type : AST_SUBR
 * last type definition node type : AST_VRNTREC
 *
 * first field type node type : AST_SUBR
 * last field type node type : AST_PROCTYPE
 *
 * first declaration node type : AST_TYPEDECL
 * last declaration node type : AST_MODDECL
 *
 * first statement node type : AST_ASSIGN
 * last statement node type : AST_EXIT
 *
 * first expression node type : AST_DESIG
 * last expression node type : AST_QUOTEDVAL
 *
 * first literal node type : AST_INTVAL
 * last literal node type : AST_QUOTEDVAL
 * ------------------------------------------------------------------------ */


public interface IAstNodeTypeMgr {

/* ---------------------------------------------------------------------------
 * method IsValid(nodeType)
 * ---------------------------------------------------------------------------
 * Returns true if nodeType is a valid node type, otherwise false.
 * ------------------------------------------------------------------------ */

bool IsValid(AstNodeType nodeType);


/* ---------------------------------------------------------------------------
 * method IsNonterminalType(nodeType)
 * ---------------------------------------------------------------------------
 * Returns true if nodeType is a nonterminal node type, otherwise false.
 * ------------------------------------------------------------------------ */

bool IsNonterminalType (AstNodeType nodeType);


/* ---------------------------------------------------------------------------
 * method IsTerminalType(nodeType)
 * ---------------------------------------------------------------------------
 * Returns true if nodeType is a terminal node type, otherwise false.
 * ------------------------------------------------------------------------ */

bool IsTerminalType (AstNodeType nodeType);


/* ---------------------------------------------------------------------------
 * method IsListType(nodeType)
 * ---------------------------------------------------------------------------
 * Returns true if nodeType is a list node type, otherwise false.
 * ------------------------------------------------------------------------ */

bool IsListType (AstNodeType nodeType);


/* ---------------------------------------------------------------------------
 * method IsLegalSubnodeCount(nodeType, subnodeCount)
 * ---------------------------------------------------------------------------
 * Returns true if the given subnode count is a legal value for the given
 * node type, otherwise false.
 * ------------------------------------------------------------------------ */

bool IsLegalSubnodeCount (AstNodeType nodeType, int SubnodeCount);


/* ---------------------------------------------------------------------------
 * method IsLegalSubnodeType(inNodeType, subnodeType, index)
 * ---------------------------------------------------------------------------
 * Returns true if the given subnode type is a legal node type for the given
 * index in a node of the given subnode type, otherwise false.
 * ------------------------------------------------------------------------ */

bool IsLegalSubnodeType
  (AstNodeType inNodeType, AstNodeType subnodeType, int index);


/* ---------------------------------------------------------------------------
 * method NameForNodeType(nodeType)
 * ---------------------------------------------------------------------------
 * Returns a string with a human readable name for nodeType or null if the
 * given node type is invalid.
 * ------------------------------------------------------------------------ */

string NameForNodeType (AstNodeType nodeType);


} /* IAstNodeTypeMgr */

} /* namespace */

/* END OF FILE */
