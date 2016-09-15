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
 * Infile.cs
 *
 * M2Sharp source file reader class
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

public class Infile : IInfile {

/* ---------------------------------------------------------------------------
 * Constants
 * ------------------------------------------------------------------------ */

  public const int MaxSize = 260000;  /* maximum file buffer size */

  public const int MaxLines = 64000;  /* line counter limit */

  public const int MaxColumns = 250;  /* column counter limit */


/* ---------------------------------------------------------------------------
 * Private properties
 * ------------------------------------------------------------------------ */

  /* filename */      private string filename;

  /* index */         private ulong  index;
  /* line */          private uint   line;
  /* column */        private uint   column;

  /* markerIsSet */   private bool   markerIsSet;
  /* markerIndex */   private ulong  markedIndex;

  /* buflen */        private ulong  buflen;
  /* buffer */        private byte[] buffer;

  /* isOpen */        private bool isOpen;
  /* status */        private InfileStatus status;


/* ---------------------------------------------------------------------------
 * factory method Open(filename)
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
  
  public static Result<IInfile, InfileStatus> Open (string filename) {
    InfileStatus status;
    Infile infile = null;
    byte[] buffer = null;
    ulong buflen = 0;
    ulong bytesRead = 0;
    
    if (string.IsNullOrEmpty(filename)) {
      status = InfileStatus.InvalidReference;
      return new Result<IInfile, InfileStatus>(null, status);
    } /* end if */
    
    var result = FileIO.Open(filename, FileIOMode.Read);
    
    if (result.Value() == null) {
      switch (result.Status()) {
        case FileIOStatus.InvalidReference :
          status = InfileStatus.InvalidReference;
          break;
        case FileIOStatus.FileNotFound :
          status = InfileStatus.FileNotFound;
          break;
        case FileIOStatus.FileAccessDenied :
          status = InfileStatus.FileAccessDenied;
          break;
        default :
          status = InfileStatus.IOSubsystemError;
          break;
      } /* end switch */
      return new Result<IInfile, InfileStatus> (null, status);
    } /* end if */
    
    result.Value().ReadNBytes(ref buffer, buflen, out bytesRead);
    result.Value().Close();
    
    if ((buffer == null) || (buflen == 0)) {
      status = InfileStatus.SourceFileIsEmpty;
      return new Result<IInfile, InfileStatus> (null, status);
    } /* end if */
    
    infile = new Infile();
    infile.filename = filename;
    infile.index = 0;
    infile.line = 1;
    infile.column = 1;
    infile.markerIsSet = false;
    infile.markedIndex = 0;
    infile.buflen = buflen;
    infile.buffer = buffer;
    infile.status = InfileStatus.Success;

    infile.isOpen = true;
    
    return new Result<IInfile, InfileStatus>(infile, infile.status);
  } /* end Open */


/* ---------------------------------------------------------------------------
 * private constructor Infile ()
 * ---------------------------------------------------------------------------
 * Prevents clients from invoking the constructor.  Clients must use Open().
 * ------------------------------------------------------------------------ */

  private Infile() {
    // no operation
  } /* end Infile */


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

  public char ReadChar () {
    char ch;

    if (!isOpen) {
      return ASCII.EOT;
    } /* end if */

    /* if new line encountered, update line and column counters */
    if (index == buflen) {
      status = InfileStatus.AttemptToReadPastEOF;
      return ASCII.EOT;
    } /* end if */

    ch = (char)buffer[index];
    index++;

    if (ch == ASCII.LF) {
      line++;
      column = 1;
    }
    else if (ch == ASCII.CR) {
      line++;
      column = 1;

      /* if LF follows, skip it */
      if ((index < buflen) && ((char)buffer[index] == ASCII.LF)) {
        index++;
      } /* end if */

      ch = ASCII.LF;
    }
    else {
      column++;
    } /* end if */

    status = InfileStatus.Success;
    return ch;
  } /* end ReadChar */


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

  public void MarkLexeme () {

    if (!isOpen) {
      return;
    } /* end if */

    /* set marker */
    markerIsSet = true;
    markedIndex = index;

    return;
  } /* end MarkLexeme */


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

  public string ReadMarkedLexeme () {
    string lexeme;
    ulong length;
  
    if (!isOpen) {
      return null;
    } /* end if */
  
    /* check pre-conditions */
    if ((markerIsSet == false) || (markedIndex >= index)) {
      status = InfileStatus.AllocationFailed;
      return null;
    } /* end if */

    /* determine length */
    length = index - markedIndex;
    
    /* copy lexeme */
    lexeme = getStringForSlice(buffer, markedIndex, length);
    
    if (lexeme == null) {
      status = InfileStatus.AllocationFailed;
      return null;
    } /* end if */
    
    /* clear marker */
    markerIsSet = false;
    
    return lexeme;
  } /* end ReadMarkedLexeme */


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

  public string SourceForLine (uint line) {
    if (!isOpen) {
      return null;
    } /* end if */

   // TO DO

    return "";
  } /* end SourceForLine */


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

  public char ConsumeChar () {

    /* consume lookahead character */
    ReadChar();

    /* return new lookahead character */
    return NextChar();
  } /* end Consume Char */ 


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

  public char NextChar () {
    char ch;

    if (!isOpen) {
      return ASCII.EOT;
    } /* end if */

    if (index == buflen) {
      status = InfileStatus.AttemptToReadPastEOF;
      return ASCII.EOT;
    } /* end if */
  
    ch = (char)buffer[index];

    /* return LF for CR */
    if (ch == ASCII.CR) {
      ch = ASCII.LF;
    } /* end if */

    status = InfileStatus.Success;
    return ch;
  } /* end NextChar */


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

  public char LA2Char () {
    char la2;

    if (!isOpen) {
      return ASCII.EOT;
    } /* end if */

    if (index+1 == buflen) {
      status = InfileStatus.AttemptToReadPastEOF;
      return ASCII.EOT;
    } /* end if */

    la2 = (char)buffer[index+1];

    /* skip CR LF sequence if encountered */
    if ((buffer[index] == ASCII.CR) && (la2 == ASCII.LF)) {
      if (index+2 == buflen) {
        status = InfileStatus.AttemptToReadPastEOF;
        return ASCII.EOT;
      } /* end if */

      la2 = (char)buffer[index+2];
    } /* end if */

    /* return LF for CR */
    if (la2 == ASCII.CR) {
      la2 = ASCII.LF;
    } /* end if */

    status = InfileStatus.Success;
    return la2;
  } /* end LA2Char */


