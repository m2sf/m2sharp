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
 * OptionParser.cs
 *
 * Command line argument parser class.
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

public class OptionParser : IOptionParser {

  private string[] argument;
  private uint argCount = 0;
  private uint index = 0;


  private OptionParser () {
    // no operation
  } /* end OptionParser */


/* N O N - T E R M I N A L S */

/* ---------------------------------------------------------------------------
 * method ParseOptions()
 * ---------------------------------------------------------------------------
 * options :
 *   infoRequest | compilationRequest
 *   ;
 * ------------------------------------------------------------------------ */

public void ParseOptions (string[] args) {
  OptionToken sym;

  argument = args;
  argCount = (uint)args.Length;
  
  sym = NextToken();

  if (IsInfoRequest(sym)) {
    sym = ParseInfoRequest(sym);
  }
  else if (IsCompilationRequest(sym)) {
    sym = ParseCompilationRequest(sym);
  }
  else {
    // error : invalid argument
    sym = OptionToken.UNKNOWN;
  } /* end if */

} /* end ParseOptions */


/* ---------------------------------------------------------------------------
 * method ParseInfoRequest(sym)
 * ---------------------------------------------------------------------------
 * options :
 *   HELP | VERSION | LICENSE
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseInfoRequest (OptionToken sym) {

  switch (sym) {

    case OptionToken.HELP :
      PrintHelp();
      break;

    case OptionToken.VERSION :
      PrintVersion();
      break;

    case OptionToken.LICENSE :
      PrintLicense();
      break;

  } /* end switch */

  return NextToken();
} /* end ParseInfoRequest */


/* ---------------------------------------------------------------------------
 * method ParseCompilationRequest(sym)
 * ---------------------------------------------------------------------------
 * compilationRequest :
 *   dialect? diagnostics? products? capabilities? sourceFile
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseCompilationRequest (OptionToken sym) {

  if (IsDialectOption(sym)) {
    sym = ParseDialect(sym);
  } /* end */

  if (IsDiagnosticsOption(sym)) {
    sym = ParseDiagnostics(sym);
  } /* end */

  if (IsProductOption(sym)) {
    sym = ParseProducts(sym);
  } /* end */

  if (IsCapabilityOption(sym)) {
    sym = ParseCapabilities(sym);
  } /* end */
  
  if (sym == OptionToken.SOURCE_FILE) {
    sym = ParseSourceFile(sym);
  }
  else {
    // error : expected source file
  } /* end if */

  return sym;
} /* end ParseCompilationRequest */


/* ---------------------------------------------------------------------------
 * method ParseDialect(sym)
 * ---------------------------------------------------------------------------
 * dialect :
 *   PIM3 | PIM4 | EXT
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseDialect (OptionToken sym) {

  switch (sym) {

    case OptionToken.PIM3 :
      CompilerOptions.SetDialect(Dialect.PIM3);
      break;

    case OptionToken.PIM4 :
      CompilerOptions.SetDialect(Dialect.PIM4);
      break;

    case OptionToken.EXT :
      CompilerOptions.SetDialect(Dialect.Extended);
      break;

  } /* end switch */

  return NextToken();
} /* end ParseDialect */


/* ---------------------------------------------------------------------------
 * method ParseDiagnostics(sym)
 * ---------------------------------------------------------------------------
 * diagnostics :
 *   VERBOSE | LEXER_DEBUG | PARSER_DEBUG | ERRANT_SEMICOLONS
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseDiagnostics (OptionToken sym) {

  switch (sym) {

    case OptionToken.VERBOSE :
      CompilerOptions.SetOption(Option.Verbose, true);
      break;

    case OptionToken.LEXER_DEBUG :
      CompilerOptions.SetOption(Option.LexerDebug, true);
      break;

    case OptionToken.PARSER_DEBUG :
      CompilerOptions.SetOption(Option.ParserDebug, true);
      break;

    case OptionToken.ERRANT_SEMICOLONS :
      CompilerOptions.SetOption(Option.ErrantSemicolons, true);
      break;

  } /* end switch */

  return NextToken();
} /* end ParseDiagnostics */


