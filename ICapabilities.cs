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
 * ICapabilities.cs
 *
 * public interface of compiler capability settings class
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
 * type Capability
 * ---------------------------------------------------------------------------
 * Enumerated values representing compiler settings.
 * ------------------------------------------------------------------------ */

public enum Capability {
  Synonyms,
  First = Synonyms,
  LineComments,
  PrefixLiterals,
  SuffixLiterals,
  OctalLiterals,
  LowlineIdentifiers,
  EscapeTabAndNewline,
  BackslashSetDiffOp,
  PostfixIncAndDec,
  IntraCommentPragmas,
  IsoPragmaDelimiters,
  SubtypeCardinals,
  SafeStringTermination,
  ImportVarsImmutable,
  ConstParameters,
  VariadicParameters,
  AdditionalTypes,
  AdditionalFunctions,
  UnifiedConversion,
  ExplicitCast,
  Coroutines,
  VariantRecords,
  ExtensibleRecords,
  IndeterminateRecords,
  UnqualifiedImport,
  LocalModules,
  WithStatement,
  ToDoStatement,
  Last = ToDoStatement
} /* Capability */


/* ---------------------------------------------------------------------------
 * interface ICapabilities
 * ---------------------------------------------------------------------------
 * This interface describes a singleton class.
 * Since C# does not fully support the concept of information hiding, this
 * interface is entirely comprised of comments for documentation purposes.
 * ------------------------------------------------------------------------ */

