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
 * ArgumentParser.cs
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

using System;

namespace org.m2sf.m2sharp {

public class ArgumentParser : IArgumentParser {

  private static ArgumentStatus status;
  private static string sourceFile;
  private static uint errorCount;
  private static uint optionSet;

  private ArgumentParser () {
    // no operation
  } /* end ArgumentParser */


/* ---------------------------------------------------------------------------
 * method ParseOptions()
 * ---------------------------------------------------------------------------
 * options :
 *   infoRequest | compilationRequest
 *   ;
 * ------------------------------------------------------------------------ */

public static ArgumentStatus ParseOptions (string[] args) {
  ArgumentToken sym;

  ArgumentLexer.InitWithArgs(args);
  sourceFile = null;
  errorCount = 0;
  optionSet = 0;
  
  sym = ArgumentLexer.NextToken();

  if (ArgumentLexer.IsInfoRequest(sym)) {
    sym = ParseInfoRequest(sym);
  }
  else if (ArgumentLexer.IsCompilationRequest(sym)) {
    sym = ParseCompilationRequest(sym);
  }
  else if (sym == ArgumentToken.END_OF_INPUT) {
    ReportMissingSourceFile();
  } /* end if */

  while (sym != ArgumentToken.END_OF_INPUT) {
    ReportExcessArgument(ArgumentLexer.LastArg());
    sym = ArgumentLexer.NextToken();
  } /* end while */

  if (errorCount > 0) {
    status = ArgumentStatus.ErrorsEncountered;
  } /* end if */

  return status;
} /* end ParseOptions */


/* ---------------------------------------------------------------------------
 * method SourceFile()
 * ---------------------------------------------------------------------------
 * Returns sourcefile
 * ------------------------------------------------------------------------ */

public static string SourceFile () {
  return sourceFile;
} /* end SourceFile */


/* ---------------------------------------------------------------------------
 * method ErrorCount()
 * ---------------------------------------------------------------------------
 * Returns error count
 * ------------------------------------------------------------------------ */

public static uint ErrorCount () {
  return errorCount;
} /* end ErrorCount */


/* ---------------------------------------------------------------------------
 * private method ParseInfoRequest(sym)
 * ---------------------------------------------------------------------------
 * infoRequest :
 *   HELP | VERSION | LICENSE
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseInfoRequest (ArgumentToken sym) {

  switch (sym) {

    case ArgumentToken.HELP :
      status = ArgumentStatus.HelpRequested;
      break;

    case ArgumentToken.VERSION :
      status = ArgumentStatus.VersionRequested;
      break;

    case ArgumentToken.LICENSE :
      status = ArgumentStatus.LicenseRequested;
      break;

  } /* end switch */

  return ArgumentLexer.NextToken();
} /* end ParseInfoRequest */


/* ---------------------------------------------------------------------------
 * private method ParseCompilationRequest(sym)
 * ---------------------------------------------------------------------------
 * compilationRequest :
 *   dialect? products? capabilities? sourceFile diagnostics?
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseCompilationRequest (ArgumentToken sym) {

  if (ArgumentLexer.IsDialectOption(sym)) {
    sym = ParseDialect(sym);
  } /* end */

  if (ArgumentLexer.IsProductOption(sym)) {
    sym = ParseProducts(sym);
  } /* end */

  if (ArgumentLexer.IsCapabilityOption(sym)) {
    sym = ParseCapabilities(sym);
  } /* end */
  
  if (sym == ArgumentToken.SOURCE_FILE) {
    sym = ParseSourceFile(sym);
  }
  else {
    ReportMissingSourceFile();
  } /* end if */

  if (ArgumentLexer.IsDiagnosticsOption(sym)) {
    sym = ParseDiagnostics(sym);
  } /* end */

  return sym;
} /* end ParseCompilationRequest */


/* ---------------------------------------------------------------------------
 * private method ParseDialect(sym)
 * ---------------------------------------------------------------------------
 * dialect :
 *   ( PIM3 | PIM4 ) ( SAFER | COMPLIANT )? | EXT
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseDialect (ArgumentToken sym) {

  if (sym == ArgumentToken.EXT) {
    CompilerOptions.SetDialect(Dialect.Extended);
  }
  else {

    switch (sym) {

      case ArgumentToken.PIM3 :
        CompilerOptions.SetDialect(Dialect.PIM3);
        break;

      case ArgumentToken.PIM4 :
        CompilerOptions.SetDialect(Dialect.PIM4);
        break;

    } /* end switch */

    sym = ArgumentLexer.NextToken();

    switch (sym) {

      case ArgumentToken.SAFER :
        CompilerOptions.SetOption(Option.Synonyms, false);
        CompilerOptions.SetOption(Option.OctalLiterals, false);
        CompilerOptions.SetOption(Option.ExplicitCast, false);
        CompilerOptions.SetOption(Option.Coroutines, false);
        CompilerOptions.SetOption(Option.VariantRecords, false);
        CompilerOptions.SetOption(Option.LocalModules, false);
        break;

      case ArgumentToken.COMPLIANT :
        CompilerOptions.SetOption(Option.Synonyms, true);
        CompilerOptions.SetOption(Option.OctalLiterals, true);
        CompilerOptions.SetOption(Option.ExplicitCast, true);
        CompilerOptions.SetOption(Option.Coroutines, true);
        CompilerOptions.SetOption(Option.VariantRecords, true);
        CompilerOptions.SetOption(Option.LocalModules, true);
        break;

    } /* end switch */

  } /* end if */

  return ArgumentLexer.NextToken();
} /* end ParseDialect */


