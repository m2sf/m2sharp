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

/* ---------------------------------------------------------------------------
 * type Option
 * ---------------------------------------------------------------------------
 * Enumerated values representing compiler options.
 * ------------------------------------------------------------------------ */

public enum OptionX {

  /* diagnostic options */

  Verbose,            /* --verbose */
  LexerDebug,         /* --lexer-debug */
  ParserDebug,        /* --parser-debug */
  ErrantSemicolons,   /* --errant-semicolons */

  /* build product options */

  AstRequired,        /* --ast, --no-ast */
  GraphRequired,      /* --graph, --no-graph */
  XlatRequired,       /* --xlat, --no-xlat */
  ObjRequired,        /* --obj, --no-obj */

  PreserveComments,   /* --preserve-comments, --strip-comments */

  /* capability options */

  Synonyms,           /* --synonyms, --no-synonyms */
  OctalLiterals,      /* --octal-literals, --no-octal-literals */
  LowlineIdentifiers, /* --lowline-identifiers, --no-lowline-identifiers */
  ExplicitCast,       /* --explicit-cast, --no-explicit-cast */
  Coroutines,         /* --coroutines, --no-coroutines */
  VariantRecords,     /* --variant-records, --no-variant-records */
  LocalModules,       /* --local-modules, --no-local-modules */
  ToDoStatement       /* --to-do-statement, --no-to-do-statement */

} /* Option */


/* ---------------------------------------------------------------------------
 * interface ICompilerOptions
 * ---------------------------------------------------------------------------
 * This interface describes a singleton class.
 * Since C# does not fully support the concept of information hiding, this
 * interface is entirely comprised of comments for documentation purposes.
 * ------------------------------------------------------------------------ */

public class CompilerOptions : ICompilerOptions {

  private static Dialect dialect = Dialect.Extended;

  private static bool verbose = false;
  private static bool lexerDebug = false;
  private static bool parserDebug = false;
  private static bool errantSemicolons = false;

  private static bool astRequired = true;
  private static bool graphRequired = false;
  private static bool xlatRequired = true;
  private static bool objRequired = false;

