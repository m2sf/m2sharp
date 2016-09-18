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
 * IDialects.cs
 *
 * public interface of compiler dialect settings class
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

namespace org.m2sf.m2sharp {

/* ---------------------------------------------------------------------------
 * type Dialect
 * ---------------------------------------------------------------------------
 * Enumerated values representing supported dialects.
 * ------------------------------------------------------------------------ */

public enum Dialect {

  /* Programming in Modula-2, 3rd Edition, 1983 */

  PIM3,

  /* Programming in Modula-2, 4th Edition, 1985 */
      
  PIM4,

  /* Extended with selected features from Modula-2 Revision 2010 */

  Extended
} /* end Dialect */


/* ---------------------------------------------------------------------------
 * Capabilities by Dialect
 * ---------------------------------------------------------------------------
 *
 * Capabilities            | PIM3           | PIM4           | Extended
 * ------------------------+----------------+----------------+----------------
 * Synonyms                | off, mutable   | off, mutable   | off, immutable
 * LineComments            | off, immutable | off, immutable | on,  immutable
 * PrefixLiterals          | off, immutable | off, immutable | on,  immutable
 * SuffixLiterals          | on,  immutable | on,  immutable | off, immutable
 * OctalLiterals           | off, mutable   | off, mutable   | off, immutable
 * LowlineIdentifiers      | off, immutable | off, immutable | off, mutable
 * EscapeTabAndNewline     | off, immutable | off, immutable | on,  immutable
 * BackslashSetDiffOp      | off, immutable | off, immutable | on,  immutable
 * PostfixIncAndDec        | off, immutable | off, immutable | on,  immutable
 * IntraCommentPragmas     | on,  immutable | on,  immutable | off, immutable
 * IsoPragmaDelimiters     | off, immutable | off, immutable | on,  immutable
 * ------------------------+----------------+----------------+----------------
 * SubtypedCardinals       | off, immutable | on,  immutable | off, immutable
 * SafeStringTermination   | off, immutable | on,  immutable | on,  immutable
 * ImportVarsImmutable     | off, immutable | off, immutable | on,  immutable
 * ConstParameters         | off, immutable | off, immutable | on,  immutable
 * VariadicParameters      | off, immutable | off, immutable | on,  immutable
 * AdditionalTypes         | off, immutable | off, immutable | on,  immutable
 * AdditionalFunctions     | off, immutable | off, immutable | on,  immutable
 * UnifiedConversion       | off, immutable | off, immutable | on,  immutable
 * ExplicitCast            | on,  mutable   | on,  mutable   | on,  immutable
 * ------------------------+----------------+----------------+----------------
 * Coroutines              | off, mutable   | off, mutable   | off, immutable
 * VariantRecords          | off, mutable   | off, mutable   | off, immutable
 * ExtensibleRecords       | off, immutable | off, immutable | on,  immutable
 * IndeterminateRecords    | off, immutable | off, immutable | on,  immutable
 * UnqualifiedImport       | on,  immutable | on,  immutable | off, immutable
 * LocalModules            | off, mutable   | off, mutable   | off, immutable
 * WithStatement           | on,  immutable | on,  immutable | off, immutable 
 * ToDoStatement           | off, immutable | off, immutable | on,  mutable
 * ------------------------+----------------+----------------+----------------
 *
 * Default capabilities are denoted by value "on".
 * Mutable capabilities are denoted by value "mutable".
 * ------------------------------------------------------------------------ */


/* ---------------------------------------------------------------------------
 * interface IDialects
 * ---------------------------------------------------------------------------
 * This interface describes a singleton class.
 * Since C# does not fully support the concept of information hiding, this
 * interface is entirely comprised of comments for documentation purposes.
 * ------------------------------------------------------------------------ */

public interface IDialects {

/* ---------------------------------------------------------------------------
 * method DefaultCapabilitiesFor(dialect)
 * ---------------------------------------------------------------------------
 * Returns an unsigned integer representing a bitset that contains all default
 * capabilities for the given dialect.  Bits are indexed, with the least sig-
 * nificant bit having index 0.  The indices correspond to the enumerated
 * capability values of enumeration type Capability.
 * ------------------------------------------------------------------------ */

// public static uint DefaultCapabilitiesFor ( Dialect dialect );


/* ---------------------------------------------------------------------------
 * method IsDefaultCapability(dialect, capability)
 * ---------------------------------------------------------------------------
 * Returns true if the given capability is a default capability of the given
 * dialect, else false.
 * ------------------------------------------------------------------------ */

// public static bool IsDefaultCapability ( Dialect dialect, Capability cap );


/* ---------------------------------------------------------------------------
 * method IsMutableCapability(dialect, capability)
 * ---------------------------------------------------------------------------
 * Returns true if the given capability is a mutable capability of the given
 * dialect, else false.
 * ------------------------------------------------------------------------ */

// public static bool IsMutableCapability ( Dialect dialect, Capability cap );


} /* IDialects */

} /* namespace */

/* END OF FILE */