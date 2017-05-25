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
                                TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000400, /* counter: */ 1 ), /* definitionModule */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x108050C8, 0x00000050, 0x00000000, /* counter: */ 9 ), /* import */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* qualifiedImport */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* unqualifiedImport */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x80000000, 0x00000021, /* counter: */ 3 ), /* identList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* definition */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* constDefinition */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* typeDefinition */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* type */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* derivedOrSubrangeType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x06501F12, 0x3FFC002C, 0x0000037B, /* counter: */ 34 ), /* qualident */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x20000000, 0x00000001, /* counter: */ 3 ), /* range */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x20000000, 0x00000001, /* counter: */ 3 ), /* enumType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* setType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x20000000, 0x00000001, /* counter: */ 3 ), /* countableType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* arrayType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* extensibleRecordType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001000, 0x00000040, 0x00000000, /* counter: */ 2 ), /* fieldListSequence */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* variantRecordType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001400, 0x00000000, 0x00000008, /* counter: */ 3 ), /* variantFieldListSeq */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001400, 0x00000000, 0x00000009, /* counter: */ 4 ), /* variantFieldList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001400, 0x00000000, 0x00000009, /* counter: */ 4 ), /* variantFields */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001400, 0x00000000, 0x00000008, /* counter: */ 3 ), /* variant */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x80000000, 0x00000000, /* counter: */ 1 ), /* caseLabelList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0xA0000000, 0x00000000, /* counter: */ 2 ), /* caseLabels */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* pointerType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* procedureType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x20000000, 0x00000020, /* counter: */ 2 ), /* simpleFormalType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* procedureHeader */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* procedureSignature */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000021, /* counter: */ 2 ), /* simpleFormalParams */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000400, /* counter: */ 1 ), /* implementationModule */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000400, /* counter: */ 1 ), /* programModule */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* modulePriority */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* block */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001008, 0x00000000, 0x00000000, /* counter: */ 2 ), /* declaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* typeDeclaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* varSizeRecordType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* variableDeclaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* procedureDeclaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* moduleDeclaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x10801048, 0x00000050, 0x00000000, /* counter: */ 7 ), /* export */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000008, /* counter: */ 5 ), /* statementSequence */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* statement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* assignmentOrProcCall */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* actualParameters */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000020, /* counter: */ 1 ), /* expressionList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* returnStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* withStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* ifStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* caseStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001400, 0x00000000, 0x00000008, /* counter: */ 3 ), /* case */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* loopStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* whileStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* repeatStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00001C00, 0x00000020, 0x00000009, /* counter: */ 6 ), /* forStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x06501F12, 0x3FFC002C, 0x0000033B, /* counter: */ 33 ), /* designator */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x06501F12, 0x3FFC022C, 0x0000033B, /* counter: */ 34 ), /* selector */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02001E10, 0x2000002C, 0x0000022B, /* counter: */ 15 ), /* expression */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02101E10, 0x23F0002C, 0x0000022B, /* counter: */ 22 ), /* simpleExpression */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x06101E10, 0x23FC002C, 0x0000022B, /* counter: */ 25 ), /* term */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x06501F12, 0x2FFC002C, 0x0000022B, /* counter: */ 30 ), /* simpleTerm */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x06501F12, 0x2FFC002C, 0x0000022B, /* counter: */ 30 ), /* factor */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x06501F12, 0x2FFC002C, 0x0000022B, /* counter: */ 30 ), /* designatorOrFuncCall */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x06501F12, 0x2FFC002C, 0x0000022B, /* counter: */ 30 ), /* setValue */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x20000000, 0x00000200, /* counter: */ 2 ), /* element */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x20000000, 0x00000020, /* counter: */ 2 ), /* formalType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x20000000, 0x00000020, /* counter: */ 2 ), /* attributedFormalType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000020, /* counter: */ 1 ), /* formalParamList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000021, /* counter: */ 2 ), /* formalParams */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000021, /* counter: */ 2 ), /* attribFormalParams */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000001, /* counter: */ 1 ), /* typeDeclarationTail */
                            };

    #endregion

    #region firstSets
    TokenSet[] firstSets = {
                               TokenSet.newFromRawData( /* bits: */ 0x00000100, 0x00000000, 0x00000000, /* counter: */ 1 ), /* definitionModule */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00120000, 0x00000000, 0x00000000, /* counter: */ 2 ), /* import */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00100000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* qualifiedImport */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00020000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* unqualifiedImport */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* identList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x20000080, 0x000000a0, 0x00000000, /* counter: */ 4 ), /* definition */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* constDefinition */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* typeDefinition */
                               
                               TokenSet.newFromRawData( /* bits: */ 0xb0000008, 0x00000404, 0x00000140, /* counter: */ 8 ), /* type */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000100, /* counter: */ 2 ), /* derivedOrSubrangeType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* qualident */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000100, /* counter: */ 1 ), /* range */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000040, /* counter: */ 1 ), /* enumType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000004, 0x00000000, /* counter: */ 1 ), /* setType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000140, /* counter: */ 3 ), /* countableType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000008, 0x00000000, 0x00000000, /* counter: */ 1 ), /* arrayType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x80000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* extensibleRecordType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* fieldListSequence */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x80000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* variantRecordType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000040, 0x00000400, 0x00000000, /* counter: */ 2 ), /* variantFieldListSeq */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000040, 0x00000400, 0x00000000, /* counter: */ 2 ), /* variantFieldList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000040, 0x00000000, 0x00000000, /* counter: */ 1 ), /* variantFields */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00187c00, 0x00000440, /* counter: */ 10 ), /* variant */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00187c00, 0x00000440, /* counter: */ 10 ), /* caseLabelList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00187c00, 0x00000440, /* counter: */ 10 ), /* caseLabels */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x10000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* pointerType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x20000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* procedureType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000008, 0x00000400, 0x00000000, /* counter: */ 2 ), /* simpleFormalType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x20000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* procedureHeader */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* procedureSignature */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* simpleFormalParams */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00080000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* implementationModule */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x01000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* programModule */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000100, /* counter: */ 1 ), /* modulePriority */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x21002090, 0x000000a0, 0x00000000, /* counter: */ 7 ), /* block */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x21000080, 0x000000a0, 0x00000000, /* counter: */ 5 ), /* declaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* typeDeclaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000080, 0x00000000, /* counter: */ 1 ), /* varSizeRecordType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* variableDeclaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x20000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* procedureDeclaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x01000000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* moduleDeclaration */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00008000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* export */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00454040, 0x00000703, 0x00000000, /* counter: */ 10 ), /* statementSequence */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00454040, 0x00000703, 0x00000000, /* counter: */ 10 ), /* statement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* assignmentOrProcCall */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000040, /* counter: */ 1 ), /* actualParameters */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00187c00, 0x00000440, /* counter: */ 10 ), /* expressionList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000002, 0x00000000, /* counter: */ 1 ), /* returnStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000200, 0x00000000, /* counter: */ 1 ), /* withStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00040000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* ifStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000040, 0x00000000, 0x00000000, /* counter: */ 1 ), /* caseStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00187c00, 0x00000440, /* counter: */ 10 ), /* case */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00400000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* loopStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000100, 0x00000000, /* counter: */ 1 ), /* whileStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000001, 0x00000000, /* counter: */ 1 ), /* repeatStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00010000, 0x00000000, 0x00000000, /* counter: */ 1 ), /* forStatement */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* designator */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000111, /* counter: */ 3 ), /* selector */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00187c00, 0x00000440, /* counter: */ 10 ), /* expression */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00187c00, 0x00000440, /* counter: */ 10 ), /* simpleExpression */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00007c00, 0x00000440, /* counter: */ 8 ), /* term */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00007c00, 0x00000440, /* counter: */ 8 ), /* simpleTerm */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00007c00, 0x00000440, /* counter: */ 7 ), /* factor */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000400, 0x00000000, /* counter: */ 1 ), /* designatorOrFuncCall */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000000, 0x00000000, 0x00000400, /* counter: */ 1 ), /* setValue */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x02000000, 0x00187c00, 0x00000440, /* counter: */ 10 ), /* element */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000088, 0x00000480, 0x00000000, /* counter: */ 4 ), /* formalType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000080, 0x00000080, 0x00000000, /* counter: */ 2 ), /* attributedFormalType */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000080, 0x00000480, 0x00000000, /* counter: */ 3 ), /* formalParamList */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000080, 0x00000480, 0x00000000, /* counter: */ 3 ), /* formalParams */
                               
                               TokenSet.newFromRawData( /* bits: */ 0x00000080, 0x00000080, 0x00000000, /* counter: */ 2 ), /* attribFormalParams */
                               
                               TokenSet.newFromRawData( /* bits: */ 0xb0000008, 0x00000484, 0x00000140, /* counter: */ 9 ), /* typeDeclarationTail */
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