/* ---------------------------------------------------------------------------
 * method ParseProducts(sym)
 * ---------------------------------------------------------------------------
 * products :
 *   ( singleProduct | multipleProducts ) commentOption?
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseProducts (OptionToken sym) {

  if (IsSingleProductOption(sym)) {
    sym = ParseSingleProduct(sym);
  }
  else if (IsMultipleProductsOption(sym)) {
    sym = ParseMultipleProducts(sym);
  }
  else {
    // error 
  } /* end if */

  if (IsCommentOption(sym)) {
    sym = ParseCommentOption(sym);
  } /* end if */

  return sym;
} /* end ParseProducts */


/* ---------------------------------------------------------------------------
 * method ParseSingleProduct(sym)
 * ---------------------------------------------------------------------------
 * singleProduct :
 *   SYNTAX_ONLY | AST_ONLY | GRAPH_ONLY | XLAT_ONLY | OBJ_ONLY
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseSingleProduct (OptionToken sym) {

  switch (sym) {

    case OptionToken.SYNTAX_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, false);
      CompilerOptions.SetOption(Option.GraphRequired, false);
      CompilerOptions.SetOption(Option.XlatRequired, false);
      CompilerOptions.SetOption(Option.ObjRequired, false);
      break;

    case OptionToken.AST_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, true);
      CompilerOptions.SetOption(Option.GraphRequired, false);
      CompilerOptions.SetOption(Option.XlatRequired, false);
      CompilerOptions.SetOption(Option.ObjRequired, false);
      break;

    case OptionToken.GRAPH_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, false);
      CompilerOptions.SetOption(Option.GraphRequired, true);
      CompilerOptions.SetOption(Option.XlatRequired, false);
      CompilerOptions.SetOption(Option.ObjRequired, false);
      break;

    case OptionToken.XLAT_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, false);
      CompilerOptions.SetOption(Option.GraphRequired, false);
      CompilerOptions.SetOption(Option.XlatRequired, true);
      CompilerOptions.SetOption(Option.ObjRequired, false);
      break;

    case OptionToken.OBJ_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, false);
      CompilerOptions.SetOption(Option.GraphRequired, false);
      CompilerOptions.SetOption(Option.XlatRequired, false);
      CompilerOptions.SetOption(Option.ObjRequired, true);
      break;

  } /* end switch */

  return NextToken();
} /* end ParseSingleProduct */


/* ---------------------------------------------------------------------------
 * method ParseMultipleProducts(sym)
 * ---------------------------------------------------------------------------
 * multipleProducts :
 *   ( ast | graph | xlat | obj )+
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseMultipleProducts (OptionToken sym) {

  while (IsMultipleProductsOption(sym)) {

    switch (sym) {

      case OptionToken.AST :
        CompilerOptions.SetOption(Option.AstRequired, true);
        break;

      case OptionToken.NO_AST :
        CompilerOptions.SetOption(Option.AstRequired, false);
        break;

      case OptionToken.GRAPH :
        CompilerOptions.SetOption(Option.GraphRequired, true);
        break;

      case OptionToken.NO_GRAPH :
        CompilerOptions.SetOption(Option.GraphRequired, false);
        break;

      case OptionToken.XLAT :
        CompilerOptions.SetOption(Option.XlatRequired, true);
        break;

      case OptionToken.NO_XLAT :
        CompilerOptions.SetOption(Option.XlatRequired, false);
        break;

      case OptionToken.OBJ :
        CompilerOptions.SetOption(Option.ObjRequired, true);
        break;

      case OptionToken.NO_OBJ :
        CompilerOptions.SetOption(Option.ObjRequired, false);
        break;

    } /* end switch */

    sym = NextToken();
  } /* end while */

  return sym;
} /* end ParseMultipleProducts */


/* ---------------------------------------------------------------------------
 * method ParseCommentOption(sym)
 * ---------------------------------------------------------------------------
 * commentOption :
 *   PRESERVE_COMMENTS | STRIP_COMMENTS
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseCommentOption (OptionToken sym) {

  switch (sym) {

    case OptionToken.PRESERVE_COMMENTS :
      CompilerOptions.SetOption(Option.PreserveComments, true);
      break;

    case OptionToken.STRIP_COMMENTS :
      CompilerOptions.SetOption(Option.PreserveComments, false);
      break;

  } /* end switch */

  return NextToken();
} /* end ParseCommentOption */


