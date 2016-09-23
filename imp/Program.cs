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
 * Program.cs
 *
 * Main program
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

class MainClass {

/* ---------------------------------------------------------------------------
 * method PrintBanner()
 * ---------------------------------------------------------------------------
 * Prints a banner to the console with name, version, copyright and license.
 * ------------------------------------------------------------------------ */

public static void PrintBanner () {
      
  Console.WriteLine("{0} version {1}.{2} ({3}), {4}",
    ProductInfo.Name(),
    ProductInfo.VersionMajor(), ProductInfo.VersionMinor(),
    ProductInfo.Build(), ProductInfo.Description());

  PrintCopyright();
  PrintLicense();

} /* end PrintBanner */


/* ---------------------------------------------------------------------------
 * constant HelpText
 * ------------------------------------------------------------------------ */

const string HelpText =
  "usage:\n" +
  " m2sharp info | compilation\n\n" +

  "info:\n" +
  " --help, -h      print help\n" +
  " --version, -V   print version info\n" +
  " --license       print license info\n\n" +

  "compilation:\n" +
  " [dialect] [products] [capabilities] sourcefile [diagnostics]\n\n" +

  "dialect:\n" +
  " --pim3 [qualifier]   follow PIM, third edition\n" +
  " --pim4 [qualifier]   follow PIM, fourth edition\n" +
  " --ext (D)            use extended dialect mode\n\n" +

  " dialect qualifiers:\n" +
  " --safer (D)   restricted mode\n" +
  " --compliant   strict compliance mode\n\n" +

  "products:\n" +
  " --ast, --no-ast         .ast file output\n" +
  " --graph, --no-graph     .dot file output\n" +
  " --xlat (D), --no-xlat   .cs file output\n" +
  " --obj (D), --no-obj     .obj and .sym file output\n\n" +

  " --syntax-only   syntax check only\n" +
  " --ast-only      .ast file only output\n" +
  " --graph-only    .dot file only output\n" +
  " --xlat-only     .cs file only output\n" +
  " --obj-only      .obj and .sym file only output\n\n" +

  " in combination with --xlat or --obj:\n" +
  " --use-identifiers-verbatim (D)   use original identifiers\n" +
  " --transliterate-identifiers      transliterate identifiers\n\n" +

  " in combination with --xlat:\n" +
  " --preserve-comments (D)   preserve comments in .cs files\n" +
  " --strip-comments          strip comments from .cs files\n\n" +

  "capabilities:\n\n" +

  " in combination with --pim3 or --pim4:\n" +
  " --synonyms, --no-synonyms (D)\n" +
  " --octal-literals, --no-octal-literals (D)\n" +
  " --explicit-cast, --no-explicit-cast (D)\n" +
  " --coroutines, --no-coroutines (D)\n" +
  " --variant-records, --no-variant-records (D)\n" +
  " --local-modules, --no-local-modules (D)\n\n" +

  " in combination with --ext:\n" +
  " --lowline-identifiers, --no-lowline-identifiers (D)\n" +
  " --to-do-statement (D), --no-to-do-statement\n\n" +

  "sourcefile:\n" +
  " may have directory path prepended\n" +
  " must match module identifier\n" +
  " must have suffix .def or .mod\n\n" +

  "diagnostics:\n" +
  " --verbose, -v         verbose mode\n" +
  " --lexer-debug         lexer debug mode\n" +
  " --parser-debug        parser debug mode\n" +
  " --show-settings       print compiler settings\n" +
  " --errant-semicolons   tolerate errant semicolons\n\n" +

  "Default settings are marked with (D)";


/* ---------------------------------------------------------------------------
 * method PrintHelp()
 * ---------------------------------------------------------------------------
 * Prints usage help to the console.
 * ------------------------------------------------------------------------ */

public static void PrintHelp () {
  Console.WriteLine(HelpText);
} /* end PrintHelp */


/* ---------------------------------------------------------------------------
 * method PrintVersion()
 * ---------------------------------------------------------------------------
 * Prints version info to the console.
 * ------------------------------------------------------------------------ */

public static void PrintVersion () {
  Console.WriteLine("version {0}.{1} ({2})",
    ProductInfo.VersionMajor(),
    ProductInfo.VersionMinor(),
    ProductInfo.Build());
} /* end PrintVersion */
    

/* ---------------------------------------------------------------------------
 * method PrintCopyright()
 * ---------------------------------------------------------------------------
 * Prints copyright info to the console.
 * ------------------------------------------------------------------------ */

public static void PrintCopyright () {
  Console.WriteLine("copyright {0}", ProductInfo.Copyright());
} /* end PrintCopyright */

    
/* ---------------------------------------------------------------------------
 * method PrintLicense()
 * ---------------------------------------------------------------------------
 * Prints license info to the console.
 * ------------------------------------------------------------------------ */

public static void PrintLicense () {
  Console.WriteLine("licensed under the {0}", ProductInfo.License());
} /* end PrintLicense */


/* ---------------------------------------------------------------------------
 * method PrintOSInfo()
 * ---------------------------------------------------------------------------
 * Prints OS name and version info to the console.
 * ------------------------------------------------------------------------ */

public static void PrintOSInfo () {

  if (PlatformInfo.IsSupported()) {
    Console.WriteLine("running on {0}, {1} version {2}.{3} ({4})",
      PlatformInfo.Name(),
      PlatformInfo.Uname(),
      PlatformInfo.VersionMajor(),
      PlatformInfo.VersionMinor(), PlatformInfo.Build());
  }
  else /* unsupported platform */ {
    Console.WriteLine("platform not supported");
  } /* end if */

} /* end PrintOSInfo */


/* ---------------------------------------------------------------------------
 * method Main(args)
 * ---------------------------------------------------------------------------
 * Starts the compiler.
 * ------------------------------------------------------------------------ */
    
public static void Main (string[] args) {
  ArgumentStatus argStatus;

  if (PlatformInfo.IsSupported() == false) {
    Console.WriteLine("platform not supported");
    Environment.Exit(1);
  } /* end if */

  argStatus = ArgumentParser.ParseOptions(args);

  switch (argStatus) {

    case ArgumentStatus.Success :
      PrintBanner();
      break;

    case ArgumentStatus.HelpRequested :
      PrintHelp();
      Environment.Exit(0);
      break;

    case ArgumentStatus.VersionRequested :
      PrintVersion();
      Environment.Exit(0);
      break;

    case ArgumentStatus.LicenseRequested :
      PrintLicense();
      Environment.Exit(0);
      break;

    case ArgumentStatus.ErrorsEncountered :
      Console.WriteLine("use m2sharp --help for usage info");
      Environment.Exit(1);
      break;

  } /* end switch */

  // TO DO : call parser on input file

  if (CompilerOptions.ShowSettings()) {
    CompilerOptions.PrintSettings();
  } /* end if */

} /* end Main */

} /* MainClass */

} /* namespace */

/* END OF FILE */