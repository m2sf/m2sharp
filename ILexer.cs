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
 * ILexer.cs
 *
 * Public lexer interface.
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
 * Lexer status codes
 * ------------------------------------------------------------------------ */

public enum LexerStatus {
  Success,
  FileNotFound,
  FileAccessDenied,
  NotInitialized,
  TODO
} /* LexerStatus */


public interface ILexer {

/* ---------------------------------------------------------------------------
 * Factory Methods
 * ---------------------------------------------------------------------------
 * Since C# does not fully support the concept of information hiding,
 * factory methods are specified as comments for documentation purposes.
 * The class constructor must be hidden to prevent clients from using it.
 * ------------------------------------------------------------------------ */


/* ---------------------------------------------------------------------------
 * Lexical limits
 * ------------------------------------------------------------------------ */

uint MaxIdentLength (); /* default 32 */

uint CommentNestingLimit (); /* default 100 */


/* ---------------------------------------------------------------------------
 * factory method newLexer(filename)
 * ---------------------------------------------------------------------------
 * Creates a new lexer instance, opens an input file, associates the file with
 * the newly created lexer and returns a Result pair with the lexer reference
 * and a status value.
 *
 * pre-conditions:
 * o  filename must refer to an existing and accessible input file 
 *
 * post-conditions:
 * o  lexer is created
 * o  status is set to Success
 *
 * error-conditions:
 * o  if the file represented by filename cannot be found
 *    lexer is set to null, status is set to FileNotFound
 * o  if the file represented by filename cannot be accessed
 *    lexer is set to null, status is set to FileAccessDenied
 * ----------------------------------------------------------------------- */

// public static Result<ILexer, LexerStatus> NewLexer (string filename);


/* --------------------------------------------------------------------------
 * method ReadSym()
 * --------------------------------------------------------------------------
 * Reads the lookahead symbol from the source file associated with lexer and
 * consumes it, thus advancing the current reading position, then returns
 * the symbol's token.
 *
 * pre-conditions:
 * o  lexer instance must have been created with constructor NewLexer()
 *    so that it is associated with an input source file
 *
 * post-conditions:
 * o  character code of lookahead character or EOF is returned
 * o  current reading position and line and column counters are updated
 * o  file status is set to Success
 *
 * error-conditions:
 * o  if no source file is associated with lexer, no operation is carried out
 *    and status is set to NotInitialized
 * ----------------------------------------------------------------------- */

Token ReadSym();


/* --------------------------------------------------------------------------
 * method NextSym()
 * --------------------------------------------------------------------------
 * Reads the lookahead symbol from the source file associated with lexer but
 * does not consume it, thus not advancing the current reading position,
 * then returns the symbol's token.
 *
 * pre-conditions:
 * o  lexer instance must have been created with constructor NewLexer()
 *    so that it is associated with an input source file
 *
 * post-conditions:
 * o  token of lookahead symbol is returned
 * o  current reading position and line and column counters are NOT updated
 * o  file status is set to Success
 *
 * error-conditions:
 * o  if no source file is associated with lexer, no operation is carried out
 *    and status is set to NotInitialized
 * ----------------------------------------------------------------------- */

Token NextSym ();


/* --------------------------------------------------------------------------
 * method ConsumeSym()
 * --------------------------------------------------------------------------
 * Consumes the lookahead symbol and returns the token of the new lookahead
 * symbol.
 * ----------------------------------------------------------------------- */

Token ConsumeSym ();


/* --------------------------------------------------------------------------
 * method Filename()
 * --------------------------------------------------------------------------
 * Returns the filename associated with the lexer instance.
 * ----------------------------------------------------------------------- */

string Filename ();


/* --------------------------------------------------------------------------
 * method Status()
 * --------------------------------------------------------------------------
 * Returns the status of the last operation on lexer.
 * ----------------------------------------------------------------------- */

LexerStatus Status ();


/* --------------------------------------------------------------------------
 * method LookaheadLexeme()
 * --------------------------------------------------------------------------
 * Returns the lexeme of the lookahead symbol.
 * ----------------------------------------------------------------------- */

string LookaheadLexeme ();


/* --------------------------------------------------------------------------
 * method CurrentLexeme()
 * --------------------------------------------------------------------------
 * Returns the lexeme of the most recently consumed symbol.
 * ----------------------------------------------------------------------- */

string CurrentLexeme ();


/* --------------------------------------------------------------------------
 * method LookaheadLine()
 * --------------------------------------------------------------------------
 * Returns the line counter of the lookahead symbol.
 * ----------------------------------------------------------------------- */

uint LookaheadLine ();


/* --------------------------------------------------------------------------
 * method CurrentLine()
 * --------------------------------------------------------------------------
 * Returns the line counter of the most recently consumed symbol.
 * ----------------------------------------------------------------------- */

uint CurrentLine ();


/* --------------------------------------------------------------------------
 * method lookaheadColumn()
 * --------------------------------------------------------------------------
 * Returns the column counter of the lookahead symbol.
 * ----------------------------------------------------------------------- */

uint LookaheadColumn ();


/* --------------------------------------------------------------------------
 * method CurrentColumn()
 * --------------------------------------------------------------------------
 * Returns the column counter of the most recently consumed symbol.
 * ----------------------------------------------------------------------- */

uint CurrentColumn ();


/* --------------------------------------------------------------------------
 * method PrintLineAndMarkColumn(line, column)
 * --------------------------------------------------------------------------
 * Prints the given source line of the current symbol to the console and
 * marks the given coloumn with a caret '^'.
 * ----------------------------------------------------------------------- */

void PrintLineAndMarkColumn (uint line, uint column);


} /* ILexer */

} /* namespace */

/* END OF FILE */