/* ---------------------------------------------------------------------------
 * method ParseCapabilities(sym)
 * ---------------------------------------------------------------------------
 * capabilities :
 *   capabilityGroup capability* | capability+
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseCapabilities (OptionToken sym) {

  if (IsCapabilityGroupOption(sym)) {
    sym = ParseCapabilityGroup(sym);

    while (IsCapabilityOption(sym)) {
      sym = ParseCapability(sym);
    } /* end while */
  }
  else /* capability */ {
    while (IsCapabilityOption(sym)) {
      sym = ParseCapability(sym);
    } /* end while */
  } /* end if */

  return sym;
} /* end ParseCapabilities */


/* ---------------------------------------------------------------------------
 * method ParseCapabilityGroup(sym)
 * ---------------------------------------------------------------------------
 * capabilityGroup :
 *   SAFER | COMPLIANT
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseCapabilityGroup (OptionToken sym) {

  switch (sym) {

    case OptionToken.SAFER :
      CompilerOptions.SetOption(Option.Synonyms, false);
      CompilerOptions.SetOption(Option.OctalLiterals, false);
      CompilerOptions.SetOption(Option.ExplicitCast, false);
      CompilerOptions.SetOption(Option.Coroutines, false);
      CompilerOptions.SetOption(Option.VariantRecords, false);
      CompilerOptions.SetOption(Option.LocalModules, false);
      break;

    case OptionToken.COMPLIANT :
      CompilerOptions.SetOption(Option.Synonyms, true);
      CompilerOptions.SetOption(Option.OctalLiterals, true);
      CompilerOptions.SetOption(Option.ExplicitCast, true);
      CompilerOptions.SetOption(Option.Coroutines, true);
      CompilerOptions.SetOption(Option.VariantRecords, true);
      CompilerOptions.SetOption(Option.LocalModules, true);
      break;

  } /* end switch */

  return NextToken();
} /* end ParseCapabilityGroup */


/* ---------------------------------------------------------------------------
 * method ParseCapability(sym)
 * ---------------------------------------------------------------------------
 * capability :
 *   synonyms | octalLiterals | explicitCast |
 *   coroutines | variantRecords | localModules |
 *   lowlineIdentifiers | toDoStatement
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseCapability (OptionToken sym) {

  switch (sym) {

    case OptionToken.SYNONYMS :
      CompilerOptions.SetOption(Option.Synonyms, true);
      break;

    case OptionToken.NO_SYNONYMS :
      CompilerOptions.SetOption(Option.Synonyms, false);
      break;

    case OptionToken.OCTAL_LITERALS :
      CompilerOptions.SetOption(Option.OctalLiterals, true);
      break;

    case OptionToken.NO_OCTAL_LITERALS :
      CompilerOptions.SetOption(Option.OctalLiterals, false);
      break;

    case OptionToken.EXPLICIT_CAST :
      CompilerOptions.SetOption(Option.ExplicitCast, true);
      break;

    case OptionToken.NO_EXPLICIT_CAST :
      CompilerOptions.SetOption(Option.ExplicitCast, false);
      break;

    case OptionToken.COROUTINES :
      CompilerOptions.SetOption(Option.Coroutines, true);
      break;

    case OptionToken.NO_COROUTINES :
      CompilerOptions.SetOption(Option.Coroutines, false);
      break;

    case OptionToken.VARIANT_RECORDS :
      CompilerOptions.SetOption(Option.VariantRecords, true);
      break;

    case OptionToken.NO_VARIANT_RECORDS :
      CompilerOptions.SetOption(Option.VariantRecords, false);
      break;

    case OptionToken.LOCAL_MODULES :
      CompilerOptions.SetOption(Option.LocalModules, true);
      break;

    case OptionToken.NO_LOCAL_MODULES :
      CompilerOptions.SetOption(Option.LocalModules, false);
      break;

    case OptionToken.LOWLINE_IDENTIFIERS :
      CompilerOptions.SetOption(Option.LowlineIdentifiers, true);
      break;

    case OptionToken.NO_LOWLINE_IDENTIFIERS :
      CompilerOptions.SetOption(Option.LowlineIdentifiers, false);
      break;

    case OptionToken.TO_DO_STATEMENT :
      CompilerOptions.SetOption(Option.ToDoStatement, true);
      break;

    case OptionToken.NO_TO_DO_STATEMENT :
      CompilerOptions.SetOption(Option.ToDoStatement, false);
      break;

  } /* end switch */

  return NextToken();
} /* end ParseCapability */


