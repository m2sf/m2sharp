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
 * IOptionParser.cs
 *
 * Public interface for command line argument parser class.
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
 * type ArgumentStatus
 * ---------------------------------------------------------------------------
 * Enumerated status values representing command line arguments.
 * ------------------------------------------------------------------------ */

public enum ArgumentStatus {
  Success,
  HelpRequested,
  VersionRequested,
  LicenseRequested,
  ErrorsEncountered
} /* ArgumentStatus */


/* ---------------------------------------------------------------------------
 * interface IArgumentParser
 * ---------------------------------------------------------------------------
 * This interface describes a singleton class.
 * Since C# does not fully support the concept of information hiding, this
 * interface is entirely comprised of comments for documentation purposes.
 * ------------------------------------------------------------------------ */

public interface IArgumentParser {

/* ---------------------------------------------------------------------------
 * method ParseOptions(args)
 * ---------------------------------------------------------------------------
 * Parses command line arguments and sets compiler options accordingly.
 * ------------------------------------------------------------------------ */

// public static ArgumentStatus ParseOptions (string[] args);


/* ---------------------------------------------------------------------------
 * method SourceFile()
 * ---------------------------------------------------------------------------
 * Returns sourcefile
 * ------------------------------------------------------------------------ */

// public static string SourceFile ();


/* ---------------------------------------------------------------------------
 * method ErrorCount()
 * ---------------------------------------------------------------------------
 * Returns error count
 * ------------------------------------------------------------------------ */

// public static uint ErrorCount ();


} /* OptionParser */

} /* namespace */

/* END OF FILE */