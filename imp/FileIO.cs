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
 * FileIO.cs
 *
 * Basic file I/O.
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

using System;
using System.IO;

namespace org.m2sf.m2sharp {

public class FileIO : IFileIO {

  FileStream file;
  FileIOMode mode;
  bool isOpen;

/* ---------------------------------------------------------------------------
 * factory method Open(filename, mode)
 * ---------------------------------------------------------------------------
 * Opens the given file, creates a new instance, associates the filename with
 * the newly created instance and returns a result pair with the instance
 * reference and a status code.
 *
 * pre-conditions:
 * o  filename must reference an existing, accessible file
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

  public static Result<IFileIO, FileIOStatus>
    Open (string filename, FileIOMode mode) {

    FileIO fio;
    FileStream fs;
    FileIOStatus status;

    if (string.IsNullOrEmpty(filename)) {
      return new Result<IFileIO, FileIOStatus>
        (null, FileIOStatus.InvalidReference);
    } /* end if */

    fs = null;

    try {
      switch (mode) {
        case FileIOMode.Read:
          fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
          break;
        case FileIOMode.Write:
          fs = new FileStream(filename, FileMode.Open, FileAccess.Write);
          break;
        case FileIOMode.Append:
          fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
          break;
      } /* end switch */
      if (fs != null) {
        status = FileIOStatus.Success;
      }
      else {
        status = FileIOStatus.IOSubsystemError;
      } /* end if */
    }
    catch (FileNotFoundException) {
      status = FileIOStatus.FileNotFound;
    }
    catch (DirectoryNotFoundException) {
      status = FileIOStatus.FileNotFound;
    }
    catch (UnauthorizedAccessException) {
      status = FileIOStatus.FileAccessDenied;
    }
    catch (PathTooLongException) {
      status = FileIOStatus.InvalidReference;
    }
    catch (IOException) {
      status = FileIOStatus.IOSubsystemError;
    } /* end try */

    if (status == FileIOStatus.Success) {
      fio = new FileIO();
      fio.isOpen = true;
      fio.mode = mode;
      fio.file = fs;
    }
    else {
      fio = null;
    } /* end if */

    return new Result<IFileIO, FileIOStatus>(fio, status);
  } /* end Open */


/* ---------------------------------------------------------------------------
 * factory method OpenNew(filename, mode)
 * ---------------------------------------------------------------------------
 * Creates a new file with the given filename and opens the file in the given
 * access mode.  Creates a new file instance and returns a result pair with
 * the new file instance and a status code.
 *
 * pre-conditions:
 * o  filename must not be null nore empty nor reference any existing file
 * o  mode must be Write
 *
 * post-conditions:
 * o  new file created, new file instance created
 * o  current position is at the start of the file
 * o  new file instance and status Success is returned
 *
 * error-conditions:
 * o  if the file represented by filename already exists
 *    file instance is null, status is FileAlreadyExists
 * o  if the directory path for filename cannot be accessed
 *    file instance is null, status is FileAccessDenied
 * ------------------------------------------------------------------------ */

  public static Result<IFileIO, FileIOStatus>
    OpenNew (string filename, FileIOMode mode) {

    FileIO fio;
    FileStream fs;
    FileIOStatus status;

    if (string.IsNullOrEmpty(filename)) {
      return new Result<IFileIO, FileIOStatus>
        (null, FileIOStatus.InvalidReference);
    } /* end if */

    if (mode != FileIOMode.Write) {
      return new Result<IFileIO, FileIOStatus>
        (null, FileIOStatus.IllegalOperation);
    } /* end if */

    fs = null;

    try {
      fs = new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
      if (fs != null) {
        status = FileIOStatus.Success;
      }
      else {
        status = FileIOStatus.IOSubsystemError;
      } /* end if */
    }
    catch (FileNotFoundException) {
      status = FileIOStatus.FileNotFound;
    }
    catch (DirectoryNotFoundException) {
      status = FileIOStatus.FileNotFound;
    }
    catch (UnauthorizedAccessException) {
      status = FileIOStatus.FileAccessDenied;
    }
    catch (PathTooLongException) {
      status = FileIOStatus.InvalidReference;
    }
    catch (IOException) {
      status = FileIOStatus.IOSubsystemError;
    } /* end try */

    if (status == FileIOStatus.Success) {
      fio = new FileIO();
      fio.isOpen = true;
      fio.mode = mode;
      fio.file = fs;
    }
    else {
      fio = null;
    } /* end if */

    return new Result<IFileIO, FileIOStatus>(fio, status);
  } /* end OpenNew */


/* ---------------------------------------------------------------------------
 * private constructor FileIO ()
 * ---------------------------------------------------------------------------
 * Prevents clients from invoking the constructor.  Clients must use Open().
 * ------------------------------------------------------------------------ */

