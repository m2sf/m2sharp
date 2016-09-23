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
 * IArgumentLexer.cs
 *
 * Public interface for command line argument lexer.
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
 * type ArgumentToken
 * ---------------------------------------------------------------------------
 * Enumerated token values representing command line arguments.
 * ------------------------------------------------------------------------ */

public enum ArgumentToken {
  UNKNOWN,

  /* information options */

  HELP,                      /* --help, -h */
  VERSION,                   /* --version, -V */
  LICENSE,                   /* --license */

  /* dialect options */

  PIM3,                      /* --pim3 */
  PIM4,                      /* --pim4 */
  EXT,                       /* --ext */

  /* dialect qualifier options */

  SAFER,                     /* --safer */
  COMPLIANT,                 /* --compliant */

  /* singe product options */

  SYNTAX_ONLY,               /* --syntax-only */
  AST_ONLY,                  /* --ast-only */
  GRAPH_ONLY,                /* --graph-only */
  XLAT_ONLY,                 /* --xlat-only */
  OBJ_ONLY,                  /* --obj-only */

  /* multiple product options */

  AST,                       /* --ast */
  NO_AST,                    /* --no-ast */
  GRAPH,                     /* --graph */
  NO_GRAPH,                  /* --no-graph */
  XLAT,                      /* --xlat */
  NO_XLAT,                   /* --no-xlat */
  OBJ,                       /* --obj */
  NO_OBJ,                    /* --no-obj */

  /* identifier options */

  USE_IDENTIFIERS_VERBATIM,  /* --use-identifiers-verbatim */
  TRANSLITERATE_IDENTIFIERS, /* --transliterate-identifiers */

  /* comment options */

  PRESERVE_COMMENTS,         /* --preserve-comments */
  STRIP_COMMENTS,            /* --strip-comments */

  /* capability options */

  SYNONYMS,                  /* --synonyms */
  NO_SYNONYMS,               /* --no-synonyms */
  OCTAL_LITERALS,            /* --octal-literals */
  NO_OCTAL_LITERALS,         /* --no-octal-literals */
  EXPLICIT_CAST,             /* --explicit-cast */
  NO_EXPLICIT_CAST,          /* --no-explicit-cast */
  COROUTINES,                /* --coroutines */
  NO_COROUTINES,             /* --no-coroutines */
  VARIANT_RECORDS,           /* --variant-records */
  NO_VARIANT_RECORDS,        /* --no-variant-records */
  LOCAL_MODULES,ES,          /* --local-modules */
  NO_LOCAL_MODULES,          /* --no-local-modules */
  LOWLINE_IDENTIFIERS,       /* --lowline-identifiers */
  NO_LOWLINE_IDENTIFIERS,    /* --no-lowline-identifiers */
  TO_DO_STATEMENT,           /* --to-do-statement */
  NO_TO_DO_STATEMENT,        /* --no-to-do-statement */

  /* source file argument */

  SOURCE_FILE,

  /* diagnostic options */

  VERBOSE,                   /* --verbose, -v */
  LEXER_DEBUG,               /* --lexer-debug */
  PARSER_DEBUG,              /* --parser-debug */
  SHOW_SETTINGS,             /* --show-settings */
  ERRANT_SEMICOLONS,         /* --errant-semicolons */

  /* end of input sentinel */

  END_OF_INPUT

} /* ArgumentToken */


/* ---------------------------------------------------------------------------
 * interface IArgumentLexer
 * ---------------------------------------------------------------------------
 * This interface describes a singleton class.
 * Since C# does not fully support the concept of information hiding, this
 * interface is entirely comprised of comments for documentation purposes.
 * ------------------------------------------------------------------------ */

public interface IArgumentLexer {

/* ---------------------------------------------------------------------------
 * method InitWithArgs(args)
 * ---------------------------------------------------------------------------
 * Initialises the argument lexer class with the given arguments.
 * ------------------------------------------------------------------------ */

// public static void InitWithArgs (string[] args);


/* ---------------------------------------------------------------------------
 * method NextToken()
 * ---------------------------------------------------------------------------
 * Reads and consumes the next commmand line argument and returns its token.
 * ------------------------------------------------------------------------ */

// public static ArgumentToken NextToken();


/* ---------------------------------------------------------------------------
 * method LastArg()
 * ---------------------------------------------------------------------------
 * Returns the argument string of the last consumed argument or null if the
 * end of input token has been returned by a prior call to NextToken().
 * ------------------------------------------------------------------------ */

// public static string LastArg ();


/* ---------------------------------------------------------------------------
 * method IsInfoRequest(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an information request
 * ------------------------------------------------------------------------ */

// public static bool IsInfoRequest (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsCompilationRequest(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a compilation request
 * ------------------------------------------------------------------------ */

// public static bool IsCompilationRequest (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsDialectOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a dialect option
 * ------------------------------------------------------------------------ */

// public static bool IsDialectOption (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsDialectQualifierOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a dialect qualifier option
 * ------------------------------------------------------------------------ */

// public static bool IsDialectQualifierOption (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsProductOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a product option
 * ------------------------------------------------------------------------ */

// public static bool IsProductOption (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsSingleProductOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a single product option
 * ------------------------------------------------------------------------ */

// public static bool IsSingleProductOption (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsMultipleProductsOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a multiple product option
 * ------------------------------------------------------------------------ */

// public static bool IsMultipleProductsOption (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsIdentifierOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an identifier option
 * ------------------------------------------------------------------------ */

// public static bool IsIdentifierOption (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsCommentOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a comment option
 * ------------------------------------------------------------------------ */

// public static bool IsCommentOption (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsCapabilityOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a capability option
 * ------------------------------------------------------------------------ */

// public static bool IsCapabilityOption (ArgumentToken sym);


/* ---------------------------------------------------------------------------
 * method IsDiagnosticsOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a diagnostic option
 * ------------------------------------------------------------------------ */

// public static bool IsDiagnosticsOption (ArgumentToken sym);


} /* IArgumentLexer */

} /* namespace */

/* END OF FILE */