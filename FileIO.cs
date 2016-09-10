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
 * IFileIO.cs
 *
 * Public interface for basic file I/O.
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

public class FileIO : IFileIO {

  FileStream file;
  string filename;
  FileIOMode mode;
  bool isOpen;
  ulong pos;


/* ---------------------------------------------------------------------------
 * constructor Open(filename, mode)
 * ---------------------------------------------------------------------------
 * Opens the given file, creates a new instance, associates the filename with
 * the newly created instance and returns a result pair with the instance
 * reference and a status code.
 *
 * pre-conditions:
 * o  filename must reference an existing, accessible file.
 *
 * post-conditions:
 * o  new file instance created 
 * o  in Read or Write mode, current position is set to the start of the file
 * o  in Append mode, current position is set to the end of the file
 * o  new file instance and status Success is returned
 *
 * error-conditions:
 * o  if the file represented by filename cannot be found
 *    file instance is null, status is FileNotFound
 * o  if the file represented by filename cannot be accessed
 *    file instance is null, status is FileAccessDenied
 * ------------------------------------------------------------------------ */

  Result<IFileIO, FileIOStatus> Open (string filename, FileIOMode mode ) {

  } /* end Open */


/* ---------------------------------------------------------------------------
 * constructor OpenNew(filename, mode)
 * ---------------------------------------------------------------------------
 * Creates a new file with the given filename and opens the file in the given
 * access mode.  Creates a new file instance and returns a result pair with
 * the new file instance and a status code.
 *
 * pre-conditions:
 * o  filename must not reference any existing file.
 *
 * post-conditions:
 * o  new file created, new file instance created
 * o  in Read or Write mode, current position is set to the start of the file
 * o  in Append mode, current position is set to the ebd of the file
 * o  new file instance and status Success is returned
 *
 * error-conditions:
 * o  if the file represented by filename cannot be found
 *    file instance is null, status is FileNotFound
 * o  if the directory path for filename cannot be accessed
 *    file instance is null, status is FileAccessDenied
 * ------------------------------------------------------------------------ */

  Result<IFileIO, FileIOStatus> OpenNew ( string filename, FileIOMode mode ) {

  } /* end OpenNew */


/* ---------------------------------------------------------------------------
 * method Filename ()
 * ---------------------------------------------------------------------------
 * Returns the receiver's filename or null if receiver is null
 *
 * pre-conditions:
 * o  receiver must be open
 *
 * post-conditions:
 * o  filename is returned
 *
 * error-conditions:
 * o  null is returned
 * ------------------------------------------------------------------------ */

  string Filename () {
    if (this.isOpen) {
      return this.filename;
    }
    else {
      return null;
    } /* end if */
  } /* end Filename */


/* ---------------------------------------------------------------------------
 * method Mode ()
 * ---------------------------------------------------------------------------
 * Passes the receiver's mode back in out parameter mode and returns a status.
 *
 * pre-conditions:
 * o  receiver must be open
 *
 * post-conditions:
 * o  mode is passed in mode, status Success is returned
 *
 * error-conditions:
 * o  out parameter remains unchanged, status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus GetMode ( FileIOMode mode ) {
    if (this.isOpen) {
      mode = this.mode;
      return FileIOStatus.Success;
    }
    else {
      return FileIOStatus.InvalidReference;
    } /* end if */
  } /* end GetMode */


/* ---------------------------------------------------------------------------
 * method ReadChar()
 * ---------------------------------------------------------------------------
 * Reads the next character from the receiver, advancing the current position,
 * passing the read character back in out parameter ch and returns a status.
 * Returns ASCII.EOT if the current position is at the end of the input file.
 *
 * pre-conditions:
 * o  receiver must be open in Read mode
 *
 * post-conditions:
 * o  character code of lookahead character or ASCII.EOT is passed in ch
 * o  if not at end of input file, current position is advanced by one
 * o  status Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus ReadChar ( out char ch ) {
    
  } /* end ReadChar */


