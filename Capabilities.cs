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
 * Capabilities.cs
 *
 * compiler capability settings
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
 * interface ICapabilities
 * ---------------------------------------------------------------------------
 * This interface describes a singleton class.
 * Since C# does not fully support the concept of information hiding, this
 * interface is entirely comprised of comments for documentation purposes.
 * ------------------------------------------------------------------------ */

public class Capabilities : ICapabilities {

  private static bool synonyms = false;
  private static bool lineComments = true;
  private static bool prefixLiterals = true;
  private static bool octalLiterals = false;
  private static bool lowlineIdentifiers = false;
  private static bool escapeTabAndNewline = true;
  private static bool backslashSetDiffOp = true;
  private static bool postfixIncAndDec = true;
  private static bool isoPragmaDelimiters = true;
  private static bool subtypeCardinals = false;
  private static bool safeStringTermination = true;
  private static bool importVarsImmutable = true;
  private static bool constParameters = true;
  private static bool variadicParameters = true;
  private static bool additionalTypes = true;
  private static bool additionalFunctions = true;
  private static bool unifiedConversion = true;
  private static bool explicitCast = true;
  private static bool coroutines = false;
  private static bool variantRecords = false;
  private static bool extensibleRecords = true;
  private static bool indeterminateRecords = true;
  private static bool unqualifiedImport = false;
  private static bool localModules = false;
  private static bool withStatement = false;
  private static bool toDoStatement = true;


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

public static void SetCapability ( Capability capability, bool value) {

  switch (capability) {
  
    case Capability.Synonyms :
      synonyms = value;
      break;

    case Capability.LineComments :
      lineComments = value;
      break;

    case Capability.PrefixLiterals :
      prefixLiterals = value;
      if (prefixLiterals) {
        octalLiterals = false;
      } /* end if */
      break;

    case Capability.SuffixLiterals :
      prefixLiterals = !value;
      if (prefixLiterals) {
        octalLiterals = false;
      } /* end if */
      break;

    case Capability.OctalLiterals :
      if (!prefixLiterals) {
        octalLiterals = value;
      } /* end if */
      break;

    case Capability.LowlineIdentifiers :
      lowlineIdentifiers = value;
      break;

    case Capability.EscapeTabAndNewline :
      escapeTabAndNewline = value;
      break;

    case Capability.BackslashSetDiffOp :
      backslashSetDiffOp = value;
      break;

    case Capability.PostfixIncAndDec :
      postfixIncAndDec = value;
      break;

    case Capability.IntraCommentPragmas :
      isoPragmaDelimiters = !value;
      break;

    case Capability.IsoPragmaDelimiters :
      isoPragmaDelimiters = value;
      break;

    case Capability.SubtypeCardinals :
      subtypeCardinals = value;
      break;

    case Capability.SafeStringTermination :
      safeStringTermination = value;
      break;

    case Capability.ImportVarsImmutable :
      importVarsImmutable = value;
      break;

    case Capability.ConstParameters :
      constParameters = value;
      break;

    case Capability.VariadicParameters :
      variadicParameters = value;
      break;

    case Capability.AdditionalTypes :
      additionalTypes = value;
      break;

    case Capability.AdditionalFunctions :
      additionalFunctions = value;
      break;

    case Capability.UnifiedConversion :
      unifiedConversion = value;
      break;

    case Capability.ExplicitCast :
      explicitCast = value;
      break;

    case Capability.Coroutines :
      coroutines = value;
      break;

    case Capability.VariantRecords :
      if ((value == false) || (!extensibleRecords && !indeterminateRecords)) {
        variantRecords = value;
      } /* end if */
      break; 

    case Capability.ExtensibleRecords :
      if ((value == false) || (variantRecords == false)) {
        extensibleRecords = value;
      } /* end if */
      break;

    case Capability.IndeterminateRecords :
      if ((value == false) || (variantRecords == false)) {
        indeterminateRecords = value;
      } /* end if */
      break;

    case Capability.UnqualifiedImport :
      unqualifiedImport = value;
      if (!unqualifiedImport) {
        localModules = false;
      } /* end if */
      break;

    case Capability.LocalModules :
      if (unqualifiedImport) {
        localModules = value;
      } /* end if */
      break;

    case Capability.WithStatement :
      withStatement = value;
      break;

    case Capability.ToDoStatement :
      toDoStatement = value;
      break;

  } /* end switch */
} /* end SetCapability */


/* ---------------------------------------------------------------------------
 * method IsEnabled(capability)
 * ---------------------------------------------------------------------------
 * Returns true if the given capability is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool IsEnabled (Capability capability) {

  switch (capability) {

    case Capability.Synonyms :
      return synonyms;

    case Capability.LineComments :
      return lineComments;

    case Capability.PrefixLiterals :
      return prefixLiterals;

    case Capability.SuffixLiterals :
      return !prefixLiterals;

    case Capability.OctalLiterals :
      return octalLiterals;

    case Capability.LowlineIdentifiers :
      return lowlineIdentifiers;

    case Capability.EscapeTabAndNewline :
      return escapeTabAndNewline;

    case Capability.BackslashSetDiffOp :
      return backslashSetDiffOp;

    case Capability.PostfixIncAndDec :
      return postfixIncAndDec;

    case Capability.IntraCommentPragmas :
      return !isoPragmaDelimiters;

    case Capability.IsoPragmaDelimiters :
      return isoPragmaDelimiters;

    case Capability.SubtypeCardinals :
      return subtypeCardinals;

    case Capability.SafeStringTermination :
      return safeStringTermination;

    case Capability.ImportVarsImmutable :
      return importVarsImmutable;

    case Capability.ConstParameters :
      return constParameters;
    
    case Capability.VariadicParameters :
      return variadicParameters;

    case Capability.AdditionalTypes :
      return additionalTypes;

    case Capability.AdditionalFunctions :
      return additionalFunctions;

    case Capability.UnifiedConversion :
      return unifiedConversion;

    case Capability.ExplicitCast :
      return explicitCast;

    case Capability.Coroutines :
      return coroutines;

    case Capability.VariantRecords :
      return variantRecords;

    case Capability.ExtensibleRecords :
      return extensibleRecords;

    case Capability.IndeterminateRecords :
      return indeterminateRecords;

    case Capability.UnqualifiedImport :
      return unqualifiedImport;

    case Capability.LocalModules :
      return localModules;

    case Capability.WithStatement :
      return withStatement;

    case Capability.ToDoStatement :
      return toDoStatement;

    default :
      return false;

  } /* end switch */

} /* end IsEnabled */