  private FileIO () {
    // no operation
  } /* end FileIO */


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

  public string Filename () {
    if (!isOpen) {
      return null;
    } /* end if */

    return file.Name;
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

  public FileIOStatus GetMode (ref FileIOMode mode) {
    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */
    mode = this.mode;
    return FileIOStatus.Success;
  } /* end GetMode */


/* ---------------------------------------------------------------------------
 * method BytesAvailable()
 * ---------------------------------------------------------------------------
 * Returns the number of bytes available for reading from the receiver.
 * Returns zero if the receiver is not open in Read mode.
 *
 * pre-conditions:
 * o  receiver must be open in Read mode
 *
 * post-conditions:
 * o  number of bytes available for reading is returned
 *
 * error-conditions:
 * o  zero is returned
 * ------------------------------------------------------------------------ */

  public ulong BytesAvailable () {
    if (!isOpen) {
      return 0;
    } /* end if */

    if (mode != FileIOMode.Read) {
      return 0;
    } /* end if */

    return (ulong)(file.Length - file.Position);
  } /* end BytesAvailable */


/* ---------------------------------------------------------------------------
 * method ReadByte()
 * ---------------------------------------------------------------------------
 * Reads the next byte from the receiver, advancing the current position,
 * passing the read byte back in out parameter data and returns a status.
 *
 * pre-conditions:
 * o  receiver must be open in Read mode
 * o  read/write position must not have reached EOF
 *
 * post-conditions:
 * o  byte at file's read/write position is passed in data
 * o  current position is advanced by one
 * o  status Success is returned
 *
 * error-conditions:
 * o  no data is read, no data is passed back
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  public FileIOStatus ReadByte (ref byte data) {
    FileIOStatus status;
    int read;

    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    read = file.ReadByte();

    if (read >= 0) {
      data = (byte)read;
      status = FileIOStatus.Success;
    }
    else {
    status = FileIOStatus.AttemptToReadPastEOF;
    } /* end if */

    return status;
  } /* end ReadByte */


/* ---------------------------------------------------------------------------
 * method ReadNBytes()
 * ---------------------------------------------------------------------------
 * Reads up to the number of bytes given by bytesToRead from the receiver into
 * the given buffer.  If null is passed in for buffer, a new buffer is first
 * instantiated.  The actual number of bytes read is passed back in out
 * parameter bytesRead.  Returns a status code.
 *
 * pre-conditions:
 * o  receiver must be open in Read mode
 *
 * post-conditions:
 * o  if buffer is null, a new buffer is instantiated and passed back
 * o  up to bytesToRead bytes are read from receiver to buffer
 * o  current position of receiver is advanced accordingly
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  public FileIOStatus ReadNBytes
    (ref byte[] buffer, ulong bytesToRead, out ulong bytesRead) {

    ulong bytesAvailable;

    if (bytesToRead == 0) {
      bytesRead = 0;
      return FileIOStatus.InvalidReference;
    } /* end if */

    if (!isOpen) {
      bytesRead = 0;
      return FileIOStatus.InvalidReference;
    } /* end if */

    if (mode != FileIOMode.Read) {
      bytesRead = 0;
      return FileIOStatus.InvalidReference;
    } /* end if */

    bytesAvailable = (ulong)(file.Length - file.Position);

    if (bytesAvailable == 0) {
      bytesRead = 0;
      return FileIOStatus.AttemptToReadPastEOF;
    } /* end if */

    if (bytesToRead > bytesAvailable) {
      bytesToRead = bytesAvailable;
    } /* end if */

    if (buffer != null) {
      if (bytesToRead > (ulong)buffer.Length) {
        bytesToRead = (ulong)buffer.Length;
      } /* end if */
    }
    else /* buffer == null */ {
      /* create new buffer of required size */
      buffer = new byte[bytesToRead];
    } /* end if */