/* ---------------------------------------------------------------------------
 * method ParseSourceFile(sym)
 * ---------------------------------------------------------------------------
 * sourceFile :
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseSourceFile (OptionToken sym) {

  return NextToken();
} /* end  */


/* ---------------------------------------------------------------------------
 * method IsInfoRequest(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(infoRequest)
 * ------------------------------------------------------------------------ */

private bool IsInfoRequest (OptionToken sym) {
  return (sym >= OptionToken.HELP) && (sym <= OptionToken.LICENSE) ;
} /* end IsInfoRequest */


/* ---------------------------------------------------------------------------
 * method IsCompilationRequest(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(compilationRequest)
 * ------------------------------------------------------------------------ */

private bool IsCompilationRequest (OptionToken sym) {
  return (sym >= OptionToken.PIM3) && (sym <= OptionToken.SOURCE_FILE) ;
} /* end IsCompilationRequest */


/* ---------------------------------------------------------------------------
 * method IsDialectOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(dialect)
 * ------------------------------------------------------------------------ */

private bool IsDialectOption (OptionToken sym) {
  return (sym >= OptionToken.PIM3) && (sym <= OptionToken.EXT) ;
} /* end IsDialectOption */


/* ---------------------------------------------------------------------------
 * method IsDiagnosticsOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(diagnostics)
 * ------------------------------------------------------------------------ */

private bool IsDiagnosticsOption (OptionToken sym) {
  return
    (sym >= OptionToken.VERBOSE) && (sym <= OptionToken.ERRANT_SEMICOLONS) ;
} /* end IsDiagnosticsOption */


/* ---------------------------------------------------------------------------
 * method IsProductOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(products)
 * ------------------------------------------------------------------------ */

private bool IsProductOption (OptionToken sym) {
  return IsSingleProductOption(sym) || IsMultipleProductsOption(sym);
} /* end IsProductOption */


/* ---------------------------------------------------------------------------
 * method IsSingleProductOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(singleProduct)
 * ------------------------------------------------------------------------ */

private bool IsSingleProductOption (OptionToken sym) {
  return (sym >= OptionToken.SYNTAX_ONLY) && (sym <= OptionToken.OBJ_ONLY) ;
} /* end IsSingleProductOption */


/* ---------------------------------------------------------------------------
 * method IsMultipleProductsOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(multipleProducts)
 * ------------------------------------------------------------------------ */

private bool IsMultipleProductsOption (OptionToken sym) {
  return (sym >= OptionToken.AST) && (sym <= OptionToken.NO_OBJ) ;
} /* end IsMultipleProductsOption */


/* ---------------------------------------------------------------------------
 * method IsCommentOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(capability)
 * ------------------------------------------------------------------------ */

private bool IsCommentOption (OptionToken sym) {
  return
    (sym >= OptionToken.PRESERVE_COMMENTS) &&
    (sym <= OptionToken.STRIP_COMMENTS) ;
} /* end IsCommentOption */


/* ---------------------------------------------------------------------------
 * method IsCapabilityOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(capabilities)
 * ------------------------------------------------------------------------ */

private bool IsCapabilityOption (OptionToken sym) {
  return IsSingleProductOption(sym) || IsMultipleProductsOption(sym);
} /* end IsCapabilityOption */


/* ---------------------------------------------------------------------------
 * method IsCapabilityGroupOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(capabilityGroup)
 * ------------------------------------------------------------------------ */

private bool IsCapabilityGroupOption (OptionToken sym) {
  return (sym >= OptionToken.SAFER) && (sym <= OptionToken.COMPLIANT) ;
} /* end IsCapabilityGroupOption */


/* ---------------------------------------------------------------------------
 * method IsSingleCapabilityOption(sym)
 * ---------------------------------------------------------------------------
 * Returns true if sym is an element of FIRST(capability)
 * ------------------------------------------------------------------------ */

private bool IsSingleCapabilityOption (OptionToken sym) {
  return
    (sym >= OptionToken.SYNONYMS) && (sym <= OptionToken.NO_TO_DO_STATEMENT) ;
} /* end IsSingleCapabilityOption */


/* T E R M I N A L S */