/* ---------------------------------------------------------------------------
 * method Filename()
 * ---------------------------------------------------------------------------
 * Returns the filename associated with infile.
 * ------------------------------------------------------------------------ */

  public string Filename () {
    if (!isOpen) {
      return null;
    } /* end if */
    return filename;
  } /* Filename */


/* ---------------------------------------------------------------------------
 * method Status()
 * ---------------------------------------------------------------------------
 * Returns the status of the last operation on infile.
 * ------------------------------------------------------------------------ */

  public InfileStatus Status () {
    if (!isOpen) {
      return InfileStatus.InvalidReference;
    } /* end if */
    return status;
  } /* Status */


/* ---------------------------------------------------------------------------
 * method EOF()
 * ---------------------------------------------------------------------------
 * Returns true if the current reading position of infile lies beyond the end
 * of the associated file, returns false otherwise.  This method should be
 * called whenever ASCII.EOT is read to ascertain that EOF has been reached.
 * ------------------------------------------------------------------------ */

  public bool EOF () {
    if (!isOpen) {
      return true;
    } /* end if */
    return (index == buflen);
  } /* end EOF */


/* ---------------------------------------------------------------------------
 * method CurrentLine()
 * ---------------------------------------------------------------------------
 * Returns the current line counter of infile.
 * ------------------------------------------------------------------------ */

  public uint CurrentLine () {
    if (!isOpen) {
      return 0;
    } /* end if */
    return line;
  } /* end CurrentLine */


/* ---------------------------------------------------------------------------
 * method CurrentColumn()
 * ---------------------------------------------------------------------------
 * Returns the current column counter of infile.
 * ------------------------------------------------------------------------ */

  public uint CurrentColumn () {
    if (!isOpen) {
      return 0;
    } /* end if */
    return column;
  } /* end CurrentColumn */


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

  public InfileStatus Close () {
    if (!isOpen) {
      return InfileStatus.InvalidReference;
    } /* end if */

    filename = null;
    index = 0;
    line = 0;
    column = 0;
    markerIsSet = false;
    markedIndex = 0;
    buflen = 0;
    buffer = null;

    isOpen = false;

    return InfileStatus.Success;
  } /* end Close */


/* ---------------------------------------------------------------------------
 * private method getStringForSlice(fromBuffer, atIndex, length)
 * ------------------------------------------------------------------------- */

  private string getStringForSlice
    (byte[] fromBuffer, ulong atIndex, ulong length) {
    
    if (length == 0) {
      return null;
    } /* end if */
    
    if (atIndex + length > (ulong)fromBuffer.LongLength) {
      return null;
    } /* end if */

    char[] slice = new char[length];
    ulong offset = atIndex;
   
    for (offset = 0; offset < length; offset++) {
      slice[offset] = (char)fromBuffer[atIndex + offset];
    } /* end for */
        
    return slice.ToString();
  } /* end getStringForSlice */


} /* IInfile */

} /* namespace */

/* END OF FILE */