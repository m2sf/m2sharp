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
 * CompilerOptions.cs
 *
 * compiler options class
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

public class CompilerOptions : ICompilerOptions {

  private static Dialect dialect = Dialect.Extended;

  private static bool verbose = false;
  private static bool lexerDebug = false;
  private static bool parserDebug = false;
  private static bool synonyms = false;
  private static bool lineComments = true;
  private static bool prefixLiterals = false;
  private static bool suffixLiterals = true;
  private static bool octalLiterals = false;
  private static bool lowlineIdentifiers = false;
  private static bool escapeTabAndNewline = true;
  private static bool backslashSetDiffOp = true;
  private static bool subtypeCardinals = false;
  private static bool safeStringTermination = true;
  private static bool constParameters = true;
  private static bool variadicParameters = false;
  private static bool additionalTypes = true;
  private static bool additionalFunctions = true;
  private static bool unifiedConversion = true;
  private static bool explicitCast = true;
  private static bool coroutines = false;
  private static bool variantRecords = false;
  private static bool extensibleRecords = true;
  private static bool indeterminateRecords = true;
  private static bool localModules = false;
  private static bool errantSemicolons = false;
  private static bool stripComments = true;
  private static bool toDoList = false;


/* ---------------------------------------------------------------------------
 * method SetOptions(dialect, option1, option2, ...)
 * ---------------------------------------------------------------------------
 * Sets current dialect and options.
 * ------------------------------------------------------------------------ */

public void SetOptions (Dialect dialect, params Option[] options) {
// TO DO
} /* end SetOptions */


/* ---------------------------------------------------------------------------
 * method GetDialect()
 * ---------------------------------------------------------------------------
 * Returns the current dialect.
 * ------------------------------------------------------------------------ */

public static Dialect GetDialect () {
  return dialect;
} /* end Dialect */


/* ---------------------------------------------------------------------------
 * method GetOpt(option)
 * ---------------------------------------------------------------------------
 * Returns true if option is turned on, otherwise false.
 * ------------------------------------------------------------------------ */

public static bool GetOpt (Option option) {
  switch (option) {

    case Option.Verbose :
      return verbose;

    case Option.LexerDebug :
      return lexerDebug;

    case Option.ParserDebug :
      return parserDebug;

    case Option.Synonyms :
      return synonyms;

    case Option.LineComments :
      return lineComments;

    case Option.PrefixLiterals :
      return prefixLiterals;

    case Option.SuffixLiterals :
      return suffixLiterals;

    case Option.OctalLiterals :
      return octalLiterals;

    case Option.LowlineIdentifiers :
      return lowlineIdentifiers;

    case Option.EscapeTabAndNewline :
      return escapeTabAndNewline;

    case Option.BackslashSetDiffOp :
      return backslashSetDiffOp;

    case Option.SubtypeCardinals :
      return subtypeCardinals;

    case Option.SafeStringTermination :
      return safeStringTermination;

    case Option.ConstParameters :
      return constParameters;

    case Option.VariadicParameters :
      return variadicParameters;

    case Option.AdditionalTypes :
      return additionalTypes;

    case Option.AdditionalFunctions :
      return additionalFunctions;

    case Option.UnifiedConversion :
      return unifiedConversion;

    case Option.ExplicitCast :
      return explicitCast;

    case Option.Coroutines :
      return coroutines;

    case Option.VariantRecords :
      return variantRecords;

    case Option.ExtensibleRecords :
      return extensibleRecords;

    case Option.IndeterminateRecords :
      return indeterminateRecords;

    case Option.LocalModules :
      return localModules;

    case Option.ErrantSemicolons :
      return errantSemicolons;

    case Option.StripComments :
      return stripComments;

    case Option.ToDoList :
      return toDoList;

    default :
      return false;

  } /* end switch */
} /* end GetOpt */


/* ---------------------------------------------------------------------------
 * convenience method Verbose()
 * ---------------------------------------------------------------------------
 * Returns true if option --verbose is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool Verbose () {
  return verbose;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method LexerDebug()
 * ---------------------------------------------------------------------------
 * Returns true if option --lexer-debug is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool LexerDebug () {
  return lexerDebug;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method ParserDebug()
 * ---------------------------------------------------------------------------
 * Returns true if option --parser-debug is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ParserDebug () {
  return parserDebug;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method Synonyms()
 * ---------------------------------------------------------------------------
 * Returns true if option --synonyms is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool Synonyms () {
  return synonyms;
} /* end  */
  
  
/* ---------------------------------------------------------------------------
 * convenience method LineComments()
 * ---------------------------------------------------------------------------
 * Returns true if option --line-comments is turned on, else false.
 * ------------------------------------------------------------------------ */
  
public static bool LineComments () {
  return lineComments;
} /* end  */
  
  
/* ---------------------------------------------------------------------------
 * convenience method PrefixLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if option --prefix-literals is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool PrefixLiterals () {
  return prefixLiterals;
} /* end  */
  
  
/* ---------------------------------------------------------------------------
 * convenience method SuffixLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if option --suffix-literals is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool SuffixLiterals () {
  return suffixLiterals;
} /* end  */
  
  
/* ---------------------------------------------------------------------------
 * convenience method OctalLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if option --octal-literals is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool OctalLiterals () {
  return octalLiterals;
} /* end  */
  
  
/* ---------------------------------------------------------------------------
 * convenience method LowlineIdentifiers()
 * ---------------------------------------------------------------------------
 * Returns true if option --lowline-identifiers is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool LowlineIdentifiers () {
  return lowlineIdentifiers;
} /* end  */
  
  
/* ---------------------------------------------------------------------------
 * convenience method EscapeTabAndNewline()
 * ---------------------------------------------------------------------------
 * Returns true if option --escape-tab-and-newline is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool EscapeTabAndNewline () {
  return escapeTabAndNewline;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method BackslashSetDiffOp()
 * ---------------------------------------------------------------------------
 * Returns true if option --backslash-set-diff-op is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool BackslashSetDiffOp () {
  return backslashSetDiffOp;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method SubtypeCardinals()
 * ---------------------------------------------------------------------------
 * Returns true if option --subtype-cardinals is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool SubtypeCardinals () {
  return subtypeCardinals;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method SafeStringTermination()
 * ---------------------------------------------------------------------------
 * Returns true if option --safe-string-termination is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool SafeStringTermination () {
  return safeStringTermination;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method ConstParameters()
 * ---------------------------------------------------------------------------
 * Returns true if option --const-parameters is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ConstParameters () {
  return constParameters;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method VariadicParameters()
 * ---------------------------------------------------------------------------
 * Returns true if option --variadic-parameters is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool VariadicParameters () {
  return variadicParameters;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method AdditionalTypes()
 * ---------------------------------------------------------------------------
 * Returns true if option --additional-types is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool AdditionalTypes () {
  return additionalTypes;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method AdditionalFunctions()
 * ---------------------------------------------------------------------------
 * Returns true if option --additional-functions is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool AdditionalFunctions () {
  return additionalFunctions;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method UnifiedConversion()
 * ---------------------------------------------------------------------------
 * Returns true if option --unified-conversion is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool UnifiedConversion () {
  return unifiedConversion;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method ExplicitCast()
 * ---------------------------------------------------------------------------
 * Returns true if option --explicit-cast is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ExplicitCast () {
  return explicitCast;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method Coroutines()
 * ---------------------------------------------------------------------------
 * Returns true if option --coroutines is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool Coroutines () {
  return coroutines;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method VariantRecords()
 * ---------------------------------------------------------------------------
 * Returns true if option --variant-records is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool VariantRecords () {
  return variantRecords;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method LocalModules()
 * ---------------------------------------------------------------------------
 * Returns true if option --local-modules is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool LocalModules () {
  return localModules;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method ErrantSemicolons()
 * ---------------------------------------------------------------------------
 * Returns true if option --errant-semicolons is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ErrantSemicolons () {
  return errantSemicolons;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method StripComments()
 * ---------------------------------------------------------------------------
 * Returns true if option --strip-comments is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool StripComments () {
  return stripComments;
} /* end  */


/* ---------------------------------------------------------------------------
 * convenience method ToDoList()
 * ---------------------------------------------------------------------------
 * Returns true if option --to-do-list is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ToDoList () {
  return toDoList;
} /* end  */

  
} /* CompilerOptions */

} /* namespace */

/* END OF FILE */