private OptionToken NextToken() {
  string nextArg;
  uint length;
  
  nextArg = NextArg();

  if (nextArg == null) {
    return OptionToken.END_OF_INPUT;
  } /* end if */

  if (nextArg[0] != '-') {
    return OptionToken.SOURCE_FILE;
  } /* end if */

  length = (uint)nextArg.Length;
  
  switch (length) {
    case 2 :
      switch (nextArg[1]) {

        case 'h' :
          return OptionToken.HELP;

        case 'v' :
          return OptionToken.VERBOSE;

        case 'V' :
          return OptionToken.VERSION;

      } /* end switch */
      break;

    case 5 :
      switch (nextArg[2]) {

        case 'a' :
          if (string.CompareOrdinal(nextArg, "--ast") == 0) {
            return OptionToken.AST;
          } /* end if */
          break;

        case 'e' :
          if (string.CompareOrdinal(nextArg, "--ext") == 0) {
            return OptionToken.EXT;
          } /* end if */
          break;

        case 'o' :
          if (string.CompareOrdinal(nextArg, "--obj") == 0) {
            return OptionToken.OBJ;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 6 :
      switch (nextArg[5]) {

        case '3' :
          if (string.CompareOrdinal(nextArg, "--pim3") == 0) {
            return OptionToken.PIM3;
          } /* end if */
          break;

        case '4' :
          if (string.CompareOrdinal(nextArg, "--pim4") == 0) {
            return OptionToken.PIM4;
          } /* end if */
          break;

        case 'p' :
          if (string.CompareOrdinal(nextArg, "--help") == 0) {
            return OptionToken.HELP;
          } /* end if */
          break;

        case 't' :
          if (string.CompareOrdinal(nextArg, "--xlat") == 0) {
            return OptionToken.PIM4;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 7 :
      switch (nextArg[2]) {

        case 'g' :
          if (string.CompareOrdinal(nextArg, "--graph") == 0) {
            return OptionToken.GRAPH;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(nextArg, "--safer") == 0) {
            return OptionToken.SAFER;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 8 :
      switch (nextArg[5]) {

        case 'a' :
          if (string.CompareOrdinal(nextArg, "--no-ast") == 0) {
            return OptionToken.NO_AST;
          } /* end if */
          break;

        case 'o' :
          if (string.CompareOrdinal(nextArg, "--no-obj") == 0) {
            return OptionToken.NO_OBJ;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 9 :
      switch (nextArg[5]) {

        case 'b' :
          if (string.CompareOrdinal(nextArg, "--verbose") == 0) {
            return OptionToken.VERBOSE;
          } /* end if */
          break;

        case 'e' :
          if (string.CompareOrdinal(nextArg, "--license") == 0) {
            return OptionToken.LICENSE;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(nextArg, "--version") == 0) {
            return OptionToken.VERSION;
          } /* end if */
          break;

        case 'x' :
          if (string.CompareOrdinal(nextArg, "--no-xlat") == 0) {
            return OptionToken.NO_XLAT;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 10 :
      switch (nextArg[2]) {

        case 'a' :
          if (string.CompareOrdinal(nextArg, "--ast-only") == 0) {
            return OptionToken.AST_ONLY;
          } /* end if */
          break;

        case 'n' :
          if (string.CompareOrdinal(nextArg, "--no-graph") == 0) {
            return OptionToken.NO_GRAPH;
          } /* end if */
          break;

        case 'o' :
          if (string.CompareOrdinal(nextArg, "--obj-only") == 0) {
            return OptionToken.OBJ_ONLY;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(nextArg, "--synonyms") == 0) {
            return OptionToken.SYNONYMS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 11 :
      switch (nextArg[2]) {

        case 'c' :
          if (string.CompareOrdinal(nextArg, "--compliant") == 0) {
            return OptionToken.COMPLIANT;
          } /* end if */
          break;

        case 'x' :
          if (string.CompareOrdinal(nextArg, "--xlat-only") == 0) {
            return OptionToken.XLAT_ONLY;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 12 :
      switch (nextArg[2]) {

        case 'c' :
          if (string.CompareOrdinal(nextArg, "--coroutines") == 0) {
            return OptionToken.COROUTINES;
          } /* end if */
          break;

        case 'g' :
          if (string.CompareOrdinal(nextArg, "--graph-only") == 0) {
            return OptionToken.GRAPH_ONLY;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 13 :
      switch (nextArg[2]) {

        case 'n' :
          if (string.CompareOrdinal(nextArg, "--no-synonyms") == 0) {
            return OptionToken.NO_SYNONYMS;
          } /* end if */
          break;

        case 'l' :
          if (string.CompareOrdinal(nextArg, "--lexer-debug") == 0) {
            return OptionToken.LEXER_DEBUG;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(nextArg, "--syntax-only") == 0) {
            return OptionToken.SYNTAX_ONLY;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 14 :
      if (string.CompareOrdinal(nextArg, "--parser-debug") == 0) {
        return OptionToken.PARSER_DEBUG;
      } /* end if */
      break;

    case 15 :
      switch (nextArg[2]) {

        case 'e' :
          if (string.CompareOrdinal(nextArg, "--explicit-cast") == 0) {
            return OptionToken.EXPLICIT_CAST;
          } /* end if */
          break;

        case 'n' :
          if (string.CompareOrdinal(nextArg, "--no-coroutines") == 0) {
            return OptionToken.NO_COROUTINES;
          } /* end if */
          break;

        case 'l' :
          if (string.CompareOrdinal(nextArg, "--local-modules") == 0) {
            return OptionToken.LOCAL_MODULES;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 16 :
      switch (nextArg[2]) {

        case 'o' :
          if (string.CompareOrdinal(nextArg, "--octal-literals") == 0) {
            return OptionToken.OCTAL_LITERALS;
          } /* end if */
          break;

        case 's' :
          if (string.CompareOrdinal(nextArg, "--strip-comments") == 0) {
            return OptionToken.STRIP_COMMENTS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 17 :
      switch (nextArg[2]) {

        case 't' :
          if (string.CompareOrdinal(nextArg, "--to-do-statement") == 0) {
            return OptionToken.TO_DO_STATEMENT;
          } /* end if */
          break;

        case 'v' :
          if (string.CompareOrdinal(nextArg, "--variant-records") == 0) {
            return OptionToken.VARIANT_RECORDS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 18 :
      switch (nextArg[5]) {

        case 'e' :
          if (string.CompareOrdinal(nextArg, "--no-explicit-cast") == 0) {
            return OptionToken.NO_EXPLICIT_CAST;
          } /* end if */
          break;

        case 'l' :
          if (string.CompareOrdinal(nextArg, "--no-local-modules") == 0) {
            return OptionToken.NO_LOCAL_MODULES;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 19 :
      switch (nextArg[2]) {

        case 'e' :
          if (string.CompareOrdinal(nextArg, "--errant-semicolons") == 0) {
            return OptionToken.ERRANT_SEMICOLONS;
          } /* end if */
          break;

        case 'n' :
          if (string.CompareOrdinal(nextArg, "--no-octal-literals") == 0) {
            return OptionToken.NO_OCTAL_LITERALS;
          } /* end if */
          break;

        case 'p' :
          if (string.CompareOrdinal(nextArg, "--preserve-comments") == 0) {
            return OptionToken.PRESERVE_COMMENTS;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 20 :
      switch (nextArg[5]) {

        case 't' :
          if (string.CompareOrdinal(nextArg, "--no-to-do-statement") == 0) {
            return OptionToken.NO_EXPLICIT_CAST;
          } /* end if */
          break;

        case 'v' :
          if (string.CompareOrdinal(nextArg, "--no-variant-records") == 0) {
            return OptionToken.NO_LOCAL_MODULES;
          } /* end if */
          break;

      } /* end switch */
      break;

    case 21 :
      if (string.CompareOrdinal(nextArg, "--lowline-identifiers") == 0) {
        return OptionToken.LOWLINE_IDENTIFIERS;
      } /* end if */
      break;

    case 24 :
      if (string.CompareOrdinal(nextArg, "--no-lowline-identifiers") == 0) {
        return OptionToken.NO_LOWLINE_IDENTIFIERS;
      } /* end if */
      break;

  } /* end switch */

  return OptionToken.UNKNOWN;
} /* end NextToken */


/* ---------------------------------------------------------------------------
 * method NextArg()
 * ---------------------------------------------------------------------------
 * Consumes and returns the next command line argument.  Returns null if all
 * arguments have previously been consumed.
 * ------------------------------------------------------------------------ */

private string NextArg() {

  if (index >= argCount) {
    return null;
  } /* end if */

  index++;
  return argument[index-1];

} /* end NextArg */


} /* OptionParser */

} /* namespace */

/* END OF FILE */