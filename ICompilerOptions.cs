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
 * ICompilerOptions.cs
 *
 * public interface of compiler options class
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
 * type Dialect
 * ---------------------------------------------------------------------------
 * Enumerated values representing supported dialects.
 * ------------------------------------------------------------------------ */

public enum Dialect {
  PIM3,
  PIM4,
  Extended
} /* Dialect */


/* ---------------------------------------------------------------------------
 * type Option
 * ---------------------------------------------------------------------------
 * Enumerated values representing compiler settings.
 * ------------------------------------------------------------------------ */

public enum Option {
  Verbose,
  LexerDebug,
  ParserDebug,
  Synonyms,
  LineComments,
  PrefixLiterals,
  SuffixLiterals,
  OctalLiterals,
  LowlineIdentifiers,
  EscapeTabAndNewline,
  BackslashSetDiffOp,
  SubtypeCardinals,
  SafeStringTermination,
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
  LocalModules,
  ErrantSemicolons,
  StripComments,
  ToDoList
} /* Option */


/* ---------------------------------------------------------------------------
 * interface ICompilerOptions
 * ---------------------------------------------------------------------------
 * This interface describes a singleton class.
 * Since C# does not fully support the concept of information hiding, this
 * interface is entirely comprised of comments for documentation purposes.
 * ------------------------------------------------------------------------ */

public interface ICompilerOptions {

/* ---------------------------------------------------------------------------
 * method SetOptions(dialect, option1, option2, ...)
 * ---------------------------------------------------------------------------
 * Sets current dialect and options.
 * ------------------------------------------------------------------------ */

// public void SetOptions (Dialect dialect, params Option[] options);


/* ---------------------------------------------------------------------------
 * method GetDialect()
 * ---------------------------------------------------------------------------
 * Returns the current dialect.
 * ------------------------------------------------------------------------ */

// public static Dialect GetDialect ();


/* ---------------------------------------------------------------------------
 * method GetOpt(option)
 * ---------------------------------------------------------------------------
 * Returns true if option is turned on, otherwise false.
 * ------------------------------------------------------------------------ */

// public static bool GetOpt (Option option);


/* ---------------------------------------------------------------------------
 * convenience method Verbose()
 * ---------------------------------------------------------------------------
 * Returns true if option --verbose is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool Verbose ();


/* ---------------------------------------------------------------------------
 * convenience method LexerDebug()
 * ---------------------------------------------------------------------------
 * Returns true if option --lexer-debug is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool LexerDebug ();


/* ---------------------------------------------------------------------------
 * convenience method ParserDebug()
 * ---------------------------------------------------------------------------
 * Returns true if option --parser-debug is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ParserDebug ();


/* ---------------------------------------------------------------------------
 * convenience method Synonyms()
 * ---------------------------------------------------------------------------
 * Returns true if option --synonyms is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool Synonyms ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method LineComments()
 * ---------------------------------------------------------------------------
 * Returns true if option --line-comments is turned on, else false.
 * ------------------------------------------------------------------------ */
  
// public static bool LineComments ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method PrefixLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if option --prefix-literals is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool PrefixLiterals ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method SuffixLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if option --suffix-literals is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool SuffixLiterals ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method OctalLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if option --octal-literals is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool OctalLiterals ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method LowlineIdentifiers()
 * ---------------------------------------------------------------------------
 * Returns true if option --lowline-identifiers is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool LowlineIdentifiers ();
  
  
/* ---------------------------------------------------------------------------
 * convenience method EscapeTabAndNewline()
 * ---------------------------------------------------------------------------
 * Returns true if option --escape-tab-and-newline is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool EscapeTabAndNewline ();


/* ---------------------------------------------------------------------------
 * convenience method BackslashSetDiffOp()
 * ---------------------------------------------------------------------------
 * Returns true if option --backslash-set-diff-op is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool BackslashSetDiffOp ();


/* ---------------------------------------------------------------------------
 * convenience method SubtypeCardinals()
 * ---------------------------------------------------------------------------
 * Returns true if option --subtype-cardinals is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool SubtypeCardinals ();


/* ---------------------------------------------------------------------------
 * convenience method SafeStringTermination()
 * ---------------------------------------------------------------------------
 * Returns true if option --safe-string-termination is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool SafeStringTermination ();


/* ---------------------------------------------------------------------------
 * convenience method ConstParameters()
 * ---------------------------------------------------------------------------
 * Returns true if option --const-parameters is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ConstParameters ();


/* ---------------------------------------------------------------------------
 * convenience method VariadicParameters()
 * ---------------------------------------------------------------------------
 * Returns true if option --variadic-parameters is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool VariadicParameters ();


/* ---------------------------------------------------------------------------
 * convenience method AdditionalTypes()
 * ---------------------------------------------------------------------------
 * Returns true if option --additional-types is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool AdditionalTypes ();


/* ---------------------------------------------------------------------------
 * convenience method AdditionalFunctions()
 * ---------------------------------------------------------------------------
 * Returns true if option --additional-functions is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool AdditionalFunctions ();


/* ---------------------------------------------------------------------------
 * convenience method UnifiedConversion()
 * ---------------------------------------------------------------------------
 * Returns true if option --unified-conversion is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool UnifiedConversion ();


/* ---------------------------------------------------------------------------
 * convenience method ExplicitCast()
 * ---------------------------------------------------------------------------
 * Returns true if option --explicit-cast is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ExplicitCast ();


/* ---------------------------------------------------------------------------
 * convenience method Coroutines()
 * ---------------------------------------------------------------------------
 * Returns true if option --coroutines is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool Coroutines ();


/* ---------------------------------------------------------------------------
 * convenience method VariantRecords()
 * ---------------------------------------------------------------------------
 * Returns true if option --variant-records is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool VariantRecords ();


/* ---------------------------------------------------------------------------
 * convenience method LocalModules()
 * ---------------------------------------------------------------------------
 * Returns true if option --local-modules is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool LocalModules ();


/* ---------------------------------------------------------------------------
 * convenience method ErrantSemicolons()
 * ---------------------------------------------------------------------------
 * Returns true if option --errant-semicolons is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ErrantSemicolons ();


/* ---------------------------------------------------------------------------
 * convenience method StripComments()
 * ---------------------------------------------------------------------------
 * Returns true if option --strip-comments is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool StripComments ();


/* ---------------------------------------------------------------------------
 * convenience method ToDoList()
 * ---------------------------------------------------------------------------
 * Returns true if option --to-do-list is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ToDoList ();

  
} /* ICompilerOptions */

} /* namespace */

/* END OF FILE */