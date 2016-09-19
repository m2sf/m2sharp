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

public void ParseOptions () {
  OptionToken sym;
  
  sym = NextArg();

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

  return NextArg();
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

  return NextArg();
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

  return NextArg();
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

  return NextArg();
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

    sym = NextArg();
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

  return NextArg();
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

  return NextArg();
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

  return NextArg();
} /* end ParseCapability */


/* ---------------------------------------------------------------------------
 * method ParseSourceFile(sym)
 * ---------------------------------------------------------------------------
 * sourceFile :
 *   ;
 * ------------------------------------------------------------------------ */

private OptionToken ParseSourceFile (OptionToken sym) {

  return NextArg();
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

private OptionToken NextArg() {

  // TO DO : read argument and tokenise

  return OptionToken.UNKNOWN;
} /* end NextArg */


} /* OptionParser */

} /* namespace */

/* END OF FILE */