    bytesRead = (ulong)file.Read(buffer, (int)file.Position, (int)bytesToRead);

    return FileIOStatus.Success;
  } /* end ReadNBytes */


/* ---------------------------------------------------------------------------
 * method WriteByte()
 * ---------------------------------------------------------------------------
 * Writes data to the receiver, advancing the current position and returns a
 * status code.
 *
 * pre-conditions:
 * o  receiver must be open in Write mode
 *
 * post-conditions:
 * o  data is written to the receiver
 * o  current position is advanced by one
 * o  status Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  public FileIOStatus WriteByte (byte data) {
    FileIOStatus status;

    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    file.WriteByte(data);
    status = FileIOStatus.Success;

    return status;
  } /* end WriteByte */


/* ---------------------------------------------------------------------------
 * method WriteNBytes()
 * ---------------------------------------------------------------------------
 * Writes the bytes in the given buffer to the receiver.  The actual number of
 * bytes written is passed back in out parameter bytesWritten.
 * Returns a status code.
 *
 * pre-conditions:
 * o  receiver must be open in Write mode
 * o  buffer must not be null
 *
 * post-conditions:
 * o  up to buffer.length bytes are written from buffer to receiver
 * o  current position of receiver is advanced accordingly
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  public FileIOStatus WriteNBytes (byte[] buffer, out ulong bytesWritten) {
    int bytesToWrite;

    if (!isOpen) {
      bytesWritten = 0;
      return FileIOStatus.InvalidReference;
    } /* end if */

    if ((mode != FileIOMode.Write) || (mode != FileIOMode.Append)) {
      bytesWritten = 0;
      return FileIOStatus.InvalidReference;
    } /* end if */

    bytesToWrite = buffer.Length;

    file.Write(buffer, 0, bytesToWrite);

    bytesWritten = (ulong)bytesToWrite;
    return FileIOStatus.Success;
  } /* end WriteNBytes */


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

  public FileIOStatus GetPos (ref ulong pos) {
    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    pos = (ulong)file.Position;
    return FileIOStatus.Success;
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

  public FileIOStatus SetPos (ulong pos) {
    FileIOStatus status;

    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    /* may set position up to length-1 in read mode */
    if ((mode == FileIOMode.Read) && (pos < (ulong)file.Length)) {
      file.Position = (long)pos;
      status = FileIOStatus.Success;
    }
    /* may set position up to length in write mode */
    else if ((mode == FileIOMode.Write) && (pos <= (ulong)file.Length)) {
      file.Position = (long)pos;
      status = FileIOStatus.Success;
    }
    /* may not set position in append mode */
    else {
      status = FileIOStatus.IOSubsystemError;
    } /* end if */

    return status;
  } /* end SetPos */


/* ---------------------------------------------------------------------------
 * method Rewind ()
 * ---------------------------------------------------------------------------
 * Resets the read/write position to the beginning of the file.
 * Returns a status.
 *
 * pre-conditions:
 * o  receiver must be open in Read or Write mode
 *
 * post-conditions:
 * o  current position is set to zero
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  public FileIOStatus Rewind () {
    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    return SetPos(0);
  } /* end Rewind */


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

  public FileIOStatus Advance (ulong offset) {
    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    return SetPos((ulong)file.Position + offset);
  } /* end Advance */


/* ---------------------------------------------------------------------------
 * method Sync ()
 * ---------------------------------------------------------------------------
 * Writes unwritten data to disk. Returns a status.
 *
 * pre-conditions:
 * o  receiver must be open in Write or Append mode
 *
 * post-conditions:
 * o  all data written to disk
 * o  Success is returned
 *
 * error-conditions:
 * o  status other than Success is returned
 * ------------------------------------------------------------------------ */

  public FileIOStatus Sync () {
    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    if (mode == FileIOMode.Read) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    file.Flush();

    return FileIOStatus.Success;
  } /* end Sync */


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

  public FileIOStatus Close () {
    if (!isOpen) {
      return FileIOStatus.InvalidReference;
    } /* end if */

    file.Close();
    isOpen = false;

    return FileIOStatus.Success;
  } /* end Close */


} /* FileIO */

} /* namespace */

/* END OF FILE */