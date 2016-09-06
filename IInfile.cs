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
 * IInfile.cs
 *
 * Public interface for M2Sharp source file reader.
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
 * Infile status codes
 * ------------------------------------------------------------------------ */

  public enum InfileStatus {
    Success,
    InvalidReference,
    FileNotFound,
    FileAccessDenied,
    AllocationFailed,
    SourceFileIsEmpty,
    AttemptToReadPastEOF,
    IOSubsystemError
  } /* InfileStatus */


public interface IInfile {

/* ---------------------------------------------------------------------------
 * Properties: file size, line and column counter limits
 * ------------------------------------------------------------------------ */

uint MaxSize (); /* returns the maximum file buffer size (260000) */

uint MaxLines (); /* returns the line counter limit (64000) */

uint MaxColumns (); /* returns the column counter limit (250) */


/* ---------------------------------------------------------------------------
 * constructor Open(filename)
 * ---------------------------------------------------------------------------
 * Opens the given file, creates a new infile instance, associates the file
 * with the newly created instance and returns a result pair with the infile
 * reference and a status code.
 *
 * pre-conditions:
 * o  filename must reference an existing, accessible file.
 *
 * post-conditions:
 * o  new infile created and returned 
 * o  line and column counters of the newly created infile are set to 1
 * o  Success is returned in status
 *
 * error-conditions:
 * o  if the file represented by filename cannot be found
 *    infile is null, status is FileNotFound
 * o  if the file represented by filename cannot be accessed
 *    infile is null, status is FileAccessDenied
 * ------------------------------------------------------------------------ */

 Result<IInfile, InfileStatus> Open (string filename);


/* ---------------------------------------------------------------------------
 * method ReadChar()
 * ---------------------------------------------------------------------------
 * Reads the lookahead character from infile, advancing the current reading
 * position, updating line and column counter and returns its character code.
 * Returns ASCII.EOT if the lookahead character lies beyond the end of infile.
 *
 * pre-conditions:
 * o  infile must be open
 *
 * post-conditions:
 * o  character code of lookahead character or ASCII.EOT is returned
 * o  current reading position and line and column counters are updated
 * o  infile status is set to Success
 *
 * error-conditions:
 * o  none
 * ------------------------------------------------------------------------ */

char ReadChar ();


/* ---------------------------------------------------------------------------
 * method MarkLexeme()
 * ---------------------------------------------------------------------------
 * Marks the current lookahead character as the start of a lexeme.
 *
 * pre-conditions:
 * o  infile must be open
 *
 * post-conditions:
 * o  position of lookahead character is stored internally
 *
 * error-conditions:
 * o  none
 * ------------------------------------------------------------------------ */

void MarkLexeme ();


/* ---------------------------------------------------------------------------
 * method ReadMarkedLexeme()
 * ---------------------------------------------------------------------------
 * Returns a string object with the character sequence starting with the
 * character that has been marked using method markLexeme() and ending
 * with the last consumed character.  Returns null if no marker has
 * been set or if the marked character has not been consumed yet.
 *
 * pre-conditions:
 * o  infile must be open
 * o  lexeme must have been marked using method markLexeme()
 * o  character at the marked position must have been consumed
 *
 * post-conditions:
 * o  marked position is cleared
 * o  string with lexeme is returned
 *
 * error-conditions:
 * o  if no marker has been set or marked character has not been consumed,
 *    no operation is carried out and null is returned
 * ------------------------------------------------------------------------ */

string ReadMarkedLexeme ();


/* ---------------------------------------------------------------------------
 * method SourceForLine(line)
 * ---------------------------------------------------------------------------
 * Returns a string object with the source of the given line number.
 *
 * pre-conditions:
 * o  infile must be open
 * o  parameter line must be greater than zero
 *
 * post-conditions:
 * o  string with source of line is returned
 *
 * error-conditions:
 * o  line is negative or zero upon entry,
 *    no operation is carried out and null is returned
 * ------------------------------------------------------------------------ */

string SourceForLine (uint line);


/* ---------------------------------------------------------------------------
 * method ConsumeChar()
 * ---------------------------------------------------------------------------
 * Consumes the current lookahead character, advancing the current reading
 * position, updating line and column counter and returns the character code
 * of the new lookahead character that follows the consumed character.
 * Returns ASCII.EOT if the lookahead character lies beyond the end of infile.
 *
 * pre-conditions:
 * o  infile must be open
 *
 * post-conditions:
 * o  character code of lookahead character or ASCII.EOT is returned
 * o  current reading position and line and column counters are updated
 * o  file status is set to Success
 *
 * error-conditions:
 * o  none
 * ------------------------------------------------------------------------ */

char ConsumeChar ();


/* ---------------------------------------------------------------------------
 * method NextChar()
 * ---------------------------------------------------------------------------
 * Reads the lookahead character from infile without advancing the current
 * reading position and returns its character code.  Returns ASCII.EOT if
 * the lookahead character lies beyond the end of infile.
 *
 * pre-conditions:
 * o  infile must be open
 *
 * post-conditions:
 * o  character code of lookahead character or ASCII.EOT is returned
 * o  current reading position and line and column counters are NOT updated
 * o  file status is set to Success
 *
 * error-conditions:
 * o  none
 * ------------------------------------------------------------------------ */

char NextChar ();


/* ---------------------------------------------------------------------------
 * method LA2Char()
 * ---------------------------------------------------------------------------
 * Reads the second lookahead character from infile without advancing the
 * current reading position and returns its character code.  Returns ASCII.EOT
 * if the second lookahead character lies beyond the end of infile.
 *
 * pre-conditions:
 * o  infile must be open
 *
 * post-conditions:
 * o  character code of second lookahead character or EOT is returned
 * o  current reading position and line and column counters are NOT updated
 * o  file status is set to Success
 *
 * error-conditions:
 * o  none
 * ------------------------------------------------------------------------ */

char LA2Char ();


/* ---------------------------------------------------------------------------
 * method filename()
 * ---------------------------------------------------------------------------
 * Returns the filename associated with infile.
 * ------------------------------------------------------------------------ */

string filename ();


/* ---------------------------------------------------------------------------
 * method Status()
 * ---------------------------------------------------------------------------
 * Returns the status of the last operation on infile.
 * ------------------------------------------------------------------------ */

InfileStatus Status ();


/* ---------------------------------------------------------------------------
 * method EOF()
 * ---------------------------------------------------------------------------
 * Returns true if the current reading position of infile lies beyond the end
 * of the associated file, returns false otherwise.  This method should be
 * called whenever ASCII.EOT is read to ascertain that EOF has been reached.
 * ------------------------------------------------------------------------ */

bool EOF ();


/* ---------------------------------------------------------------------------
 * method CurrentLine()
 * ---------------------------------------------------------------------------
 * Returns the current line counter of infile.
 * ------------------------------------------------------------------------ */

uint CurrentLine ();


/* ---------------------------------------------------------------------------
 * method CurrentColumn()
 * ---------------------------------------------------------------------------
 * Returns the current column counter of infile.
 * ------------------------------------------------------------------------ */

uint CurrentColumn ();


/* ---------------------------------------------------------------------------
 * method Close()
 * ---------------------------------------------------------------------------
 * Closes the file associated with infile and returns a status code.
 *
 * pre-conditions:
 * o  infile must be open
 *
 * post-conditions:
 * o  associated file is closed
 * o  Success is returned
 *
 * error-conditions:
 * o  none
 * ------------------------------------------------------------------------ */

InfileStatus Close ();


} /* IInfile */

} /* M2SF.M2Sharp */

/* END OF FILE */
