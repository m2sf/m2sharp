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

public enum OptionToken {
  UNKNOWN,

  /* information options */

  HELP,                     /* --help, -h */
  VERSION,                  /* --version, -V */
  LICENSE,                  /* --license */

  /* dialect options */

  PIM3,                     /* --pim3 */
  PIM4,                     /* --pim4 */
  EXT,                      /* --ext */

  /* diagnostic options */

  VERBOSE,                  /* --verbose, -v */
  LEXER_DEBUG,              /* --lexer-debug */
  PARSER_DEBUG,             /* --parser-debug */
  ERRANT_SEMICOLONS,        /* --errant-semicolons */

  /* singe product options */

  SYNTAX_ONLY,              /* --syntax-only */
  AST_ONLY,                 /* --ast-only */
  GRAPH_ONLY,               /* --graph-only */
  XLAT_ONLY,                /* --xlat-only */
  OBJ_ONLY,                 /* --obj-only */

  /* multiple product options */

  AST,                      /* --ast */
  NO_AST,                   /* --no-ast */
  GRAPH,                    /* --graph */
  NO_GRAPH,                 /* --no-graph */
  XLAT,                     /* --xlat */
  NO_XLAT,                  /* --no-xlat */
  OBJ,                      /* --obj */
  NO_OBJ,                   /* --no-obj */

  /* comment option */

  PRESERVE_COMMENTS,        /* --preserve-comments */
  STRIP_COMMENTS,           /* --strip-comments */

  /* capability group options */

  SAFER,                    /* --safer */
  COMPLIANT,                /* --compliant */

  /* capability options */

  SYNONYMS,                 /* --synonyms */
  NO_SYNONYMS,              /* --no-synonyms */
  OCTAL_LITERALS,           /* --octal-literals */
  NO_OCTAL_LITERALS,        /* --no-octal-literals */
  EXPLICIT_CAST,            /* --explicit-cast */
  NO_EXPLICIT_CAST,         /* --no-explicit-cast */
  COROUTINES,               /* --coroutines */
  NO_COROUTINES,            /* --no-coroutines */
  VARIANT_RECORDS,          /* --variant-records */
  NO_VARIANT_RECORDS,       /* --no-variant-records */
  LOCAL_MODULES,ES,         /* --local-modules */
  NO_LOCAL_MODULES,         /* --no-local-modules */
  LOWLINE_IDENTIFIERS,      /* --lowline-identifiers */
  NO_LOWLINE_IDENTIFIERS,   /* --no-lowline-identifiers */
  TO_DO_STATEMENT,          /* --to-do-statement */
  NO_TO_DO_STATEMENT,       /* --no-to-do-statement */

  /* source file */

  SOURCE_FILE,

  /* end of input sentinel */

  END_OF_INPUT

} /* OptionToken */


public interface IOptionParser {

/* ---------------------------------------------------------------------------
 * method ParseOptions()
 * ---------------------------------------------------------------------------
 * Parses command line arguments and sets compiler options accordingly.
 * ------------------------------------------------------------------------ */

public void ParseOptions ();


} /* OptionParser */

} /* namespace */

/* END OF FILE */