/* ---------------------------------------------------------------------------
 * convenience method Synonyms()
 * ---------------------------------------------------------------------------
 * Returns true if capability Synonyms is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool Synonyms () {
  return synonyms;
} /* end Synonyms */
  
  
/* ---------------------------------------------------------------------------
 * convenience method LineComments()
 * ---------------------------------------------------------------------------
 * Returns true if capability LineComments is enabled, else false.
 * ------------------------------------------------------------------------ */
  
public static bool LineComments () {
  return lineComments;
} /* end LineComments */
  
  
/* ---------------------------------------------------------------------------
 * convenience method PrefixLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if capability PrefixLiterals is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool PrefixLiterals () {
  return prefixLiterals;
} /* end PrefixLiterals */
  
  
/* ---------------------------------------------------------------------------
 * convenience method SuffixLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if capability SuffixLiterals is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool SuffixLiterals () {
  return !prefixLiterals;
} /* end SuffixLiterals */
  
  
/* ---------------------------------------------------------------------------
 * convenience method OctalLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if capability OctalLiterals is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool OctalLiterals () {
  return octalLiterals;
} /* end OctalLiterals */
  
  
/* ---------------------------------------------------------------------------
 * convenience method LowlineIdentifiers()
 * ---------------------------------------------------------------------------
 * Returns true if capability LowlineIdentifiers is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool LowlineIdentifiers () {
  return lowlineIdentifiers;
} /* end LowlineIdentifiers */
  
  
/* ---------------------------------------------------------------------------
 * convenience method EscapeTabAndNewline()
 * ---------------------------------------------------------------------------
 * Returns true if capability EscapeTabAndNewline is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool EscapeTabAndNewline () {
  return escapeTabAndNewline;
} /* end EscapeTabAndNewline */


/* ---------------------------------------------------------------------------
 * convenience method BackslashSetDiffOp()
 * ---------------------------------------------------------------------------
 * Returns true if capability BackslashSetDiffOp is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool BackslashSetDiffOp () {
  return backslashSetDiffOp;
} /* end BackslashSetDiffOp */


/* ---------------------------------------------------------------------------
 * convenience method PostfixIncAndDec()
 * ---------------------------------------------------------------------------
 * Returns true if capability PostfixIncAndDec is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool PostfixIncAndDec () {
  return postfixIncAndDec;
} /* end PostfixIncAndDec */


/* ---------------------------------------------------------------------------
 * convenience method IntraCommentPragmas()
 * ---------------------------------------------------------------------------
 * Returns true if capability IntraCommentPragmas is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool IntraCommentPragmas () {
  return !isoPragmaDelimiters;
} /* end IntraCommentPragmas */


/* ---------------------------------------------------------------------------
 * convenience method IsoPragmaDelimiters()
 * ---------------------------------------------------------------------------
 * Returns true if capability IsoPragmaDelimiters is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool IsoPragmaDelimiters () {
  return isoPragmaDelimiters;
} /* end IsoPragmaDelimiters */


