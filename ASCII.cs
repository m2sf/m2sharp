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
 * ASCII.cs
 *
 * ASCII code constants.
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

/* --------------------------------------------------------------------------
 * ASCII codes used within the compiler.
 * ----------------------------------------------------------------------- */

public static class ASCII {

  /* ASCII NUL is used as string terminator in M2 strings */

  public const char NUL = '\u0000';

  /* ASCII EOT is used to signal the end of a source file */

  public const char EOT = '\u0004';

  /* TAB, LF and CRLF are legal within M2 source files */

  public const char TAB = '\u0009';
  public const char LF  = '\u000A';
  public const char CR  = '\u000D';

  /* SPACE */

  public const char SPACE = '\u0020';

  /* BACKSLASH */

  public const char BACKSLASH = '\\';

  /* IsCtrl(ch) -- returns true if ch is control character */

  public static bool IsCtrl (char ch) {
    return (ch >= NUL) && (ch < SPACE);
  } /* end IsCtrl */

  /* IsUpper(ch) -- returns true if ch is uppercase letter */

  public static bool IsUpper (char ch) {
    return (ch >= 'A') && (ch <= 'Z');
  } /* end IsUpper */

  /* IsLower(ch) -- returns true if ch is lowercase letter */

  public static bool IsLower (char ch) {
    return (ch >= 'a') && (ch <= 'z');
  } /* end IsLower */

  /* IsDigit(ch) -- returns true if ch is digit */

  public static bool IsDigit (char ch) {
    return (ch >= '0') && (ch <= '9');
  } /* end IsDigit */

  /* IsAtoF(ch) -- returns true if ch is in 'A' .. 'F' */

  public static bool IsAtoF (char ch) {
    return (ch >= 'A') && (ch <= 'F');
  } /* end IsAtoF */

  /* IsAlnum(ch) -- returns true if ch is alpha-numeric */

  public static bool IsAlnum (char ch) {
    return
      ((ch >= 'A') && (ch <= 'Z')) ||
      ((ch >= 'a') && (ch <= 'z')) ||
      ((ch >= '0') && (ch <= '9'));
  } /* end IsAlnum */

} /* ASCII */

} /* namespace */

/* END OF FILE */