/* ---------------------------------------------------------------------------
 * private method ParseProducts(sym)
 * ---------------------------------------------------------------------------
 * products :
 *   ( singleProduct | multipleProducts ) identifierOption? commentOption?
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseProducts (ArgumentToken sym) {

  if (ArgumentLexer.IsSingleProductOption(sym)) {
    sym = ParseSingleProduct(sym);
  }
  else if (ArgumentLexer.IsMultipleProductsOption(sym)) {
    sym = ParseMultipleProducts(sym);
  } /* end if */

  if (ArgumentLexer.IsIdentifierOption(sym)) {
    if (CompilerOptions.XlatRequired() || CompilerOptions.ObjRequired()) {
      sym = ParseIdentifierOption(sym);
    }
    else {
      ReportMissingDependencyFor(ArgumentLexer.LastArg(), "--xlat or --obj");
      sym = ArgumentLexer.NextToken();
    } /* end if */
  } /* end if */
  
  if (ArgumentLexer.IsCommentOption(sym)) {
    if (CompilerOptions.XlatRequired() || CompilerOptions.ObjRequired()) {
      sym = ParseCommentOption(sym);
    }
    else {
      ReportMissingDependencyFor(ArgumentLexer.LastArg(), "--xlat");
      sym = ArgumentLexer.NextToken();
    } /* end if */
  } /* end if */

  return sym;
} /* end ParseProducts */


/* ---------------------------------------------------------------------------
 * private method ParseSingleProduct(sym)
 * ---------------------------------------------------------------------------
 * singleProduct :
 *   SYNTAX_ONLY | AST_ONLY | GRAPH_ONLY | XLAT_ONLY | OBJ_ONLY
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseSingleProduct (ArgumentToken sym) {

  switch (sym) {

    case ArgumentToken.SYNTAX_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, false);
      CompilerOptions.SetOption(Option.GraphRequired, false);
      CompilerOptions.SetOption(Option.XlatRequired, false);
      CompilerOptions.SetOption(Option.ObjRequired, false);
      break;

    case ArgumentToken.AST_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, true);
      CompilerOptions.SetOption(Option.GraphRequired, false);
      CompilerOptions.SetOption(Option.XlatRequired, false);
      CompilerOptions.SetOption(Option.ObjRequired, false);
      break;

    case ArgumentToken.GRAPH_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, false);
      CompilerOptions.SetOption(Option.GraphRequired, true);
      CompilerOptions.SetOption(Option.XlatRequired, false);
      CompilerOptions.SetOption(Option.ObjRequired, false);
      break;

    case ArgumentToken.XLAT_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, false);
      CompilerOptions.SetOption(Option.GraphRequired, false);
      CompilerOptions.SetOption(Option.XlatRequired, true);
      CompilerOptions.SetOption(Option.ObjRequired, false);
      break;

    case ArgumentToken.OBJ_ONLY :
      CompilerOptions.SetOption(Option.AstRequired, false);
      CompilerOptions.SetOption(Option.GraphRequired, false);
      CompilerOptions.SetOption(Option.XlatRequired, false);
      CompilerOptions.SetOption(Option.ObjRequired, true);
      break;

  } /* end switch */

  return ArgumentLexer.NextToken();
} /* end ParseSingleProduct */


/* ---------------------------------------------------------------------------
 * private method ParseMultipleProducts(sym)
 * ---------------------------------------------------------------------------
 * multipleProducts :
 *   ( ast | graph | xlat | obj )+
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseMultipleProducts (ArgumentToken sym) {

  while (ArgumentLexer.IsMultipleProductsOption(sym)) {

    switch (sym) {

      case ArgumentToken.AST :
        SetOption(Option.AstRequired, true);
        break;

      case ArgumentToken.NO_AST :
        SetOption(Option.AstRequired, false);
        break;

      case ArgumentToken.GRAPH :
        SetOption(Option.GraphRequired, true);
        break;

      case ArgumentToken.NO_GRAPH :
        SetOption(Option.GraphRequired, true);
        break;

      case ArgumentToken.XLAT :
        SetOption(Option.XlatRequired, true);
        break;

      case ArgumentToken.NO_XLAT :
        SetOption(Option.XlatRequired, false);
        break;

      case ArgumentToken.OBJ :
        SetOption(Option.ObjRequired, true);
        break;

      case ArgumentToken.NO_OBJ :
        SetOption(Option.ObjRequired, true);
        break;

    } /* end switch */

    sym = ArgumentLexer.NextToken();
  } /* end while */

  return sym;
} /* end ParseMultipleProducts */