public interface ICapabilities {

/* ---------------------------------------------------------------------------
 * method SetCapability(capability, value)
 * ---------------------------------------------------------------------------
 * Sets the given capability to the given boolean value.
 * A value of true enables the capability, a value of false disables it.
 *
 * The following constraints apply:
 * o  Enabling PrefixLiterals disables SuffixLiterals and vice versa
 * o  Enabling IsoPragmaDelimiters disables IntraCommentPragmas and vice versa
 * o  VariantRecords and ExtensibleRecords are mutually exclusive
 * o  VariantRecords and IndeterminateRecords are mutually exclusive
 * o  Enabling OctalLiterals fails if SuffixLiterals is disabled
 * o  Enabling LocalModules fails if UnqualifiedImport is disabled
 * ------------------------------------------------------------------------ */

// public static void SetCapability ( Capability capability, bool value);


/* ---------------------------------------------------------------------------
 * method IsEnabled(capability)
 * ---------------------------------------------------------------------------
 * Returns true if the given capability is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool IsEnabled (Capability capability);


/* ---------------------------------------------------------------------------
 * convenience method Synonyms()
 * ---------------------------------------------------------------------------
 * Returns true if capability Synonyms is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool Synonyms ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method LineComments()
 * ---------------------------------------------------------------------------
 * Returns true if capability LineComments is enabled, else false.
 * ------------------------------------------------------------------------ */
  
// public static bool LineComments ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method PrefixLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if capability PrefixLiterals is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool PrefixLiterals ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method SuffixLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if capability SuffixLiterals is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool SuffixLiterals ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method OctalLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if capability OctalLiterals is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool OctalLiterals ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method LowlineIdentifiers()
 * ---------------------------------------------------------------------------
 * Returns true if capability LowlineIdentifiers is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool LowlineIdentifiers ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method EscapeTabAndNewline()
 * ---------------------------------------------------------------------------
 * Returns true if capability EscapeTabAndNewline is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool EscapeTabAndNewline ();


/* ---------------------------------------------------------------------------
 * convenience method BackslashSetDiffOp()
 * ---------------------------------------------------------------------------
 * Returns true if capability BackslashSetDiffOp is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool BackslashSetDiffOp ();


/* ---------------------------------------------------------------------------
 * convenience method PostfixIncAndDec()
 * ---------------------------------------------------------------------------
 * Returns true if capability PostfixIncAndDec is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool PostfixIncAndDec ();


/* ---------------------------------------------------------------------------
 * convenience method IntraCommentPragmas()
 * ---------------------------------------------------------------------------
 * Returns true if capability IntraCommentPragmas is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool IntraCommentPragmas ();


/* ---------------------------------------------------------------------------
 * convenience method IsoPragmaDelimiters()
 * ---------------------------------------------------------------------------
 * Returns true if capability IsoPragmaDelimiters is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool IsoPragmaDelimiters ();


/* ---------------------------------------------------------------------------
 * convenience method SubtypeCardinals()
 * ---------------------------------------------------------------------------
 * Returns true if capability SubtypeCardinals is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool SubtypeCardinals ();


/* ---------------------------------------------------------------------------
 * convenience method SafeStringTermination()
 * ---------------------------------------------------------------------------
 * Returns true if capability SafeStringTermination is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool SafeStringTermination ();


/* ---------------------------------------------------------------------------
 * convenience method ImportVarsImmutable()
 * ---------------------------------------------------------------------------
 * Returns true if capability ImportVarsImmutable is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool ImportVarsImmutable ();


/* ---------------------------------------------------------------------------
 * convenience method ConstParameters()
 * ---------------------------------------------------------------------------
 * Returns true if capability ConstParameters is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool ConstParameters ();


/* ---------------------------------------------------------------------------
 * convenience method VariadicParameters()
 * ---------------------------------------------------------------------------
 * Returns true if capability VariadicParameters is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool VariadicParameters ();


/* ---------------------------------------------------------------------------
 * convenience method AdditionalTypes()
 * ---------------------------------------------------------------------------
 * Returns true if capability AdditionalTypes is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool AdditionalTypes ();


/* ---------------------------------------------------------------------------
 * convenience method AdditionalFunctions()
 * ---------------------------------------------------------------------------
 * Returns true if capability AdditionalFunctions is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool AdditionalFunctions ();


/* ---------------------------------------------------------------------------
 * convenience method UnifiedConversion()
 * ---------------------------------------------------------------------------
 * Returns true if capability UnifiedConversion is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool UnifiedConversion ();


/* ---------------------------------------------------------------------------
 * convenience method ExplicitCast()
 * ---------------------------------------------------------------------------
 * Returns true if capability ExplicitCast is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool ExplicitCast ();


/* ---------------------------------------------------------------------------
 * convenience method Coroutines()
 * ---------------------------------------------------------------------------
 * Returns true if capability Coroutines is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool Coroutines ();


/* ---------------------------------------------------------------------------
 * convenience method VariantRecords()
 * ---------------------------------------------------------------------------
 * Returns true if capability VariantRecords is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool VariantRecords ();


/* ---------------------------------------------------------------------------
 * convenience method ExtensibleRecords()
 * ---------------------------------------------------------------------------
 * Returns true if capability ExtensibleRecords is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool ExtensibleRecords ();


/* ---------------------------------------------------------------------------
 * convenience method IndeterminateRecords()
 * ---------------------------------------------------------------------------
 * Returns true if capability IndeterminateRecords is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool IndeterminateRecords ();


/* ---------------------------------------------------------------------------
 * convenience method UnqualifiedImport()
 * ---------------------------------------------------------------------------
 * Returns true if capability UnqualifiedImport is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool UnqualifiedImport ();


/* ---------------------------------------------------------------------------
 * convenience method LocalModules()
 * ---------------------------------------------------------------------------
 * Returns true if capability LocalModules is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool LocalModules ();


/* ---------------------------------------------------------------------------
 * convenience method WithStatement()
 * ---------------------------------------------------------------------------
 * Returns true if capability WithStatement is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool WithStatement ();


/* ---------------------------------------------------------------------------
 * convenience method ToDoStatement()
 * ---------------------------------------------------------------------------
 * Returns true if capability ToDoStatement is enabled, else false.
 * ------------------------------------------------------------------------ */

// public static bool ToDoStatement ();

  
} /* ICapabilities */

} /* namespace */

/* END OF FILE */