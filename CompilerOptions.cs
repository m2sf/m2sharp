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

using System;

namespace org.m2sf.m2sharp {

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
  private static bool showSettings = false;
  private static bool errantSemicolons = false;

  private static bool astRequired = true;
  private static bool graphRequired = false;
  private static bool xlatRequired = true;
  private static bool objRequired = false;

  private static bool preserveComments = true;
  private static bool useIdentifiersVerbatim = true;


/* ---------------------------------------------------------------------------
 * method SetDialect(dialect)
 * ---------------------------------------------------------------------------
 * Sets the current dialect to the given dialect and sets all capabilities to
 * the dialect's default capability settings. 
 * ------------------------------------------------------------------------ */

public static void SetDialect (Dialect dialect) {
  Capability cap;
  bool value;

  /* clear mutually exclusive capabilities */
  Capabilities.SetCapability(Capability.VariantRecords, false);
  Capabilities.SetCapability(Capability.ExtensibleRecords, false);
  Capabilities.SetCapability(Capability.IndeterminateRecords, false);

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

    case Option.ShowSettings :
      showSettings = value;
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

    case Option.UseIdentifiersVerbatim :
      useIdentifiersVerbatim = value;
      break;

    default :
      SetCapability(option, value);
      break;

  } /* end switch */

} /* end SetOption */


/* ---------------------------------------------------------------------------
 * method IsMutableOption(option)
 * ---------------------------------------------------------------------------
 * Returns true if option is mutable for the current dialect, else false.
 * ------------------------------------------------------------------------ */

public static bool IsMutableOption (Option option) {
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
      return true;

  } /* end switch */
  
  return Dialects.IsMutableCapability(dialect, capability);
} /* end SetCapability */


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
 * method ShowSettings()
 * ---------------------------------------------------------------------------
 * Returns true if option --show-settings is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool ShowSettings () {
  return showSettings;
} /* end ShowSettings */


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
 * method UseIdentifiersVerbatim()
 * ---------------------------------------------------------------------------
 * Returns true if option --use-identifiers-verbatim is turned on, else false.
 * ------------------------------------------------------------------------ */

public static bool UseIdentifiersVerbatim () {
  return useIdentifiersVerbatim;
} /* end UseIdentifiersVerbatim */


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
 * method PrintSettings()
 * ---------------------------------------------------------------------------
 * Prints the current settings to the console.
 * ------------------------------------------------------------------------ */

public static void PrintSettings () {

  Console.WriteLine("dialect: {0}\n", dialect);

  Console.WriteLine("verbose: {0}", verbose);
  Console.WriteLine("lexer debug: {0}", lexerDebug);
  Console.WriteLine("parser debug: {0}", parserDebug);
  Console.WriteLine("show settings: {0}", showSettings);
  Console.WriteLine("errant semicolons: {0}\n", errantSemicolons);

  Console.WriteLine(".ast file output: {0}", astRequired);
  Console.WriteLine(".dot file output: {0}", graphRequired);
  Console.WriteLine(".cs file output: {0}", xlatRequired);
  Console.WriteLine(".obj and .sym file output: {0}\n", objRequired);

  if (xlatRequired || objRequired) {
    Console.WriteLine("verbatim identifiers: {0}", useIdentifiersVerbatim);
  } /* end if */

  if (xlatRequired) {
    Console.WriteLine("preserve comments: {0}", preserveComments);
  } /* end if */

  if ((dialect == Dialect.PIM3) || (dialect == Dialect.PIM4)) {
    Console.WriteLine("synonyms: {0}", Capabilities.Synonyms());
    Console.WriteLine("octal literals: {0}", Capabilities.OctalLiterals());
    Console.WriteLine("explicit cast: {0}", Capabilities.ExplicitCast());
    Console.WriteLine("coroutines: {0}", Capabilities.Coroutines());
    Console.WriteLine("variant records: {0}", Capabilities.VariantRecords());
    Console.WriteLine("local modules: {0}", Capabilities.LocalModules());
  } /* end if */

  if (dialect == Dialect.Extended) {
    Console.WriteLine("lowline identifiers: {0}",
      Capabilities.LowlineIdentifiers());
    Console.WriteLine("TO DO statement: {0}", Capabilities.ToDoStatement());
  } /* end if */

} /* end PrintSettings */


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

    case Option.Coroutines :
      capability = Capability.Coroutines;
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
      // not a capability option
      return;

  } /* end switch */
  
  if (Dialects.IsMutableCapability(dialect, capability)) {
    Capabilities.SetCapability(capability, value);
  } /* end if */
  
} /* end SetCapability */

  
} /* CompilerOptions */

} /* namespace */

/* END OF FILE */