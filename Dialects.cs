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
 * Dialects.cs
 *
 * compiler dialect settings class
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

public class Dialects : IDialects {

/* ---------------------------------------------------------------------------
 * bitset constant PIM3Defaults
 * ---------------------------------------------------------------------------
 * Represents a capability set containing default capabilities for PIM3
 * ------------------------------------------------------------------------ */

  private const uint PIM3Defaults =
    (1 << (int)Capability.SuffixLiterals) |
    (1 << (int)Capability.ExplicitCast) |
    (1 << (int)Capability.UnqualifiedImport) |
    (1 << (int)Capability.WithStatement);


/* ---------------------------------------------------------------------------
 * bitset constant PIM3Mutables
 * ---------------------------------------------------------------------------
 * Represents a capability set containing mutable capabilities for PIM3
 * ------------------------------------------------------------------------ */

  private const uint PIM3Mutables =
    (1 << (int)Capability.Synonyms) |
    (1 << (int)Capability.OctalLiterals) |
    (1 << (int)Capability.ExplicitCast) |
    (1 << (int)Capability.Coroutines) |
    (1 << (int)Capability.VariantRecords) |
    (1 << (int)Capability.LocalModules);


/* ---------------------------------------------------------------------------
 * bitset constant PIM4Defaults
 * ---------------------------------------------------------------------------
 * Represents a capability set containing default capabilities for PIM4
 * ------------------------------------------------------------------------ */

  private const uint PIM4Defaults =
    (1 << (int)Capability.SuffixLiterals) |
    (1 << (int)Capability.SubtypeCardinals) |
    (1 << (int)Capability.SafeStringTermination) |
    (1 << (int)Capability.ExplicitCast) |
    (1 << (int)Capability.UnqualifiedImport) |
    (1 << (int)Capability.WithStatement);


/* ---------------------------------------------------------------------------
 * bitset constant PIM4Mutables
 * ---------------------------------------------------------------------------
 * Represents a capability set containing mutable capabilities for PIM4
 * ------------------------------------------------------------------------ */

  private const uint PIM4Mutables =
    (1 << (int)Capability.Synonyms) |
    (1 << (int)Capability.OctalLiterals) |
    (1 << (int)Capability.ExplicitCast) |
    (1 << (int)Capability.Coroutines) |
    (1 << (int)Capability.VariantRecords) |
    (1 << (int)Capability.LocalModules);


/* ---------------------------------------------------------------------------
 * bitset constant ExtDefaults
 * ---------------------------------------------------------------------------
 * Represents a capability set containing default capabilities for Extended
 * ------------------------------------------------------------------------ */

  private const uint ExtDefaults =
    (1 << (int)Capability.LineComments) |
    (1 << (int)Capability.PrefixLiterals) |
    (1 << (int)Capability.EscapeTabAndNewline) |
    (1 << (int)Capability.BackslashSetDiffOp) |
    (1 << (int)Capability.PostfixIncAndDec) |
    (1 << (int)Capability.IsoPragmaDelimiters) |
    (1 << (int)Capability.SafeStringTermination) |
    (1 << (int)Capability.ImportVarsImmutable) |
    (1 << (int)Capability.ConstParameters) |
    (1 << (int)Capability.VariadicParameters) |
    (1 << (int)Capability.AdditionalTypes) |
    (1 << (int)Capability.AdditionalFunctions) |
    (1 << (int)Capability.UnifiedConversion) |
    (1 << (int)Capability.ExplicitCast) |
    (1 << (int)Capability.ExtensibleRecords) |
    (1 << (int)Capability.IndeterminateRecords) |
    (1 << (int)Capability.ToDoStatement);


/* ---------------------------------------------------------------------------
 * bitset constant ExtMutables
 * ---------------------------------------------------------------------------
 * Represents a capability set containing mutable capabilities for Extended
 * ------------------------------------------------------------------------ */

  private const uint ExtMutables =
    (1 << (int)Capability.LowlineIdentifiers) |
    (1 << (int)Capability.ToDoStatement);


/* ---------------------------------------------------------------------------
 * method DefaultCapabilitiesFor(dialect)
 * ---------------------------------------------------------------------------
 * Returns an unsigned integer representing a bitset that contains all default
 * capabilities for the given dialect.  Bits are indexed, with the least sig-
 * nificant bit having index 0.  The indices correspond to the enumerated
 * capability values of enumeration type Capability.
 * ------------------------------------------------------------------------ */

public static uint DefaultCapabilitiesFor ( Dialect dialect ) {

  switch (dialect) {

    case Dialect.PIM3 :
      return PIM3Defaults;

    case Dialect.PIM4 :
      return PIM4Defaults;

    case Dialect.Extended :
      return ExtDefaults;

    default :
      return 0;

  } /* end switch */

} /* end DefaultCapabilitiesFor */


/* ---------------------------------------------------------------------------
 * method IsDefaultCapability(dialect, capability)
 * ---------------------------------------------------------------------------
 * Returns true if the given capability is a default capability of the given
 * dialect, else false.
 * ------------------------------------------------------------------------ */

public static bool IsDefaultCapability ( Dialect dialect, Capability cap ) {

  switch (dialect) {

    case Dialect.PIM3 :
      return IsCapabilityInSet(PIM3Defaults, cap);

    case Dialect.PIM4 :
      return IsCapabilityInSet(PIM4Defaults, cap);

    case Dialect.Extended :
      return IsCapabilityInSet(ExtDefaults, cap);

    default :
      return false;

  } /* end switch */

} /* end IsDefaultCapability */


/* ---------------------------------------------------------------------------
 * method IsMutableCapability(dialect, capability)
 * ---------------------------------------------------------------------------
 * Returns true if the given capability is a mutable capability of the given
 * dialect, else false.
 * ------------------------------------------------------------------------ */

public static bool IsMutableCapability ( Dialect dialect, Capability cap ) {

  switch (dialect) {

    case Dialect.PIM3 :
      return IsCapabilityInSet(PIM3Mutables, cap);

    case Dialect.PIM4 :
      return IsCapabilityInSet(PIM4Mutables, cap);

    case Dialect.Extended :
      return IsCapabilityInSet(ExtMutables, cap);

    default :
      return false;

  } /* end switch */

} /* end IsDefaultCapability */


/* ---------------------------------------------------------------------------
 * private method IsCapabilityInSet(capabilitySet, capability)
 * ---------------------------------------------------------------------------
 * Returns true if capability is present in bitset capabilitySet, else false.
 * ------------------------------------------------------------------------ */

private static bool IsCapabilityInSet (uint capabilitySet, Capability cap) {

  return (capabilitySet & (1 << (int)cap)) != 0;

} /* end IsCapabilityInSet */


} /* Dialects */

} /* namespace */

/* END OF FILE */