/* ---------------------------------------------------------------------------
 * private method ParseIdentifierOption(sym)
 * ---------------------------------------------------------------------------
 * identifierOption :
 *   USE_IDENTIFIERS_VERBATIM | TRANSLITERATE_IDENTIFIERS
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseIdentifierOption (ArgumentToken sym) {

  switch (sym) {

    case ArgumentToken.USE_IDENTIFIERS_VERBATIM :
      CompilerOptions.SetOption(Option.UseIdentifiersVerbatim, true);
      break;

    case ArgumentToken.TRANSLITERATE_IDENTIFIERS :
      CompilerOptions.SetOption(Option.UseIdentifiersVerbatim, false);
      break;

  } /* end switch */

  return ArgumentLexer.NextToken();
} /* end ParseIdentifierOption */


/* ---------------------------------------------------------------------------
 * private method ParseCommentOption(sym)
 * ---------------------------------------------------------------------------
 * commentOption :
 *   PRESERVE_COMMENTS | STRIP_COMMENTS
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseCommentOption (ArgumentToken sym) {

  switch (sym) {

    case ArgumentToken.PRESERVE_COMMENTS :
      CompilerOptions.SetOption(Option.PreserveComments, true);
     break;

    case ArgumentToken.STRIP_COMMENTS :
      CompilerOptions.SetOption(Option.PreserveComments, false);
      break;

  } /* end switch */

  return ArgumentLexer.NextToken();
} /* end ParseCommentOption */


/* ---------------------------------------------------------------------------
 * private method ParseCapabilities(sym)
 * ---------------------------------------------------------------------------
 * capabilities :
 *   ( synonyms | octalLiterals | explicitCast |
 *     coroutines | variantRecords | localModules |
 *     lowlineIdentifiers | toDoStatement )+
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseCapabilities (ArgumentToken sym) {
  
  while (ArgumentLexer.IsCapabilityOption(sym)) {

    switch (sym) {

      case ArgumentToken.SYNONYMS :
        SetOption(Option.Synonyms, true);
        break;

      case ArgumentToken.NO_SYNONYMS :
        SetOption(Option.Synonyms, false);
        break;

      case ArgumentToken.OCTAL_LITERALS :
        SetOption(Option.OctalLiterals, true);
        break;

      case ArgumentToken.NO_OCTAL_LITERALS :
        SetOption(Option.OctalLiterals, false);
        break;

      case ArgumentToken.EXPLICIT_CAST :
        SetOption(Option.ExplicitCast, true);
        break;

      case ArgumentToken.NO_EXPLICIT_CAST :
        SetOption(Option.ExplicitCast, false);
        break;

      case ArgumentToken.COROUTINES :
        SetOption(Option.Coroutines, true);
        break;

      case ArgumentToken.NO_COROUTINES :
        SetOption(Option.Coroutines, false);
        break;

      case ArgumentToken.VARIANT_RECORDS :
        SetOption(Option.VariantRecords, true);
        break;

      case ArgumentToken.NO_VARIANT_RECORDS :
        SetOption(Option.VariantRecords, false);
        break;

      case ArgumentToken.LOCAL_MODULES :
        SetOption(Option.LocalModules, true);
        break;

      case ArgumentToken.NO_LOCAL_MODULES :
        SetOption(Option.LocalModules, false);
        break;

      case ArgumentToken.LOWLINE_IDENTIFIERS :
        SetOption(Option.LowlineIdentifiers, true);
        break;

      case ArgumentToken.NO_LOWLINE_IDENTIFIERS :
        SetOption(Option.LowlineIdentifiers, false);
        break;

      case ArgumentToken.TO_DO_STATEMENT :
        SetOption(Option.ToDoStatement, true);
        break;

      case ArgumentToken.NO_TO_DO_STATEMENT :
        SetOption(Option.ToDoStatement, false);
        break;

    } /* end switch */

    sym = ArgumentLexer.NextToken();
  } /* end while */

  return sym;
} /* end ParseCapabilities */


/* ---------------------------------------------------------------------------
 * private method ParseSourceFile(sym)
 * ---------------------------------------------------------------------------
 * sourceFile :
 *   <platform dependendent path/filename>
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseSourceFile (ArgumentToken sym) {
  sourceFile = ArgumentLexer.LastArg();
  return ArgumentLexer.NextToken();
} /* end  */


