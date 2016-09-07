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
 * IDiagnostics.cs
 *
 * Public diagnostics interface.
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

using System.Collections.Generic;

/* ---------------------------------------------------------------------------
 * type DiagCode
 * ---------------------------------------------------------------------------
 * Enumerated diagnostic codes representing compilation warnings and errors.
 * ------------------------------------------------------------------------ */

public enum DiagCode {
  /* Null Error */

  Unknown,

  /* Option Errors */

  ErrorInvalidOption,
  ErrorInvalidArgument,
  ErrorMissingFilename,
  ErrorInvalidFilename,
  ErrorInputFileNotFound,

  /* Lexical Warnings and Errors */

  WarnDisabledCodeSection,
  ErrorInvalidInputChar,
  ErrorEndOfFileInBlockComment,
  ErrorNewLineInStringLiteral,
  ErrorEndOfFileInStringLiteral,
  ErrorInvalidEscapeSequence,
  ErrorEndOfFileInPragma,
  ErrorMissingStringDelimiter,
  ErrorMissingSuffix,
  ErrorMissingExponent,

  /* Syntax Warnings and Errors */

  ErrorUnexpectedToken,
  WarnSemicolonAfterFieldListSeq,
  WarnEmptyFieldListSeq,
  WarnSemicolonAfterFormalParamList,
  WarnSemicolonAfterStatementSeq,
  WarnEmptyStatementSeq,
  ERROR_Y,              /* Y */

  /* Semantic Errors */

  ERROR_Z               /* Z */

} /* Code */


public interface IDiagnostics {

/* ---------------------------------------------------------------------------
* method isOptionError(code)
* ---------------------------------------------------------------------------
* Returns true if code represents an option error code, otherwise false.
  * ------------------------------------------------------------------------ */

bool isOptionError (DiagCode code);


/* ---------------------------------------------------------------------------
 * method isLexicalError(code)
 * ---------------------------------------------------------------------------
 * Returns true if code represents a lexical error code, otherwise false.
 * ------------------------------------------------------------------------ */

bool isLexicalError (DiagCode code);


/* ---------------------------------------------------------------------------
 * method isSyntaxError(error)
 * ---------------------------------------------------------------------------
 * Returns true if code represents a syntax error code, otherwise false.
 * ------------------------------------------------------------------------ */

bool isSyntaxError (DiagCode code);


/* ---------------------------------------------------------------------------
 * method isSemanticError(code)
 * ---------------------------------------------------------------------------
 * Returns true if code represents a semantic error code, otherwise false.
 * ------------------------------------------------------------------------ */

bool isSemanticError (DiagCode code);


/* ---------------------------------------------------------------------------
 * method diagMsgText(code)
 * ---------------------------------------------------------------------------
 * Returns a pointer to an immutable human readable message string for the
 * given diagnostic code or null if the code is not a valid diagnostic code.
 * ------------------------------------------------------------------------ */

string diagMsgText (DiagCode code);


/* ---------------------------------------------------------------------------
 * method emitError(code)
 * ---------------------------------------------------------------------------
 * Emits an error message for code to the console.
 * ------------------------------------------------------------------------ */

void emitError (DiagCode code);


/* ---------------------------------------------------------------------------
 * method emitErrorWithOffendingStr(code, offendingStr)
 * ---------------------------------------------------------------------------
 * Emits an error message for code and offendingStr to the console.
 * ------------------------------------------------------------------------ */

void emitErrorWithOffendingStr (DiagCode code, string offendingStr);


/* ---------------------------------------------------------------------------
 * method emitErrorWithPos(code, line, column)
 * ---------------------------------------------------------------------------
 * Emits an error message for code, line and column to the console.
 * ------------------------------------------------------------------------ */

void emitErrorWithPos (DiagCode code, uint line, uint column);


/* ---------------------------------------------------------------------------
 * method emitErrorWithChr(error, line, column, offendingChr)
 * ---------------------------------------------------------------------------
 * Emits an error message for code, line, column and offendingChr to the
 * console.
 * ------------------------------------------------------------------------ */

void emitErrorWithChr
  (DiagCode code, uint line, uint column, char offendingChr);


/* ---------------------------------------------------------------------------
 * method m2c_emit_error_w_lex(error, line, column, offendingLexeme)
 * ---------------------------------------------------------------------------
 * Emits an error message for code, line, column and offendingLexeme to the
 * console.
 * ------------------------------------------------------------------------ */

void emitErrorWithLex
  (DiagCode code, uint line, uint column, string offendingLexeme);


/* ---------------------------------------------------------------------------
 * method emitSyntaxErrorWithToken(line, col, unexpToken, offLex, expToken)
 * ---------------------------------------------------------------------------
 * Emits a syntax error message of the following format to the console:
 * line: n, column: m, unexpected offending-symbol offending-lexeme found
 *   expected token
 * ------------------------------------------------------------------------ */

void emitSyntaxErrorWithToken
  (uint line, uint column,
   Token unexpectedToken,
   string offendingLexeme,
   Token expectedToken);


/* ---------------------------------------------------------------------------
 * method emitSyntaxErrorWithSet(line, col, unexpToken, offLex, expTokenSet)
 * ---------------------------------------------------------------------------
 * Emits a syntax error message of the following format to the console:
 * line: n, column: m, unexpected offending-symbol offending-lexeme found
 *   expected set-symbol-1, set-symbol-2, set-symbol-3, ... or set-symbol-N
 * ------------------------------------------------------------------------ */

void emitSyntaxErrorWithSet
  (uint line, uint column,
   Token unexpectedToken,
   string offendingLexeme,
   SortedSet<Token> expectedTokenSet);


/* ---------------------------------------------------------------------------
 * method emitWarningWithPos(code, line, column)
 * ---------------------------------------------------------------------------
 * Emits a warning message for code, line and column to the console.
 * ------------------------------------------------------------------------ */

void emitWarningWithPos (DiagCode code, uint line, uint column);


/* ---------------------------------------------------------------------------
 * method emitWarningWithRange(error, firstLine, lastLine)
 * ---------------------------------------------------------------------------
 * Emits a warning message for range from firstLine to lastLine.
 * ------------------------------------------------------------------------ */

void emitWarningWithRange (DiagCode code, uint firstLine, uint lastLine);


} /* ProtoDiagnostics */

} /* namespace */

/* END OF FILE */
