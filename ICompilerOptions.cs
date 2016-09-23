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
 * type Option
 * ---------------------------------------------------------------------------
 * Enumerated values representing compiler options.
 * ------------------------------------------------------------------------ */

public enum Option {

  /* diagnostic options */

  Verbose,            /* --verbose */
  LexerDebug,         /* --lexer-debug */
  ParserDebug,        /* --parser-debug */
  ShowSettings,       /* --show-settings */
  ErrantSemicolons,   /* --errant-semicolons */

  /* build product options */

  AstRequired,        /* --ast, --no-ast */
  GraphRequired,      /* --graph, --no-graph */
  XlatRequired,       /* --xlat, --no-xlat */
  ObjRequired,        /* --obj, --no-obj */

  /* identifier option */

  UseIdentifiersVerbatim,
                      /* --use-identifiers-verbatim,
                         --transliterate-identifiers */

  /* comment option */

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

public interface ICompilerOptions {

/* ---------------------------------------------------------------------------
 * method SetDialect(dialect)
 * ---------------------------------------------------------------------------
 * Sets the current dialect to the given dialect and sets all capabilities to
 * the dialect's default capability settings. 
 * ------------------------------------------------------------------------ */

// public static void SetDialect (Dialect dialect);


/* ---------------------------------------------------------------------------
 * method CurrentDialect()
 * ---------------------------------------------------------------------------
 * Returns the current dialect.
 * ------------------------------------------------------------------------ */

// public static Dialect CurrentDialect ();


/* ---------------------------------------------------------------------------
 * method SetOption(option, value)
 * ---------------------------------------------------------------------------
 * Sets the given option to the given boolean value.
 * ------------------------------------------------------------------------ */

// public static void SetOption (Option option, bool value);


/* ---------------------------------------------------------------------------
 * method IsMutableOption(option)
 * ---------------------------------------------------------------------------
 * Returns true if option is mutable for the current dialect, else false.
 * ------------------------------------------------------------------------ */

// public static bool IsMutableOption (Option option);


/* ---------------------------------------------------------------------------
 * method Verbose()
 * ---------------------------------------------------------------------------
 * Returns true if option --verbose is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool Verbose ();


/* ---------------------------------------------------------------------------
 * method LexerDebug()
 * ---------------------------------------------------------------------------
 * Returns true if option --lexer-debug is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool LexerDebug ();


/* ---------------------------------------------------------------------------
 * method ParserDebug()
 * ---------------------------------------------------------------------------
 * Returns true if option --parser-debug is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ParserDebug ();


/* ---------------------------------------------------------------------------
 * method ShowSettings()
 * ---------------------------------------------------------------------------
 * Returns true if option --show-settings is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ShowSettings ();


/* ---------------------------------------------------------------------------
 * method ErrantSemicolons()
 * ---------------------------------------------------------------------------
 * Returns true if option --errant-semicolons is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ErrantSemicolons ();


/* ---------------------------------------------------------------------------
 * method AstRequired()
 * ---------------------------------------------------------------------------
 * Returns true if option --ast is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool AstRequired ();


/* ---------------------------------------------------------------------------
 * method GraphRequired()
 * ---------------------------------------------------------------------------
 * Returns true if option --graph is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool GraphRequired ();


/* ---------------------------------------------------------------------------
 * method XlatRequired()
 * ---------------------------------------------------------------------------
 * Returns true if option --xlat is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool XlatRequired ();


/* ---------------------------------------------------------------------------
 * method ObjRequired()
 * ---------------------------------------------------------------------------
 * Returns true if option --obj is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ObjRequired ();


/* ---------------------------------------------------------------------------
 * method UseIdentifiersVerbatim()
 * ---------------------------------------------------------------------------
 * Returns true if option --use-identifiers-verbatim is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool UseIdentifiersVerbatim ();


/* ---------------------------------------------------------------------------
 * method PreserveComments()
 * ---------------------------------------------------------------------------
 * Returns true if option --preserve-comments is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool PreserveComments ();


/* ---------------------------------------------------------------------------
 * method Synonyms()
 * ---------------------------------------------------------------------------
 * Returns true if option --synonyms is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool Synonyms ();
  
  
/* ---------------------------------------------------------------------------
 * method OctalLiterals()
 * ---------------------------------------------------------------------------
 * Returns true if option --octal-literals is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool OctalLiterals ();
  
  
/* ---------------------------------------------------------------------------
 * method LowlineIdentifiers()
 * ---------------------------------------------------------------------------
 * Returns true if option --lowline-identifiers is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool LowlineIdentifiers ();
  
  
/* ---------------------------------------------------------------------------
 * method ExplicitCast()
 * ---------------------------------------------------------------------------
 * Returns true if option --explicit-cast is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ExplicitCast ();


/* ---------------------------------------------------------------------------
 * method Coroutines()
 * ---------------------------------------------------------------------------
 * Returns true if option --coroutines is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool Coroutines ();


/* ---------------------------------------------------------------------------
 * method VariantRecords()
 * ---------------------------------------------------------------------------
 * Returns true if option --variant-records is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool VariantRecords ();


/* ---------------------------------------------------------------------------
 * method LocalModules()
 * ---------------------------------------------------------------------------
 * Returns true if option --local-modules is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool LocalModules ();


/* ---------------------------------------------------------------------------
 * method ToDoStatement()
 * ---------------------------------------------------------------------------
 * Returns true if option --to-do-statements is turned on, else false.
 * ------------------------------------------------------------------------ */

// public static bool ToDoStatement ();


/* ---------------------------------------------------------------------------
 * method PrintSettings()
 * ---------------------------------------------------------------------------
 * Prints the current settings to the console.
 * ------------------------------------------------------------------------ */

// public static void PrintSettings ();


} /* ICompilerOptions */

} /* namespace */

/* END OF FILE */