/* ---------------------------------------------------------------------------
 * private method ParseDiagnostics(sym)
 * ---------------------------------------------------------------------------
 * diagnostics :
 *   ( VERBOSE | LEXER_DEBUG | PARSER_DEBUG | PRINT_SETTINGS
 *     ERRANT_SEMICOLONS )+
 *   ;
 * ------------------------------------------------------------------------ */

private static ArgumentToken ParseDiagnostics (ArgumentToken sym) {

  while (ArgumentLexer.IsDiagnosticsOption(sym)) {

    switch (sym) {

      case ArgumentToken.VERBOSE :
        CompilerOptions.SetOption(Option.Verbose, true);
        break;

      case ArgumentToken.LEXER_DEBUG :
        CompilerOptions.SetOption(Option.LexerDebug, true);
        break;

      case ArgumentToken.PARSER_DEBUG :
        CompilerOptions.SetOption(Option.ParserDebug, true);
        break;

      case ArgumentToken.SHOW_SETTINGS :
        CompilerOptions.SetOption(Option.ShowSettings, true);
        break;

      case ArgumentToken.ERRANT_SEMICOLONS :
        CompilerOptions.SetOption(Option.ErrantSemicolons, true);
        break;

    } /* end switch */

    sym = ArgumentLexer.NextToken();
  } /* end while*/

  return sym;
} /* end ParseDiagnostics */


/* ---------------------------------------------------------------------------
 * private method SetOption(option)
 * ---------------------------------------------------------------------------
 * Sets option unless duplicate.
 * ------------------------------------------------------------------------ */

private static void SetOption (Option option, bool value) {

  if (CompilerOptions.IsMutableOption(option) == false) {
    ReportInvalidOption(ArgumentLexer.LastArg());
  }
  else if (IsInOptionSet(option)) {
    ReportDuplicateOption(ArgumentLexer.LastArg());
  }
  else {
    CompilerOptions.SetOption(option, value);
    StoreInOptionSet(option);
  } /* end if */

} /* end SetOption */


/* ---------------------------------------------------------------------------
 * private method StoreInOptionSet(option)
 * ---------------------------------------------------------------------------
 * Stores option in optionSet.
 * ------------------------------------------------------------------------ */

private static void StoreInOptionSet (Option option) {
  optionSet = (optionSet | (uint)(1 << (int)option));
} /* end StoreInOptionSet */


/* ---------------------------------------------------------------------------
 * private method IsInOptionSet(option)
 * ---------------------------------------------------------------------------
 * Returns true if option is present in optionSet.
 * ------------------------------------------------------------------------ */

private static bool IsInOptionSet (Option option) {
  return (optionSet & (uint)(1 << (int)option)) != 0;
} /* end IsInOptionSet */


/* ---------------------------------------------------------------------------
 * private method ReportInvalidOption(arg)
 * ---------------------------------------------------------------------------
 * Reports arg as an invalid option to the console.
 * ------------------------------------------------------------------------ */

private static void ReportInvalidOption (string arg) {
  Console.WriteLine("invalid option {0}", arg);
  errorCount++;
} /* end InvalidOption */


/* ---------------------------------------------------------------------------
 * private method ReportDuplicateOption(arg)
 * ---------------------------------------------------------------------------
 * Reports arg as a duplicate option to the console.
 * ------------------------------------------------------------------------ */

private static void ReportDuplicateOption (string arg) {
  Console.WriteLine("duplicate option {0}", arg);
  errorCount++;
} /* end ReportDuplicateOption */


/* ---------------------------------------------------------------------------
 * private method ReportExcessArgument(arg)
 * ---------------------------------------------------------------------------
 * Reports arg as an excess argument to the console.
 * ------------------------------------------------------------------------ */

private static void ReportExcessArgument (string arg) {
  Console.WriteLine("excess argument {0}", arg);
  errorCount++;
} /* end ReportExcessArgument */


/* ---------------------------------------------------------------------------
 * private method ReportMissingSourceFile()
 * ---------------------------------------------------------------------------
 * Reports missing sourcefile argument.
 * ------------------------------------------------------------------------ */

private static void ReportMissingSourceFile () {
  Console.WriteLine("missing sourcefile argument");
  errorCount++;
} /* end ReportMissingSourceFile */


/* ---------------------------------------------------------------------------
 * private method MissingDependencyFor(arg1, arg2)
 * ---------------------------------------------------------------------------
 * Reports arg1 to have a missing dependency on arg2 to the console.
 * ------------------------------------------------------------------------ */

private static void ReportMissingDependencyFor(string arg1, string arg2) {
  Console.WriteLine("option {0} only available with {1}", arg1, arg2);
  errorCount++;
} /* end ReportMissingDependencyFor */


} /* OptionParser */

} /* namespace */

/* END OF FILE */