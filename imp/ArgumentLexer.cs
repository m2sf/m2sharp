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

public class ArgumentLexer : IArgumentLexer {

  private static uint argCount;
  private static uint index;

  private static string[] args;
  private static string lastArg;


/* ---------------------------------------------------------------------------
 * method InitWithArgs(args)
 * ---------------------------------------------------------------------------
 * Initialises the argument lexer class with the given arguments.
 * ------------------------------------------------------------------------ */

public static void InitWithArgs (string[] args) {

  ArgumentLexer.args = args;
  lastArg = null;

  index = 0;

  if (args == null) {
    argCount = 0;
  }
  else {
    argCount = (uint)args.Length;
  } /* end if */

} /* end InitWithArgs */


/* ---------------------------------------------------------------------------
 * method NextToken()
 * ---------------------------------------------------------------------------
 * Reads and consumes the next commmand line argument and returns its token.
 * ------------------------------------------------------------------------ */

public static ArgumentToken NextToken() {
  string thisArg;
  uint length;

  thisArg = NextArg();

  if (thisArg == null) {
    return ArgumentToken.END_OF_INPUT;
  } /* end if */

  if (thisArg[0] != '-') {
    return ArgumentToken.SOURCE_FILE;
  } /* end if */

  length = (uint)thisArg.Length;
  
  switch (length) {
    case 2 :
      switch (thisArg[1]) {

        case 'h' :
          return ArgumentToken.HELP;

        case 'v' :
          return ArgumentToken.VERBOSE;

        case 'V' :
          return ArgumentToken.VERSION;

      } /* end switch */
      break;

    case 4 :
      if (string.CompareOrdinal(thisArg, "--cs") == 0) {
            return ArgumentToken.XLAT;
      } /* end if */
      break;


    case 5 :
      switch (thisArg[2]) {

        case 'a' :
          if (string.CompareOrdinal(thisArg, "--ast") == 0) {
            return ArgumentToken.AST;
          } /* end if */
          break;

        case 'e' :
          if (string.CompareOrdinal(thisArg, "--ext") == 0) {
            return ArgumentToken.EXT;
          } /* end if */
          break;

        case 'o' :
          if (string.CompareOrdinal(thisArg, "--obj") == 0) {
            return ArgumentToken.OBJ;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 6 :
      switch (thisArg[5]) {

        case '3' :
          if (string.CompareOrdinal(thisArg, "--pim3") == 0) {
            return ArgumentToken.PIM3;
          } /* end if */
          break;

        case '4' :
          if (string.CompareOrdinal(thisArg, "--pim4") == 0) {
            return ArgumentToken.PIM4;
          } /* end if */
          break;

        case 'p' :
          if (string.CompareOrdinal(thisArg, "--help") == 0) {
            return ArgumentToken.HELP;
          } /* end if */
          break;

        case 't' :
          if (string.CompareOrdinal(thisArg, "--xlat") == 0) {
            return ArgumentToken.PIM4;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 7 :
      switch (thisArg[2]) {

        case 'g' :
          if (string.CompareOrdinal(thisArg, "--graph") == 0) {
            return ArgumentToken.GRAPH;
          } /* end if */
          break;

        case 'n' :
          if (string.CompareOrdinal(thisArg, "--no-cs") == 0) {
            return ArgumentToken.NO_XLAT;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(thisArg, "--safer") == 0) {
            return ArgumentToken.SAFER;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 8 :
      switch (thisArg[5]) {

        case 'a' :
          if (string.CompareOrdinal(thisArg, "--no-ast") == 0) {
            return ArgumentToken.NO_AST;
          } /* end if */
          break;

        case 'o' :
          if (string.CompareOrdinal(thisArg, "--no-obj") == 0) {
            return ArgumentToken.NO_OBJ;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 9 :
      switch (thisArg[5]) {

        case 'b' :
          if (string.CompareOrdinal(thisArg, "--verbose") == 0) {
            return ArgumentToken.VERBOSE;
          } /* end if */
          break;

        case 'e' :
          if (string.CompareOrdinal(thisArg, "--license") == 0) {
            return ArgumentToken.LICENSE;
          } /* end if */
          break;

        case 'o' :
          if (string.CompareOrdinal(thisArg, "--cs-only") == 0) {
            return ArgumentToken.XLAT_ONLY;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(thisArg, "--version") == 0) {
            return ArgumentToken.VERSION;
          } /* end if */
          break;

        case 'x' :
          if (string.CompareOrdinal(thisArg, "--no-xlat") == 0) {
            return ArgumentToken.NO_XLAT;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 10 :
      switch (thisArg[2]) {

        case 'a' :
          if (string.CompareOrdinal(thisArg, "--ast-only") == 0) {
            return ArgumentToken.AST_ONLY;
          } /* end if */
          break;

        case 'n' :
          if (string.CompareOrdinal(thisArg, "--no-graph") == 0) {
            return ArgumentToken.NO_GRAPH;
          } /* end if */
          break;

        case 'o' :
          if (string.CompareOrdinal(thisArg, "--obj-only") == 0) {
            return ArgumentToken.OBJ_ONLY;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(thisArg, "--synonyms") == 0) {
            return ArgumentToken.SYNONYMS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 11 :
      switch (thisArg[2]) {

        case 'c' :
          if (string.CompareOrdinal(thisArg, "--compliant") == 0) {
            return ArgumentToken.COMPLIANT;
          } /* end if */
          break;

        case 'x' :
          if (string.CompareOrdinal(thisArg, "--xlat-only") == 0) {
            return ArgumentToken.XLAT_ONLY;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 12 :
      switch (thisArg[2]) {

        case 'c' :
          if (string.CompareOrdinal(thisArg, "--coroutines") == 0) {
            return ArgumentToken.COROUTINES;
          } /* end if */
          break;

        case 'g' :
          if (string.CompareOrdinal(thisArg, "--graph-only") == 0) {
            return ArgumentToken.GRAPH_ONLY;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 13 :
      switch (thisArg[2]) {

        case 'n' :
          if (string.CompareOrdinal(thisArg, "--no-synonyms") == 0) {
            return ArgumentToken.NO_SYNONYMS;
          } /* end if */
          break;

        case 'l' :
          if (string.CompareOrdinal(thisArg, "--lexer-debug") == 0) {
            return ArgumentToken.LEXER_DEBUG;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(thisArg, "--syntax-only") == 0) {
            return ArgumentToken.SYNTAX_ONLY;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 14 :
      if (string.CompareOrdinal(thisArg, "--parser-debug") == 0) {
        return ArgumentToken.PARSER_DEBUG;
      } /* end if */
      break;

    case 15 :
      switch (thisArg[2]) {

        case 'e' :
          if (string.CompareOrdinal(thisArg, "--explicit-cast") == 0) {
            return ArgumentToken.EXPLICIT_CAST;
          } /* end if */
          break;

        case 'n' :
          if (string.CompareOrdinal(thisArg, "--no-coroutines") == 0) {
            return ArgumentToken.NO_COROUTINES;
          } /* end if */
          break;

        case 'l' :
          if (string.CompareOrdinal(thisArg, "--local-modules") == 0) {
            return ArgumentToken.LOCAL_MODULES;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(thisArg, "--show-settings") == 0) {
            return ArgumentToken.SHOW_SETTINGS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 16 :
      switch (thisArg[2]) {

        case 'o' :
          if (string.CompareOrdinal(thisArg, "--octal-literals") == 0) {
            return ArgumentToken.OCTAL_LITERALS;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(thisArg, "--strip-comments") == 0) {
            return ArgumentToken.STRIP_COMMENTS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 17 :
      switch (thisArg[2]) {

        case 't' :
          if (string.CompareOrdinal(thisArg, "--to-do-statement") == 0) {
            return ArgumentToken.TO_DO_STATEMENT;
          } /* end if */
          break;

        case 'v' :
          if (string.CompareOrdinal(thisArg, "--variant-records") == 0) {
            return ArgumentToken.VARIANT_RECORDS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 18 :
      switch (thisArg[5]) {

        case 'e' :
          if (string.CompareOrdinal(thisArg, "--no-explicit-cast") == 0) {
            return ArgumentToken.NO_EXPLICIT_CAST;
          } /* end if */
          break;

        case 'l' :
          if (string.CompareOrdinal(thisArg, "--no-local-modules") == 0) {
            return ArgumentToken.NO_LOCAL_MODULES;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 19 :
      switch (thisArg[2]) {

        case 'e' :
          if (string.CompareOrdinal(thisArg, "--errant-semicolons") == 0) {
            return ArgumentToken.ERRANT_SEMICOLONS;
          } /* end if */
          break;

        case 'n' :
          if (string.CompareOrdinal(thisArg, "--no-octal-literals") == 0) {
            return ArgumentToken.NO_OCTAL_LITERALS;
          } /* end if */
          break;

        case 'p' :
          if (string.CompareOrdinal(thisArg, "--preserve-comments") == 0) {
            return ArgumentToken.PRESERVE_COMMENTS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 20 :
      switch (thisArg[5]) {

        case 't' :
          if (string.CompareOrdinal(thisArg, "--no-to-do-statement") == 0) {
            return ArgumentToken.NO_EXPLICIT_CAST;
          } /* end if */
          break;

        case 'v' :
          if (string.CompareOrdinal(thisArg, "--no-variant-records") == 0) {
            return ArgumentToken.NO_LOCAL_MODULES;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 21 :
      if (string.CompareOrdinal(thisArg, "--lowline-identifiers") == 0) {
        return ArgumentToken.LOWLINE_IDENTIFIERS;
      } /* end if */
      break;

    case 24 :
      if (string.CompareOrdinal(thisArg, "--no-lowline-identifiers") == 0) {
        return ArgumentToken.NO_LOWLINE_IDENTIFIERS;
      } /* end if */
      break;

    case 26 :
      if (string.CompareOrdinal(thisArg, "--use-identifiers-verbatim") == 0) {
        return ArgumentToken.USE_IDENTIFIERS_VERBATIM;
      } /* end if */
      break;

    case 27 :
      if
        (string.CompareOrdinal(thisArg, "--transliterate-identifiers") == 0) {
        return ArgumentToken.TRANSLITERATE_IDENTIFIERS;
      } /* end if */
      break;

  } /* end switch */

  return ArgumentToken.UNKNOWN;
} /* end NextToken */


/* ---------------------------------------------------------------------------
 * method LastArg()
 * ---------------------------------------------------------------------------
 * Returns the argument string of the last consumed argument or null if the
 * end of input token has been returned by a prior call to NextToken().
 * ------------------------------------------------------------------------ */

public static string LastArg () {
  return lastArg;
} /* end LastArg */


/* ---------------------------------------------------------------------------
 * method IsInfoRequest(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an information request
 * ------------------------------------------------------------------------ */

public static bool IsInfoRequest (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.HELP) &&
    (sym <= ArgumentToken.LICENSE);
} /* end IsInfoRequest */


/* ---------------------------------------------------------------------------
 * method IsCompilationRequest(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a compilation request
 * ------------------------------------------------------------------------ */

public static bool IsCompilationRequest (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.PIM3) &&
    (sym <= ArgumentToken.SOURCE_FILE);
} /* end IsCompilationRequest */


/* ---------------------------------------------------------------------------
 * method IsDialectOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a dialect option
 * ------------------------------------------------------------------------ */

public static bool IsDialectOption (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.PIM3) &&
    (sym <= ArgumentToken.EXT);
} /* end IsDialectOption */


/* ---------------------------------------------------------------------------
 * method IsDialectQualifierOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a dialect qualifier option
 * ------------------------------------------------------------------------ */

public static bool IsDialectQualifierOption (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.SAFER) &&
    (sym <= ArgumentToken.COMPLIANT);
} /* end IsDialectQualifierOption */


/* ---------------------------------------------------------------------------
 * method IsProductOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a product option
 * ------------------------------------------------------------------------ */

public static bool IsProductOption (ArgumentToken sym) {
  return (IsSingleProductOption(sym) || IsMultipleProductsOption(sym));
} /* end IsProductOption */


/* ---------------------------------------------------------------------------
 * method IsSingleProductOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a single product option
 * ------------------------------------------------------------------------ */

public static bool IsSingleProductOption (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.SYNTAX_ONLY) &&
    (sym <= ArgumentToken.OBJ_ONLY);
} /* end IsSingleProductOption */


/* ---------------------------------------------------------------------------
 * method IsMultipleProductsOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a multiple product option
 * ------------------------------------------------------------------------ */

public static bool IsMultipleProductsOption (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.AST) &&
    (sym <= ArgumentToken.NO_OBJ);
} /* end IsMultipleProductsOption */


/* ---------------------------------------------------------------------------
 * method IsIdentifierOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an identifier option
 * ------------------------------------------------------------------------ */

public static bool IsIdentifierOption (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.USE_IDENTIFIERS_VERBATIM) &&
    (sym <= ArgumentToken.TRANSLITERATE_IDENTIFIERS);
} /* end IsIdentifierOption */


/* ---------------------------------------------------------------------------
 * method IsCommentOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a comment option
 * ------------------------------------------------------------------------ */

public static bool IsCommentOption (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.PRESERVE_COMMENTS) &&
    (sym <= ArgumentToken.STRIP_COMMENTS);
} /* end IsCommentOption */


/* ---------------------------------------------------------------------------
 * method IsCapabilityOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a capability option
 * ------------------------------------------------------------------------ */

public static bool IsCapabilityOption (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.SYNONYMS) &&
    (sym <= ArgumentToken.NO_TO_DO_STATEMENT);
} /* end IsCapabilityOption */


/* ---------------------------------------------------------------------------
 * method IsDiagnosticsOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is a diagnostic option
 * ------------------------------------------------------------------------ */

public static bool IsDiagnosticsOption (ArgumentToken sym) {
  return
    (sym >= ArgumentToken.VERBOSE) &&
    (sym <= ArgumentToken.ERRANT_SEMICOLONS);
} /* end IsDiagnosticsOption */


/* ---------------------------------------------------------------------------
 * private method NextArg()
 * ---------------------------------------------------------------------------
 * Consumes and returns the next command line argument.  Returns null if all
 * arguments have previously been consumed.
 * ------------------------------------------------------------------------ */

private static string NextArg() {
  string thisArg;

  if (index < argCount) {
    thisArg = args[index];
    index++;
  }
  else /* end of input */ {
    thisArg = null;
  } /* end if */

  /* remember the argument */
  lastArg = thisArg;

  return thisArg;
} /* end NextArg */


} /* IArgumentLexer */

} /* namespace */

/* END OF FILE */