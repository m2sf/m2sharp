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
 * NonTerminals.cs
 * 
 * provides FIRST() and FOLLOW() sets for each non-terminal symbol //SAM CHANGE
 * used by the parser class for syntax analysis
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

    using System;
    using System.Collections.Generic;

public class NonTerminals : INonTerminals {

    public static Production firstConstParamDependent = Production.FormalType,
                             lastConstParamDependent = Production.AttribFormalParams,
                             firstNoVariantRecDependent = Production.TypeDeclarationTail,
                             lastNoVariantRecDependent = Production.TypeDeclarationTail,
                             firstOptionDependent = firstConstParamDependent,
                             lastOptionDependent = lastNoVariantRecDependent;
    public static uint alternateSetOffset = (uint)lastOptionDependent - (uint)firstOptionDependent + 1;

    #region followSets
    TokenSet[] followSets = {
                                new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000400, /* counter: */ 1 ), /* definitionModule */
                               
                               new TokenSet( /* bits: */ 0x108050C8, 0x00000050, 0x00000000, /* counter: */ 9 ), /* import */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* qualifiedImport */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* unqualifiedImport */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x80000000, 0x00000021, /* counter: */ 3 ), /* identList */
                               
                               new TokenSet( /* bits: */ 0x00001000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* definition */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* constDefinition */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* typeDefinition */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* type */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* derivedOrSubrangeType */
                               
                               new TokenSet( /* bits: */ 0x06501F12, 0x3FFC002C, 0x0000037B, /* counter: */ 34 ), /* qualident */
                               
                               new TokenSet( /* bits: */ 0x02000000, 0x20000000, 0x00000001, /* counter: */ 3 ), /* range */
                               
                               new TokenSet( /* bits: */ 0x02000000, 0x20000000, 0x00000001, /* counter: */ 3 ), /* enumType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* setType */
                               
                               new TokenSet( /* bits: */ 0x02000000, 0x20000000, 0x00000001, /* counter: */ 3 ), /* countableType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* arrayType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* extensibleRecordType */
                               
                               new TokenSet( /* bits: */ 0x00001000, 0x00000040, 0x00000000, /* counter: */ 2 ), /* fieldListSequence */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* variantRecordType */
                               
                               new TokenSet( /* bits: */ 0x00001400, 0x00000000, 0x00000008, /* counter: */ 3 ), /* variantFieldListSeq */
                               
                               new TokenSet( /* bits: */ 0x00001400, 0x00000000, 0x00000009, /* counter: */ 4 ), /* variantFieldList */
                               
                               new TokenSet( /* bits: */ 0x00001400, 0x00000000, 0x00000009, /* counter: */ 4 ), /* variantFields */
                               
                               new TokenSet( /* bits: */ 0x00001400, 0x00000000, 0x00000008, /* counter: */ 3 ), /* variant */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x80000000, 0x00000000, /* counter: */ 1 ), /* caseLabelList */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0xA0000000, 0x00000000, /* counter: */ 2 ), /* caseLabels */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* pointerType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* procedureType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x20000000, 0x00000020, /* counter: */ 2 ), /* simpleFormalType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* procedureHeader */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* procedureSignature */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000021, /* counter: */ 2 ), /* simpleFormalParams */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000400, /* counter: */ 1 ), /* implementationModule */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000400, /* counter: */ 1 ), /* programModule */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* modulePriority */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* block */
                               
                               new TokenSet( /* bits: */ 0x00001008, 0x00000000, 0x00000000, /* counter: */ 2 ), /* declaration */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* typeDeclaration */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* varSizeRecordType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* variableDeclaration */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* procedureDeclaration */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* moduleDeclaration */
                               
                               new TokenSet( /* bits: */ 0x10801048, 0x00000050, 0x00000000, /* counter: */ 7 ), /* export */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000008, /* counter: */ 5 ), /* statementSequence */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* statement */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* assignmentOrProcCall */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* actualParameters */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000020, /* counter: */ 1 ), /* expressionList */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* returnStatement */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* withStatement */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* ifStatement */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* caseStatement */
                               
                               new TokenSet( /* bits: */ 0x00001400, 0x00000000, 0x00000008, /* counter: */ 3 ), /* case */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* loopStatement */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* whileStatement */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* repeatStatement */
                               
                               new TokenSet( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* forStatement */
                               
                               new TokenSet( /* bits: */ 0x06501F12, 0x3FFC002C, 0x0000033B, /* counter: */ 33 ), /* designator */
                               
                               new TokenSet( /* bits: */ 0x06501F12, 0x3FFC022C, 0x0000033B, /* counter: */ 34 ), /* selector */
                               
                               new TokenSet( /* bits: */ 0x02001E10, 0x2000002C, 0x0000022B, /* counter: */ 15 ), /* expression */
                               
                               new TokenSet( /* bits: */ 0x02101E10, 0x23F0002C, 0x0000022B, /* counter: */ 22 ), /* simpleExpression */
                               
                               new TokenSet( /* bits: */ 0x06101E10, 0x23FC002C, 0x0000022B, /* counter: */ 25 ), /* term */
                               
                               new TokenSet( /* bits: */ 0x06501F12, 0x2FFC002C, 0x0000022B, /* counter: */ 30 ), /* simpleTerm */
                               
                               new TokenSet( /* bits: */ 0x06501F12, 0x2FFC002C, 0x0000022B, /* counter: */ 30 ), /* factor */
                               
                               new TokenSet( /* bits: */ 0x06501F12, 0x2FFC002C, 0x0000022B, /* counter: */ 30 ), /* designatorOrFuncCall */
                               
                               new TokenSet( /* bits: */ 0x06501F12, 0x2FFC002C, 0x0000022B, /* counter: */ 30 ), /* setValue */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x20000000, 0x00000200, /* counter: */ 2 ), /* element */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x20000000, 0x00000020, /* counter: */ 2 ), /* formalType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x20000000, 0x00000020, /* counter: */ 2 ), /* attributedFormalType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000020, /* counter: */ 1 ), /* formalParamList */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000021, /* counter: */ 2 ), /* formalParams */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000021, /* counter: */ 2 ), /* attribFormalParams */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* typeDeclarationTail */
                            };

    #endregion

    #region firstSets
    TokenSet[] firstSets = {
                               new TokenSet( /* bits: */ 0x00000080, 0x00000000, 0x00000000, /* counter: */ 1 ), /* definitionModule */
                               
                               new TokenSet( /* bits: */ 0x00090000, 0x00000000, 0x00000000, /* counter: */ 2 ), /* import */
                               
                               new TokenSet( /* bits: */ 0x00080000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* qualifiedImport */
                               
                               new TokenSet( /* bits: */ 0x00010000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* unqualifiedImport */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* identList */
                               
                               new TokenSet( /* bits: */ 0x10000040, 0x00000050, 0x00000000, /* counter: */ 4 ), /* definition */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* constDefinition */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* typeDefinition */
                               
                               new TokenSet( /* bits: */ 0x58000004, 0x00000202, 0x00000050, /* counter: */ 8 ), /* type */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000040, /* counter: */ 2 ), /* derivedOrSubrangeType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* qualident */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000040, /* counter: */ 1 ), /* range */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000010, /* counter: */ 1 ), /* enumType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000002, 0x00000000, /* counter: */ 1 ), /* setType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000050, /* counter: */ 3 ), /* countableType */
                               
                               new TokenSet( /* bits: */ 0x00000004, 0x00000000, 0x00000000, /* counter: */ 1 ), /* arrayType */
                               
                               new TokenSet( /* bits: */ 0x40000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* extensibleRecordType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* fieldListSequence */
                               
                               new TokenSet( /* bits: */ 0x40000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* variantRecordType */
                               
                               new TokenSet( /* bits: */ 0x00000020, 0x00000200, 0x00000000, /* counter: */ 2 ), /* variantFieldListSeq */
                               
                               new TokenSet( /* bits: */ 0x00000020, 0x00000200, 0x00000000, /* counter: */ 2 ), /* variantFieldList */
                               
                               new TokenSet( /* bits: */ 0x00000020, 0x00000000, 0x00000000, /* counter: */ 1 ), /* variantFields */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x000C3E00, 0x00000110, /* counter: */ 10 ), /* variant */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x000C3E00, 0x00000110, /* counter: */ 10 ), /* caseLabelList */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x000C3E00, 0x00000110, /* counter: */ 10 ), /* caseLabels */
                               
                               new TokenSet( /* bits: */ 0x08000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* pointerType */
                               
                               new TokenSet( /* bits: */ 0x10000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* procedureType */
                               
                               new TokenSet( /* bits: */ 0x00000004, 0x00000200, 0x00000000, /* counter: */ 2 ), /* simpleFormalType */
                               
                               new TokenSet( /* bits: */ 0x10000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* procedureHeader */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* procedureSignature */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* simpleFormalParams */
                               
                               new TokenSet( /* bits: */ 0x00040000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* implementationModule */
                               
                               new TokenSet( /* bits: */ 0x00800000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* programModule */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000040, /* counter: */ 1 ), /* modulePriority */
                               
                               new TokenSet( /* bits: */ 0x10801048, 0x00000050, 0x00000000, /* counter: */ 7 ), /* block */
                               
                               new TokenSet( /* bits: */ 0x10800040, 0x00000050, 0x00000000, /* counter: */ 5 ), /* declaration */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* typeDeclaration */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000040, 0x00000000, /* counter: */ 1 ), /* varSizeRecordType */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* variableDeclaration */
                               
                               new TokenSet( /* bits: */ 0x10000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* procedureDeclaration */
                               
                               new TokenSet( /* bits: */ 0x00800000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* moduleDeclaration */
                               
                               new TokenSet( /* bits: */ 0x00004000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* export */
                               
                               new TokenSet( /* bits: */ 0x8022A020, 0x00000381, 0x00000000, /* counter: */ 10 ), /* statementSequence */
                               
                               new TokenSet( /* bits: */ 0x8022A020, 0x00000381, 0x00000000, /* counter: */ 10 ), /* statement */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* assignmentOrProcCall */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000010, /* counter: */ 1 ), /* actualParameters */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x000C3E00, 0x00000110, /* counter: */ 10 ), /* expressionList */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000001, 0x00000000, /* counter: */ 1 ), /* returnStatement */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000100, 0x00000000, /* counter: */ 1 ), /* withStatement */
                               
                               new TokenSet( /* bits: */ 0x00020000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* ifStatement */
                               
                               new TokenSet( /* bits: */ 0x00000020, 0x00000000, 0x00000000, /* counter: */ 1 ), /* caseStatement */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x000C3E00, 0x00000110, /* counter: */ 10 ), /* case */
                               
                               new TokenSet( /* bits: */ 0x00200000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* loopStatement */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000080, 0x00000000, /* counter: */ 1 ), /* whileStatement */
                               
                               new TokenSet( /* bits: */ 0x80000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* repeatStatement */
                               
                               new TokenSet( /* bits: */ 0x00008000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* forStatement */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* designator */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x40000000, 0x00000044, /* counter: */ 3 ), /* selector */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x000C3E00, 0x00000110, /* counter: */ 10 ), /* expression */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x000C3E00, 0x00000110, /* counter: */ 10 ), /* simpleExpression */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x00003E00, 0x00000110, /* counter: */ 8 ), /* term */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x00003E00, 0x00000110, /* counter: */ 8 ), /* simpleTerm */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00003E00, 0x00000110, /* counter: */ 7 ), /* factor */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* designatorOrFuncCall */
                               
                               new TokenSet( /* bits: */ 0x00000000, 0x00000000, 0x00000100, /* counter: */ 1 ), /* setValue */
                               
                               new TokenSet( /* bits: */ 0x01000000, 0x000C3E00, 0x00000110, /* counter: */ 10 ), /* element */
                               
                               new TokenSet( /* bits: */ 0x00000044, 0x00000240, 0x00000000, /* counter: */ 4 ), /* formalType */
                               
                               new TokenSet( /* bits: */ 0x00000040, 0x00000040, 0x00000000, /* counter: */ 2 ), /* attributedFormalType */
                               
                               new TokenSet( /* bits: */ 0x00000040, 0x00000240, 0x00000000, /* counter: */ 3 ), /* formalParamList */
                               
                               new TokenSet( /* bits: */ 0x00000040, 0x00000240, 0x00000000, /* counter: */ 3 ), /* formalParams */
                               
                               new TokenSet( /* bits: */ 0x00000040, 0x00000040, 0x00000000, /* counter: */ 2 ), /* attribFormalParams */
                               
                               new TokenSet( /* bits: */ 0x58000004, 0x00000242, 0x00000050, /* counter: */ 9 ), /* typeDeclarationTail */
                           };
    #endregion

    /* --------------------------------------------------------------------------
     * method Count() -- Returns the number of productions
     * ----------------------------------------------------------------------- */ //SAM CHANGE

    static uint Count() {
        return (uint)Enum.GetNames(typeof(Production)).Length;
    } /* end Count */


    /* --------------------------------------------------------------------------
     * method IsOptionDependent(p)
     * --------------------------------------------------------------------------
     * Returns true if p is dependent on any compiler option, else false.
     * ----------------------------------------------------------------------- */ //SAM CHANGE

    bool IsOptionDependent(Production p) {
        return p >= firstOptionDependent;
    } /* end IsOptionDependent */


    /* --------------------------------------------------------------------------
     * method IsConstParamDependent(p)
     * --------------------------------------------------------------------------
     * Returns true if p is dependent on CONST parameter option, else false.
     * ----------------------------------------------------------------------- */ //SAM CHANGE

    bool IsConstParamDependent(Production p)
    {
        return p >= firstConstParamDependent && p <= lastConstParamDependent;
    } /* end IsConstParamDependent */


    /* --------------------------------------------------------------------------
     * method IsVariantRecordDependent(p)
     * --------------------------------------------------------------------------
     * Returns true if p is dependent on variant record type option, else false.
     * ----------------------------------------------------------------------- */ //SAM CHANGE

    bool IsVariantRecordDependent(Production p) {
        return p >= firstNoVariantRecDependent && p <= lastNoVariantRecDependent;
    }

    /* --------------------------------------------------------------------------
     * method FIRST(p)
     * --------------------------------------------------------------------------
     * Returns a tokenset with the FIRST set of production p.
     * ----------------------------------------------------------------------- */

    TokenSet FIRST(Production p) {
        TokenSet tokenset = null;
        uint index = 0;

        if (IsConstParamDependent(p))
        {
            index = Convert.ToUInt32(p) + alternateSetOffset;
        } /* end if */
        if (IsVariantRecordDependent(p) && CompilerOptions.VariantRecords())
        {
            index = Convert.ToUInt32(p) + alternateSetOffset;
        } /* end if */

        tokenset = firstSets[index];

        return tokenset;
    } /* end FIRST */


    /* --------------------------------------------------------------------------
     * method FOLLOW(p)
     * --------------------------------------------------------------------------
     * Returns a tokenset with the FOLLOW set of production p.
     * ----------------------------------------------------------------------- */

    TokenSet FOLLOW(Production p) {
        TokenSet tokenset = null;
        uint index = 0;

        if (IsConstParamDependent(p)) {
            index = Convert.ToUInt32(p) + alternateSetOffset;
        } /* end if */
        if (IsVariantRecordDependent(p) && !CompilerOptions.VariantRecords()) {
            index = Convert.ToUInt32(p) + alternateSetOffset;
        } /* end if */

        tokenset = followSets[index];

        return tokenset;
    } /* end FOLLOW */


    /* --------------------------------------------------------------------------
     * method NameForProduction(p)
     * --------------------------------------------------------------------------
     * Returns a string with a human readable name for production p.
     * ----------------------------------------------------------------------- */

    string NameForProduction(Production p);



} /* NonTerminals */

} /* namespace */