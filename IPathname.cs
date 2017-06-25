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
 * IPathname.cs
 *
 * Public interface to portable pathname library.
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
 * Filetypes
 * ------------------------------------------------------------------------ */

public enum SuffixTypes {
  None, /*  no  suffix  */
  Def,  /* .def or .DEF */
  Mod,  /* .mod or .MOD */
  Sym,  /* .sym or .SYM */
  Ast,  /* .ast or .AST */
  Dot,  /* .dot or .DOT */
  Obj,  /* .obj or .OBJ */
  Other /*  any others  */
} /* SuffixTypes */


/* ---------------------------------------------------------------------------
 * Pathname status codes
 * ------------------------------------------------------------------------ */

public enum PathnameStatus {
  Success,
  InvalidPath,
  InvalidFilename,
  InvalidReference,
  AllocationFailed
} /* PathnameStatus */


public interface ILexer {

/* ---------------------------------------------------------------------------
 * Factory Methods
 * ---------------------------------------------------------------------------
 * Since C# does not fully support the concept of information hiding,
 * factory methods are specified as comments for documentation purposes.
 * The class constructor must be hidden to prevent clients from using it.
 * ------------------------------------------------------------------------ */

/* ---------------------------------------------------------------------------
 * factory method NewFromOSPath(osPath)
 * ---------------------------------------------------------------------------
 * Creates a new pathname instance, initialised with the path given in osPath
 * and returns a Result pair with the pathname reference and a status value.
 *
 * pre-conditions:
 * o  the path given in osPath must be a valid pathname 
 *
 * post-conditions:
 * o  pathname is created
 * o  status is set to Success
 *
 * error-conditions:
 * o  if the path given in osPath is not a valid pathname
 *    pathname is set to null, status is set to InvalidPath
 * ----------------------------------------------------------------------- */

// public static Result<IPathname, PathnameStatus>
//   NewFromOSPath (String osPath);


/* ---------------------------------------------------------------------------
 * factory method NewFromComponents(dirpath, filename, suffix)
 * ---------------------------------------------------------------------------
 * Creates a new pathname instance, initialised with the given components
 * and returns a Result pair with the pathname reference and a status value.
 *
 * pre-conditions:
 * o  the path represented by the components must be a valid pathname 
 *
 * post-conditions:
 * o  pathname is created
 * o  status is set to Success
 *
 * error-conditions:
 * o  if the path represented by the components is not a valid pathname
 *    pathname is set to null, status is set to InvalidPath
 * ----------------------------------------------------------------------- */

// public static Result<IPathname, PathnameStatus>
//   NewFromComponents (String dirpath, String filename, String suffix);


/* --------------------------------------------------------------------------
 * method FullPath()
 * --------------------------------------------------------------------------
 * Returns an interned string with the full pathname of the receiver.
 *
 * pre-conditions:
 * o  the receiver must have been created with constructor NewFromOSPath()
 *    or NewFromComponents() so that it is associated with a valid OS path.
 *
 * post-conditions:
 * o  interned string with the full pathname of the receiver is returned
 *
 * error-conditions:
 * o  if no OS path is associated with the receiver, null is returned
 * ----------------------------------------------------------------------- */

 public String FullPath();


/* --------------------------------------------------------------------------
 * method DirPath()
 * --------------------------------------------------------------------------
 * Returns an interned string with the directory path of the receiver.
 *
 * pre-conditions:
 * o  the receiver must have been created with constructor NewFromOSPath()
 *    or NewFromComponents() so that it is associated with a valid OS path.
 *
 * post-conditions:
 * o  interned string with the directory path of the receiver is returned
 *
 * error-conditions:
 * o  if no OS path is associated with the receiver, null is returned
 * ----------------------------------------------------------------------- */

 public String DirPath();


/* --------------------------------------------------------------------------
 * method Filename()
 * --------------------------------------------------------------------------
 * Returns an interned string with the filename of the receiver.
 *
 * pre-conditions:
 * o  the receiver must have been created with constructor NewFromOSPath()
 *    or NewFromComponents() so that it is associated with a valid OS path.
 *
 * post-conditions:
 * o  interned string with the filename of the receiver is returned
 *
 * error-conditions:
 * o  if no OS path is associated with the receiver, null is returned
 * ----------------------------------------------------------------------- */

 public String Filename();


/* --------------------------------------------------------------------------
 * method Basename()
 * --------------------------------------------------------------------------
 * Returns an interned string with the basename of the receiver's filename.
 *
 * pre-conditions:
 * o  the receiver must have been created with constructor NewFromOSPath()
 *    or NewFromComponents() so that it is associated with a valid OS path.
 *
 * post-conditions:
 * o  interned string with the basename of the receiver's filename is
 *    returned
 *
 * error-conditions:
 * o  if no OS path is associated with the receiver, null is returned
 * ----------------------------------------------------------------------- */

 public String Basename();


/* --------------------------------------------------------------------------
 * method Suffix()
 * --------------------------------------------------------------------------
 * Returns an interned string with the suffix of the receiver's filename.
 *
 * pre-conditions:
 * o  the receiver must have been created with constructor NewFromOSPath()
 *    or NewFromComponents() so that it is associated with a valid OS path.
 *
 * post-conditions:
 * o  interned string with the suffix of the receiver's filename is returned
 *
 * error-conditions:
 * o  if no OS path is associated with the receiver, null is returned
 * ----------------------------------------------------------------------- */

 public String Suffix();


/* --------------------------------------------------------------------------
 * method SuffixType()
 * --------------------------------------------------------------------------
 * Returns the enumerated suffix type value of the receiver's suffix.
 *
 * pre-conditions:
 * o  the receiver must have been created with constructor NewFromOSPath()
 *    or NewFromComponents() so that it is associated with a valid OS path.
 *
 * post-conditions:
 * o  the enumerated value of the suffix type of the receiver's suffix
 *    is returned
 *
 * error-conditions:
 * o  if no OS path is associated with the receiver, value None is returned
 * ----------------------------------------------------------------------- */

 public SuffixTypes SuffixType();


/* --------------------------------------------------------------------------
 * static method IsValidOSPath(osPath)
 * --------------------------------------------------------------------------
 * Returns true if osPath contains a valid pathname, otherwise false.
 *
 * pre-conditions:
 * o  osPath must not be null.
 *
 * post-conditions:
 * o  if the path given in osPath is valid, true is returned
 * o  if the path given in osPath is invalid, false is returned
 *
 * error-conditions:
 * o  if osPath is null, false is returned
 * ----------------------------------------------------------------------- */

 // public static bool IsValidOSPath(String osPath);


/* --------------------------------------------------------------------------
 * static method IsValidFilename(filename)
 * --------------------------------------------------------------------------
 * Returns true if filename contains a valid filename, otherwise false.
 *
 * pre-conditions:
 * o  filename must not be null.
 *
 * post-conditions:
 * o  if the given filename is valid, true is returned
 * o  if the given filename is invalid, false is returned
 *
 * error-conditions:
 * o  if filename is null, false is returned
 * ----------------------------------------------------------------------- */

 // public static bool IsValidFilename(String filename);


} /* IPathname */

} /* namespace */

/* END OF FILE */