/* ---------------------------------------------------------------------------
 * method ReadNChars()
 * ---------------------------------------------------------------------------
 * Reads the number of characters given by charsToRead from the receiver into
 * the given buffer.  If null is passed in for buffer, a new buffer is first
 * instantiated.  The actual number of characters read is passed back in out
 * parameter charsRead.  Returns a status code.
 *
 * pre-conditions:
 * o  receiver must be open in Read mode
 *
 * post-conditions:
 * o  if buffer is null, new buffer is instantiated and passed back
 * o  up to charsToRead characters are read from receiver to buffer
 * o  current position of receiver is advanced accordingly
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus ReadNChars
    ( ref char[] buffer, ulong charsToRead, out ulong charsRead ) {

  } /* end ReadNChars */


/* ---------------------------------------------------------------------------
 * method WriteChar()
 * ---------------------------------------------------------------------------
 * Writes ch to the receiver, advancing the current position and returns a
 * status code.
 *
 * pre-conditions:
 * o  receiver must be open in Write mode
 *
 * post-conditions:
 * o  ch is written to receiver
 * o  current position is advanced by one
 * o  status Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus WriteChar ( char ch ) {

  } /* end WriteChar */


/* ---------------------------------------------------------------------------
 * method WriteNChars()
 * ---------------------------------------------------------------------------
 * Writes the characters in the given buffer to the receiver.  The actual
 * number of characters read is passed back in out parameter charsWritten.
 * Returns a status code.
 *
 * pre-conditions:
 * o  receiver must be open in Write mode
 * o  buffer must not be null
 *
 * post-conditions:
 * o  up to buffer.length characters are written from buffer to receiver
 * o  current position of receiver is advanced accordingly
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus WriteNChars
    ( ref char[] buffer, out ulong charsWritten ) {

  } /* end WriteNChars */



/* ---------------------------------------------------------------------------
 * method GetPos ()
 * ---------------------------------------------------------------------------
 * Passes the receiver's read/write position back in out parameter pos.
 * Returns a status.
 *
 * pre-conditions:
 * o  receiver must be open
 *
 * post-conditions:
 * o  current position is passed in pos
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus GetPos ( out ulong pos ) {
    if (this.isOpen) {
      pos = this.pos;
      return FileIOStatus.Success;
    }
    else {
      return FileIOStatus.InvalidReference;
    } /* end if */
  } /* end GetPos */


/* ---------------------------------------------------------------------------
 * method SetPos ()
 * ---------------------------------------------------------------------------
 * Sets the receiver's read/write position to the value given by pos.
 * Returns a status.
 *
 * pre-conditions:
 * o  receiver must be open in Read or Write mode
 * o  in Read mode, pos must not exceed the final position
 * o  in Write mode, pos must not exceed the final position + 1
 *
 * post-conditions:
 * o  current position is set to pos
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus SetPos ( ulong pos ) {

  } /* end SetPos */


/* ---------------------------------------------------------------------------
 * method Advance (offset)
 * ---------------------------------------------------------------------------
 * Advances the receiver's read/write position by offset.  Returns a status.
 *
 * pre-conditions:
 * o  receiver must be open in Read or Write mode
 * o  in Read mode, the new position must not exceed the final position
 * o  in Write mode, the new position must not exceed the final position + 1
 *
 * post-conditions:
 * o  current position is set to pos + offset
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus Advance ( ulong offset ) {

  } /* end Advance */


/* ---------------------------------------------------------------------------
 * method Close ()
 * ---------------------------------------------------------------------------
 * Closes the file associated with the receiver.  Returns a status.
 *
 * pre-conditions:
 * o  receiver must be open
 *
 * post-conditions:
 * o  file is closed
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  FileIOStatus Close () {

  } /* end Close */


} /* IFileIO */

} /* namespace */

/* END OF FILE */
