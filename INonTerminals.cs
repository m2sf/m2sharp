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
 * INonTerminals.cs
 *
 * Public interface for Non-Terminal's FIRST and FOLLOW set lookup.
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

namespace M2SF.M2Sharp {

/* --------------------------------------------------------------------------
 * type Production
 * --------------------------------------------------------------------------
 * Enumerated production values representing Modula-2 non-terminal symbols.
 * ----------------------------------------------------------------------- */

public enum Production {
  /* Productions with unique FIRST and FOLLOW sets */

  DefinitionModule,         /* definitionModule */
  Import,                   /* import */
  QualifiedImport,          /* qualifiedImport */
  UnqualifiedImport,        /* unqualifiedImport */
  IdentList,                /* identList */
  Definition,               /* definition */
  ConstDefinition,          /* constDefinition */
  TypeDefinition,           /* typeDefinition */
  Type,                     /* type */
  DerivedOrSubrangeType,    /* derivedOrSubrangeType */
  Qualident,                /* qualident */
  Range,                    /* range */
  EnumType,                 /* enumType */
  SetType,                  /* setType */
  CountableType,            /* countableType */
  ArrayType,                /* arrayType */
  ExtensibleRecordType,     /* extensibleRecordType */
  FieldListSequence,        /* fieldListSequence */
  VariantRecordType,        /* variantRecordType */
  VariantFieldListSeq,      /* variantFieldListSeq */
  VariantFieldList,         /* variantFieldList */
  VariantFields,            /* variantFields */
  Variant,                  /* variant */
  CaseLabelList,            /* caseLabelList */
  CaseLabels,               /* caseLabels */
  PointerType,              /* pointerType */
  ProcedureType,            /* procedureType */
  SimpleFormalType,         /* simpleFormalType */
  ProcedureHeader,          /* procedureHeader */
  ProcedureSignature,       /* procedureSignature */
  SimpleFormalParams,       /* simpleFormalParams */
  ImplementationModule,     /* implementationModule */
  ProgramModule,            /* programModule */
  ModulePriority,           /* modulePriority */
  Block,                    /* block */
  Declaration,              /* declaration */
  TypeDeclaration,          /* typeDeclaration */
  VarSizeRecordType,        /* varSizeRecordType */
  VariableDeclaration,      /* variableDeclaration */
  ProcedureDeclaration,     /* procedureDeclaration */
  ModuleDeclaration,        /* moduleDeclaration */
  Export,                   /* export */
  StatementSequence,        /* statementSequence */
  Statement,                /* statement */
  AssignmentOrProcCall,     /* assignmentOrProcCall */
  ActualParameters,         /* actualParameters */
  ExpressionList,           /* expressionList */
  ReturnStatement,          /* returnStatement */
  WithStatement,            /* withStatement */
  IfStatement,              /* ifStatement */
  CaseStatement,            /* caseStatement */
  Case,                     /* case */
  LoopStatement,            /* loopStatement */
  WhileStatement,           /* whileStatement */
  RepeatStatement,          /* repeatStatement */
  ForStatement,             /* forStatement */
  Designator,               /* designator */
  Selector,                 /* selector */
  Expression,               /* expression */
  SimpleExpression,         /* simpleExpression */
  Term,                     /* term */
  SimpleTerm,               /* simpleTerm */
  Factor,                   /* factor */
  DesignatorOrFuncCall,     /* designatorOrFuncCall */
  SetValue,                 /* setValue */
  Element,                  /* element */
  
  /* Productions with alternative FIRST or FOLLOW sets */
  
  /* Dependent on option --const-parameters */
  FormalType,               /* formalType */
  AttributedFormalType,     /* attributedFormalType */
  FormalParamList,          /* formalParamList */
  FormalParams,             /* formalParams */
  AttribFormalParams,       /* attribFormalParams */
  
  /* Dependent on option --no-variant-records */
  TypeDeclarationTail;      /* typeDeclarationTail */

} /* Production */


interface INonTerminals {

/* --------------------------------------------------------------------------
 * method Count() -- Returns the number of productions
 * ----------------------------------------------------------------------- */

public uint Count ();


/* --------------------------------------------------------------------------
 * method IsOptionDependent(p)
 * --------------------------------------------------------------------------
 * Returns true if p is dependent on any compiler option, else false.
 * ----------------------------------------------------------------------- */

public bool IsOptionDependent (Production p);


/* --------------------------------------------------------------------------
 * method IsConstParamDependent(p)
 * --------------------------------------------------------------------------
 * Returns true if p is dependent on CONST parameter option, else false.
 * ----------------------------------------------------------------------- */

public bool IsConstParamDependent (Production p);


/* --------------------------------------------------------------------------
 * method IsVariantRecordDependent(p)
 * --------------------------------------------------------------------------
 * Returns true if p is dependent on variant record type option, else false.
 * ----------------------------------------------------------------------- */

public bool IsVariantRecordDependent (Production p);


/* --------------------------------------------------------------------------
 * method FIRST(p)
 * --------------------------------------------------------------------------
 * Returns a tokenset with the FIRST set of production p.
 * ----------------------------------------------------------------------- */

public TokenSet FIRST (Production p);


/* --------------------------------------------------------------------------
 * method FOLLOW(p)
 * --------------------------------------------------------------------------
 * Returns a tokenset with the FOLLOW set of production p.
 * ----------------------------------------------------------------------- */

public TokenSet FOLLOW (Production p);


/* --------------------------------------------------------------------------
 * method NameForProduction(p)
 * --------------------------------------------------------------------------
 * Returns a string with a human readable name for production p.
 * ----------------------------------------------------------------------- */

public string NameForProduction (Production p);


} /* INonTerminals */

} /* M2SF.M2Sharp */

/* END OF FILE */