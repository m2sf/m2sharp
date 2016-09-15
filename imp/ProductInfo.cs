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
 * ProductInfo.cs
 *
 * product information
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

using System.Reflection;

namespace org.m2sf.m2sharp {

/* ---------------------------------------------------------------------------
 * singleton class ProductInfo
 * ---------------------------------------------------------------------------
 * All methods are static. All methods return singleton values.
 * ------------------------------------------------------------------------ */

public sealed class ProductInfo : IProductInfo {

  private const string DefaultLicense = "LGPL version 2.1 and 3.0";

/* ---------------------------------------------------------------------------
 * private class variable initialized
 * ---------------------------------------------------------------------------
 * Set to true if class variables have been initialised, otherwise false.
 * ------------------------------------------------------------------------ */
  
  private static bool initialized = false;
  

/* ---------------------------------------------------------------------------
 * private class variable name
 * ---------------------------------------------------------------------------
 * Holds the human readable name of the current assembly.
 * ------------------------------------------------------------------------ */

  private static string name;

  
/* ---------------------------------------------------------------------------
 * private class variable vmajor
 * ---------------------------------------------------------------------------
 * Holds the major version of the current assembly.
 * ------------------------------------------------------------------------ */

  private static int vmajor;


/* ---------------------------------------------------------------------------
 * private class variable vminor
 * ---------------------------------------------------------------------------
 * Holds the minor version of the current assembly.
 * ------------------------------------------------------------------------ */

  private static int vminor;


/* ---------------------------------------------------------------------------
 * private class variable build
 * ---------------------------------------------------------------------------
 * Holds the build number of the current assembly.
 * ------------------------------------------------------------------------ */

  private static int build;


/* ---------------------------------------------------------------------------
 * private class variable description
 * ---------------------------------------------------------------------------
 * Holds the human readable description of the current assembly.
 * ------------------------------------------------------------------------ */

  private static string description;


/* ---------------------------------------------------------------------------
 * private class variable description
 * ---------------------------------------------------------------------------
 * Holds the human readable copyright of the current assembly.
 * ------------------------------------------------------------------------ */

  private static string copyright;


/* ---------------------------------------------------------------------------
 * private class variable description
 * ---------------------------------------------------------------------------
 * Holds the human readable license name of this product.
 * ------------------------------------------------------------------------ */

  private static string license;


/* ---------------------------------------------------------------------------
 * private constructor ProductInfo()
 * ---------------------------------------------------------------------------
 * Prevents clients from invoking the constructor.
 * ------------------------------------------------------------------------ */

  private ProductInfo() {
   // no operation
  } /* end ProductInfo */


/* ---------------------------------------------------------------------------
 * private initialiser Init()
 * ---------------------------------------------------------------------------
 * Initialises all class variables from the current assembly.
 * ------------------------------------------------------------------------ */

  private static void Init () {

    if (initialized) {
      return;
    } /* end if */
    
    Assembly bundle = Assembly.GetExecutingAssembly();
    object[] attributes = bundle.GetCustomAttributes(false);
    
    /* obtain assembly name */
    name = bundle.GetName().Name;
  
    /* obtain major version */
    vmajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
    
    /* obtain minor version */
    vminor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
    
    /* obtain build number */
    build = Assembly.GetExecutingAssembly().GetName().Version.Build;
    
    /* obtain custom attributes */
    foreach (object attr in attributes) {
      if (attr is AssemblyDescriptionAttribute) {
        AssemblyDescriptionAttribute a = (AssemblyDescriptionAttribute)attr;
        description = a.Description;
      }
      else if (attr is AssemblyCopyrightAttribute) {
        AssemblyCopyrightAttribute a = (AssemblyCopyrightAttribute)attr;
        copyright = a.Copyright;
      } /* end if */
    } /* foreach */
    
    /* set license info */  
    license = DefaultLicense;
    
    initialized = true;
    
    return;
  } /* end Init */
  
  
/* ---------------------------------------------------------------------------
 * method Name()
 * ---------------------------------------------------------------------------
 * Returns the human readable name of the current assembly.
 * ------------------------------------------------------------------------ */

  public static string Name () {
    if (initialized == false) {
      ProductInfo.Init();
    } /* end if */
    return name;
  } /* end Name */
  
  
/* ---------------------------------------------------------------------------
 * method VersionMajor()
 * ---------------------------------------------------------------------------
 * Returns the major version of the current assembly.
 * ------------------------------------------------------------------------ */
  
  public static int VersionMajor () {
    if (initialized == false) {
      ProductInfo.Init();
    } /* end if */
    return vmajor;
  } /* end VersionMajor */
  
  
/* ---------------------------------------------------------------------------
 * method VersionMinor()
 * ---------------------------------------------------------------------------
 * Returns the minor version of the current assembly.
 * ------------------------------------------------------------------------ */

  public static int VersionMinor () {
    if (initialized == false) {
      ProductInfo.Init();
    } /* end if */
    return vminor;
  } /* end VersionMinor */
  
  
/* ---------------------------------------------------------------------------
 * method Build()
 * ---------------------------------------------------------------------------
 * Returns the build number of the current assembly.
 * ------------------------------------------------------------------------ */

  public static int Build () {
    if (initialized == false) {
      ProductInfo.Init();
    } /* end if */
    return build;
  } /* end Build */
  
  
/* ---------------------------------------------------------------------------
 * method Description()
 * ---------------------------------------------------------------------------
 * Returns the human readable descroption of the current assembly.
 * ------------------------------------------------------------------------ */

  public static string Description () {
    if (initialized == false) {
      ProductInfo.Init();
    } /* end if */
    return description;
  } /* end Description */
  
  
/* ---------------------------------------------------------------------------
 * method Copyright()
 * ---------------------------------------------------------------------------
 * Returns the human readable copyright of the current assembly.
 * ------------------------------------------------------------------------ */

  public static string Copyright () {
    if (initialized == false) {
      ProductInfo.Init();
    } /* end if */
    return copyright;
  } /* end Copyright */
  
  
/* ---------------------------------------------------------------------------
 * method License()
 * ---------------------------------------------------------------------------
 * Returns the human readable license name for this product.
 * ------------------------------------------------------------------------ */

  public static string License () {
    if (initialized == false) {
      ProductInfo.Init();
    } /* end if */
    return license;
  } /* end License */
  
  
} /* ProductInfo */

} /* namespace */

/* END OF FILE */