/* ---------------------------------------------------------------------------
 * convenience method SubtypeCardinals()
 * ---------------------------------------------------------------------------
 * Returns true if capability SubtypeCardinals is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool SubtypeCardinals () {
  return subtypeCardinals;
} /* end SubtypeCardinals */


/* ---------------------------------------------------------------------------
 * convenience method SafeStringTermination()
 * ---------------------------------------------------------------------------
 * Returns true if capability SafeStringTermination is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool SafeStringTermination () {
  return safeStringTermination;
} /* end SafeStringTermination */


/* ---------------------------------------------------------------------------
 * convenience method ImportVarsImmutable()
 * ---------------------------------------------------------------------------
 * Returns true if capability ImportVarsImmutable is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool ImportVarsImmutable () {
  return importVarsImmutable;
} /* end ImportVarsImmutable */


/* ---------------------------------------------------------------------------
 * convenience method ConstParameters()
 * ---------------------------------------------------------------------------
 * Returns true if capability ConstParameters is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool ConstParameters () {
  return constParameters;
} /* end ConstParameters */


/* ---------------------------------------------------------------------------
 * convenience method VariadicParameters()
 * ---------------------------------------------------------------------------
 * Returns true if capability VariadicParameters is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool VariadicParameters () {
  return variadicParameters;
} /* end VariadicParameters */


/* ---------------------------------------------------------------------------
 * convenience method AdditionalTypes()
 * ---------------------------------------------------------------------------
 * Returns true if capability AdditionalTypes is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool AdditionalTypes () {
  return additionalTypes;
} /* end AdditionalTypes */


/* ---------------------------------------------------------------------------
 * convenience method AdditionalFunctions()
 * ---------------------------------------------------------------------------
 * Returns true if capability AdditionalFunctions is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool AdditionalFunctions () {
  return additionalFunctions;
} /* end AdditionalFunctions */


/* ---------------------------------------------------------------------------
 * convenience method UnifiedConversion()
 * ---------------------------------------------------------------------------
 * Returns true if capability UnifiedConversion is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool UnifiedConversion () {
  return unifiedConversion;
} /* end UnifiedConversion */


/* ---------------------------------------------------------------------------
 * convenience method ExplicitCast()
 * ---------------------------------------------------------------------------
 * Returns true if capability ExplicitCast is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool ExplicitCast () {
  return explicitCast;
} /* end ExplicitCast */


/* ---------------------------------------------------------------------------
 * convenience method Coroutines()
 * ---------------------------------------------------------------------------
 * Returns true if capability Coroutines is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool Coroutines () {
  return coroutines;
} /* end Coroutines */


/* ---------------------------------------------------------------------------
 * convenience method VariantRecords()
 * ---------------------------------------------------------------------------
 * Returns true if capability VariantRecords is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool VariantRecords () {
  return variantRecords;
} /* end VariantRecords */


/* ---------------------------------------------------------------------------
 * convenience method ExtensibleRecords()
 * ---------------------------------------------------------------------------
 * Returns true if capability ExtensibleRecords is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool ExtensibleRecords () {
  return extensibleRecords;
} /* end ExtensibleRecords */


/* ---------------------------------------------------------------------------
 * convenience method IndeterminateRecords()
 * ---------------------------------------------------------------------------
 * Returns true if capability IndeterminateRecords is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool IndeterminateRecords () {
  return indeterminateRecords;
} /* end IndeterminateRecords */


/* ---------------------------------------------------------------------------
 * convenience method UnqualifiedImport()
 * ---------------------------------------------------------------------------
 * Returns true if capability UnqualifiedImport is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool UnqualifiedImport () {
  return unqualifiedImport;
} /* end UnqualifiedImport */


/* ---------------------------------------------------------------------------
 * convenience method LocalModules()
 * ---------------------------------------------------------------------------
 * Returns true if capability LocalModules is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool LocalModules () {
  return localModules;
} /* end LocalModules */


/* ---------------------------------------------------------------------------
 * convenience method WithStatement()
 * ---------------------------------------------------------------------------
 * Returns true if capability WithStatement is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool WithStatement () {
  return withStatement;
} /* end WithStatement */


/* ---------------------------------------------------------------------------
 * convenience method ToDoStatement()
 * ---------------------------------------------------------------------------
 * Returns true if capability ToDoStatement is enabled, else false.
 * ------------------------------------------------------------------------ */

public static bool ToDoStatement () {
  return toDoStatement;
} /* end ToDoStatement */

  
} /* Capabilities */

} /* namespace */

/* END OF FILE */