  private static bool preserveComments = true;


/* ---------------------------------------------------------------------------
 * method SetDialect(dialect)
 * ---------------------------------------------------------------------------
 * Sets the current dialect to the given dialect and sets all capabilities to
 * the dialect's default capability settings. 
 * ------------------------------------------------------------------------ */

public static void SetDialect (Dialect dialect) {
  Capability cap;
  bool value;

  for (cap = Capability.First; cap <= Capability.Last; cap++) {

    value = Dialects.IsDefaultCapability(dialect, cap);
    Capabilities.SetCapability(cap, value);

  } /* end for */

  CompilerOptions.dialect = dialect;
} /* end SetDialect */


/* ---------------------------------------------------------------------------
 * method CurrentDialect()
 * ---------------------------------------------------------------------------
 * Returns the current dialect.
 * ------------------------------------------------------------------------ */

public static Dialect CurrentDialect () {
  return dialect;
} /* end CurrentDialect */


/* ---------------------------------------------------------------------------
 * method SetOption(option, value)
 * ---------------------------------------------------------------------------
 * Sets the given option to the given boolean value.
 * ------------------------------------------------------------------------ */

public static void SetOption (Option option, bool value) {

  switch (option) {

    case Option.Verbose :
      verbose = value;
      break;

    case Option.LexerDebug :
      lexerDebug = value;
      break;

    case Option.ParserDebug :
      parserDebug = value;
      break;

    case Option.ErrantSemicolons :
      errantSemicolons = value;
      break;

    case Option.AstRequired :
      astRequired = value;
      break;

    case Option.GraphRequired :
      graphRequired = value;
      break;

    case Option.XlatRequired :
      xlatRequired = value;
      break;

    case Option.ObjRequired :
      objRequired = value;
      break;

    case Option.PreserveComments :
      preserveComments = value;
      break;

    default :
      SetCapability(option, value);
      break;

  } /* end switch */

} /* end SetOpt */


/* ---------------------------------------------------------------------------
 * method Verbose()
 * ---------------------------------------------------------------------------
 * Returns true if option --verbose is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool Verbose () {
  return verbose;
} /* end Verbose */


/* ---------------------------------------------------------------------------
 * method LexerDebug()
 * ---------------------------------------------------------------------------
 * Returns true if option --lexer-debug is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool LexerDebug () {
  return lexerDebug;
} /* end LexerDebug */


/* ---------------------------------------------------------------------------
 * method ParserDebug()
 * ---------------------------------------------------------------------------
 * Returns true if option --parser-debug is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ParserDebug () {
  return parserDebug;
} /* end ParserDebug */


/* ---------------------------------------------------------------------------
 * method ErrantSemicolons()
 * ---------------------------------------------------------------------------
 * Returns true if option --errant-semicolons is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ErrantSemicolons () {
  return errantSemicolons;
} /* end ErrantSemicolons */


/* ---------------------------------------------------------------------------
 * method AstRequired()
 * ---------------------------------------------------------------------------
 * Returns true if option --ast is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool AstRequired () {
  return astRequired;
} /* end AstRequired */


/* ---------------------------------------------------------------------------
 * method GraphRequired()
 * ---------------------------------------------------------------------------
 * Returns true if option --graph is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool GraphRequired () {
  return graphRequired;
} /* end GraphRequired */


/* ---------------------------------------------------------------------------
 * method XlatRequired()
 * ---------------------------------------------------------------------------
 * Returns true if option --xlat is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool XlatRequired () {
  return xlatRequired;
} /* end XlatRequired */


/* ---------------------------------------------------------------------------
 * method ObjRequired()
 * ---------------------------------------------------------------------------
 * Returns true if option --obj is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ObjRequired () {
  return objRequired;
} /* end ObjRequired */


/* ---------------------------------------------------------------------------
 * method PreserveComments()
 * ---------------------------------------------------------------------------
 * Returns true if option --preserve-comments is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool PreserveComments () {
  return preserveComments;
} /* end PreserveComments */


/* ---------------------------------------------------------------------------
 * method Synonyms()
 * ---------------------------------------------------------------------------
 * Returns true if option --synonyms is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool Synonyms () {
  return Capabilities.Synonyms();
} /* end Synonyms */
  
  
/* ---------------------------------------------------------------------------
 * method OctalLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if option --octal-literals is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool OctalLiterals () {
  return Capabilities.OctalLiterals();
} /* end OctalLiterals */
  
  
/* ---------------------------------------------------------------------------
 * method LowlineIdentifiers()
 * ---------------------------------------------------------------------------
 * Returns true if option --lowline-identifiers is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool LowlineIdentifiers () {
  return Capabilities.LowlineIdentifiers();
} /* end LowlineIdentifiers */
  
  
/* ---------------------------------------------------------------------------
 * method ExplicitCast()
 * ---------------------------------------------------------------------------
 * Returns true if option --explicit-cast is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ExplicitCast () {
  return Capabilities.ExplicitCast();
} /* end ExplicitCast */


/* ---------------------------------------------------------------------------
 * method Coroutines()
 * ---------------------------------------------------------------------------
 * Returns true if option --coroutines is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool Coroutines () {
  return Capabilities.Coroutines();
} /* end Coroutines */


/* ---------------------------------------------------------------------------
 * method VariantRecords()
 * ---------------------------------------------------------------------------
 * Returns true if option --variant-records is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool VariantRecords () {
  return Capabilities.VariantRecords();
} /* end VariantRecords */


/* ---------------------------------------------------------------------------
 * method LocalModules()
 * ---------------------------------------------------------------------------
 * Returns true if option --local-modules is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool LocalModules () {
  return Capabilities.LocalModules();
} /* end LocalModules */


/* ---------------------------------------------------------------------------
 * method ToDoStatement()
 * ---------------------------------------------------------------------------
 * Returns true if option --to-do-statements is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ToDoStatement () {
  return Capabilities.ToDoStatement();
} /* end ToDoStatement */


/* ---------------------------------------------------------------------------
 * private method SetCapability(option, value)
 * ---------------------------------------------------------------------------
 * Sets the capability associated with option to the given value.
 * ------------------------------------------------------------------------ */

private static void SetCapability (Option option, bool value) {
  Capability capability;

  switch (option) {

    case Option.Synonyms :
      capability = Capability.Synonyms;
      break;

    case Option.OctalLiterals :
      capability = Capability.OctalLiterals;
      break;

    case Option.LowlineIdentifiers :
      capability = Capability.LowlineIdentifiers;
      break;

    case Option.ExplicitCast :
      capability = Capability.ExplicitCast;
      break;

    case Option.VariantRecords :
      capability = Capability.VariantRecords;
      break;

    case Option.LocalModules :
      capability = Capability.LocalModules;
      break;

    case Option.ToDoStatement :
      capability = Capability.ToDoStatement;
      break;

    default :
      // error : not a capability option
      return;

  } /* end switch */
  
  if (Dialects.IsMutableCapability(dialect, capability)) {
    Capabilities.SetCapability(capability, value);
  }
  else /* immutable capability */ {
    // error : not a mutable option
  } /* end if */
  
} /* end SetCapability */

  
} /* CompilerOptions */

} /* namespace */

/* END OF FILE */